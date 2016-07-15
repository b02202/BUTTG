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
            //MenuItem myMenuItem = (MenuItem)sender;
            //string name = myMenuItem.Name;
            //string type = myMenuItem.GetType().Name;
            //txtOutput.Text = "You clicked a " + type + " named " + name;

            Window WinSet = new SettingsWindow();
            WinSet.Show();
            
           

        }

        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {
            Window WinSet = new MainWindow();
            this.Close();
        }
    }
}
