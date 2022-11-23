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
    /// Interaction logic for Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        protected int price;
        public Page3()
        {
            InitializeComponent();
        }

        private void PriceToSet_TextChanged(object sender, TextChangedEventArgs e)
        {
            {
                if (!int.TryParse(PriceToSet.Text, out price))
                {
                    NextStep.IsEnabled = false;
                    return;
                }
                if (price > 999999)
                {
                    NextStep.IsEnabled = false;
                    return;
                }
                NextStep.IsEnabled = true;
            }
        }

        private void NextPage(object sender, RoutedEventArgs e)
        {
            Coins.cost = price;
            CoinsConfig.Steps.step3 = true;
            App.ParentWindowRef.Close();
        }
    }
}
