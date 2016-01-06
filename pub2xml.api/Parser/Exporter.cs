using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Publisher;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;
using pub2xml.api.Structures.Core;
using pub2xml.api.Structures;

namespace pub2xml.api.Parser
{
    internal class Exporter
    {

        internal delegate void onChange_Progress(int Maximum, int Current, string Message);
        internal event onChange_Progress _onChange_Progress;

        internal ExportPackage export(string pubFilePath, string xmlFilePath, string imagePath, SettingsCore settings)
        {

            pub2xml.api.Processor.ProcessingErrors = new List<Structures.Core.TextFrame>();
            pub2xml.api.Processor.MaximumShapes = 0;
            pub2xml.api.Processor.CurrentIndex = 0;
            pub2xml.api.Processor.FramesDictoinary = null;


            Structures.Core.ExportPackage ep = new Structures.Core.ExportPackage();
            ep.pubFilePath = pubFilePath;
            ep.xmlFilePath = xmlFilePath;
            ep.imagePath = imagePath;



            Application pbApp = new Application();

            try
            {
                if (_onChange_Progress != null)
                    _onChange_Progress(pub2xml.api.Processor.MaximumShapes, pub2xml.api.Processor.MaximumShapes, StringResources.LoadingPublisherFile);

                Document pbDoc = pbApp.Open(pubFilePath, false, false, PbSaveOptions.pbDoNotSaveChanges);
                pbDoc.ActiveWindow.Visible = false;

                object fileName_temp = pubFilePath + Constants.pub2xmlTempPubExtension;
                pbDoc.SaveAs(fileName_temp, PbFileFormat.pbFilePublication, false);

                #region  |  get total shapes count  |


                foreach (Page page in pbDoc.MasterPages)
                    foreach (Shape shape in page.Shapes)
                        pub2xml.api.Processor.MaximumShapes++;

                foreach (Page page in pbDoc.Pages)
                    foreach (Shape shape in page.Shapes)
                        pub2xml.api.Processor.MaximumShapes++;


                #endregion


                pub2xml.api.Processor.CurrentIndex = 0;

                try
                {
                    #region  |  MasterPages  |
                    foreach (Page page in pbDoc.MasterPages)
                    {
                        foreach (Shape shape in page.Shapes)
                        {
                            pub2xml.api.Processor.CurrentIndex++;
                            if (_onChange_Progress != null)
                                _onChange_Progress(pub2xml.api.Processor.MaximumShapes, pub2xml.api.Processor.CurrentIndex, StringResources.ParsingShape + ": " + shape.ID + ", " + shape.Name + "...");

                            try
                            {
                                List<Structures.Core.TextFrame> tfs = getTextFramesFromShape(shape, settings, ep.imagePath, Path.GetFileName(pubFilePath));
                                if (tfs.Count > 0)
                                    ep.textFrames.AddRange(tfs);

                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                    #endregion

                    #region  |  Pages  |

                    foreach (Page page in pbDoc.Pages)
                    {
                        foreach (Shape shape in page.Shapes)
                        {
                            pub2xml.api.Processor.CurrentIndex++;
                            if (_onChange_Progress != null)
                                _onChange_Progress(pub2xml.api.Processor.MaximumShapes, pub2xml.api.Processor.CurrentIndex, StringResources.ParsingShape + ": " + shape.ID + ", " + shape.Name + "...");
                            try
                            {
                                List<Structures.Core.TextFrame> tfs = getTextFramesFromShape(shape, settings, ep.imagePath, Path.GetFileName(pubFilePath));
                                if (tfs.Count > 0)
                                    ep.textFrames.AddRange(tfs);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }

                            if (pub2xml.api.Processor.CurrentIndex % 10 == 0)
                            {
                                if (_onChange_Progress != null)
                                    _onChange_Progress(pub2xml.api.Processor.MaximumShapes, pub2xml.api.Processor.CurrentIndex, StringResources.SavingChanges);

                                pbDoc.Save();
                            }

                        }
                    }
                    #endregion

                    ep.success = true;


                }
                catch (Exception ex)
                {
                    ep.success = false;
                    ep.message = ex.Message;
                    throw ex;
                }
                finally
                {
                    if (ep.success)
                    {
                        if (settings.ExportPseudoTranslateFile)
                        {
                            object fileName_vts = pubFilePath + Constants.pub2xmlPseudoTranslationExtension;
                            pbDoc.SaveAs(fileName_vts, PbFileFormat.pbFilePublication, false);
                        }
                    }
                    pbDoc.Close();
                    pbDoc = null;
                }
            }
            catch (Exception ex)
            {
                ep.success = false;
                ep.message = ex.Message;

                throw ex;
            }
            finally
            {
                if (ep.success)
                {
                    if (_onChange_Progress != null)
                        _onChange_Progress(pub2xml.api.Processor.MaximumShapes, pub2xml.api.Processor.MaximumShapes, StringResources.SavingOutputToXmlFile);

                    saveExportPackage(ep);


                    #region  |  create pdf  |

                    if (settings.ExportCreatePdfFile)
                    {

                        if (_onChange_Progress != null)
                            _onChange_Progress(pub2xml.api.Processor.MaximumShapes, pub2xml.api.Processor.MaximumShapes, StringResources.LoadingPublisherFile);

                        Document pbDoc2 = pbApp.Open(pubFilePath, false, false, PbSaveOptions.pbDoNotSaveChanges);

                        try
                        {
                            if (_onChange_Progress != null)
                                _onChange_Progress(pub2xml.api.Processor.MaximumShapes, pub2xml.api.Processor.MaximumShapes, StringResources.SavingPDFFile);

                            pbDoc2.ExportAsFixedFormat(PbFixedFormatType.pbFixedFormatTypePDF, pubFilePath + Constants.pub2xmlPDFAfterExportExtension);
                        }
                        finally
                        {
                            pbDoc2.Close();
                            pbDoc2 = null;
                        }
                    }
                    #endregion

                    #region  |  remove temp file  |

                    try
                    {
                        if (File.Exists(pubFilePath + Constants.pub2xmlTempPubExtension))
                            File.Delete(pubFilePath + Constants.pub2xmlTempPubExtension);
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine(ex.Message);
                    }

                    #endregion

                }

                pbApp = null;
                GC.Collect();

                Process[] Processes = Process.GetProcessesByName("MSPUB");
                foreach (Process p in Processes)
                {
                    if (p.MainWindowTitle.Trim() == string.Empty)
                        p.Kill();
                }
            }



            return ep;
        }


        private void saveExportPackage(ExportPackage ep)
        {
            XmlSerializer serializer = null;
            FileStream stream = null;
            try
            {
                serializer = new XmlSerializer(typeof(Structures.Core.ExportPackage));
                stream = new FileStream(ep.xmlFilePath, FileMode.Create, FileAccess.Write);
                serializer.Serialize(stream, ep);
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

        private string getPseudoTranslatedText(string text, List<PseudoTranslateItem> vtsItems)
        {
            vtsItems.ForEach(a =>
            {
                text = text.Replace(a.FindWhat, a.ReplaceWith);
            });

            return text;
        }





        private List<Structures.Core.TextFrame> getTextFramesFromShape(Shape shape, SettingsCore settings, string imagePath, string pubFileName)
        {
            List<Structures.Core.TextFrame> tfs = new List<Structures.Core.TextFrame>();

            try
            {
                if ((shape.Type == PbShapeType.pbPicture
                    || shape.Type == PbShapeType.pbLinkedPicture)
                    && settings.ExportPictures)
                {
                    if (!Directory.Exists(imagePath))
                        Directory.CreateDirectory(imagePath);

                    tfs.AddRange(getImageFramesFromShape(shape, settings, imagePath, pubFileName));
                }
                else
                {
                    #region  |  HasTextFrame  |

                    if (shape.HasTextFrame == Microsoft.Office.Core.MsoTriState.msoTrue)
                        tfs.AddRange(getTextFramesFromTextFrame(shape, settings, pubFileName));

                    #endregion

                    #region  |  HasTable  |
                    if (shape.HasTable == Microsoft.Office.Core.MsoTriState.msoTrue)
                        if (shape.Table.Cells.Count > 0)
                            tfs.AddRange(getTextFramesFromTableFrame(shape, settings, pubFileName));


                    #endregion

                    #region  |  GroupItems.Count > 0  |


                    if (shape.Type == PbShapeType.pbGroup && shape.GroupItems.Count > 0)
                    {
                        foreach (Shape _shape in shape.GroupItems)
                        {
                            if ((shape.Type == PbShapeType.pbPicture
                                || shape.Type == PbShapeType.pbLinkedPicture)
                                && settings.ExportPictures)
                            {
                                if (!Directory.Exists(imagePath))
                                    Directory.CreateDirectory(imagePath);

                                tfs.AddRange(getImageFramesFromShape(_shape, settings, imagePath, pubFileName));
                            }
                            else
                            {
                                #region  |  HasTextFrame  |

                                if (_shape.HasTextFrame == Microsoft.Office.Core.MsoTriState.msoTrue)
                                    tfs.AddRange(getTextFramesFromTextFrame(_shape, settings, pubFileName));


                                #endregion

                                #region  |  HasTable  |

                                if (_shape.HasTable == Microsoft.Office.Core.MsoTriState.msoTrue)
                                    tfs.AddRange(getTextFramesFromTableFrame(_shape, settings, pubFileName));

                                #endregion
                            }
                        }
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tfs;
        }
        private List<Structures.Core.TextFrame> getTextFramesFromTextFrame(Shape shape, SettingsCore settings, string pubFileName)
        {
            List<Structures.Core.TextFrame> tfs = new List<Structures.Core.TextFrame>();


            #region  |  HasTextFrame  |

            if (shape.HasTextFrame == Microsoft.Office.Core.MsoTriState.msoTrue)
            {
                if (shape.TextFrame.HasText == Microsoft.Office.Core.MsoTriState.msoTrue)
                {
                    try
                    {
                        if (!shape.TextFrame.Story.TextRange.Text.Trim().StartsWith(Structures.Constants.pub2xml))
                        {
                            try
                            {
                                if (settings.ExportText)
                                {
                                    List<string> paragraphsText = getParagraphsText(shape.TextFrame.Story.TextRange, settings.ExportMarkupInternalFontEffects);
                                    for (int i = 0; i < paragraphsText.Count; i++)
                                    {
                                        if (_onChange_Progress != null)
                                            _onChange_Progress(pub2xml.api.Processor.MaximumShapes, pub2xml.api.Processor.CurrentIndex, StringResources.ParsingShape + ": " + shape.ID + ", "
                                                + shape.Name + "... " + StringResources.Paragraph + ": " + (i + 1).ToString());

                                        Structures.Core.TextFrame tf = new Structures.Core.TextFrame();
                                        tf.shapeId = shape.ID;
                                        tf.shapeName = shape.Name;
                                        tf.shapeType = shape.Type.ToString();
                                        tf.tableColumn = string.Empty;
                                        tf.tableRow = string.Empty;
                                        tf.paragraph = (i + 1);

                                        tf.text = (string)paragraphsText[i].Clone();


                                        tfs.Add(tf);
                                    }

                                    shape.TextFrame.Story.TextRange.Text = Structures.Constants.pub2xml
                                        + (settings.ExportPseudoTranslateFile
                                        ? getPseudoTranslatedText(shape.TextFrame.Story.TextRange.Text, settings.PseudoTranslateItems)
                                        : shape.TextFrame.Story.TextRange.Text);
                                }
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            #endregion

            return tfs;
        }
        private List<Structures.Core.TextFrame> getTextFramesFromTableFrame(Shape shape, SettingsCore settings, string pubFileName)
        {
            List<Structures.Core.TextFrame> tfs = new List<Structures.Core.TextFrame>();

            #region  |  HasTable  |
            if (shape.HasTable == Microsoft.Office.Core.MsoTriState.msoTrue)
            {
                foreach (Microsoft.Office.Interop.Publisher.Cell cl in shape.Table.Cells)
                {
                    if (cl.HasText)
                    {
                        if (!cl.TextRange.Text.Trim().StartsWith(Structures.Constants.pub2xml))
                        {
                            if (settings.ExportText)
                            {
                                List<string> paragraphsText = getParagraphsText(cl.TextRange, settings.ExportMarkupInternalFontEffects);
                                for (int i = 0; i < paragraphsText.Count; i++)
                                {
                                    if (_onChange_Progress != null)
                                        _onChange_Progress(pub2xml.api.Processor.MaximumShapes, pub2xml.api.Processor.CurrentIndex, StringResources.ParsingShape + ": " + shape.ID + ", "
                                            + shape.Name + "... " + StringResources.Paragraph + ": " + (i + 1).ToString() + " (" + StringResources.TableRow + ": " + cl.Row.ToString() + ", " + StringResources.Column + ": " + cl.Column.ToString() + ")");

                                    Structures.Core.TextFrame tf = new Structures.Core.TextFrame();
                                    tf.shapeId = shape.ID;
                                    tf.shapeName = shape.Name;
                                    tf.shapeType = shape.Type.ToString();
                                    tf.tableColumn = cl.Column.ToString();
                                    tf.tableRow = cl.Row.ToString();
                                    tf.paragraph = (i + 1);
                                    tf.text = (string)paragraphsText[i].Clone();

                                    tfs.Add(tf);
                                }

                                cl.TextRange.Text = Structures.Constants.pub2xml
                                    + (settings.ExportPseudoTranslateFile
                                    ? getPseudoTranslatedText(cl.TextRange.Text, settings.PseudoTranslateItems)
                                    : cl.TextRange.Text);
                            }
                        }
                    }
                }
            }
            #endregion

            return tfs;
        }
        private List<Structures.Core.TextFrame> getImageFramesFromShape(Shape shape, SettingsCore settings, string imagePath, string pubFileName)
        {
            List<Structures.Core.TextFrame> tfs = new List<Structures.Core.TextFrame>();

            if ((shape.Type == PbShapeType.pbPicture
                //|| shape.Type == PbShapeType.pbBarCodePictureHolder 
                || shape.Type == PbShapeType.pbLinkedPicture)
                   && settings.ExportPictures)
            {

                string imageFileName = "#" + (shape.PictureFormat.Filename.Trim() != string.Empty ? Path.GetFileName(shape.PictureFormat.Filename) : string.Empty);

                Structures.Core.TextFrame tf = new Structures.Core.TextFrame();
                tf.shapeId = shape.ID;
                tf.shapeName = shape.Name;
                tf.shapeType = shape.Type.ToString();
                tf.tableColumn = string.Empty;
                tf.tableRow = string.Empty;
                tf.paragraph = 1;
                tf.text = string.Empty;
                tf.imageName = pubFileName + "." + shape.ID.ToString() + "." + imageFileName + ".png";

                string ext = string.Empty;
                try
                {
                    if (_onChange_Progress != null)
                        _onChange_Progress(pub2xml.api.Processor.MaximumShapes, pub2xml.api.Processor.CurrentIndex, StringResources.ParsingShape + ": " + shape.ID + ", "
                            + shape.Name + "... " + StringResources.SavingImage + ": " + imageFileName);


                    shape.Shadow.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
                    shape.Shadow.OffsetX = 0;
                    shape.Shadow.OffsetY = 0;
                    shape.Shadow.Obscured = Microsoft.Office.Core.MsoTriState.msoFalse;

                    shape.ScaleHeight(1f, Microsoft.Office.Core.MsoTriState.msoTrue, Microsoft.Office.Core.MsoScaleFrom.msoScaleFromTopLeft);
                    shape.ScaleWidth(1f, Microsoft.Office.Core.MsoTriState.msoTrue, Microsoft.Office.Core.MsoScaleFrom.msoScaleFromTopLeft);

                    shape.SetShapesDefaultProperties();

                    shape.SaveAsPicture(Path.Combine(imagePath, tf.imageName), PbPictureResolution.pbPictureResolutionDefault);
                    tfs.Add(tf);
                }
                catch (Exception ex)
                {
                    try
                    {
                        tf.message = StringResources.Picture + ": " + shape.ID + (imageFileName.Trim() != string.Empty ? imageFileName : string.Empty) + "\r\n" + ex.Message;
                        pub2xml.api.Processor.ProcessingErrors.Add(tf);
                    }
                    catch (Exception ex1)
                    {
                        Trace.WriteLine(ex1.Message);
                    }
                }
            }

            return tfs;
        }


        private List<string> getParagraphsText(TextRange textRange, bool markupInternalFonts)
        {
            List<string> trs = new List<string>();

            for (int i = 1; i <= textRange.ParagraphsCount; i++)
            {
                TextRange tr = textRange.Paragraphs(i);

                string text = (markupInternalFonts ? getTextWithFontFormatting(tr) : (string)tr.Text.Clone());


                //remove encapsulating paragraph marks
                text = text.Replace("\r", "<r/>");
                text = text.Replace("\n", "<n/>");


                trs.Add(text);
            }
            return trs;
        }


       
        private string getTextWithFontFormatting(TextRange textRange)
        {
            string rs = string.Empty;


            List<string> tags = new List<string>();

            Structures.Core.FormattedRange fr_previous = null;

            #region  |  get formatted range words  |

            string prefix = string.Empty;
            string suffix = string.Empty;


            if (textRange.Font.Bold == Microsoft.Office.Core.MsoTriState.msoTriStateMixed
                || textRange.Font.Italic == Microsoft.Office.Core.MsoTriState.msoTriStateMixed
                || textRange.Font.StrikeThrough == Microsoft.Office.Core.MsoTriState.msoTriStateMixed
                || textRange.Font.SuperScript == Microsoft.Office.Core.MsoTriState.msoTriStateMixed
                || textRange.Font.SubScript == Microsoft.Office.Core.MsoTriState.msoTriStateMixed)
            {
                bool continueMixedParse = true;


                if (continueMixedParse)
                {
                    for (int j = 1; j <= textRange.WordsCount; j++)
                    {
                        TextRange tr_j = textRange.Words(j);

                        if (tr_j.Font.Bold == Microsoft.Office.Core.MsoTriState.msoTrue
                            || tr_j.Font.Bold == Microsoft.Office.Core.MsoTriState.msoTriStateMixed
                            || tr_j.Font.Italic == Microsoft.Office.Core.MsoTriState.msoTrue
                            || tr_j.Font.Italic == Microsoft.Office.Core.MsoTriState.msoTriStateMixed
                            || tr_j.Font.StrikeThrough == Microsoft.Office.Core.MsoTriState.msoTrue
                            || tr_j.Font.StrikeThrough == Microsoft.Office.Core.MsoTriState.msoTriStateMixed
                            || tr_j.Font.SuperScript == Microsoft.Office.Core.MsoTriState.msoTrue
                            || tr_j.Font.SuperScript == Microsoft.Office.Core.MsoTriState.msoTriStateMixed
                            || tr_j.Font.SubScript == Microsoft.Office.Core.MsoTriState.msoTrue
                            || tr_j.Font.SubScript == Microsoft.Office.Core.MsoTriState.msoTriStateMixed)
                        {
                            for (int i = 1; i <= tr_j.Text.Length; i++)
                            {
                                TextRange tr_i = tr_j.Characters(i);
                                //Bold = 1,
                                //Italic = 2,
                                //Name = 4,
                                //Size = 8,
                                //StrikeThrough = 16,
                                //SuperScript = 32,
                                //SubScript = 64,
                                //Underline = 128,

                                Structures.Core.FormattedRange fr_current = new Structures.Core.FormattedRange();
                                fr_current.text = (string)tr_i.Text.Clone();

                                prefix = string.Empty;
                                suffix = string.Empty;

                                #region  |  close  |

                                if (fr_previous != null)
                                {

                                    Cache.settings.FontFormatTags.ForEach(a =>
                                    {
                                        if (fr_previous.formatType.HasFlag(a.formatType)
                                           && (Helpers.getMSFontState(tr_i, a) != Microsoft.Office.Core.MsoTriState.msoTrue
                                            || tr_j.Text == "\r"))
                                        {
                                            suffix += "</" + a.name + ">" + suffix;
                                            tags.RemoveAt(tags.Count - 1);
                                        }
                                    });                                    
                                }
                                #endregion


                                Cache.settings.FontFormatTags.ForEach(a =>
                                {
                                    if (Helpers.getMSFontState(tr_i, a) == Microsoft.Office.Core.MsoTriState.msoTrue)
                                    {
                                        fr_current.formatType |= a.formatType;
                                        if (fr_previous != null)
                                        {
                                            #region  |  open  |
                                            if (!fr_previous.formatType.HasFlag(a.formatType))
                                            {
                                                if (fr_current.text != "\r" || j != textRange.WordsCount)
                                                {
                                                    prefix += "<" + a.name + ">";
                                                    tags.Add(a.name);
                                                }                                               
                                            }
                                            #endregion
                                        }
                                        else
                                        {
                                            if (fr_current.text != "\r" || j != textRange.WordsCount)
                                            {
                                                prefix += "<" + a.name + ">";
                                                tags.Add(a.name);
                                            }                                            
                                        }
                                    };

                                });
                                

                                if (tr_i.Font.Bold != Microsoft.Office.Core.MsoTriState.msoTrue
                                    && tr_i.Font.Italic != Microsoft.Office.Core.MsoTriState.msoTrue
                                    && tr_i.Font.StrikeThrough != Microsoft.Office.Core.MsoTriState.msoTrue
                                    && tr_i.Font.SuperScript != Microsoft.Office.Core.MsoTriState.msoTrue
                                    && tr_i.Font.SubScript != Microsoft.Office.Core.MsoTriState.msoTrue)
                                {
                                    fr_current.formatType = Structures.Core.FormattedRange.FormatType.None;
                                }

                                rs += suffix + prefix + fr_current.text;

                                fr_previous = (Structures.Core.FormattedRange)fr_current.Clone();
                            }
                        }
                        else
                        {
                            prefix = string.Empty;
                            suffix = string.Empty;

                            #region  |  close  |

                            if (fr_previous != null)
                            {
                                Cache.settings.FontFormatTags.ForEach(a =>
                                {
                                    if (fr_previous.formatType.HasFlag(a.formatType)
                                      && (Helpers.getMSFontState(tr_j, a) != Microsoft.Office.Core.MsoTriState.msoTrue
                                            || tr_j.Text == "\r"))
                                    {
                                        suffix += "</" + a.name + ">" + suffix;
                                        tags.RemoveAt(tags.Count - 1);
                                    }
                                });                                
                            }
                            #endregion

                            rs += suffix + tr_j.Text;


                            Structures.Core.FormattedRange _fr_current = new Structures.Core.FormattedRange();
                            _fr_current.text = tr_j.Text;
                            fr_previous = (Structures.Core.FormattedRange)_fr_current.Clone();

                        }
                    }
                }
                else
                {
                    rs = (string)textRange.Text.Clone();
                }
            }
            else
            {
                rs = (string)textRange.Text.Clone();
            }
            #endregion

            if (tags.Count > 0)
            {
                tags.Reverse();
                foreach (string stag in tags)
                    rs += "</" + stag + ">";
            }

            return rs;
        }

    }
}
