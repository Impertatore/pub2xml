using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using pub2xml.api.Structures.Core;
using pub2xml.api.Structures;
using System.Xml.Serialization;

namespace pub2xml.api
{
    [Serializable]
    public class SettingsCore : ICloneable
    {
        [XmlAttribute("ApplicationSettingsPath")]
        public string ApplicationSettingsPath { get; set; }

        [XmlAttribute("ApplicationSettingsFullPath")]
        public string ApplicationSettingsFullPath { get; set; }


        [XmlAttribute("ImportCreateBakFile")]
        public bool ImportCreateBakFile { get; set; }

        [XmlAttribute("ImportCreatePdfFile")]
        public bool ImportCreatePdfFile { get; set; }

        [XmlAttribute("ImportText")]
        public bool ImportText { get; set; }

        [XmlAttribute("ImportPictures")]
        public bool ImportPictures { get; set; }



        [XmlAttribute("ExportCreatePdfFile")]
        public bool ExportCreatePdfFile { get; set; }

        [XmlAttribute("ExportMarkupInternalFontEffects")]
        public bool ExportMarkupInternalFontEffects { get; set; }

        [XmlAttribute("ExportText")]
        public bool ExportText { get; set; }

        [XmlAttribute("ExportPictures")]
        public bool ExportPictures { get; set; }

        [XmlAttribute("ExportPseudoTranslateFile")]
        public bool ExportPseudoTranslateFile { get; set; }

        [XmlArrayItem("PseudoTranslateItem", typeof(PseudoTranslateItem))]
        [XmlArray("PseudoTranslateItems")]
        public List<PseudoTranslateItem> PseudoTranslateItems { get; set; }

        [XmlArrayItem("FontFormatTag", typeof(FontFormatTag))]
        [XmlArray("FontFormatTags")]
        public List<FontFormatTag> FontFormatTags { get; set; }

        public SettingsCore()
        {
            // the default setting path location; this can be set by the user
            ApplicationSettingsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Constants.pub2xmlFolderName);

            if (!Directory.Exists(ApplicationSettingsPath))
                Directory.CreateDirectory(ApplicationSettingsPath);

            // the default setting file name; this can be set by the user
            ApplicationSettingsFullPath = Path.Combine(ApplicationSettingsPath, Constants.pub2xmlFileName);


            ExportCreatePdfFile = true;
            ExportPseudoTranslateFile = true;
            ExportMarkupInternalFontEffects = true;

            ExportText = true;
            ExportPictures = true;

            ImportCreateBakFile = true;
            ImportCreatePdfFile = true;

            ImportText = true;
            ImportPictures = true;

            PseudoTranslateItems = null;
            FontFormatTags = null;
  
        }

        public object Clone()
        {
            SettingsCore sc = new SettingsCore();
            sc.ApplicationSettingsFullPath = this.ApplicationSettingsFullPath;
            sc.ApplicationSettingsPath = this.ApplicationSettingsPath;
            sc.ExportCreatePdfFile = this.ExportCreatePdfFile;
            sc.ExportMarkupInternalFontEffects = this.ExportMarkupInternalFontEffects;
            sc.ExportPictures = this.ExportPictures;
            sc.ExportText = this.ExportText;
            sc.ExportPseudoTranslateFile = this.ExportPseudoTranslateFile;
            sc.FontFormatTags = new List<FontFormatTag>();
            foreach (var fft in this.FontFormatTags)
                sc.FontFormatTags.Add((FontFormatTag)fft.Clone());

            sc.ImportCreateBakFile = this.ImportCreateBakFile;
            sc.ImportCreatePdfFile = this.ImportCreatePdfFile;
            sc.ImportPictures = this.ImportPictures;
            sc.ImportText = this.ImportText;
            sc.PseudoTranslateItems = new List<PseudoTranslateItem>();
            foreach (var vtsi in this.PseudoTranslateItems)
                sc.PseudoTranslateItems.Add((PseudoTranslateItem)vtsi.Clone());

            
            return sc;
        }
    }
}
