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
        public void Config_Machine(object sender, RoutedEventArgs e)
        {
            ConfigWindow conf = new ConfigWindow();

            Starter.IsEnabled = false;
            Config.IsEnabled = false;
            TextBlock.Text = "Aparatul este in curs de configurare.";
            Coins.wasconfigured = true;

            conf.ShowDialog();

            TextBlock.Height = 72;
            TextBlock.Text = $"Aparatul a fost reconfigurat. {Environment.NewLine}Apasati butonul pentru a porni aparatul:";
            ConfigSteps.CheckConfig();
            if (ConfigSteps.badconfig)
            {
                MessageBox.Show($"Aparatul nu a fost reconfigurat corespunzator.{Environment.NewLine}Daca porniti aparatul, v-a rula cu setari implicite.");
                TextBlock.Text = $"Aparatul s-a resetat la setari implicite. {Environment.NewLine}Apasati butonul pentru a porni aparatul:";
            }
            Starter.IsEnabled = true;
            Config.IsEnabled = true;
            
        }

        public void Start_Machine(object sender, RoutedEventArgs e)
        {
            if (!Coins.wasconfigured)
            {
                AparatMain win = new AparatMain();

                Starter.IsEnabled = false;
                TextBlock.Height = 37;
                TextBlock.Text = "Aparatul functioneaza.";

                win.ShowDialog();

                TextBlock.Text = "Aparatul s-a oprit, pentru a-l reporni apasati butonul:";
                Starter.IsEnabled = true;
            }
            else
            {
                
            }
        }
    }
}
