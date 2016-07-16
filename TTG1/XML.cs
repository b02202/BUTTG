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
        public static string ParseDetails(string path)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"c:\temp\details2.xml");
            XmlNode root = xDoc.SelectSingleNode("*");
            ReadXML(root);

            XmlDocument xD = new XmlDocument();
            string details = "";
            return details;


            //////////Testing XmlNodeList, commented to test XmlElemet instead
            //XmlNodeList xNode = xDoc.GetElementsByTagName("Item");
            //Console.WriteLine("There are " + xNode.Count + " Items");
            //Console.WriteLine("Enumerators: " + xNode.GetEnumerator().ToString());
            //int i = 1;
            //while (xNode.Count > i)
            //{

            //    Console.WriteLine(xNode. xNode.Item(i).ChildNodes.Count;
            //    i++;
            //}


            /////////Testing XmlElemt, Commenting to work on Dictinary
            //XmlElement root = xDoc.DocumentElement;
            //XmlNodeList elemList = root.GetElementsByTagName("Title");
            //IEnumerator ienum = elemList.GetEnumerator();
            //while (ienum.MoveNext())
            //{
            //    XmlNode title = (XmlNode)ienum.Current;
            //    Console.WriteLine(title.InnerText);
            //}

            //var results = from q in TivoInfo2.Descendants("Item")
            //              select new
            //              {
            //                  Title = q.Element("Title").Value,
            //                  Episode = q.Element("EpisodeTitle").Value
            //              };
            //foreach (var item in results)
            //{
            //    Console.WriteLine("Title: {0}, Epsode: {1}", item.Title, item.Episode);
            //}

        }

        public static void ReadXML(XmlNode root)
        {
            if (root is XmlElement)
            {
                Console.WriteLine("Current Root Namne: " + root.Name + " = " + root.InnerText);
                //Console.WriteLine("Value: " + root.Attributes[root.Name].Value);
                DoWork(root);

                if (root.HasChildNodes)
                {
                 //   Console.WriteLine("Get Child");
                    ReadXML(root.FirstChild);
                }
                if (root.NextSibling != null)
                {
                 //   Console.WriteLine("Get Sibling");
                    ReadXML(root.NextSibling);
                }
            }
            else if (root is XmlText)
            { }
            else if (root is XmlComment)
            { }
        }

        private static void DoWork(XmlNode node)
        {
            //if (node.Name == "TiVoContainer")
            //{
            //    Console.WriteLine("Found Root TiVoContainer");
            //    ReadXML(node.NextSibling);
            //}
            //if (node.Name == "Details" && node.LastChild.ToString() == "/NowPlaying")
            //{
            //    Console.WriteLine("Found Details - Now Playing");
            //    ReadXML(node.NextSibling);
            //}

            //if (node.Attributes["Title"] != null)
            //{
            //    Console.WriteLine("Title: " + node.ParentNode.ParentNode.Attributes["Title"].Value);
            //    Console.WriteLine("Episode Title: " + node.ParentNode.ParentNode.Attributes["EpisodeTitle"].Value);
            //    Console.WriteLine(".....");
            //}

            switch (node.Name)
            {
                case "TiVoContainer":
                    Console.WriteLine("Node Name: "+ node.Name);
                    ReadXML(node.NextSibling);
                    break;
                case "Details":
                    //Console.WriteLine("Node Name: " + node.Name);
                    if (node.HasChildNodes)
                    {
                        //Console.WriteLine("First Child Node: " + node.FirstChild.Name);
                     //   Console.WriteLine(node.InnerText);
                        
                    }
                    ReadXML(node.NextSibling);
                    break;

                default:
                    break;
            }

        }
    }
}

