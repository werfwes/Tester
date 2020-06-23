using System;
using System.IO;
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
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Tester
{
    /// <summary>
    /// Логика взаимодействия для doTest.xaml
    /// </summary>
    public partial class doTest : Window
    {
        private string tp = "";
        public doTest()
        {
            
            InitializeComponent();
            tp = Class1.testPath;
            parse();
            label.Content = "№1";
            textQ.Text = AQ[1, 0];
        }
        
        public static string[,] AQ = new string[2, 1000];
        public static string[] A = new string[1000];
        int qNum = 0;
        public static float qCount = 0;
        public void parse()
        {
            int i = 0;
            int i1 = 0;
            string line;



            FileStream stream = new FileStream(tp, FileMode.Open, FileAccess.Read);                              //
            DESCryptoServiceProvider cryptic = new DESCryptoServiceProvider();                                   //
                                                                                                                 //
            cryptic.Key = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH");                                              // Создание потока дешифратора,
            cryptic.IV = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH");                                               // для чтения файла
                                                                                                                 //
            CryptoStream crStream = new CryptoStream(stream, cryptic.CreateDecryptor(), CryptoStreamMode.Read);  //
            StreamReader reader = new StreamReader(crStream);                                                    //

            line = reader.ReadLine();

            // Деление на задания
            string[] AQs = line.Split(new char[] { '#' });                                                       
            foreach (string s in AQs)
            {
                // Деление на вопросы-ответы
                string[] AandQ = s.Split(new char[] { '|' });                                                       
                foreach(string s1 in AandQ)
                {
                    // Запись одной строки
                    AQ[i, i1] = s1;
                    i++;
                }
                i = 0;
                i1++;
            }
            i1 = 0;

            // Определение кол-ва заданий
            for(int n = 0; n < 1000; n++)
            {
                if (AQ[0, n] != null && AQ[0, n] != "")
                {
                    qCount++;
                }
                else 
                {
                    break;
                }
            }
            qCount--;



            crStream.Close();
            stream.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            openTest ot = new openTest();
            ot.Show();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //Далее
        {
            A[qNum] = textA.Text;
            qNum++;
            label.Content = "№" + (qNum+1).ToString();
            bB.IsEnabled = true;
            if(qNum == qCount)
            {
                bN.Content = "Результат";
                bN.FontWeight = FontWeights.UltraBold;
            }
            else if (qNum > qCount)
            {
                MessageBoxResult mbr = System.Windows.MessageBox.Show("Вы уверены, что хотите завершить тест?\rВы больше не сможете изменить ответы.",
                                                       "Просмотр результатов",
                                                       MessageBoxButton.YesNo,
                                                       MessageBoxImage.Question);
               if(mbr == MessageBoxResult.No)
               {
                    return;
               }
               else 
               {
                    A[qNum-1] = textA.Text;
                    testResults tr = new testResults();
                    tr.Show();
                    this.Hide();
               }
            }
            textQ.Text = AQ[1, qNum];
            textA.Text = A[qNum];
        }

        private void bB_Click(object sender, RoutedEventArgs e) //Назад
        {
            A[qNum] = textA.Text;
            qNum--;
            label.Content = "№" + (qNum + 1).ToString();
            if(qNum == 0) {bB.IsEnabled = false;}
            textQ.Text = AQ[1, qNum];
            bN.Content = "Далее>";
            bN.FontWeight = FontWeights.Normal;
            textA.Text = A[qNum];
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
