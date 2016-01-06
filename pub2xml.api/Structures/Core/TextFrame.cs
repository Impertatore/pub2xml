using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace pub2xml.api.Structures.Core
{
    [Serializable]
    public class TextFrame : ICloneable
    {
        [XmlAttribute("guid")]
        public string guid { get; set; }

        [XmlAttribute("shapeId")]
        public Int32 shapeId { get; set; }

        [XmlAttribute("shapeName")]
        public string shapeName { get; set; }

        [XmlAttribute("shapeType")]
        public string shapeType { get; set; }

        [XmlAttribute("tableColumn")]
        public string tableColumn { get; set; }

        [XmlAttribute("tableRow")]
        public string tableRow { get; set; }

        [XmlAttribute("paragraph")]
        public Int32 paragraph { get; set; }

        [XmlAttribute("imageName")]
        public string imageName { get; set; }

        [XmlAttribute("message")]
        public string message { get; set; }


        [XmlElement("text", typeof(string))]
        public string text { get; set; }

 
        public TextFrame()
        {
            guid = Guid.NewGuid().ToString();
            shapeId = -1;
            shapeName = string.Empty;
            shapeType = string.Empty;
            tableColumn = string.Empty;
            tableRow = string.Empty;
            paragraph = 0;
            imageName = string.Empty;
            message = string.Empty;    

            text = string.Empty;         
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
