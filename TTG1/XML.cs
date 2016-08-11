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
    public class ShowData
    {
        public string Title { get; set; }
        public string EpisodeTitle { get; set; }
        public string SeasonNumber { get; set; }
        public string EpisodeNumber { get; set; }
        public string ShowingStartTime { get; set; }
        public string Duration { get; set; }
        public string SourceSize { get; set; }
        public string SourceChannel { get; set; }
        public string SourceStation { get; set; }
        public string InProgress { get; set; }
        public string StreamingPermission { get; set; }
        public string Description { get; set; }
        public string TSURL { get; set; }
        public string XMLURL { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class XML
    {
        public static string title { get; set; }
        public static string episodeTitle { get; set; }
        public static string seasonNumber { get; set; }
        public static string episodeNumber { get; set; }
        public static string showingStartTime { get; set; }
        public static string duration { get; set; }
        public static string sourceSize { get; set; }
        public static string sourceChannel { get; set; }
        public static string sourceStation { get; set; }
        public static string inProgress { get; set; }
        public static string streamingPermission { get; set; }
        public static string description { get; set; }
        public static string tSURL { get; set; }
        public static string xMLURL { get; set; }
        public static int ShowCount { get; set; }
        public static int TotalItems { get; set; }
        public static int ItemCount { get; set; }
        public static int ItemStart { get; set; }
        public static int LoopCount { get; set; }
        List<ShowData> shows = new List<ShowData>();
        public XML()
                {

                }
        public XML(string xmlContents)
                {
                    ParseName(xmlContents);
                }
        public XML(string xmlContents, bool shows)
        {
            switch (shows)
            {
                case false:
                    ParseCount(xmlContents);
                    break;
                case true:
                    ParseShows(xmlContents);
                    break;
                default:
                    break;
            }
        }

        public void ParseName(string contents)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(contents);
            XmlNode root = xDoc.SelectSingleNode("*");
            
            RecurseName(root);
        }


        public void ParseCount(string contents)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(contents);
            XmlNode root = xDoc.SelectSingleNode("*");
            RecurseCount(root);
            
        }

        public void RecurseName(XmlNode rootNode)
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
                if (TotalItems > 0 && ItemCount > 0) return;
                GetCount(rootNode);
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
                    RecurseCount(node.NextSibling);
                    break;
                case "LastChangeDate":
                    RecurseCount(node.NextSibling);
                    break;
                case "TotalItems":
                    TotalItems = Int32.Parse(node.InnerText) - 1;
                    RecurseCount(node.NextSibling);
                    break;
                case "UniqueId":
                    RecurseCount(node.ParentNode.NextSibling);
                    break;
                case "SortOrder":
                    RecurseCount(node.NextSibling);
                    break;
                case "GlobalSort":
                    RecurseCount(node.NextSibling);
                    break;
                case "ItemStart":
                    ItemStart = Int32.Parse(node.InnerText);
                    RecurseCount(node.NextSibling);
                    break;
                case "ItemCount":
                    ItemCount = Int32.Parse(node.InnerText);
                    RecurseCount(node.NextSibling);
                    break;
                default:
                    Tivo.curTivoName = "Fell Through Switch";
                    break;
            }
        }

        public void ParseShows(string contents)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(contents);
            XmlNode root = xDoc.SelectSingleNode("*");
            RecurseShows(root);
        }

        public void RecurseShows(XmlNode rootNode)
        {
            if (rootNode is XmlElement)
            {
                if (LoopCount == ItemCount) return;
                if (rootNode != null)
                {
                    GetShows(rootNode);
                    if (rootNode == null) return;
                }
                else
                {
                    return;
                }
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
                if (rootNode.NextSibling != null)
                {
                    RecurseShows(rootNode.NextSibling); 
                }
                else
                {
                    return;
                }
            }
        }

        private void GetShows(XmlNode node)
        {
            if (node == null) return;
            switch (node.Name)
            {
                case "TiVoContainer":
                    RecurseShows(node.FirstChild);
                    break;
                case "SortOrder":
                    RecurseShows(node.NextSibling);
                    break;
                case "GlobalSort":
                    RecurseShows(node.NextSibling);
                    break;
                case "ItemStart":
                    RecurseShows(node.NextSibling);
                    break;
                case "ItemCount":
                    ItemCount = Int32.Parse(node.InnerText);
                    RecurseShows(node.NextSibling);
                    break;
                case "Item":
                    RecurseShows(node.FirstChild);
                    break;
                case "Details":
                    if (node.ParentNode.Name != "Item")
                    {
                        RecurseShows(node.NextSibling);

                    }
                    if (node.ParentNode.Name == "Item")
                    {
                        RecurseShows(node.FirstChild);
                    }
                    break;
                case "ContentType":
                    RecurseShows(node.NextSibling);
                    break;
                case "SourceFormat":
                    RecurseShows(node.NextSibling);
                    break;
                case "Title":
                    title = node.InnerText;
                    RecurseShows(node.NextSibling);
                    break;
                case "EpisodeTitle":
                    episodeTitle = node.InnerText;
                    RecurseShows(node.NextSibling);
                    break;
                case "EpisodeNumber":
                    string en = node.InnerText;
                    switch (en.Count())
                    {
                        case 1:
                            seasonNumber = "00";
                            episodeNumber = "00";
                            break;
                        case 3:
                            seasonNumber = "0" + en.Substring(0, 1);
                            episodeNumber = en.Substring(1, 2);
                            break;
                        case 4:
                            seasonNumber = en.Substring(0, 2);
                            episodeNumber = en.Substring(2, 2);
                            break;
                        default:
                            break;
                    }
                    RecurseShows(node.NextSibling);
                    break;
                case "ShowingStartTime":
                    string sst = FD(node.InnerText);
                    showingStartTime = sst;
                    if (node.NextSibling.Name != "EpisodeTitle")
                    {
                        episodeTitle = "";

                    }
                    RecurseShows(node.NextSibling);
                    break;
                case "ShowingDuration":
                    //int sdi = Int32.Parse(node.InnerText) / 3600000;
                    //string sd = sdi.ToString("F1");
                    //showingDuration = sd + " Hrs";
                    RecurseShows(node.NextSibling);
                    break;
                case "SourceSize":
                    string ss = "";
                    Double ssl = Int64.Parse(node.InnerText) / 1048576;
                    if (ssl >= 1024)
                    {
                        ssl = ssl / 1024;
                        ss = ssl.ToString("F2") + " GB";
                    }
                    else
                    {
                        ss = ssl.ToString("F0") + " MB";
                    }

                    sourceSize = ss;
                    RecurseShows(node.NextSibling);
                    break;
                case "SourceChannel":
                    sourceChannel = node.InnerText;
                    RecurseShows(node.NextSibling);
                    break;
                case "SourceStation":
                    sourceStation = node.InnerText;
                    if (node.NextSibling.Name != "InProgress")
                    {
                        inProgress = "No";
                    }
                    RecurseShows(node.NextSibling);
                    break;
                case "InProgress":
                    inProgress = node.InnerText;
                    RecurseShows(node.NextSibling);
                    break;
                case "Description":
                    description = node.InnerText;
                    RecurseShows(node.NextSibling);
                    break;
                case "Duration":
                    TimeSpan t = TimeSpan.FromMilliseconds(Int64.Parse(node.InnerText));
                    duration = string.Format("{0:D2}h:{1:D2}m", t.Hours, t.Minutes);

                    RecurseShows(node.NextSibling);
                    break;
                case "CaptureDate":
                    RecurseShows(node.NextSibling);
                    break;
                case "StartPadding":
                    RecurseShows(node.NextSibling);
                    break;
                case "EndPadding":
                    RecurseShows(node.NextSibling);
                    break;
                case "HighDefinition":
                    RecurseShows(node.NextSibling);
                    break;
                case "ProgramId":
                    RecurseShows(node.NextSibling);
                    break;
                case "SeriesId":
                    if (node.NextSibling.InnerText != "EpisodeNumber")
                    {
                        seasonNumber = "";
                        episodeNumber = "";
                    }
                    RecurseShows(node.NextSibling);
                    break;
                case "ByteOffset":
                    RecurseShows(node.NextSibling);
                    break;
                case "RecordingQuality":
                    RecurseShows(node.NextSibling);
                    break;
                case "StreamingPermission":
                    streamingPermission = node.InnerText;
                    RecurseShows(node.NextSibling);
                    break;
                case "TvRating":
                    RecurseShows(node.NextSibling);
                    break;
                case "ShowingBits":
                    RecurseShows(node.NextSibling);
                    break;
                case "SourceType":
                    RecurseShows(node.NextSibling);
                    break;
                case "PausePointTime":
                    RecurseShows(node.NextSibling);
                    break;
                case "IdGuideSource":
                    RecurseShows(node.ParentNode.NextSibling);
                    break;
                case "Content":
                    if (node.FirstChild.Name == "Url")
                    {
                        tSURL = node.FirstChild.InnerText;
                    }
                    if (node.NextSibling.Name == "TiVoVideoDetails")
                    {
                        xMLURL = node.NextSibling.FirstChild.InnerText;
                    }
                    if (node.NextSibling.Name == "CustomIcon")
                    {
                        if (node.NextSibling.NextSibling.Name == "TiVoVideoDetails")
                        {
                            xMLURL = node.NextSibling.NextSibling.FirstChild.InnerText;
                        }
                    }

                    ///Pushing data into a List
                    //shows.Add(new ShowData()
                    //{
                    //    Title = title,
                    //    EpisodeTitle = episodeTitle,
                    //    SeasonNumber = seasonNumber,
                    //    EpisodeNumber = episodeNumber,
                    //    Description = description,
                    //    ShowingStartTime = showingStartTime,
                    //    Duration = duration,
                    //    SourceSize = sourceSize,
                    //    SourceChannel = sourceChannel,
                    //    SourceStation = sourceStation,
                    //    InProgress = inProgress,
                    //    StreamingPermission = streamingPermission,
                    //    TSURL = tSURL,
                    //    XMLURL = xMLURL
                    //});

                    ///Pushing data directly into the ListView 
                    ((MainWindow)System.Windows.Application.Current.MainWindow).listShows.Items.Add(new ShowData()
                    {
                        Title = title,
                        EpisodeTitle = episodeTitle,
                        SeasonNumber = seasonNumber,
                        EpisodeNumber = episodeNumber,
                        Description = description,
                        ShowingStartTime = showingStartTime,
                        Duration = duration,
                        SourceSize = sourceSize,
                        SourceChannel = sourceChannel,
                        SourceStation = sourceStation,
                        InProgress = inProgress,
                        StreamingPermission = streamingPermission,
                        TSURL = tSURL,
                        XMLURL = xMLURL
                    });
                    ShowCount++;
                    LoopCount++;
                    if (node.ParentNode.ParentNode.NextSibling == null)
                    {
                        return;
                    }
                    else
                    {
                        RecurseShows(node.ParentNode.ParentNode.NextSibling.FirstChild);
                    }
                    
                    break;
                default:
                    Tivo.curTivoName = "Fell Through Switch";
                    break;
            }
        }
        public static string FD(string XMLDate)
        {
            string HexDate = XMLDate.Substring(2, 8);
            Console.WriteLine(HexDate);
            int epoch = Convert.ToInt32(HexDate, 16);
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(epoch).ToLocalTime();
            return dtDateTime.ToString();
        }

    }
}

