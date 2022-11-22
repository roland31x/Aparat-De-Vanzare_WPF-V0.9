using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace vendingmachinewpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AparatMain : Window
    {
        Aparat vending = new Aparat();
        public AparatMain()
        {
            InitializeComponent();
            CoinsConfig.Type.Defaults();
            vending.Work();
            UpdateUI();
        }
        private async void Insert_Quarter(object sender, RoutedEventArgs e)
        {
            await ClearLog();
            vending.Handle(25);
            UpdateUI();
        }

        private async void Insert_Dime(object sender, RoutedEventArgs e)
        {
            await ClearLog();
            vending.Handle(10);
            UpdateUI();
        }

        private async void Insert_Nickel(object sender, RoutedEventArgs e)
        {
            await ClearLog();           
            vending.Handle(5);
            UpdateUI();
        }

        void UpdateUI()
        {
            Cost.Text = $"{Coins.cost}c";
            MachineBal.Text = $"{Coins.machinebalance}c";
            ConsoleLine.Text = $"{vending.finalrest}";
        }
        async Task ClearLog()
        {
            vending.ClearMachineLog();
            ConsoleLine.Text = $"{vending.finalrest}";
            await Task.Delay(200);
            return;
        }
    }
}
