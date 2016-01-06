using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.Office.Interop.Publisher;
using System.Diagnostics;
using System.Text.RegularExpressions;
using pub2xml.api.Structures;

namespace pub2xml.api.Parser
{
    internal class Importer
    {

        internal delegate void onChange_Progress(int Maximum, int Current, string Message);
        internal event onChange_Progress _onChange_Progress;

        internal bool Import(string xmlFilePath, string pubFilePath, string imagePath, SettingsCore settings)
        {
            bool success = false;

            pub2xml.api.Processor.ProcessingErrors = new List<Structures.Core.TextFrame>();
            pub2xml.api.Processor.MaximumShapes = 0;
            pub2xml.api.Processor.CurrentIndex = 0;
            pub2xml.api.Processor.FramesDictoinary = null;


            string fileName = pubFilePath;
            if (settings.ImportCreateBakFile)
            {
                string fileNameBak = pubFilePath + Constants.pub2xmlBakExtension;

                if (_onChange_Progress != null)
                    _onChange_Progress(pub2xml.api.Processor.MaximumShapes, pub2xml.api.Processor.MaximumShapes, StringResources.CreatingBackupFile);


                if (File.Exists(fileNameBak))
                    File.Delete(fileNameBak);
                File.Copy(fileName, fileNameBak, true);
            }



            if (_onChange_Progress != null)
                _onChange_Progress(pub2xml.api.Processor.MaximumShapes, pub2xml.api.Processor.MaximumShapes, StringResources.LoadingXmlFile);



            Structures.Core.ExportPackage ep = ReadExportPackage(xmlFilePath);

            pub2xml.api.Processor.FramesDictoinary = new Dictionary<long, List<Structures.Core.TextFrame>>();
            foreach (Structures.Core.TextFrame tf in ep.textFrames)
            {
                if (pub2xml.api.Processor.FramesDictoinary.ContainsKey(tf.shapeId))
                {
                    pub2xml.api.Processor.FramesDictoinary[tf.shapeId].Add(tf);
                }
                else
                {
                    pub2xml.api.Processor.FramesDictoinary.Add(tf.shapeId, new List<Structures.Core.TextFrame> { tf });
                }
            }


            Microsoft.Office.Interop.Publisher.Application pbApp = new Microsoft.Office.Interop.Publisher.Application();

            pbApp.Options.AutoHyphenate = false;

            try
            {
                if (_onChange_Progress != null)
                    _onChange_Progress(pub2xml.api.Processor.MaximumShapes, pub2xml.api.Processor.MaximumShapes, StringResources.LoadingPublisherFile);

                Microsoft.Office.Interop.Publisher.Document pbDoc = pbApp.Open(pubFilePath, false, false, PbSaveOptions.pbDoNotSaveChanges);


                #region  |  get total shapes count  |
                foreach (Microsoft.Office.Interop.Publisher.Page page in pbDoc.MasterPages)                
                    foreach (Microsoft.Office.Interop.Publisher.Shape shape in page.Shapes)                    
                        pub2xml.api.Processor.MaximumShapes++;
                    
                
                foreach (Microsoft.Office.Interop.Publisher.Page page in pbDoc.Pages)                
                    foreach (Microsoft.Office.Interop.Publisher.Shape shape in page.Shapes)                    
                        pub2xml.api.Processor.MaximumShapes++;                                    
                #endregion



                try
                {
                    #region  |  MasterPages  |

                    foreach (Microsoft.Office.Interop.Publisher.Page page in pbDoc.MasterPages)
                    {
                        foreach (Microsoft.Office.Interop.Publisher.Shape shape in page.Shapes)
                        {
                            pub2xml.api.Processor.CurrentIndex++;

                            if (_onChange_Progress != null)
                                _onChange_Progress(pub2xml.api.Processor.MaximumShapes, pub2xml.api.Processor.CurrentIndex, StringResources.BuildingShape + ": " + shape.ID + ", " + shape.Name + "...");
                            try
                            {
                                List<Structures.Core.TextFrame> tfs = setTextFramesFromShape(shape, imagePath, settings);
                                if (tfs.Count > 0)
                                {
                                    ep.textFrames.AddRange(tfs);
                                }
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                    #endregion

                    #region  |  Pages  |


                    foreach (Microsoft.Office.Interop.Publisher.Page page in pbDoc.Pages)
                    {
                        foreach (Microsoft.Office.Interop.Publisher.Shape shape in page.Shapes)
                        {
                            pub2xml.api.Processor.CurrentIndex++;
                            if (_onChange_Progress != null)
                                _onChange_Progress(pub2xml.api.Processor.MaximumShapes, pub2xml.api.Processor.CurrentIndex, StringResources.BuildingShape + ": " + shape.ID + ", " + shape.Name + "...");

                            try
                            {
                                List<Structures.Core.TextFrame> tfs = setTextFramesFromShape(shape, imagePath, settings);
                                if (tfs.Count > 0)
                                {
                                    ep.textFrames.AddRange(tfs);
                                }
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }

                            if (pub2xml.api.Processor.CurrentIndex % 100 == 0)
                            {
                                if (_onChange_Progress != null)
                                    _onChange_Progress(pub2xml.api.Processor.MaximumShapes, pub2xml.api.Processor.CurrentIndex, StringResources.SavingChanges);

                                pbDoc.Save();
                            }
                        }
                    }
                    #endregion

                    if (_onChange_Progress != null)
                        _onChange_Progress(pub2xml.api.Processor.MaximumShapes, pub2xml.api.Processor.MaximumShapes, StringResources.ApplyingInternalFontStyles);

                    #region  |  apply internal font information  |

                    Cache.settings.FontFormatTags.ForEach(a =>
                    {
                        pbDoc.Find.FindText = "<" + a.name + ">";
                        pbDoc.Find.ReplaceScope = PbReplaceScope.pbReplaceScopeAll;
                        pbDoc.Find.ReplaceWithText = "";
                        pbDoc.Find.Execute();

                        pbDoc.Find.FindText = "</" + a.name + ">";
                        pbDoc.Find.ReplaceScope = PbReplaceScope.pbReplaceScopeAll;
                        pbDoc.Find.ReplaceWithText = "";
                        pbDoc.Find.Execute();
                    });



                    #endregion

                    success = true;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    if (success)
                    {
                        if (_onChange_Progress != null)
                            _onChange_Progress(pub2xml.api.Processor.MaximumShapes, pub2xml.api.Processor.MaximumShapes, StringResources.SavingPublisherFile);


                        pbDoc.Save();

                        #region  |  create pdf  |

                        if (settings.ImportCreatePdfFile)
                        {
                            if (_onChange_Progress != null)
                                _onChange_Progress(pub2xml.api.Processor.MaximumShapes, pub2xml.api.Processor.MaximumShapes, StringResources.SavingPDFFile);

                            pbDoc.ExportAsFixedFormat(PbFixedFormatType.pbFixedFormatTypePDF, pubFilePath + Constants.pub2xmlPDFAfterImportExtension);

                        }
                        #endregion
                    }

                    pbDoc.Close();
                    pbDoc = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pbApp = null;
                GC.Collect();

                Process[] Processes = Process.GetProcessesByName("MSPUB");
                foreach (Process p in Processes)
                {
                    if (p.MainWindowTitle.Trim() == "")
                        p.Kill();
                }

            }

            return success;
        }


        private Structures.Core.ExportPackage ReadExportPackage(string xmlFilePath)
        {


            XmlSerializer serializer = null;
            FileStream stream = null;
            try
            {
                serializer = new XmlSerializer(typeof(Structures.Core.ExportPackage));
                stream = new FileStream(xmlFilePath, FileMode.Open);
                Structures.Core.ExportPackage ep = (Structures.Core.ExportPackage)serializer.Deserialize(stream);

                return ep;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }



        private List<Structures.Core.TextFrame> setTextFramesFromShape(Shape shape, string imagePath, SettingsCore settings)
        {
            List<Structures.Core.TextFrame> tfs_updated = new List<Structures.Core.TextFrame>();

            if ((shape.Type == PbShapeType.pbPicture
                //|| shape.Type == PbShapeType.pbBarCodePictureHolder 
                   || shape.Type == PbShapeType.pbLinkedPicture)
                   && settings.ImportPictures)
            {
                if (Directory.Exists(imagePath))
                {
                    tfs_updated.AddRange(setImageFramesFromShape(shape, imagePath, settings));
                }
            }
            else
            {
                #region  |  HasTextFrame  |

                if (shape.HasTextFrame == Microsoft.Office.Core.MsoTriState.msoTrue)
                {
                    tfs_updated.AddRange(setTextFramesFromTextFrame(shape, settings));
                }
                #endregion

                #region  |  HasTable  |
                if (shape.HasTable == Microsoft.Office.Core.MsoTriState.msoTrue)
                {
                    if (shape.Table.Cells.Count > 0)
                    {
                        tfs_updated.AddRange(setTextFramesFromTableFrame(shape, settings));
                    }
                }
                #endregion

                #region  |  GroupItems.Count > 0  |


                if (shape.Type == PbShapeType.pbGroup && shape.GroupItems.Count > 0)
                {
                    foreach (Microsoft.Office.Interop.Publisher.Shape _shape in shape.GroupItems)
                    {
                        if ((shape.Type == PbShapeType.pbPicture
                            //|| shape.Type == PbShapeType.pbBarCodePictureHolder 
                           || shape.Type == PbShapeType.pbLinkedPicture)
                           && settings.ImportPictures)
                        {
                            if (Directory.Exists(imagePath))
                            {
                                tfs_updated.AddRange(setImageFramesFromShape(_shape, imagePath, settings));
                            }
                        }
                        else
                        {
                            #region  |  HasTextFrame  |

                            if (_shape.HasTextFrame == Microsoft.Office.Core.MsoTriState.msoTrue)
                            {
                                tfs_updated.AddRange(setTextFramesFromTextFrame(_shape, settings));
                            }
                            #endregion

                            #region  |  HasTable  |

                            if (_shape.HasTable == Microsoft.Office.Core.MsoTriState.msoTrue)
                            {

                                tfs_updated.AddRange(setTextFramesFromTableFrame(_shape, settings));

                            }
                            #endregion
                        }
                    }
                }

                #endregion
            }

            return tfs_updated;
        }
        private List<Structures.Core.TextFrame> setTextFramesFromTextFrame(Shape shape, SettingsCore settings)
        {
            List<Structures.Core.TextFrame> tfs_updated = new List<Structures.Core.TextFrame>();

            #region  |  HasTextFrame  |

            if (shape.HasTextFrame == Microsoft.Office.Core.MsoTriState.msoTrue)
            {
                if (shape.TextFrame.HasText == Microsoft.Office.Core.MsoTriState.msoTrue)
                {
                    if (settings.ImportText)
                    {
                        List<Structures.Core.TextFrame> tf_paragraphs = new List<Structures.Core.TextFrame>();
                        if (pub2xml.api.Processor.FramesDictoinary.ContainsKey(shape.ID))
                        {
                            foreach (Structures.Core.TextFrame tf in pub2xml.api.Processor.FramesDictoinary[shape.ID])
                            {
                                if (shape.ID == tf.shapeId)
                                {
                                    tf_paragraphs.Add(tf);
                                }
                            }



                            if (tf_paragraphs.Count > 0)
                            {
                                if (tf_paragraphs.Count == shape.TextFrame.Story.TextRange.ParagraphsCount)
                                {
                                    int paragraphsCount = shape.TextFrame.Story.TextRange.ParagraphsCount;

                                    List<ParagraphFormat> pfs = new List<ParagraphFormat>();
                                    List<Font> fts = new List<Font>();
                                    for (int i = paragraphsCount; i > 0; i--)
                                    {
                                        TextRange tr = shape.TextFrame.Story.TextRange.Paragraphs(i);
                                        fts.Add(tr.Font.Duplicate());
                                        pfs.Add(tr.ParagraphFormat.Duplicate());
                                    }
                                    pfs.Reverse();
                                    fts.Reverse();



                                    for (int i = paragraphsCount; i > 0; i--)
                                    {
                                        if (_onChange_Progress != null)
                                            _onChange_Progress(pub2xml.api.Processor.MaximumShapes, pub2xml.api.Processor.CurrentIndex, StringResources.BuildingShape + ": " + shape.ID + ", "
                                                + shape.Name + "... " + StringResources.Paragraph + ": " + i.ToString());


                                        TextRange tr = shape.TextFrame.Story.TextRange.Paragraphs(i);


                                        Structures.Core.TextFrame tf = tf_paragraphs[(i - 1)];


                                        tr.Text = string.Empty;

                                        string rangeText = tf.text.Replace("<r/>", "\r").Replace("<n/>", "\n");

                                        tr.Text = rangeText;

                                        setTaggedText(tr);

                                        tr.Font = fts[(i - 1)];
                                        tr.ParagraphFormat = pfs[(i - 1)];


                                    }
                                }
                                else
                                {
                                    throw new Exception(StringResources.TheParagraphCountsAreDifferentForShapeId + ": " + shape.ID.ToString());
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            return tfs_updated;
        }
        private List<Structures.Core.TextFrame> setTextFramesFromTableFrame(Shape shape, SettingsCore settings)
        {
            List<Structures.Core.TextFrame> tfs_updated = new List<Structures.Core.TextFrame>();

            #region  |  HasTable  |
            if (shape.HasTable == Microsoft.Office.Core.MsoTriState.msoTrue)
            {


                foreach (Microsoft.Office.Interop.Publisher.Cell cl in shape.Table.Cells)
                {


                    if (cl.HasText)
                    {
                        if (settings.ImportText)
                        {
                            List<Structures.Core.TextFrame> tf_paragraphs = new List<Structures.Core.TextFrame>();
                            if (pub2xml.api.Processor.FramesDictoinary.ContainsKey(shape.ID))
                            {
                                foreach (Structures.Core.TextFrame tf in pub2xml.api.Processor.FramesDictoinary[shape.ID])
                                {
                                    if (shape.ID == tf.shapeId
                                        && cl.Column.ToString() == tf.tableColumn
                                        && cl.Row.ToString() == tf.tableRow)
                                    {
                                        tf_paragraphs.Add(tf);
                                    }
                                }

                                if (tf_paragraphs.Count > 0)
                                {
                                    if (tf_paragraphs.Count == cl.TextRange.ParagraphsCount
                                        || (tf_paragraphs.Count > cl.TextRange.ParagraphsCount && cl.TextRange.ParagraphsCount == 1))
                                    {
                                        if (tf_paragraphs.Count == cl.TextRange.ParagraphsCount)
                                        {
                                            int paragraphsCount = cl.TextRange.ParagraphsCount;

                                            List<ParagraphFormat> pfs = new List<ParagraphFormat>();
                                            List<Font> fts = new List<Font>();
                                            for (int i = paragraphsCount; i > 0; i--)
                                            {
                                                TextRange tr = cl.TextRange.Paragraphs(i);
                                                fts.Add(tr.Font.Duplicate());
                                                pfs.Add(tr.ParagraphFormat.Duplicate());
                                            }
                                            pfs.Reverse();
                                            fts.Reverse();


                                            for (int i = paragraphsCount; i > 0; i--)
                                            {

                                                if (_onChange_Progress != null)
                                                    _onChange_Progress(pub2xml.api.Processor.MaximumShapes, pub2xml.api.Processor.CurrentIndex, StringResources.BuildingShape + ": " + shape.ID + ", "
                                                        + shape.Name + "... " + StringResources.Paragraph + ": " + i.ToString() + " (" + StringResources.TableRow + ": " + cl.Row.ToString() + ", " + StringResources.Column + ": " + cl.Column.ToString() + ")");


                                                TextRange tr = cl.TextRange.Paragraphs(i);
                                                Structures.Core.TextFrame tf = tf_paragraphs[(i - 1)];

                                                string rangeText = tf.text.Replace("<r/>", "\r").Replace("<n/>", "\n");

                                                //testing this...
                                                if (rangeText.EndsWith("\r"))
                                                {
                                                    rangeText = rangeText.TrimEnd('\r');
                                                }



                                                tr.Text = rangeText;

                                                setTaggedText(tr);

                                                tr.Font = fts[(i - 1)];
                                                tr.ParagraphFormat = pfs[(i - 1)];
                                            }
                                        }
                                        else
                                        {
                                            ParagraphFormat pf = cl.TextRange.ParagraphFormat.Duplicate();
                                            Font ft = cl.TextRange.Font.Duplicate();

                                            string rangeText = string.Empty;
                                            foreach (Structures.Core.TextFrame tf in tf_paragraphs)
                                            {
                                                rangeText += tf.text.Replace("<r/>", "\r").Replace("<n/>", "\n");
                                            }
                                            //testing this...
                                            if (rangeText.EndsWith("\r"))
                                            {
                                                rangeText = rangeText.TrimEnd('\r');
                                            }


                                            cl.TextRange.Text = rangeText;

                                            setTaggedText(cl.TextRange);

                                            cl.TextRange.Font = ft;
                                            cl.TextRange.ParagraphFormat = pf;

                                        }



                                    }
                                    else
                                    {
                                        throw new Exception(StringResources.TheParagraphCountsAreDifferentForShapeId + ": " + shape.ID.ToString());
                                    }
                                }
                            }
                        }
                    }
                }



            }
            #endregion

            return tfs_updated;
        }
        private List<Structures.Core.TextFrame> setImageFramesFromShape(Shape shape, string imagePath, SettingsCore settings)
        {
            List<Structures.Core.TextFrame> tfs_updated = new List<Structures.Core.TextFrame>();

            if ((shape.Type == PbShapeType.pbPicture
                //|| shape.Type == PbShapeType.pbBarCodePictureHolder 
                  || shape.Type == PbShapeType.pbLinkedPicture)
                  && settings.ImportPictures)
            {
                Structures.Core.TextFrame tf_image = null;
                if (pub2xml.api.Processor.FramesDictoinary.ContainsKey(shape.ID))
                {
                    foreach (Structures.Core.TextFrame tf in pub2xml.api.Processor.FramesDictoinary[shape.ID])
                    {
                        if (shape.ID == tf.shapeId
                            && string.Compare(shape.Type.ToString(), tf.shapeType, true) == 0)
                        {
                            tf_image = tf;
                            break;
                        }
                    }
                }
                if (tf_image != null)
                {

                    if (tf_image.imageName.Trim() != string.Empty)
                    {
                        string imagePathFile = Path.Combine(imagePath, tf_image.imageName);
                        if (File.Exists(imagePathFile))
                        {
                            try
                            {
                                shape.PictureFormat.Replace(imagePathFile);
                                //shape.PictureFormat.ReplaceEx(imagePathFile, PbPictureInsertAs.pbPictureInsertAsOriginalState, pbPictureInsertFit.pbFill);

                                tfs_updated.Add(tf_image);
                            }
                            catch (Exception ex)
                            {
                                tf_image.message = StringResources.Picture + ": " + shape.ID + (shape.PictureFormat.Filename != string.Empty ? shape.PictureFormat.Filename : string.Empty) + "\r\n" + ex.Message;

                                pub2xml.api.Processor.ProcessingErrors.Add(tf_image);
                            }
                        }
                    }

                }
            }

            return tfs_updated;
        }


        private void setTaggedText(TextRange textRange)
        {

            Cache.settings.FontFormatTags.ForEach(a =>
            {
                Regex r = new Regex(@"\<" + a.name + @"\>(?<x0>" + a.regexContent + @")\<\/" + a.name + @"\>", RegexOptions.IgnoreCase | RegexOptions.Singleline);

                MatchCollection mc_r = r.Matches(textRange.Text);
                if (mc_r.Count > 0)
                {
                    foreach (Match m_r in mc_r)
                    {
                        try
                        {
                            switch(a.formatType)
                            {
                                case Structures.Core.FormattedRange.FormatType.Bold: textRange.Characters((m_r.Index + 1), m_r.Length).Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue; break;
                                case Structures.Core.FormattedRange.FormatType.Italic: textRange.Characters((m_r.Index + 1), m_r.Length).Font.Italic = Microsoft.Office.Core.MsoTriState.msoTrue; break;
                                case Structures.Core.FormattedRange.FormatType.StrikeThrough: textRange.Characters((m_r.Index + 1), m_r.Length).Font.StrikeThrough = Microsoft.Office.Core.MsoTriState.msoTrue; break;
                                case Structures.Core.FormattedRange.FormatType.SuperScript: textRange.Characters((m_r.Index + 1), m_r.Length).Font.SuperScript = Microsoft.Office.Core.MsoTriState.msoTrue; break;
                                case Structures.Core.FormattedRange.FormatType.SubScript: textRange.Characters((m_r.Index + 1), m_r.Length).Font.SubScript = Microsoft.Office.Core.MsoTriState.msoTrue; break;
                            }

                        }
                        catch (Exception ex)
                        {
                            Trace.WriteLine(ex.Message);
                        }
                    }
                }
            });


        }
    }
}
