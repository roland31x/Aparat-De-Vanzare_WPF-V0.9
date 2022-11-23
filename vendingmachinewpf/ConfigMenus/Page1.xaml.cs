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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        SortedSet<int> leCoins = new();
        protected int CoinToAdd;
        public Page1()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {           
            if (!int.TryParse(CoinsToAdd.Text, out CoinToAdd))
            {
                MessageBox.Show("Trebuie sa introduci un numar!!!");
                return;
            }
            if (CoinToAdd > 999999)
            {
                MessageBox.Show("Moneda prea mare!!!");
                return;
            }
            leCoins.Add(CoinToAdd);
            MOutput.Text=$"* '{CoinsToAdd.Text}c' a fost adaugat.";
            CoinsToAdd.Text = null;
            NextStep.IsEnabled = true;
        }
        private void NextPage(object sender, RoutedEventArgs e)
        {
            Coins.coins = leCoins.ToArray();
            CoinsConfig.Steps.step1 = true;
            App.ParentWindowRef.ParentFrame.Navigate(new Page2());
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!int.TryParse(CoinsToAdd.Text, out CoinToAdd))
            {
                AddButton.IsEnabled = false;
                return;
            }
            if (CoinToAdd > 999999)
            {
                AddButton.IsEnabled = false;
                return;
            }
            AddButton.IsEnabled = true;
        }
    }
}
