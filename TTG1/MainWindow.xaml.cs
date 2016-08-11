using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;



namespace TTG1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void mnuSettings_Click(object sender, RoutedEventArgs e)
        {

            Window WinSet = new SettingsWindow();
            WinSet.Show();
        }

        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {
            Window WinSet = new MainWindow();
            Application.Current.Shutdown();
        }

        private void mnuTivos_Click(object sender, RoutedEventArgs e)
        {
            if (listShows.HasItems)
            {
                listShows.Items.Clear();
            }
            //Set curTivo* config stuff temporarily for external access and no need to use Settings to configure
            Tivo.curTivoDesc = "My Test Tivo";
            Tivo.curTivoName = "Man Cave";
            Tivo.curTivoIP = "68.100.133.126";
            Tivo.curTivoMAK = "4822977039";
            //Make sure the XML.*COUNTS* are all zero'd
            XML.TotalItems = 0;
            XML.ShowCount = 0;
            XML.ItemCount = 0;
            XML.LoopCount = 0;
            //Get the info from the TiVo (IP, MAK, # of listings to get, # of offset to start listing)
            string xmlDetails = Tivo.GetShowList(Tivo.curTivoIP, Tivo.curTivoMAK, 32, 0);
            //Parse the TotalItems count from XML and set the XML.TotalItems variable
            XML xmlClass = new XML(xmlDetails, false);
            //Here I will need to start the logic to loop through as many sets of 50 results are nescessary 
            txtOutput.Text = "Total Items: " + XML.TotalItems + " Item Start: " + XML.ItemStart + " Item Count: " + XML.ItemCount;
            //Parse the Show List from XML and set the XML.TotalItems variable
            while (XML.TotalItems > XML.ShowCount)
                {
                    string xmlShows = Tivo.GetShowList(Tivo.curTivoIP, Tivo.curTivoMAK, 32, XML.ShowCount);
                    XML.LoopCount = 0;
                    XML xmlClass2 = new XML(xmlShows, true);
                };
            txtOutput.Text = "DONE  " + txtOutput.Text;
            ///Here I wouls like to iterate through the ListView and change rows to different colors based on content


        }

        private void winMain_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
