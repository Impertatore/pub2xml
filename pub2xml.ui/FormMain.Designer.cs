namespace pub2xml.api.ui
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar_main = new System.Windows.Forms.ToolStripProgressBar();
            this.label_percentage = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label_Message = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_startProcessing = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Settings = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listView_files_export = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addFilesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFilesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList_listview = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel_deselect_all_export = new System.Windows.Forms.LinkLabel();
            this.linkLabel_select_all_export = new System.Windows.Forms.LinkLabel();
            this.label_fileCount_export = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.listView_files_import = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.linkLabel_deselect_all_import = new System.Windows.Forms.LinkLabel();
            this.linkLabel_select_all_import = new System.Windows.Forms.LinkLabel();
            this.label_fileCount_import = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList_main = new System.Windows.Forms.ImageList(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl_main.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.progressBar_main,
            this.label_percentage,
            this.toolStripStatusLabel3,
            this.label_Message});
            this.statusStrip1.Location = new System.Drawing.Point(0, 425);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(876, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(52, 17);
            this.toolStripStatusLabel1.Text = "Progress";
            // 
            // progressBar_main
            // 
            this.progressBar_main.AutoSize = false;
            this.progressBar_main.Name = "progressBar_main";
            this.progressBar_main.Size = new System.Drawing.Size(200, 16);
            // 
            // label_percentage
            // 
            this.label_percentage.Name = "label_percentage";
            this.label_percentage.Size = new System.Drawing.Size(23, 17);
            this.label_percentage.Text = "0%";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(13, 17);
            this.toolStripStatusLabel3.Text = "  ";
            // 
            // label_Message
            // 
            this.label_Message.Name = "label_Message";
            this.label_Message.Size = new System.Drawing.Size(571, 17);
            this.label_Message.Spring = true;
            this.label_Message.Text = "...";
            this.label_Message.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_startProcessing,
            this.toolStripSeparator3,
            this.toolStripButton_Settings,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(876, 39);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_startProcessing
            // 
            this.toolStripButton_startProcessing.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_startProcessing.Image")));
            this.toolStripButton_startProcessing.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_startProcessing.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_startProcessing.Name = "toolStripButton_startProcessing";
            this.toolStripButton_startProcessing.Size = new System.Drawing.Size(76, 36);
            this.toolStripButton_startProcessing.Text = "Export";
            this.toolStripButton_startProcessing.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripButton_startProcessing.Click += new System.EventHandler(this.toolStripButton_startProcessing_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton_Settings
            // 
            this.toolStripButton_Settings.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Settings.Image")));
            this.toolStripButton_Settings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Settings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Settings.Name = "toolStripButton_Settings";
            this.toolStripButton_Settings.Size = new System.Drawing.Size(85, 36);
            this.toolStripButton_Settings.Text = "Settings";
            this.toolStripButton_Settings.Click += new System.EventHandler(this.toolStripButton_Settings_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tabControl_main
            // 
            this.tabControl_main.Controls.Add(this.tabPage1);
            this.tabControl_main.Controls.Add(this.tabPage2);
            this.tabControl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_main.ImageList = this.imageList1;
            this.tabControl_main.Location = new System.Drawing.Point(0, 5);
            this.tabControl_main.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(876, 381);
            this.tabControl_main.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl_main.TabIndex = 14;
            this.tabControl_main.SelectedIndexChanged += new System.EventHandler(this.tabControl_main_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(5, 8, 5, 5);
            this.tabPage1.Size = new System.Drawing.Size(868, 346);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Export";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(5, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(858, 333);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Microsoft Publisher Files";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listView_files_export);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(8);
            this.panel2.Size = new System.Drawing.Size(852, 292);
            this.panel2.TabIndex = 1;
            // 
            // listView_files_export
            // 
            this.listView_files_export.AllowDrop = true;
            this.listView_files_export.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.listView_files_export.ContextMenuStrip = this.contextMenuStrip1;
            this.listView_files_export.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_files_export.FullRowSelect = true;
            this.listView_files_export.GridLines = true;
            this.listView_files_export.Location = new System.Drawing.Point(8, 8);
            this.listView_files_export.Name = "listView_files_export";
            this.listView_files_export.Size = new System.Drawing.Size(836, 276);
            this.listView_files_export.SmallImageList = this.imageList_listview;
            this.listView_files_export.TabIndex = 37;
            this.listView_files_export.UseCompatibleStateImageBehavior = false;
            this.listView_files_export.View = System.Windows.Forms.View.Details;
            this.listView_files_export.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_files_export_DragDrop);
            this.listView_files_export.DragOver += new System.Windows.Forms.DragEventHandler(this.listView_files_export_DragOver);
            this.listView_files_export.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listView_files_export_KeyUp);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Full Path";
            this.columnHeader3.Width = 500;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Processing Message";
            this.columnHeader4.Width = 260;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFilesToolStripMenuItem1,
            this.removeFilesToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(144, 48);
            // 
            // addFilesToolStripMenuItem1
            // 
            this.addFilesToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("addFilesToolStripMenuItem1.Image")));
            this.addFilesToolStripMenuItem1.Name = "addFilesToolStripMenuItem1";
            this.addFilesToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.addFilesToolStripMenuItem1.Text = "Add Files";
            this.addFilesToolStripMenuItem1.Click += new System.EventHandler(this.addFilesToolStripMenuItem1_Click);
            // 
            // removeFilesToolStripMenuItem1
            // 
            this.removeFilesToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("removeFilesToolStripMenuItem1.Image")));
            this.removeFilesToolStripMenuItem1.Name = "removeFilesToolStripMenuItem1";
            this.removeFilesToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.removeFilesToolStripMenuItem1.Text = "Remove Files";
            this.removeFilesToolStripMenuItem1.Click += new System.EventHandler(this.removeFilesToolStripMenuItem1_Click);
            // 
            // imageList_listview
            // 
            this.imageList_listview.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_listview.ImageStream")));
            this.imageList_listview.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_listview.Images.SetKeyName(0, "ok");
            this.imageList_listview.Images.SetKeyName(1, "warning");
            this.imageList_listview.Images.SetKeyName(2, "blue");
            this.imageList_listview.Images.SetKeyName(3, "green");
            this.imageList_listview.Images.SetKeyName(4, "red");
            this.imageList_listview.Images.SetKeyName(5, "yellow");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.linkLabel_deselect_all_export);
            this.panel1.Controls.Add(this.linkLabel_select_all_export);
            this.panel1.Controls.Add(this.label_fileCount_export);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 308);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.panel1.Size = new System.Drawing.Size(852, 22);
            this.panel1.TabIndex = 0;
            // 
            // linkLabel_deselect_all_export
            // 
            this.linkLabel_deselect_all_export.AutoSize = true;
            this.linkLabel_deselect_all_export.Location = new System.Drawing.Point(72, 3);
            this.linkLabel_deselect_all_export.Name = "linkLabel_deselect_all_export";
            this.linkLabel_deselect_all_export.Size = new System.Drawing.Size(63, 13);
            this.linkLabel_deselect_all_export.TabIndex = 38;
            this.linkLabel_deselect_all_export.TabStop = true;
            this.linkLabel_deselect_all_export.Text = "Deselect All";
            this.linkLabel_deselect_all_export.Visible = false;
            this.linkLabel_deselect_all_export.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_deselect_all_export_LinkClicked);
            // 
            // linkLabel_select_all_export
            // 
            this.linkLabel_select_all_export.AutoSize = true;
            this.linkLabel_select_all_export.Location = new System.Drawing.Point(11, 3);
            this.linkLabel_select_all_export.Name = "linkLabel_select_all_export";
            this.linkLabel_select_all_export.Size = new System.Drawing.Size(51, 13);
            this.linkLabel_select_all_export.TabIndex = 38;
            this.linkLabel_select_all_export.TabStop = true;
            this.linkLabel_select_all_export.Text = "Select All";
            this.linkLabel_select_all_export.Visible = false;
            this.linkLabel_select_all_export.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_select_all_export_LinkClicked);
            // 
            // label_fileCount_export
            // 
            this.label_fileCount_export.AutoSize = true;
            this.label_fileCount_export.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_fileCount_export.Location = new System.Drawing.Point(801, 0);
            this.label_fileCount_export.Name = "label_fileCount_export";
            this.label_fileCount_export.Size = new System.Drawing.Size(43, 13);
            this.label_fileCount_export.TabIndex = 37;
            this.label_fileCount_export.Text = "Files: 0 ";
            this.label_fileCount_export.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(5, 8, 5, 5);
            this.tabPage2.Size = new System.Drawing.Size(868, 346);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Import";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(5, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(858, 333);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Updated XML Files";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.listView_files_import);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 16);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(8);
            this.panel3.Size = new System.Drawing.Size(852, 292);
            this.panel3.TabIndex = 1;
            // 
            // listView_files_import
            // 
            this.listView_files_import.AllowDrop = true;
            this.listView_files_import.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView_files_import.ContextMenuStrip = this.contextMenuStrip1;
            this.listView_files_import.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_files_import.FullRowSelect = true;
            this.listView_files_import.GridLines = true;
            this.listView_files_import.Location = new System.Drawing.Point(8, 8);
            this.listView_files_import.Name = "listView_files_import";
            this.listView_files_import.Size = new System.Drawing.Size(836, 276);
            this.listView_files_import.SmallImageList = this.imageList_listview;
            this.listView_files_import.TabIndex = 36;
            this.listView_files_import.UseCompatibleStateImageBehavior = false;
            this.listView_files_import.View = System.Windows.Forms.View.Details;
            this.listView_files_import.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_files_import_DragDrop);
            this.listView_files_import.DragOver += new System.Windows.Forms.DragEventHandler(this.listView_files_import_DragOver);
            this.listView_files_import.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listView_files_import_KeyUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Full Path";
            this.columnHeader1.Width = 500;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Processing Message";
            this.columnHeader2.Width = 260;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.linkLabel_deselect_all_import);
            this.panel4.Controls.Add(this.linkLabel_select_all_import);
            this.panel4.Controls.Add(this.label_fileCount_import);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 308);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.panel4.Size = new System.Drawing.Size(852, 22);
            this.panel4.TabIndex = 0;
            // 
            // linkLabel_deselect_all_import
            // 
            this.linkLabel_deselect_all_import.AutoSize = true;
            this.linkLabel_deselect_all_import.Location = new System.Drawing.Point(72, 3);
            this.linkLabel_deselect_all_import.Name = "linkLabel_deselect_all_import";
            this.linkLabel_deselect_all_import.Size = new System.Drawing.Size(63, 13);
            this.linkLabel_deselect_all_import.TabIndex = 38;
            this.linkLabel_deselect_all_import.TabStop = true;
            this.linkLabel_deselect_all_import.Text = "Deselect All";
            this.linkLabel_deselect_all_import.Visible = false;
            this.linkLabel_deselect_all_import.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_deselect_all_import_LinkClicked);
            // 
            // linkLabel_select_all_import
            // 
            this.linkLabel_select_all_import.AutoSize = true;
            this.linkLabel_select_all_import.Location = new System.Drawing.Point(11, 3);
            this.linkLabel_select_all_import.Name = "linkLabel_select_all_import";
            this.linkLabel_select_all_import.Size = new System.Drawing.Size(51, 13);
            this.linkLabel_select_all_import.TabIndex = 38;
            this.linkLabel_select_all_import.TabStop = true;
            this.linkLabel_select_all_import.Text = "Select All";
            this.linkLabel_select_all_import.Visible = false;
            this.linkLabel_select_all_import.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_select_all_import_LinkClicked);
            // 
            // label_fileCount_import
            // 
            this.label_fileCount_import.AutoSize = true;
            this.label_fileCount_import.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_fileCount_import.Location = new System.Drawing.Point(801, 0);
            this.label_fileCount_import.Name = "label_fileCount_import";
            this.label_fileCount_import.Size = new System.Drawing.Size(43, 13);
            this.label_fileCount_import.TabIndex = 37;
            this.label_fileCount_import.Text = "Files: 0 ";
            this.label_fileCount_import.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Download-32.png");
            this.imageList1.Images.SetKeyName(1, "Upload-32.png");
            this.imageList1.Images.SetKeyName(2, "Start-32.png");
            // 
            // imageList_main
            // 
            this.imageList_main.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_main.ImageStream")));
            this.imageList_main.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_main.Images.SetKeyName(0, "Export-32.png");
            this.imageList_main.Images.SetKeyName(1, "Import-32.png");
            this.imageList_main.Images.SetKeyName(2, "Export-Blue-32.png");
            this.imageList_main.Images.SetKeyName(3, "Import-Blue-32.png");
            this.imageList_main.Images.SetKeyName(4, "Start-32.png");
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tabControl_main);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 39);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel5.Size = new System.Drawing.Size(876, 386);
            this.panel5.TabIndex = 15;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 447);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Publisher Converter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl_main.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_startProcessing;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton_Settings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_fileCount_export;
        private System.Windows.Forms.LinkLabel linkLabel_deselect_all_export;
        private System.Windows.Forms.LinkLabel linkLabel_select_all_export;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView listView_files_import;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.LinkLabel linkLabel_deselect_all_import;
        private System.Windows.Forms.LinkLabel linkLabel_select_all_import;
        private System.Windows.Forms.Label label_fileCount_import;
        private System.Windows.Forms.ListView listView_files_export;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addFilesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem removeFilesToolStripMenuItem1;
        private System.Windows.Forms.ImageList imageList_main;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar progressBar_main;
        private System.Windows.Forms.ToolStripStatusLabel label_percentage;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel label_Message;
        private System.Windows.Forms.ImageList imageList_listview;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel5;

    }
}

