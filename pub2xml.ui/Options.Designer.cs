namespace pub2xml.api.ui
{
    partial class Options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.checkBox_pictures_export = new System.Windows.Forms.CheckBox();
            this.checkBox_translatable_text_export = new System.Windows.Forms.CheckBox();
            this.checkBox_markup_internal_fonts_export = new System.Windows.Forms.CheckBox();
            this.checkBox_create_pdf_export = new System.Windows.Forms.CheckBox();
            this.checkBox_create_xed_export = new System.Windows.Forms.CheckBox();
            this.checkBox_pictures_import = new System.Windows.Forms.CheckBox();
            this.checkBox_translatable_text_import = new System.Windows.Forms.CheckBox();
            this.checkBox_create_pdf_import = new System.Windows.Forms.CheckBox();
            this.checkBox_create_bak_import = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_ok
            // 
            this.button_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ok.Location = new System.Drawing.Point(247, 9);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 4;
            this.button_ok.Text = "&OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.Location = new System.Drawing.Point(328, 9);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 3;
            this.button_cancel.Text = "&Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // checkBox_pictures_export
            // 
            this.checkBox_pictures_export.AutoSize = true;
            this.checkBox_pictures_export.Location = new System.Drawing.Point(23, 45);
            this.checkBox_pictures_export.Name = "checkBox_pictures_export";
            this.checkBox_pictures_export.Size = new System.Drawing.Size(92, 17);
            this.checkBox_pictures_export.TabIndex = 2;
            this.checkBox_pictures_export.Text = "Export images";
            this.checkBox_pictures_export.UseVisualStyleBackColor = true;
            // 
            // checkBox_translatable_text_export
            // 
            this.checkBox_translatable_text_export.AutoSize = true;
            this.checkBox_translatable_text_export.Location = new System.Drawing.Point(23, 22);
            this.checkBox_translatable_text_export.Name = "checkBox_translatable_text_export";
            this.checkBox_translatable_text_export.Size = new System.Drawing.Size(152, 17);
            this.checkBox_translatable_text_export.TabIndex = 0;
            this.checkBox_translatable_text_export.Text = "Export translatable content";
            this.checkBox_translatable_text_export.UseVisualStyleBackColor = true;
            // 
            // checkBox_markup_internal_fonts_export
            // 
            this.checkBox_markup_internal_fonts_export.AutoSize = true;
            this.checkBox_markup_internal_fonts_export.Location = new System.Drawing.Point(23, 112);
            this.checkBox_markup_internal_fonts_export.Name = "checkBox_markup_internal_fonts_export";
            this.checkBox_markup_internal_fonts_export.Size = new System.Drawing.Size(174, 17);
            this.checkBox_markup_internal_fonts_export.TabIndex = 5;
            this.checkBox_markup_internal_fonts_export.Text = "Markup internal font information";
            this.checkBox_markup_internal_fonts_export.UseVisualStyleBackColor = true;
            // 
            // checkBox_create_pdf_export
            // 
            this.checkBox_create_pdf_export.AutoSize = true;
            this.checkBox_create_pdf_export.Location = new System.Drawing.Point(23, 66);
            this.checkBox_create_pdf_export.Name = "checkBox_create_pdf_export";
            this.checkBox_create_pdf_export.Size = new System.Drawing.Size(97, 17);
            this.checkBox_create_pdf_export.TabIndex = 3;
            this.checkBox_create_pdf_export.Text = "Create PDF file";
            this.checkBox_create_pdf_export.UseVisualStyleBackColor = true;
            // 
            // checkBox_create_xed_export
            // 
            this.checkBox_create_xed_export.AutoSize = true;
            this.checkBox_create_xed_export.Location = new System.Drawing.Point(23, 89);
            this.checkBox_create_xed_export.Name = "checkBox_create_xed_export";
            this.checkBox_create_xed_export.Size = new System.Drawing.Size(112, 17);
            this.checkBox_create_xed_export.TabIndex = 4;
            this.checkBox_create_xed_export.Text = "Create Pseudo file";
            this.checkBox_create_xed_export.UseVisualStyleBackColor = true;
            // 
            // checkBox_pictures_import
            // 
            this.checkBox_pictures_import.AutoSize = true;
            this.checkBox_pictures_import.Location = new System.Drawing.Point(23, 45);
            this.checkBox_pictures_import.Name = "checkBox_pictures_import";
            this.checkBox_pictures_import.Size = new System.Drawing.Size(91, 17);
            this.checkBox_pictures_import.TabIndex = 1;
            this.checkBox_pictures_import.Text = "Import images";
            this.checkBox_pictures_import.UseVisualStyleBackColor = true;
            // 
            // checkBox_translatable_text_import
            // 
            this.checkBox_translatable_text_import.AutoSize = true;
            this.checkBox_translatable_text_import.Location = new System.Drawing.Point(23, 22);
            this.checkBox_translatable_text_import.Name = "checkBox_translatable_text_import";
            this.checkBox_translatable_text_import.Size = new System.Drawing.Size(151, 17);
            this.checkBox_translatable_text_import.TabIndex = 0;
            this.checkBox_translatable_text_import.Text = "Import translatable content";
            this.checkBox_translatable_text_import.UseVisualStyleBackColor = true;
            // 
            // checkBox_create_pdf_import
            // 
            this.checkBox_create_pdf_import.AutoSize = true;
            this.checkBox_create_pdf_import.Location = new System.Drawing.Point(23, 90);
            this.checkBox_create_pdf_import.Name = "checkBox_create_pdf_import";
            this.checkBox_create_pdf_import.Size = new System.Drawing.Size(97, 17);
            this.checkBox_create_pdf_import.TabIndex = 3;
            this.checkBox_create_pdf_import.Text = "Create PDF file";
            this.checkBox_create_pdf_import.UseVisualStyleBackColor = true;
            // 
            // checkBox_create_bak_import
            // 
            this.checkBox_create_bak_import.AutoSize = true;
            this.checkBox_create_bak_import.Location = new System.Drawing.Point(23, 67);
            this.checkBox_create_bak_import.Name = "checkBox_create_bak_import";
            this.checkBox_create_bak_import.Size = new System.Drawing.Size(112, 17);
            this.checkBox_create_bak_import.TabIndex = 2;
            this.checkBox_create_bak_import.Text = "Create backup file";
            this.checkBox_create_bak_import.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(5, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(405, 228);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBox_pictures_export);
            this.tabPage1.Controls.Add(this.checkBox_translatable_text_export);
            this.tabPage1.Controls.Add(this.checkBox_markup_internal_fonts_export);
            this.tabPage1.Controls.Add(this.checkBox_create_xed_export);
            this.tabPage1.Controls.Add(this.checkBox_create_pdf_export);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(397, 202);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Export";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkBox_pictures_import);
            this.tabPage2.Controls.Add(this.checkBox_translatable_text_import);
            this.tabPage2.Controls.Add(this.checkBox_create_bak_import);
            this.tabPage2.Controls.Add(this.checkBox_create_pdf_import);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(397, 202);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Import";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_cancel);
            this.panel1.Controls.Add(this.button_ok);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 238);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 40);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(415, 238);
            this.panel2.TabIndex = 7;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 278);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Options_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.CheckBox checkBox_create_pdf_export;
        private System.Windows.Forms.CheckBox checkBox_markup_internal_fonts_export;
        private System.Windows.Forms.CheckBox checkBox_pictures_export;
        private System.Windows.Forms.CheckBox checkBox_translatable_text_export;
        private System.Windows.Forms.CheckBox checkBox_pictures_import;
        private System.Windows.Forms.CheckBox checkBox_translatable_text_import;
        private System.Windows.Forms.CheckBox checkBox_create_pdf_import;
        private System.Windows.Forms.CheckBox checkBox_create_bak_import;
        private System.Windows.Forms.CheckBox checkBox_create_xed_export;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}