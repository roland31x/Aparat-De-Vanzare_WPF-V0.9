using Microsoft.VisualBasic;
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
using System.Windows.Shapes;

namespace vendingmachinewpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ConfigWindow : Window
    {
        SortedSet<int> leCoins = new();
        public ConfigWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            int CoinToAdd;
            if (!int.TryParse(CoinsToAdd.Text, out CoinToAdd))
            {
                MessageBox.Show("Trebuie sa introduci un numar!!!");
                return;
            }
            if(CoinToAdd > 99999)
            {
                MessageBox.Show("Moneda prea mare!!!");
                return;
            }
            leCoins.Add(CoinToAdd);
            MessageBox.Show($"{CoinsToAdd.Text} a fost adaugat ca moneda acceptata.{Environment.NewLine}Adaugati mai multe sau continuati la urmatorul pas.");
            NextStep.IsEnabled = true;

        }
        private void NextPage(object sender, RoutedEventArgs e)
        {
            Coins.coins = leCoins.ToArray();
            ConfigSteps.step1 = true;
            this.Close();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
