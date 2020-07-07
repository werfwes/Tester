using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Security.Cryptography;
using System.Windows.Controls;

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
            ttrToAQ(Class1.testPath);
            AQtoTrueAnsw();
            AQtoTextBoxes();
            label.Content = "№1";
        }

       

        public static string[,] AQ = new string[2, 1000];
        public static string[] A = new string[1000];
        public static string[] trueAnsw = new string[1000];
        int qNum = 0;
        public static float qCount = 0;


        public void ttrToAQ(string testPath)
        {
            int i = 0;
            int i1 = 0;
            string line;



            FileStream stream = new FileStream(testPath, FileMode.Open, FileAccess.Read);                              //
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
        public void AQtoTrueAnsw()
        {
            string thisas = "";
            for(int i = 0; i < qCount; i++)
            {
                if (AQ[0, i][0] == '@')
                {
                    thisas = AQ[0, i];
                    string[] As = thisas.Split('$');
                    foreach (string a in As)
                    {
                        if (a[0] == '~')
                        {
                            trueAnsw[i] = i.ToString();
                        }
                    }
                }
                else
                {
                    trueAnsw[i] = AQ[0, i];
                }
            }
        }
        public void AQtoTextBoxes()
        {
            if (AQ[0, 0][0] == '@')
            {
                textA.Visibility = Visibility.Hidden;
                textQ.Text = AQ[1, 0];
                int i = 0;
                string[] As = AQ[0, 0].Split('$');
                foreach (string s in As)
                {                   
                    switch (i + 1)
                    {
                        case 1:
                            a1.Content = s.Trim('~', '@');
                            rb1.Visibility = Visibility.Visible;
                            break;
                        case 2:
                            a2.Content = s.Trim('~', '@');
                            rb2.Visibility = Visibility.Visible;
                            break;
                        case 3:
                            a3.Content = s.Trim('~', '@');
                            rb3.Visibility = Visibility.Visible;
                            break;
                        case 4:
                            a4.Content = s.Trim('~', '@');
                            rb4.Visibility = Visibility.Visible;
                            break;
                        case 5:
                            a5.Content = s.Trim('~', '@');
                            rb5.Visibility = Visibility.Visible;
                            break;
                        case 6:
                            a6.Content = s.Trim('~', '@');
                            rb6.Visibility = Visibility.Visible;
                            break;
                    }
                    i++;
                }

            }
            else 
            {
                textA.Visibility = Visibility.Visible;
                textQ.Text = AQ[1, 0];    
            }
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


            if (AQ[0, qNum + 1][0] == '@')
            {
                if((bool)rb1.IsChecked)
                {
                    A[qNum] = "1";
                }
                else if ((bool)rb2.IsChecked)
                {
                    A[qNum] = "2";
                }
                else if ((bool)rb3.IsChecked)
                {
                    A[qNum] = "3";
                }
                else if ((bool)rb4.IsChecked)
                {
                    A[qNum] = "4";
                }
                else if ((bool)rb5.IsChecked)
                {
                    A[qNum] = "5";
                }
                else if ((bool)rb6.IsChecked)
                {
                    A[qNum] = "6";
                }
                else
                {
                    MessageBox.Show("Выберте ответ");
                    return;
                }




                textQ.Text = AQ[1, qNum + 1];
                textA.Visibility = Visibility.Hidden;
                int i = 0;
                string[] As = AQ[0, qNum + 1].Split(new char[] { '$' });
                foreach (string s in As)
                {
                    switch (i + 1)
                    {
                        case 1:
                            a1.Content = s.Trim('~', '@');
                            rb1.Visibility = Visibility.Visible;
                            break;
                        case 2:
                            a2.Content = s.Trim('~', '@');
                            rb2.Visibility = Visibility.Visible;
                            break;
                        case 3:
                            a3.Content = s.Trim('~', '@');
                            rb3.Visibility = Visibility.Visible;
                            break;
                        case 4:
                            a4.Content = s.Trim('~', '@');
                            rb4.Visibility = Visibility.Visible;
                            break;
                        case 5:
                            a5.Content = s.Trim('~', '@');
                            rb5.Visibility = Visibility.Visible;
                            break;
                        case 6:
                            a6.Content = s.Trim('~', '@');
                            rb6.Visibility = Visibility.Visible;
                            break;
                    }
                    i++;
                }
                i = 0;
            }
            else
            {
                
                A[qNum] = textA.Text;
                label.Content = "№" + (qNum + 2).ToString();
                bB.IsEnabled = true;
            }
            qNum++;




            if (qNum == qCount)
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
