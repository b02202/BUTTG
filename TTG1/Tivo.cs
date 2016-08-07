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
    public class Tivo

    {
        public static string curTivoName { get; set; }
        public static string curTivoIP { get; set; }
        public static string curTivoMAK { get; set; }
        public static string curTivoDesc { get; set; }



        public static string GetShowList(string TivoAddress, string Password, int Count, int Offset)
        {
            if (Offset == 0)
            {
                return GetContent(new Uri("https://" + TivoAddress + "/TiVoConnect?Command=QueryContainer&Container=/NowPlaying&Recurse=Yes&ItemCount=" + Count.ToString() + "&AnchorOffset="), "tivo", Password);
            }
            else
            {
                return GetContent(new Uri("https://" + TivoAddress + "/TiVoConnect?Command=QueryContainer&Container=/NowPlaying&Recurse=Yes&ItemCount=" + Count.ToString() + "&AnchorOffset=" + Offset.ToString()), "tivo", Password);
            }
        }

        public static string GetDetails(string TivoAddress, string Password)
        {
            return GetContent(new Uri("https://" + TivoAddress + "/TiVoConnect?AnchorOffset=0&Command=QueryContainer&Details=All&ItemCount=0"), "tivo", Password);
            
        }


        private static string GetContent(Uri TivoURL, string UserName, string Password)
        {
            WebClient Client = new WebClient();
            StreamReader Reader = null;
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(IgnoreCertErrorsCallback);
            Client.Credentials = new NetworkCredential(UserName, Password);
            Reader = new StreamReader(Client.OpenRead(TivoURL));
            string contents = Reader.ReadToEnd();
            return contents;
        }

        private static bool IgnoreCertErrorsCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

    }

}