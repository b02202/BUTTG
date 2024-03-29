﻿using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace TTG1
{
    public static class Tivo

    {

        public static string GetShowList(string TivoAddress, string Password)
        {
            return GetContent(new Uri("https://" + TivoAddress + "/TiVoConnect?Command=QueryContainer&Container=/NowPlaying&Recurse=Yes&ItemCount=32&AnchorOffset="), "tivo", Password);
        }

        public static string GetDetails(string TivoAddress, string Password)
        {
            return GetContent(new Uri("https://" + TivoAddress + "/TiVoConnect?AnchorOffset=0&Command=QueryContainer&Details=All&ItemCount=1"), "tivo", Password);
            
        }


        private static string GetContent(Uri TivoURL, string UserName, string Password)
        {
            WebClient Client = new WebClient();
            StreamReader Reader = null;
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(IgnoreCertErrorsCallback);
            Client.Credentials = new NetworkCredential(UserName, Password);
            Reader = new StreamReader(Client.OpenRead(TivoURL));
            string contents = Reader.ReadToEnd();
            XDocument testDoc = new XDocument();
            testDoc = XDocument.Parse(contents);
           // XmlSerializer xs = new XmlSerializer(testDoc, testDoc.Root);
           // XDocument tivoDetail = XDocument.Parse(contents);
            var results = from q in testDoc.Descendants("Details")
                          select new
                          {
                              Title = (string)q.Attribute("Title").Value,
                              Episode = (string)q.Attribute("EpisodeTitle").Value
                          };
            foreach (var item in results)
            {
                Console.WriteLine("Title: {0}, Epsode: {1}", item.Title, item.Episode);
            }


            string path = @"c:\temp\details.xml";
           // tivoDetail.Save(path);
            return path;
            //return contents;
        }

        private static bool IgnoreCertErrorsCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

    }

}
