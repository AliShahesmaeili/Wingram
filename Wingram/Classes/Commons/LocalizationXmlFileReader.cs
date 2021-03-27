using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Wingram.Classes.Models;

namespace Wingram.Classes.Commons
{
    public class LocalizationXmlFileReader
    {
        public static Dictionary<string, LocalizationModel> GetEntries(string path)
        {
            var entries = new Dictionary<string, LocalizationModel>();
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(path);
            foreach (XmlNode xmlNode in xmlDocument.SelectNodes("//string"))
            {
                entries.Add(xmlNode.Attributes?["name"].Value, new LocalizationModel() { Value = xmlNode.InnerText.Trim() });
            }

            return entries;
        }
    }
}
