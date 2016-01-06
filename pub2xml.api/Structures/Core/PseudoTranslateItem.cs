using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace pub2xml.api.Structures.Core
{
    public class PseudoTranslateItem: ICloneable
    {
        [XmlAttribute("FindWhat")]
        public string FindWhat { get; set; }

        [XmlAttribute("ReplaceWith")]
        public string ReplaceWith { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
