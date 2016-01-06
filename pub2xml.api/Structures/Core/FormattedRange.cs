using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace pub2xml.api.Structures.Core
{
    [Serializable]
    public class FormattedRange : ICloneable
    {
        
        [Flags]
        public enum FormatType
        {
            None = 1,
            Bold = 2,
            Italic = 4,
            Name = 8,
            Size = 16,
            StrikeThrough = 32,
            SuperScript = 64,
            SubScript = 128,
            Underline = 256,

            Empty = 0
        }

        

        [XmlAttribute("text")]
        public string text { get; set; }

        [XmlAttribute("underlineType")]
        public string underlineType { get; set; }


        [XmlElement("formatType", typeof(FormatType))]
        public FormatType formatType { get; set; }

        public FormattedRange()
        {
            formatType = FormatType.Empty;
            text = string.Empty;
            underlineType = string.Empty;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
