using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pub2xml.api.ui
{
    public partial class Options : Form
    {
        public bool saved { get; set; }
        public  pub2xml.api.SettingsCore settings { get; set; }

        public Options()
        {
            InitializeComponent();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            

            saved = false;

            
            this.checkBox_create_pdf_export.Checked = settings.ExportCreatePdfFile;
            this.checkBox_create_xed_export.Checked = settings.ExportPseudoTranslateFile;
            this.checkBox_markup_internal_fonts_export.Checked = settings.ExportMarkupInternalFontEffects;
            this.checkBox_create_bak_import.Checked = settings.ImportCreateBakFile;
            this.checkBox_create_pdf_import.Checked = settings.ImportCreatePdfFile;


            this.checkBox_translatable_text_export.Checked = settings.ExportText;
            this.checkBox_pictures_export.Checked = settings.ExportPictures;

            this.checkBox_translatable_text_import.Checked = settings.ImportText;
            this.checkBox_pictures_import.Checked = settings.ImportPictures;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
           
            settings.ExportCreatePdfFile = this.checkBox_create_pdf_export.Checked;
            settings.ExportPseudoTranslateFile = this.checkBox_create_xed_export.Checked;
            settings.ExportMarkupInternalFontEffects = this.checkBox_markup_internal_fonts_export.Checked;
            settings.ImportCreateBakFile = this.checkBox_create_bak_import.Checked;
            settings.ImportCreatePdfFile = this.checkBox_create_pdf_import.Checked;


            settings.ExportText = this.checkBox_translatable_text_export.Checked;
            settings.ExportPictures = this.checkBox_pictures_export.Checked;

            settings.ImportText = this.checkBox_translatable_text_import.Checked;
            settings.ImportPictures = this.checkBox_pictures_import.Checked;

            saved = true;
            this.Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            saved = false;
            this.Close();
        }
    }
}
