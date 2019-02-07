using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DesignPatternsLib.API
{
    public static class Keys
    {
        public static string KeysXml = @"Path_to_Keys.xml";

        public static string GoogleGeocoding
        {
            get
            {
                try
                {
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.Load(KeysXml);
                    string apiKey = xdoc.GetElementsByTagName("GoogleGeocoding").Item(0).InnerText;
                    return apiKey;
                }
                catch (Exception e)
                {
                    return "Error: " + e.Message;
                }
            }
        }
        public static string OpenWeatherMap
        {
            get
            {
                try
                {

                    XmlDocument xdoc = new XmlDocument();
                    xdoc.Load(KeysXml);
                    string apiKey = xdoc.GetElementsByTagName("OpenWeatherMap").Item(0).InnerText;
                    return apiKey;
                }
                catch (Exception e)
                {
                    return "Error: " + e.Message;
                }
            }
        }
    }
}
