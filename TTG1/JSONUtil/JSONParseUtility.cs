using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TTG1.JSONUtil
{
    class JSONParseUtility
    {

        public static string JSONText { get; set; }
        public static XmlDocument XMLDoc { get; set; }

        // Default Constructor only invokes object initializer processing - NO PARAMS
        public JSONParseUtility()
        {

        }
        // Class Constructor used for XML Parse
        public JSONParseUtility(XmlDocument xmlDoc)
        {
            XMLDoc = xmlDoc;
            ParseJSON(XMLDoc);
        }

        public void ParseJSON(XmlDocument xmlDoc)
        {

            try
            {
                // Convert XML To JSON
                string jsonText = JsonConvert.SerializeXmlNode(xmlDoc);

                if (!String.IsNullOrEmpty(jsonText))
                {
                    JSONText = jsonText;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: {0}", ex.ToString());
            }

        }

       






    }
}
