using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Publisher;
using System.Reflection;
using Microsoft.Office.Interop;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Diagnostics;
using pub2xml.api.Structures.Core;



namespace pub2xml.api
{
    public class Processor
    {



        public delegate void onChange_Progress(int Maximum, int Current, string Message);
        public event onChange_Progress _onChange_Progress;


        internal static Int32 MaximumShapes { get; set; }
        internal static Int32 CurrentIndex { get; set; }

        internal static Dictionary<Int64, List<Structures.Core.TextFrame>> FramesDictoinary { get; set; }
        public static List<Structures.Core.TextFrame> ProcessingErrors { get; set; }


        public Processor()
        {
            MaximumShapes = 0;
            CurrentIndex = 0;
            FramesDictoinary = null;
            ProcessingErrors = null;
        }

        /// <summary>
        /// Import the updated content back into the MS Publisher file
        /// </summary>
        /// <param name="xmlFilePath">The path to the xml file containing the updated content</param>
        /// <param name="pubFilePath">The path to the MS Publisher file that you want to import the content</param>
        /// <param name="imagePath">The path to the image folder containing the updated images</param>
        /// <param name="settings">The settings structure</param>
        /// <returns>Return true if successful; if the result is false, then you can recover the processing error from [ProcessingErrors]</returns>
        public bool Import(string xmlFilePath, string pubFilePath, string imagePath, SettingsCore settings)
        {
            Parser.Importer importer = new Parser.Importer();
            importer._onChange_Progress += importer__onChange_Progress;
            return importer.Import(xmlFilePath, pubFilePath, imagePath, settings);
        }

        void importer__onChange_Progress(int Maximum, int Current, string Message)
        {
            if (_onChange_Progress != null)
                _onChange_Progress(Maximum, Current, Message);
        }

        /// <summary>
        /// Export the translatable content from the MS Publisher file
        /// </summary>
        /// <param name="pubFilePath">The path to the MS Publisher file that you want to export content</param>
        /// <param name="xmlFilePath">The path to the XMl file where the exported content will be written to</param>
        /// <param name="imagePath">The path to the image folder where the images will be written to</param>
        /// <param name="settings">The settings structure</param>
        /// <returns>Returns a structure of the epxorted content [ConverterExportPackage]</returns>
        public ExportPackage Export(string pubFilePath, string xmlFilePath, string imagePath, SettingsCore settings)
        {
            Parser.Exporter exporter = new Parser.Exporter();
            exporter._onChange_Progress += exporter__onChange_Progress;
            return exporter.export(pubFilePath, xmlFilePath, imagePath, settings);
        }

        void exporter__onChange_Progress(int Maximum, int Current, string Message)
        {
            if (_onChange_Progress != null)
                _onChange_Progress(Maximum, Current, Message);
        }

        
        /// <summary>
        /// Creates a PDF of teh MS Publisher document
        /// </summary>
        /// <param name="pdfFilePath">The path where you will save the PDF file</param>
        /// <param name="pbDoc">The path to the MS Publisher document that you will export to PDF</param>
        private void ExportToPDF(string pdfFilePath, Microsoft.Office.Interop.Publisher.Document pbDoc)
        {
            pbDoc.ExportAsFixedFormat(
                PbFixedFormatType.pbFixedFormatTypePDF, 
                pdfFilePath, PbFixedFormatIntent.pbIntentPrinting, 
                true, 300, 450, 1200, 1800, 1, pbDoc.Pages.Count, 1, 
                false, PbPrintStyle.pbPrintStyleDefault, 
                false, false, false, System.Reflection.Missing.Value);
        }

    }
}
