using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;
using System.Xml;

namespace TTG1
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
            if (Tivo.curTivoName != null)
            {
                lstTivos.Items.Add(new TivoSettings()
                {
                    Description = Tivo.curTivoDesc,
                    Name = Tivo.curTivoName,
                    IP = Tivo.curTivoIP,
                    MAK = Tivo.curTivoMAK
                });

            }
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            Window WinSet = new SettingsWindow();
            this.Close();
        }

        private void btnTestTivo_Click(object sender, RoutedEventArgs e)
        {
            //Load Variables from test boxes
            Tivo.curTivoIP = txtTivoIP.Text;
            Tivo.curTivoMAK = txtTivoMAK.Text;
            //Get stream of data from TiVo
            string contents = Tivo.GetDetails(Tivo.curTivoIP, Tivo.curTivoMAK);
            //Parse stream into XML - Setting XML.name in the process
            XML xmlClass = new XML(contents);
            //Change button text to indicate connection state
            btnTestTivo.Content = "Connected to: " + Tivo.curTivoName;
        }

        private void btnAddTivo_Click(object sender, RoutedEventArgs e)
        {
            //Load Variables from test boxes
            Tivo.curTivoIP = txtTivoIP.Text;
            Tivo.curTivoMAK = txtTivoMAK.Text;
            Tivo.curTivoDesc = txtTivoDesc.Text;
            //Get stream of data from TiVo
            string contents = Tivo.GetDetails(Tivo.curTivoIP, Tivo.curTivoMAK);
            //Parse stream into XML - Setting XML.name in the process
            XML xmlClass = new XML(contents);
            //Here we need to add XML.name, tivoName, ip, mak to the ListView lstTivos
            lstTivos.Items.Add(new TivoSettings()
            {
                Description = Tivo.curTivoDesc,
                Name = Tivo.curTivoName,
                IP = Tivo.curTivoIP,
                MAK = Tivo.curTivoMAK
            });
        }

        private void lstTivos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    public class TivoSettings
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public string IP { get; set; }
        public string MAK { get; set; }
    }
}
