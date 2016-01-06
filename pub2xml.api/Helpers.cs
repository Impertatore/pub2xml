using Microsoft.Office.Interop.Publisher;
using pub2xml.api.Structures.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pub2xml.api
{
    public class Helpers
    {
        internal static Microsoft.Office.Core.MsoTriState getMSFontState(TextRange tr, FontFormatTag fontFormatTag)
        {

            switch (fontFormatTag.formatType)
            {
                case FormattedRange.FormatType.Bold: return tr.Font.Bold;
                case FormattedRange.FormatType.Italic: return tr.Font.Italic;
                case FormattedRange.FormatType.SubScript: return tr.Font.SubScript;
                case FormattedRange.FormatType.SuperScript: return tr.Font.SuperScript;
                case FormattedRange.FormatType.StrikeThrough: return tr.Font.StrikeThrough;
            }

            return Microsoft.Office.Core.MsoTriState.msoFalse;
        }
    }
}
