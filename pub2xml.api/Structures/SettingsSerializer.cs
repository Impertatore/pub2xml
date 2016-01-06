using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;
using System.Globalization;
using pub2xml.api.Structures.Core;

namespace pub2xml.api
{
    public class SettingsSerializer
    {
        #region  |  settings serialization  |

        /// <summary>
        /// Save the settings
        /// </summary>
        /// <param name="settings">setting serialized from the caller</param>
        public static void SaveSettings(SettingsCore settings)
        {
            XmlSerializer serializer = null;
            FileStream stream = null;
            try
            {
                serializer = new XmlSerializer(typeof(SettingsCore));
                stream = new FileStream(settings.ApplicationSettingsFullPath, FileMode.Create, FileAccess.Write);
                serializer.Serialize(stream, settings);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }

        /// <summary>
        /// Read in the settings the default location or from the file specified by the user
        /// </summary>
        /// <param name="settingFileFullPath">if file exists, then read/save the settings from this location</param>
        /// <returns>The settings serialzied from the file</returns>
        public static SettingsCore ReadSettings(string settingFileFullPath = null)
        {
            SettingsCore settings = new SettingsCore();

            // if the users provided setting file exists, then set the path info
            if (File.Exists(settingFileFullPath))
            {
                settings.ApplicationSettingsFullPath = settingFileFullPath;
                settings.ApplicationSettingsPath = Path.GetDirectoryName(settingFileFullPath);
            }
            else if (!File.Exists(settings.ApplicationSettingsFullPath))
                // if the first time, then create the settings file in the default location
                SaveSettings(settings);



            XmlSerializer serializer = null;
            FileStream stream = null;
            try
            {
                serializer = new XmlSerializer(typeof(SettingsCore));
                stream = new FileStream(settings.ApplicationSettingsFullPath, FileMode.Open);
                settings = (SettingsCore)serializer.Deserialize(stream);

                if (settings == null)
                    settings = new SettingsCore();


                #region  |  preset the setting with some defalut settings for VTS and FFT  |
                if (settings.PseudoTranslateItems == null || settings.PseudoTranslateItems.Count == 0)
                    settings.PseudoTranslateItems = new List<PseudoTranslateItem>
                    {
                        new PseudoTranslateItem{ FindWhat = "a", ReplaceWith= "%"},
                        new PseudoTranslateItem{ FindWhat = "e", ReplaceWith= "%"},
                        new PseudoTranslateItem{ FindWhat = "i", ReplaceWith= "%"},
                        new PseudoTranslateItem{ FindWhat = "o", ReplaceWith= "%"},
                        new PseudoTranslateItem{ FindWhat = "u", ReplaceWith= "%"},
                        new PseudoTranslateItem{ FindWhat = "A", ReplaceWith= "$"},
                        new PseudoTranslateItem{ FindWhat = "E", ReplaceWith= "$"},
                        new PseudoTranslateItem{ FindWhat = "I", ReplaceWith= "$"},
                        new PseudoTranslateItem{ FindWhat = "O", ReplaceWith= "$"},
                        new PseudoTranslateItem{ FindWhat = "U", ReplaceWith= "$"}                
                    };

                if (settings.FontFormatTags == null || settings.FontFormatTags.Count == 0)
                    settings.FontFormatTags = new List<FontFormatTag>
                    {
                        new FontFormatTag{ name="b", formatType = FormattedRange.FormatType.Bold, regexContent = "|.*?" },
                        new FontFormatTag{ name="i", formatType = FormattedRange.FormatType.Italic, regexContent = "|.*?" },
                        new FontFormatTag{ name="del", formatType = FormattedRange.FormatType.StrikeThrough, regexContent = "|.*?" },
                        new FontFormatTag{ name="sup", formatType = FormattedRange.FormatType.SuperScript, regexContent = "|.*?" },               
                        new FontFormatTag{ name="sub", formatType = FormattedRange.FormatType.SubScript, regexContent = "|.*?" },
                    };

                #endregion

                return settings;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }

        #endregion
    }
}
