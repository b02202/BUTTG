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
            RecurseName(root);
        }

        public void ParseShows(string contents, int count)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(contents);
            XmlNode root = xDoc.SelectSingleNode("*");
        }

        public  void RecurseName(XmlNode rootNode)
        {
            if (rootNode is XmlElement)
            {
                GetName(rootNode);
                if (Tivo.curTivoName != null) return;
                if (rootNode.HasChildNodes)
                {
                    RecurseName(rootNode.FirstChild);
                }
                if (rootNode.NextSibling != null)
                {
                    RecurseName(rootNode.NextSibling);
                }
            }
            else if (rootNode is XmlText)
            {
                RecurseName(rootNode.NextSibling);
            }
        }

        private void GetName(XmlNode node)
        {
            switch (node.Name)
            {
                case "TiVoContainer":
                    RecurseName(node.FirstChild);
                    break;
                case  "Details":
                    RecurseName(node.FirstChild);
                    break;
                case "ContentType":
                    RecurseName(node.NextSibling);
                    break;
                case "SourceFormat":
                    RecurseName(node.NextSibling);
                    break;
                case "Title":
                    Tivo.curTivoName = node.InnerText;
                    break;

                default:
                    Tivo.curTivoName = "Fell Through Switch";
                    break;
            }
        }

        public void RecurseCount(XmlNode rootNode)
        {
            if (rootNode is XmlElement)
            {
                GetCount(rootNode);
                if (Tivo.curTivoName != null) return;
                if (rootNode.HasChildNodes)
                {
                    RecurseCount(rootNode.FirstChild);
                }
                if (rootNode.NextSibling != null)
                {
                    RecurseCount(rootNode.NextSibling);
                }
            }
            else if (rootNode is XmlText)
            {
                RecurseCount(rootNode.NextSibling);
            }
        }

        private void GetCount(XmlNode node)
        {
            switch (node.Name)
            {
                case "TiVoContainer":
                    RecurseCount(node.FirstChild);
                    break;
                case "Details":
                    RecurseCount(node.FirstChild);
                    break;
                case "ContentType":
                    RecurseCount(node.NextSibling);
                    break;
                case "SourceFormat":
                    RecurseCount(node.NextSibling);
                    break;
                case "Title":
                    Tivo.curTivoName = node.InnerText;
                    break;

                default:
                    Tivo.curTivoName = "Fell Through Switch";
                    break;
            }
        }

        public void RecurseShows(XmlNode rootNode)
        {
            if (rootNode is XmlElement)
            {
                GetShows(rootNode);
                if (Tivo.curTivoName != null) return;
                if (rootNode.HasChildNodes)
                {
                    RecurseShows(rootNode.FirstChild);
                }
                if (rootNode.NextSibling != null)
                {
                    RecurseShows(rootNode.NextSibling);
                }
            }
            else if (rootNode is XmlText)
            {
                RecurseShows(rootNode.NextSibling);
            }
        }

        private void GetShows(XmlNode node)
        {
            switch (node.Name)
            {
                case "TiVoContainer":
                    RecurseShows(node.FirstChild);
                    break;
                case "Details":
                    RecurseShows(node.FirstChild);
                    break;
                case "ContentType":
                    RecurseShows(node.NextSibling);
                    break;
                case "SourceFormat":
                    RecurseShows(node.NextSibling);
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

