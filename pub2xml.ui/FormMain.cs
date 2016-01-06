using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace pub2xml.api.ui
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }


        
        private void Form1_Load(object sender, EventArgs e)
        {
            pub2xml.api.Cache.settings = pub2xml.api.SettingsSerializer.ReadSettings();

            this.Text = this.Text + " (" + Application.ProductVersion + ")";
            tabControl_main_SelectedIndexChanged(null, null);
            checkEnabled();
        }

        private void startProcessing()
        {

            Dictionary<FileRecord, List<pub2xml.api.Structures.Core.TextFrame>> messages = new Dictionary<FileRecord, List<pub2xml.api.Structures.Core.TextFrame>>();


            this.Enabled = false;

            this.toolStripStatusLabel1.Text = "Progress";
            this.progressBar_main.Value = 0;
            this.progressBar_main.Maximum = 0;
            this.label_Message.Text = "Processing, please wait...";

            string windowTitleBase = this.Text;
            Int32 totalFiles =  (tabControl_main.SelectedIndex == 0 ? this.listView_files_export.Items.Count : this.listView_files_import.Items.Count);
            Int32 currentFile = 0;
            try
            {


                pub2xml.api.Cache.settings = pub2xml.api.SettingsSerializer.ReadSettings();

              
                pub2xml.api.Processor p = new pub2xml.api.Processor();


              
                p._onChange_Progress += p__onChange_Progress;
                switch (tabControl_main.SelectedIndex)
                {
                    case 0:
                        {
                            #region  |  Export  |

                            foreach (ListViewItem itmx in this.listView_files_export.Items)
                            {
                                currentFile++;
                                this.Text = windowTitleBase + "  (Processing " + currentFile.ToString() + " of " + totalFiles.ToString() + " files)";

                                this.progressBar_main.Value = 0;
                                this.label_percentage.Text = "0%";
                                this.label_Message.Text = "Processing, please wait...";

                                FileRecord fr = (FileRecord)itmx.Tag;

                                try
                                {

                                    itmx.ImageKey = "green";
                                    itmx.SubItems[1].Text = "Processing...";

                                    pub2xml.api.Structures.Core.ExportPackage ep = p.Export(fr.pubFilePath, fr.xmlFilePath, fr.imagePath, pub2xml.api.Cache.settings);

                                    if (pub2xml.api.Processor.ProcessingErrors.Count > 0)
                                    {
                                        messages.Add(fr, pub2xml.api.Processor.ProcessingErrors);
                                    }


                                    if (ep.success)
                                    {
                                        fr.completed = true;
                                        fr.completedDate = DateTime.Now;

                                        fr.processingError = false;
                                        fr.processingMessage = "Processing Complete";

                                        itmx.ImageKey = "ok";
                                        itmx.SubItems[1].Text = fr.processingMessage;

                                        if (pub2xml.api.Processor.ProcessingErrors.Count > 0)
                                        {
                                            fr.processingError = true;
                                            fr.processingMessage = "Warning: " + " some images where not exported; refer to the processing report for more info!";

                                            itmx.ImageKey = "warning";
                                            itmx.SubItems[1].Text = fr.processingMessage;
                                        }

                                    }
                                    else
                                    {
                                        fr.processingError = true;
                                        fr.processingMessage = "Error: " + ep.message;

                                        itmx.ImageKey = "warning";
                                        itmx.SubItems[1].Text = fr.processingMessage;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    fr.processingError = true;
                                    fr.processingMessage = ex.Message;

                                    itmx.ImageKey = "warning";
                                    itmx.SubItems[1].Text = fr.processingMessage;

                                    throw ex;
                                }
                                finally
                                {
                                    this.Text = windowTitleBase;
                                }
                            }
                            #endregion
                        } break;
                    case 1:
                        {
                            #region  |  Import  |

                            foreach (ListViewItem itmx in this.listView_files_import.Items)
                            {
                                currentFile++;
                                this.Text = windowTitleBase + "  (Processing " + currentFile.ToString() + " of " + totalFiles.ToString() + " files)";

                                this.progressBar_main.Value = 0;
                                this.label_percentage.Text = "0%";
                                this.label_Message.Text = "Processing, please wait...";

                               
                                FileRecord fr = (FileRecord)itmx.Tag;
                                try
                                {
                                    itmx.ImageKey = "green";
                                    itmx.SubItems[1].Text = "Processing...";

                                    bool success = p.Import(fr.xmlFilePath, fr.pubFilePath, fr.imagePath, pub2xml.api.Cache.settings);

                                    if (pub2xml.api.Processor.ProcessingErrors.Count > 0)
                                    {
                                        messages.Add(fr, pub2xml.api.Processor.ProcessingErrors);
                                    }

                                    if (success)
                                    {
                                        fr.completed = true;
                                        fr.completedDate = DateTime.Now;

                                        fr.processingError = false;
                                        fr.processingMessage = "Processing Complete";

                                        itmx.ImageKey = "ok";
                                        itmx.SubItems[1].Text = fr.processingMessage;

                                        if (pub2xml.api.Processor.ProcessingErrors.Count > 0)
                                        {
                                            fr.processingError = true;
                                            fr.processingMessage = "Warning: " + " some images where not imported; refer to the processing report for more info!";

                                            itmx.ImageKey = "warning";
                                            itmx.SubItems[1].Text = fr.processingMessage;
                                        }
                                    }
                                    else 
                                    {
                                        fr.processingError = true;
                                        fr.processingMessage = "error processing file...";

                                        itmx.ImageKey = "warning";
                                        itmx.SubItems[1].Text = fr.processingMessage;
                                    }
                                }
                                catch(Exception ex)
                                {
                                    fr.processingError = true;
                                    fr.processingMessage = ex.Message;

                                    itmx.ImageKey = "warning";
                                    itmx.SubItems[1].Text = fr.processingMessage;
                                    throw ex;
                                }
                                finally
                                {
                                    this.Text = windowTitleBase;
                                }
                            }
                            #endregion
                        } break;
                           
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            
                this.Enabled = true;
                this.toolStripStatusLabel1.Text = "Progress";
                this.label_Message.Text = "Finished processing";
            }

            

            if (messages.Count > 0)
            {

                string message_path = Path.Combine(Application.StartupPath, "pubConverter.message.txt");


                using (System.IO.StreamWriter w = new StreamWriter(message_path, false, Encoding.UTF8))
                {
                    foreach (KeyValuePair<FileRecord, List<pub2xml.api.Structures.Core.TextFrame>> kvp in messages)
                    {
                        w.WriteLine(kvp.Key.pubFilePath);
                        w.WriteLine("Errors: " + kvp.Value.Count.ToString() + "");
                        foreach (pub2xml.api.Structures.Core.TextFrame tf in kvp.Value)
                        {
                            w.WriteLine("Message:" + tf.message + "\r\n");
                        }
                    }
                    w.Flush();
                    w.Close();
                }

                System.Diagnostics.Process.Start(message_path);
                
                MessageBox.Show("Finished Processing (with errors)\r\n\r\nPlease review the processing report for more info!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {               
                //MessageBox.Show("Finished Processing!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        void p__onChange_Progress(int Maximum, int Current, string Message)
        {
            if (Current <= Maximum)
            {
                try
                {

                    this.progressBar_main.Maximum = Maximum;
                    this.progressBar_main.Value = Current;

                    if (Current != 0)
                        this.progressBar_main.Value = Current - 1;
                    this.progressBar_main.Value = Current;


                    if (this.progressBar_main.Value > 0)
                    {
                        double perc = Convert.ToDouble(this.progressBar_main.Value) / Convert.ToDouble(this.progressBar_main.Maximum);
                        this.label_percentage.Text = Convert.ToString(Math.Round(perc * 100, 0)) + "%";
                    }
                    else
                    {
                        this.label_percentage.Text = "0%";
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            this.label_Message.Text = Message;        
        }


        private void checkEnabled()
        {
            bool enabled = true;

            switch (tabControl_main.SelectedIndex)
            {
                case 0:
                    {

                        if (this.listView_files_export.Items.Count > 0)
                        {
                            foreach (ListViewItem itmx in this.listView_files_export.Items)
                            {
                                FileRecord fr = (FileRecord)itmx.Tag;
                                if (fr.processingError)
                                {
                                    enabled = false;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            enabled = false;
                        }

                    } break;
                case 1:
                    {
                        if (this.listView_files_import.Items.Count > 0)
                        {
                            foreach (ListViewItem itmx in this.listView_files_import.Items)
                            {
                                FileRecord fr = (FileRecord)itmx.Tag;
                                if (fr.processingError)
                                {
                                    enabled = false;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            enabled = false;
                        }
                    } break;
            }

            this.toolStripButton_startProcessing.Enabled = enabled;
          
        }

        private void addFile(string filePath)
        {
            switch (tabControl_main.SelectedIndex)
            {
                case 0:
                    {
                        addFileExport(filePath);
                    } break;
                case 1:
                    {
                        addFileImport(filePath);
                    } break;
            }
        }
        private void addFileExport(string filePath)
        {

            bool found = false;
            foreach (ListViewItem itmx in this.listView_files_export.Items)
            {
                FileRecord fr = (FileRecord)itmx.Tag;
                if (string.Compare(fr.pubFilePath, filePath, true) == 0)
                {
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                FileRecord fr = new FileRecord();
                fr.pubFilePath = filePath;
                fr.xmlFilePath = filePath + ".xml";
                string directory = Path.GetDirectoryName(filePath);
                fr.imagePath = Path.Combine(directory, "images");

                fr.processType = "Export";

                fr.processingError = false;
                fr.processingMessage = "Ready...";



                ListViewItem itmx = this.listView_files_export.Items.Add(fr.pubFilePath);
                itmx.SubItems.Add(fr.processingMessage);

                if (fr.processingError)
                {
                    itmx.ImageKey = "warning";
                }
                else
                {
                    itmx.ImageKey = "blue";
                }
                itmx.Tag = fr;                
            }

            checkEnabled();
            this.label_fileCount_export.Text = "Files: " + this.listView_files_export.Items.Count.ToString();
        }
        private void addFileImport(string filePath)
        {
            bool found = false;
            foreach (ListViewItem itmx in this.listView_files_import.Items)
            {
                FileRecord fr = (FileRecord)itmx.Tag;
                if (string.Compare(fr.xmlFilePath, filePath, true) == 0)
                {
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                FileRecord fr = new FileRecord();
                fr.xmlFilePath = filePath.Trim();
                fr.pubFilePath = fr.xmlFilePath.Substring(0, fr.xmlFilePath.Length - 4);
                string directory = Path.GetDirectoryName(filePath);
                fr.imagePath = Path.Combine(directory, "images");

                fr.processType = "Import";

                fr.processingError = false;
                fr.processingMessage = "Ready...";

                if (!File.Exists(fr.pubFilePath))
                {
                    fr.processingError = true;
                    fr.processingMessage = "Unable to locate Publisher file...";
                }


                ListViewItem itmx = this.listView_files_import.Items.Add(fr.xmlFilePath);
                itmx.SubItems.Add(fr.processingMessage);
                if (fr.processingError)
                {
                    itmx.ImageKey = "warning";
                }
                else
                {
                    itmx.ImageKey = "blue";
                }
                itmx.Tag = fr;
            }

            checkEnabled();
            this.label_fileCount_import.Text = "Files: " + this.listView_files_import.Items.Count.ToString();
        }


        private void removeFiles()
        {
            switch (tabControl_main.SelectedIndex)
            {
                case 0:
                    {
                        removeFilesExport();
                    } break;
                case 1:
                    {
                        removeFilesImport();
                    } break;
            }
        }
        private void removeFilesExport()
        {

            foreach (ListViewItem itmx in this.listView_files_export.Items)
            {
                if (itmx.Selected)
                    itmx.Remove();
            }
            checkEnabled();
            this.label_fileCount_export.Text = "Files: " + this.listView_files_export.Items.Count.ToString();
        }
        private void removeFilesImport()
        {
            foreach (ListViewItem itmx in this.listView_files_import.Items)
            {
                if (itmx.Selected)
                    itmx.Remove();
            }
            checkEnabled();
            this.label_fileCount_import.Text = "Files: " + this.listView_files_import.Items.Count.ToString();
        }


        private void loadSettings()
        {
            Options f = new Options();
            f.settings = (pub2xml.api.SettingsCore)pub2xml.api.Cache.settings.Clone();
            f.ShowDialog();
            if (f.saved)
            {
                
                pub2xml.api.Cache.settings.ExportCreatePdfFile = f.settings.ExportCreatePdfFile;
                pub2xml.api.Cache.settings.ExportPseudoTranslateFile = f.settings.ExportPseudoTranslateFile;
                pub2xml.api.Cache.settings.ExportMarkupInternalFontEffects = f.settings.ExportMarkupInternalFontEffects;
                pub2xml.api.Cache.settings.ImportCreateBakFile = f.settings.ImportCreateBakFile;
                pub2xml.api.Cache.settings.ImportCreatePdfFile = f.settings.ImportCreatePdfFile;

                pub2xml.api.Cache.settings.ExportText = f.settings.ExportText;
                pub2xml.api.Cache.settings.ExportPictures = f.settings.ExportPictures;

                pub2xml.api.Cache.settings.ImportText = f.settings.ImportText;
                pub2xml.api.Cache.settings.ImportPictures = f.settings.ImportPictures;


                pub2xml.api.SettingsSerializer.SaveSettings(pub2xml.api.Cache.settings);
            }
        }

        private void tabControl_main_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl_main.SelectedIndex)
            {
                case 0:
                    {                        
                        this.toolStripButton_startProcessing.Image = this.imageList_main.Images[4];
                        this.toolStripButton_startProcessing.Text = "Export";
                        this.toolStripButton_startProcessing.ToolTipText = "Start Processing (Export)";                        
                    } break;
                case 1:
                    {                        
                        this.toolStripButton_startProcessing.Image = this.imageList_main.Images[4];
                        this.toolStripButton_startProcessing.Text = "Import";
                        this.toolStripButton_startProcessing.ToolTipText = "Start Processing (Import)";

                     
                    } break;
            }
        }

        private void listView_files_export_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                try
                {
                    foreach (string file in files)
                    {
                        if (file.Trim().ToLower().EndsWith(".pub"))
                            addFile(file);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
      
        private void listView_files_export_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void listView_files_import_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                try
                {
                    foreach (string file in files)
                    {
                        if (file.Trim().ToLower().EndsWith(".xml"))
                            addFile(file);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void listView_files_import_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }


       
        

        private void addFilesDialog()
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Multiselect = false;
            f.RestoreDirectory = true;
            if (tabControl_main.SelectedIndex == 0)
            {
                f.Filter = "Publisher Files (*.pub)|*.pub";
                f.Title = "Browse & select the Publisher files";
            }
            else
            {
                f.Filter = "XML Files (*.xml)|*.xml";
                f.Title = "Browse & select the XML files";
            }

            DialogResult dr = f.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string filePath in f.FileNames)
                {
                    addFile(filePath);
                }
            }
        }

        private void addFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addFilesDialog();
        }       

        private void addFilesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addFilesDialog();
        }

        private void removeFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removeFiles();
            
        }

        private void removeFilesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            removeFiles();
        }

        private void listView_files_import_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                removeFiles();
        }

        private void listView_files_export_KeyUp(object sender, KeyEventArgs e)
        {
            removeFiles();
        }

        private void linkLabel_select_all_export_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (ListViewItem item in this.listView_files_export.Items)
                item.Selected = true;
        }

        private void linkLabel_deselect_all_export_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (ListViewItem item in this.listView_files_export.Items)
                item.Selected = false;
        }

        private void linkLabel_select_all_import_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (ListViewItem item in this.listView_files_import.Items)
                item.Selected = true;
        }

        private void linkLabel_deselect_all_import_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (ListViewItem item in this.listView_files_import.Items)
                item.Selected = false;
        }

        private void startProcessingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startProcessing();
        }

        private void toolStripButton_startProcessing_Click(object sender, EventArgs e)
        {
            startProcessing();
        }



       

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadSettings();
        }

        private void toolStripButton_Settings_Click(object sender, EventArgs e)
        {
            loadSettings();
        }

        

        

        

   
    }
}
