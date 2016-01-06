using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace pub2xml.api.ui
{
    [Serializable]
    public class FileRecord: ICloneable
    {

        public string xmlFilePath { get; set; }
        public string pubFilePath { get; set; }
        public string pubFilePathBak { get; set; }
        public string imagePath { get; set; }

        public bool completed { get; set; }
        public DateTime completedDate { get; set; }

        public string processType { get; set; }

        public bool processingError { get; set; }
        public string processingMessage { get; set; }

        public FileRecord()
        {
            xmlFilePath = string.Empty;
            pubFilePath = string.Empty;
            pubFilePathBak = string.Empty;
            imagePath = string.Empty;

            completed = false;
            completedDate = DateTime.Now;

            processType = "Export";

            processingError = false;
            processingMessage = string.Empty;

        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
