using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace vendingmachinewpf
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

        public void Start_Machine(object sender, RoutedEventArgs e)
        {
            Window1 win = new Window1();
            
            Starter.IsEnabled = false;
            TextBlock.Text = "Aparatul functioneaza.";

            win.ShowDialog();

            TextBlock.Text = "Aparatul s-a oprit, pentru a-l reporni apasati butonul:";
            Starter.IsEnabled = true;


        }
    }
}
