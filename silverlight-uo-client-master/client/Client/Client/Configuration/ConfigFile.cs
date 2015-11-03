using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Xml;
using System.Xml.Linq;

using Client.Diagnostics;
using Client.IO;

namespace Client.Configuration
{
    public class ConfigFile
    {
        private static object _syncRoot = new object();

        private readonly string _filename;
        private readonly Dictionary<string, Dictionary<string, string>> _sections;

        public bool Exists { get { return File.Exists(_filename); } }

        public ConfigFile(string filename)
        {
            _filename = filename;
            _sections = new Dictionary<string, Dictionary<string, string>>();

            if (Exists)
            {
                LoadSettings();
            }
        }

        private void LoadSettings()
        {
            Tracer.Info("Loading configuration...");

            _sections.Clear();

            try
            {
                if (!Application.Current.IsRunningOutOfBrowser)
                    return;

                lock (_syncRoot)
                {
                    using (Stream stream = File.Open(Paths.ConfigFile, FileMode.Open))
                    {
                        XDocument document = XDocument.Load(stream);

                        foreach (XElement section in document.Root.Descendants("section"))
                        {
                            try
                            {
                                Dictionary<string, string> sectionTable = new Dictionary<string, string>();
                                _sections.Add(section.Attribute("name").Value, sectionTable);

                                foreach (XElement element in section.DescendantNodes())
                                {
                                    try
                                    {
                                        sectionTable.Add(element.Attribute("name").Value, element.Attribute("value").Value);
                                    }
                                    catch (Exception e)
                                    {
                                        Tracer.Error(e);
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                Tracer.Error(e);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Tracer.Error(e);
            }
        }

        private void SaveSettings()
        {
            try
            {
                //FileSystemHelper.EnsureDirectoryExists(Paths.StorageFolder);
                XmlWriterSettings settings = new XmlWriterSettings();

                settings.CheckCharacters = false;
                settings.CloseOutput = true;
                settings.Encoding = Encoding.UTF8;
                settings.Indent = true;
                settings.NewLineHandling = NewLineHandling.Entitize;

                XDocument document = new XDocument();
                document.Add(new XElement("configuration"));

                XElement configuration = document.Element("configuration");

                foreach (var section in _sections)
                {
                    XElement xSection = new XElement("section", new XAttribute("name", section.Key));

                    foreach (var setting in section.Value)
                    {
                        xSection.Add(
                            new XElement("setting",
                                new XAttribute("name", setting.Key),
                                new XAttribute("value", setting.Value)));
                    }

                    configuration.Add(xSection);
                }

                if (Application.Current.IsRunningOutOfBrowser)
                {
                    lock (_syncRoot)
                    {
                        using (Stream stream = File.Open(Paths.ConfigFile, FileMode.Create))
                            document.Save(stream);
                    }
                }
            }
            catch (Exception e)
            {
                Tracer.Error(e);
            }
        }

        public void SetValue<T>(string section, string key, T value)
        {
            Dictionary<string, string> sectionTable;

            if (!_sections.TryGetValue(section, out sectionTable))
            {
                sectionTable = new Dictionary<string, string>();
                _sections.Add(section, sectionTable);
            }

            if (sectionTable.ContainsKey(key))
                sectionTable[key] = value.ToString();
            else
                sectionTable.Add(key, value.ToString());

            SaveSettings();
        }

        public T GetValue<T>(string section, string key)
        {
            return GetValue(section, key, default(T));
        }

        public T GetValue<T>(string section, string key, T defaultValue)
        {
            if (!_sections.ContainsKey(section))
                return defaultValue;

            Dictionary<string, string> sectionTable = _sections[section];

            return !sectionTable.ContainsKey(key) ? defaultValue : sectionTable[key].ConvertTo<T>();
        }
    }
}
