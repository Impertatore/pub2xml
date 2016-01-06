using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace pub2xml.api.Structures.Core
{
    [Serializable]
    public class FontFormatTag: ICloneable
    {
        [XmlAttribute("name")]
        public string name { get; set; }

        [XmlAttribute("regexContent")]
        public string regexContent { get; set; }

        [XmlElement("formatType", typeof(FormattedRange.FormatType))]
        public FormattedRange.FormatType formatType { get; set; }




        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
