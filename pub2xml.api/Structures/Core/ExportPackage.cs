using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace pub2xml.api.Structures.Core
{
    [Serializable]
    public class ExportPackage: ICloneable
    {
        [XmlAttribute("guild")]
        public string guid { get; set; }

        [XmlAttribute("xmlFilePath")]
        public string xmlFilePath { get; set; }

        [XmlAttribute("pubFilePath")]
        public string pubFilePath { get; set; }

        [XmlAttribute("imagePath")]
        public string imagePath { get; set; }

        [XmlAttribute("success")]
        public bool success { get; set; }

         [XmlAttribute("created")]
        public DateTime created { get; set; }

        [XmlElement("message", typeof(string))]
        public string message { get; set; }

        [XmlArrayItem("TextFrame", typeof(TextFrame))]
        [XmlArray("textFrames")]
        public List<TextFrame> textFrames { get; set; }

        public ExportPackage()
        {
            guid = Guid.NewGuid().ToString();

            xmlFilePath = string.Empty;
            pubFilePath = string.Empty;
            imagePath = string.Empty;

            success = false;
            message = string.Empty;
            created = DateTime.Now;
            
            textFrames = new List<TextFrame>();

        }
        public object Clone()
        {
            ExportPackage ep = new ExportPackage();
            ep.guid = this.guid;
            ep.xmlFilePath = this.xmlFilePath;
            ep.pubFilePath = this.pubFilePath;

            ep.success = this.success;
            ep.message = this.message;
            ep.created = this.created;

            ep.textFrames = new List<TextFrame>();
            foreach (var tf in this.textFrames)
                ep.textFrames.Add((TextFrame)tf.Clone());

            return ep;
        }
    }
}
