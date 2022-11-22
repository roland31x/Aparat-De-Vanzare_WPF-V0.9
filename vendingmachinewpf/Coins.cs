using System.Linq;
using System;
using System.Windows;
using System.Text;
using System.Threading;
using System.Windows.Media;

namespace vendingmachinewpf
{
    public class ConfigSteps 
    {
        public static bool step1 = false;
        public static bool step2 = false;
        public static bool step3 = false;
        public static bool step4 = false;
        public static bool step5 = false;
        public static bool badconfig = false;
        public static void CheckConfig()
        {
            if (step1 && step2 && step3 && step4 && step5) 
            {
                Coins.wasconfigured = true;
            }
            else
            {
                badconfig = true;
            }
        }
    }

    public class Coins
    {
        public static int[] coins; // pentru a adauga noi monede acceptate
        public static int[] coinsavailable;
        public static int[] coinsstock;
        public static int cost; // pentru a schimba costul produsului // pentru a schimba banii de buzunar
        public static int machinebalance;
        public static int merch;
        public static bool refreshstock = false;
        public static bool wasconfigured = false;
    }
    public class CoinsConfig : Coins
    {
        public class Type
        {
            public static void BalanceSet(int amount)
            {
                //balance = amount;
            }
            public static void DefaultCoins()
            {
                coins = new int[3];
                Coins.coins[0] = 5;
                Coins.coins[1] = 10;
                Coins.coins[2] = 25;
            }
            public static void DispensableCoinsDefault()
            {
                coinsavailable = new int[] { 1, 1, 0 };
                CoinsStockSet();
                refreshstock = true;
            }
            public static void CoinsStockSet() // pentru a crea o copie de tablou tip "deep"
            {
                coinsstock = new int[coinsavailable.Length];
                string s = "";
                for (int i = 0; i < coinsavailable.Length; i++)
                {
                    s = s + coinsavailable[i] + ",";
                }
                string[] tokens;
                tokens = s.Split(',');
                for (int i = 0; i < coinsstock.Length; i++)
                {
                    coinsstock[i] = int.Parse(tokens[i]);
                }
            }
            public static void DefaultCost()
            {
                cost = 20;
            }
            public static void Defaults()
            {
                BalanceSet(300);
                DefaultCoins();
                DispensableCoinsDefault();
                DefaultCost();
            }
        }
    }
    public class Aparat : Coins
    {
        public string finalrest;
        public void Work()
        {
            //merch = 0;
            machinebalance = 0;
        }
        public void Handle(int input)
        {
            State(input, ref machinebalance, ref merch);
        }
        public void State(int input, ref int machinebalance, ref int merch)
        {
            machinebalance += input;
            if (machinebalance == cost) // returneaza produs
            {
                finalrest = "Ati primit un produs!";
                machinebalance -= cost;
                return;
            }
            else if (machinebalance > cost)
            {
                machinebalance -= cost;
                RestCalc(ref machinebalance);
                return;
            }
            else finalrest = $"Ati introdus {input}c";
            return;
        }
        public void RestCalc(ref int machinebalance) // calculeaza cat rest trebuie sa dea / cat poate da
        {
            StringBuilder Rest = new StringBuilder();
            Rest.Append("Ati primit un produs si rest: ");
            int r;
            r = machinebalance;
            int CL = GetCoinsLength();
            int[] coinsgiven = new int[CL]; // tablout pt monede date ca rest in acest ciclu
            if (refreshstock)
            {
                for (int i = 0; i < coinsavailable.Length; i++)
                {
                    // Console.WriteLine(coinsavailable[i]);// + "s" + coinsstock[i]);
                    coinsavailable[i] = coinsstock[i];
                }
            }
            for (int i = CL - 1; i >= 0; i--)
            {
                while (r > 0 && coinsavailable[i] > 0)
                {
                    if ((r - Coins.coins[i]) >= 0)
                    {
                        coinsgiven[i]++;
                        coinsavailable[i]--;
                        r -= Coins.coins[i];
                    }
                    else break;
                }
            }
            bool restgiven = false;
            for (int j = 0; j < CL; j++)
            {
                if (coinsgiven[j] > 0)
                {
                    if (restgiven)
                    {
                        Rest.Append(',');
                    }
                    Rest.Append($" {coinsgiven[j]} x {Coins.coins[j]}c ");
                    restgiven = true;
                    machinebalance -= coinsgiven[j] * Coins.coins[j];
                }
            }
            this.finalrest = Rest.ToString();
            // MessageBox.Show($"{finalrest}");
            return;
        }
        public void ClearMachineLog()
        {
            finalrest = "";
            return;
        }
        public static int GetCoinsLength()
        {
            return Coins.coins.Length;
        }
    }
}