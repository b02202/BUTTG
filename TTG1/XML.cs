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
    public static class XML
    {

        
public static string ParseName(string contents)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(contents);
            XmlNode root = xDoc.SelectSingleNode("*");
            string name = RecurseXML(root);
            return name;


            //switch (root.Name)
            //{
            //    case "TiVoContainer":
            //        Console.WriteLine("root Name: " + root.Name);
            //        RecurseXML(root.FirstChild);
            //        break;
            //    case "Details":
            //        if (root.HasChildNodes)
            //        {
            //            Console.WriteLine("root Name: " + root.Name);
            //            RecurseXML(root.FirstChild);
            //        }
            //        break;
            //    case "ContentType":
            //        Console.WriteLine("root Name: " + root.Name);
            //        RecurseXML(root.NextSibling);
            //        break;
            //    case "SourceFormat":
            //        Console.WriteLine("root Name: " + root.Name);
            //        RecurseXML(root.NextSibling);
            //        break;
            //    case "Title":
            //        Console.WriteLine("root Name: " + root.Name);
            //        string name = root.InnerText;
            //        return name;
            //    default:
            //        break;
            //}
            //if (root.HasChildNodes)
            //{
            //    Console.WriteLine("Get Child");
            //    RecurseXML(root.FirstChild);
            //}
            //if (root.NextSibling != null)
            //{
            //    Console.WriteLine("Get Sibling");
            //    RecurseXML(root.NextSibling);
            //}
            //string def = "FT-ParseName";
            //return def;
        }

        public static string ParseDetails(string contents)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(contents);
            XmlNode root = xDoc.SelectSingleNode("*");



            string details = "";
            return details;
        }

        public static string RecurseXML(XmlNode rootNode)
        {

            
            if (rootNode is XmlElement)
            {
                //Console.WriteLine("Current Root Namne: " + rootNode.Name + " = " + rootNode.InnerText);
                string name = GetName(rootNode);
                if (name != null)
                {
                    return name;
                }

                if (rootNode.HasChildNodes)
                {
                 //   Console.WriteLine("Get Child");
                    RecurseXML(rootNode.FirstChild);
                }
                if (rootNode.NextSibling != null)
                {
                 //   Console.WriteLine("Get Sibling");
                    RecurseXML(rootNode.NextSibling);
                }
            }
            else if (rootNode is XmlText)
            {
                RecurseXML(rootNode.NextSibling);
            }
            else if (rootNode is XmlComment)
            { }
            //string def = "FT-RecurseXML";      /////is this really what we are returning
            return "didn't work";

        }

        private static string GetName(XmlNode node)
        {
            string named;
            if (node.Name != "Title")
            {
                if (node.HasChildNodes && node.FirstChild.Name == "Details")
                {
                    //   Console.WriteLine("Get Child");
                    RecurseXML(node.FirstChild);
                }
                else if (node.Name == "Details")
                {
                    RecurseXML(node.FirstChild);
                }
                else if (node.Name == "ContentType")
                {
                    RecurseXML(node.NextSibling);
                }
                else if (node.Name == "SourceFormat")
                {
                    RecurseXML(node.NextSibling);
                }
                //if (node.NextSibling == null)
                //{
                //    //   Console.WriteLine("Get Sibling");
                //    name = "Did NOT Connect";
                //}
            }
            if (node.Name=="Title")
            {
                named = node.InnerText;
                return named;
            }
            return "WHY??";
            //if (node.Name == "TiVoContainer")
            //{
            //    Console.WriteLine("Node Name: " + node.Name + " getting First Child: " + node.FirstChild.Name);
            //    RecurseXML(node.FirstChild);
            //}
            //else if (node.Name == "Details")
            //{
            //    Console.WriteLine("Node Name: " + node.Name + " getting First Child: " + node.FirstChild.Name);
            //    RecurseXML(node.NextSibling);
            //}
            //else if (node.Name == "ContentType")
            //{
            //    Console.WriteLine("Node Name: "+ node.Name + " getting Next Sibling: " + node.NextSibling.Name);
            //    RecurseXML(node.NextSibling);
            //}




            //case "TiVoContainer":
            //Console.WriteLine("TiVo Container, getting Next Sibling:" + node.NextSibling);
            //RecurseXML(node.NextSibling);
            //    break;
            //case "Details":
            //    Console.WriteLine("Node Name: " + node.Name);
            //    if (node.HasChildNodes)
            //    {
            //        RecurseXML(node.FirstChild);
            //    }
            //    break;
            //case "ContentType":
            //    Console.WriteLine("Node Name: " + node.Name);
            //    RecurseXML(node.NextSibling);
            //    break;
            //case "SourceFormat":
            //    Console.WriteLine("Node Name: " + node.Name);
            //    RecurseXML(node.NextSibling);
            //    break;
            //case "Title":
            //    Console.WriteLine("Node Name: " + node.Name);
            //    name = node.InnerText;
            //    return name;
            //default:

        }
    }
}

