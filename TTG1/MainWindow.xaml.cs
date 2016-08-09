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
            //MenuItem myMenuItem = (MenuItem)sender;
            //txtOutput.Text = "You clicked a " + myMenuItem.GetType().Name + " named " + myMenuItem.Name;
            //txtOutput.Text = e.Source.ToString();


            //Set curTivo* config stuff temporarily for external access and no need to use Settings to configure
            Tivo.curTivoDesc = "My Test Tivo";
            Tivo.curTivoName = "Man Cave";
            Tivo.curTivoIP = "68.100.133.126";
            Tivo.curTivoMAK = "4822977039";
            //Make sure the XML.*COUNTS* are all zero'd
            XML.TotalItems = 0;
            XML.ShowCount = 0;
            XML.ItemCount = 0;
            //Get the info from the TV (IP, MAK, # of listings to get, # of offset to start listing)
            string xmlContent = Tivo.GetShowList(Tivo.curTivoIP, Tivo.curTivoMAK, 5, 0);
            //Parse the TotalItems count from XML and set the XML.TotalItems variable
            XML xmlClass = new XML(xmlContent, false);
            //Here I will need to start the logic to loop through as many sets of 50 results are nescessary 
            txtOutput.Text = "Total Items: " + XML.TotalItems + " Item Start: " + XML.ItemStart + " Item Count: " + XML.ItemCount;
            //Parse the Show List from XML and set the XML.TotalItems variable
            XML xmlClass2 = new XML(xmlContent, true);
            txtOutput.Text = "DONE  " + txtOutput.Text;



        }

        private void winMain_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
