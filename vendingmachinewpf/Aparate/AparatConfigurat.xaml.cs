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
    public partial class AparatConfigurat : Window
    {
        Aparat vending = new Aparat();
        public AparatConfigurat()
        {
            InitializeComponent();
            CreateButtons();
            vending.Work();
            UpdateUI();
        }

        void CreateButtons()
        {
            for (int i = 0; i < Coins.coins.Length; i++)
            {
                Button button = new Button()
                {
                    Height = 90,
                    VerticalAlignment = VerticalAlignment.Center,
                    Width = 90,
                    FontSize = 32,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(10, 5, 10, 0),
                    Background = new SolidColorBrush(Colors.DarkGoldenrod),
                    Cursor = Cursors.Hand,
                    Content = string.Format(Coins.coins[i].ToString()+"c"),
                    Tag = Coins.coins[i]
                };
                button.Click += new RoutedEventHandler(Button_Click);
                if (i < 8)
                {
                    this.ButtonDock.Children.Add(button);
                }
                else
                {
                    this.ButtonDock2.Children.Add(button);
                }
            }
        }
        async void Button_Click(object sender, RoutedEventArgs e)
        {
            await ClearLog();
            vending.Handle(Convert.ToInt32((sender as Button).Tag));          
            UpdateUI();
        }

        void UpdateUI()
        {
            Cost.Text = $"{Coins.cost}c";
            MachineBal.Text = $"{vending.machinebalance}c";
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
