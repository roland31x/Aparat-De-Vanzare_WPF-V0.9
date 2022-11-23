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

namespace vendingmachinewpf.ConfigMenus
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        protected int stock;
        protected int stockstep = 0;
        public Page2()
        {
            InitializeComponent();
            Coins.coinsavailable = new int[Coins.coins.Length];
            CoinBox.Text = Coins.coins[stockstep].ToString() + "c :";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Coins.coinsavailable[stockstep] = stock;
            StockToSet.Text = null;
            stockstep++;
            if (stockstep == Coins.coins.Length)
            {
                RefButtonDa.Visibility = Visibility.Visible;
                RefButtonNu.Visibility = Visibility.Visible;
                Page2Canvas.Visibility= Visibility.Collapsed;
                InfoBox.Text = $"Stoc setat cu succes!{Environment.NewLine}Doriti ca masina sa isi reactualizeze stocul de monede la stocul setat anterior dupa fiecare ciclu de dispensare?";
                return;
            }
            CoinBox.Text = Coins.coins[stockstep].ToString() + "c :";
        }



        private void StockToSet_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!int.TryParse(StockToSet.Text, out stock))
            {
                SetterButton.IsEnabled = false;
                return;
            }
            if (stock > 999999)
            {
                SetterButton.IsEnabled = false;
                return;
            }
            SetterButton.IsEnabled = true;
        }

        private void RefButtonDa_Click(object sender, RoutedEventArgs e)
        {
            Coins.refreshstock = true;
            CoinsConfig.Type.CoinsStockSet();
            NextStep.Visibility = Visibility.Visible;
            RefButtonDa.Visibility = Visibility.Collapsed;
            RefButtonNu.Visibility = Visibility.Collapsed;
            InfoBox.Text = $"Stoc setat cu succes!";
        }

        private void RefButtonNu_Click(object sender, RoutedEventArgs e)
        {
            NextStep.Visibility = Visibility.Visible;
            RefButtonDa.Visibility = Visibility.Collapsed;
            RefButtonNu.Visibility = Visibility.Collapsed;
            Coins.refreshstock = false;
            InfoBox.Text = $"Stoc setat cu succes!";

        }        
        private void NextPage(object sender, RoutedEventArgs e)
        {
            CoinsConfig.Steps.step2 = true;
            App.ParentWindowRef.ParentFrame.Navigate(new Page3());
        }
    }
}
