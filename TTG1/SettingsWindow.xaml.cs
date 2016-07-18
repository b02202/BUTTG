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
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            Window WinSet = new SettingsWindow();
            this.Close();
        }

        private void btnTestTivo_Click(object sender, RoutedEventArgs e)
        {
            string ip = txtTivoIP.Text;
            string mak = txtTivoMAK.Text;
            string contents = Tivo.GetDetails(ip, mak);
            string TivoName = XML.ParseName(contents);
            btnTestTivo.Content = "Connected to: " + TivoName;






        }

        private void btnAddTivo_Click(object sender, RoutedEventArgs e)
        {
            string ip = txtTivoIP.Text;
            string mak = txtTivoMAK.Text;
            string path = Tivo.GetDetails(ip, mak);
            
        }
    }
}
