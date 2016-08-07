using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace TTG1
{
    /// <summary>
    /// 
    /// </summary>
    public class XML
    {

        public XML()
                {

                }
        public XML(string xmlContents)
                {
                    ParseName(xmlContents);
                }
        public XML(string path, int showCount)
        {
            ParseShows(path, showCount);
        }

        public void ParseName(string contents)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(contents);
            XmlNode root = xDoc.SelectSingleNode("*");
            RecurseXML(root);
        }

        public void ParseShows(string contents, int count)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(contents);
            XmlNode root = xDoc.SelectSingleNode("*");
        }

        public  void RecurseXML(XmlNode rootNode)
        {
            if (rootNode is XmlElement)
            {
                GetName(rootNode);
                if (Tivo.curTivoName != null) return;
                if (rootNode.HasChildNodes)
                {
                    RecurseXML(rootNode.FirstChild);
                }
                if (rootNode.NextSibling != null)
                {
                    RecurseXML(rootNode.NextSibling);
                }
            }
            else if (rootNode is XmlText)
            {
                RecurseXML(rootNode.NextSibling);
            }
        }

        private void GetName(XmlNode node)
        {
            switch (node.Name)
            {
                case "TiVoContainer":
                    RecurseXML(node.FirstChild);
                    break;
                case  "Details":
                    RecurseXML(node.FirstChild);
                    break;
                case "ContentType":
                    RecurseXML(node.NextSibling);
                    break;
                case "SourceFormat":
                    RecurseXML(node.NextSibling);
                    break;
                case "Title":
                    Tivo.curTivoName = node.InnerText;
                    break;

                default:
                    Tivo.curTivoName = "Fell Through Switch";
                    break;
            }
        }
    }
}

