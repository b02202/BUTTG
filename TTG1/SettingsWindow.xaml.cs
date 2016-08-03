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
            //Load Variables from test boxes
            string ip = txtTivoIP.Text;
            string mak = txtTivoMAK.Text;
            //Get stream of data from TiVo
            string contents = Tivo.GetDetails(ip, mak);
            //Parse stream into XML - Setting XML.name in the process
            XML xmlClass = new XML(contents);
            //Change button text to indicate connection state
            btnTestTivo.Content = "Connected to: " + XML.name;
        }

        private void btnAddTivo_Click(object sender, RoutedEventArgs e)
        {
            //Load Variables from test boxes
            string ip = txtTivoIP.Text;
            string mak = txtTivoMAK.Text;
            string tivoName = txtTivoName.Text;
            //Get stream of data from TiVo
            string contents = Tivo.GetDetails(ip, mak);
            //Parse stream into XML - Setting XML.name in the process
            XML xmlClass = new XML(contents);
            //Here we need to add XML.name, tivoName, ip, mak to the ListView lstTivos
            //lstTivos.Items.Add(XML.name); //adds the string to all fields

            //lstTivos.Items.Add("Testing");

            // lstTivos.ItemsSource = new List<string> { "test 1", "Test 2", "Test3" };

            lstTivos.Items.Add(new TivoData()
            {
                Description = tivoName,
                Name = XML.name,
                IP = ip,
                MAK = mak
            });

            //lstTivos.SetValue(DataGridTextColumn);
            /////////////Try to pass a simple array into ListView
            //string[] row1 = { "s1", "s2", "s3" };
            //lstTivos.Items.Add("Column1Text").SubItems.AddRange(row1);  //does not like subitems!!!

            //////////////just monkeying around
            //ListViewItem item = new ListViewItem();
            //item.Name = (XML.name);
            //item.Content = ip;
            //lstTivos.Items.Add(item);
            //var item2 = new ListViewItem(new[] { "test" });

            ///////////////ListView code from stackoverflow..........Contructor issues?!?!?
            //ListViewItem newList = new ListViewItem(XML.name); //does not like any arguments
            //newList.SubItems.Add(tivoName); //again does not like the subitems 
            //newList.SubItems.Add(ip);
            //newList.SubItems.Add(mak);
            //lstTivos.Items.Add(newList);


        }

        private void lstTivos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    public class TivoData
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public string IP { get; set; }
        public string MAK { get; set; }
    }
}
