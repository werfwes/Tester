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

namespace Tester
{
    /// <summary>
    /// Логика взаимодействия для testResults.xaml
    /// </summary>
    public partial class testResults : Window
    {
        public testResults()
        {
            InitializeComponent();
            res();
        }
        int qTrueCount = 0;
        float qTruePercent = 0;
        private void res()
        {
            for(int i = 0; i < doTest.qCount + 1; i++)
            {
                if(doTest.AQ[0, i] == doTest.A[i])
                {
                    qTrueCount++;
                }
            }
            lCount.Content = qTrueCount.ToString();

            qTruePercent = qTrueCount / (doTest.qCount + 1) * 100;
            lPercent.Content = qTruePercent.ToString() + "%";

            if (qTruePercent >= 90)
            {
                lMark.Content = "5";
                lMark.Foreground = Brushes.Green;
            }
            else if (qTruePercent >= 75)
            {
                lMark.Content = "4";
                lMark.Foreground = Brushes.Blue;
            }
            else if (qTruePercent >= 50)
            {
                lMark.Content = "3";
                lMark.Foreground = Brushes.Orange;
            }
            else 
            {
                lMark.Content = "2";
                lMark.Foreground = Brushes.Red;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Form1 ta = new Form1();
            ta.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();
            MW.Show();
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow MW = new MainWindow();
            MW.Show();
        }
    }
}
