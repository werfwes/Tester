using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace Tester
{
    /// <summary>
    /// Логика взаимодействия для newTest.xaml
    /// </summary>
    public partial class newTest : Window
    {
        public newTest()
        {
            InitializeComponent();
            typeChangeBut.Content = "Тестовое задание";
            label1.Content = "Номер вопроса: " + (qNum + 1);
            butBack.IsEnabled = false;
            for (int i = 0; i < 1000; i++)
            {
                AQ[0, i] = "";
                AQ[1, i] = "";
            }
        }


        #region Переменные и поля
        int qNum = 0;
        string[,] AQ = new string[2, 1000];
        bool isTest = false;
        public string path { get; set; }
        #endregion



        #region Кнопки


            #region Меню
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string caption = "Меню";
            string message = "Вы уверены, что хотите выйти в меню?\r" + "Несохраненные данные будут утеряны";
            MessageBoxResult result = MessageBox.Show(message, caption, MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result.ToString() == "Yes")
            {
                MainWindow MW = new MainWindow();
                MW.Show();
                this.Close();
            }
        }
        #endregion

            #region Назад
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string Q = textQ.Text;
            string A;
            if (textBox1.Text != "" ||
                textBox2.Text != "" ||
                textBox3.Text != "" ||
                textBox4.Text != "" ||
                textBox5.Text != "" ||
                textBox6.Text != "" ||
                textQ.Text != "" ||
                textA.Text != "")
            {


                if (isTest)
                {

                    string A1, A2, A3, A4, A5, A6;
                    A1 = textBox1.Text;
                    A2 = textBox2.Text;
                    A3 = textBox3.Text;
                    A4 = textBox4.Text;
                    A5 = textBox5.Text;
                    A6 = textBox6.Text;


                    if (rb1.IsChecked.Value)
                    {
                        A1 = "~" + A1;
                    }
                    else if (rb2.IsChecked.Value)
                    {
                        A2 = "~" + A2;
                    }
                    else if (rb3.IsChecked.Value)
                    {
                        A3 = "~" + A3;
                    }
                    else if (rb4.IsChecked.Value)
                    {
                        A4 = "~" + A4;
                    }
                    else if (rb5.IsChecked.Value)
                    {
                        A5 = "~" + A5;
                    }
                    else if (rb6.IsChecked.Value)
                    {
                        A6 = "~" + A6;
                    }
                    else
                    {
                        MessageBox.Show("Укажите верный ответ");
                        return;
                    }

                    A = A1 + "$" + A2;

                    if (A3 != "")
                    {
                        A = A + "$" + A3;
                    }
                    if (A4 != "")
                    {
                        A = A + "$" + A4;
                    }
                    if (A5 != "")
                    {
                        A = A + "$" + A5;
                    }
                    if (A6 != "")
                    {
                        A = A + "$" + A6;
                    }

                    AQ[0, qNum] = "@" + A;
                    AQ[1, qNum] = Q;

                }
                else
                {

                    A = textA.Text;
                    Q = textQ.Text;
                    AQ[0, qNum] = "-" + A;
                    AQ[1, qNum] = Q;


                }
            }

            qNum--;
            
            if (AQ[0, qNum] != null && AQ[0, qNum] != "") // Проверка на пустое значение
            {
                if (AQ[0, qNum][0] == '@') // Если тест
                {
                    
                    cb1.IsChecked = true;
                    cb2.IsChecked = true;
                    cb3.IsChecked = true;
                    cb4.IsChecked = true;
                    cb5.IsChecked = true;
                    cb6.IsChecked = true;


                    AQ[0, qNum] = AQ[0, qNum].TrimStart('@');
                    textQ.Text = AQ[1, qNum];
                    textA.Visibility = Visibility.Hidden;
                    isTest = true;
                    int i = 0;
                    string[] As = AQ[0, qNum].Split(new char[] { '$' });
                    foreach (string s in As)
                    {
                        if (s != "" && s != null)
                        {

                            if (s[0] == '~')
                            {
                                switch (i + 1)
                                {
                                    case 1:
                                        rb1.IsChecked = true;
                                        break;
                                    case 2:
                                        rb2.IsChecked = true;
                                        break;
                                    case 3:
                                        rb3.IsChecked = true;
                                        break;
                                    case 4:
                                        rb4.IsChecked = true;
                                        break;
                                    case 5:
                                        rb5.IsChecked = true;
                                        break;
                                    case 6:
                                        rb6.IsChecked = true;
                                        break;
                                }

                            }
                            switch (i + 1)
                            {
                                case 1:
                                    textBox1.Text = s.Trim('~');
                                    break;
                                case 2:
                                    textBox2.Text = s.Trim('~');
                                    break;
                                case 3:
                                    textBox3.Text = s.Trim('~');
                                    break;
                                case 4:
                                    textBox4.Text = s.Trim('~');
                                    break;
                                case 5:
                                    textBox5.Text = s.Trim('~');
                                    break;
                                case 6:
                                    textBox6.Text = s.Trim('~');
                                    break;
                            }
                        }
                        i++;
                    }
                    AQ[0, qNum] = "@" + AQ[0, qNum];


                    if(textBox1.Text == "" || textBox1.Text == null)
                    {
                        cb1.IsChecked = false;
                    }
                    if (textBox2.Text == "" || textBox2.Text == null)
                    {
                        cb2.IsChecked = false;
                    }
                    if (textBox3.Text == "" || textBox3.Text == null)
                    {
                        cb3.IsChecked = false;
                    }
                    if (textBox4.Text == "" || textBox4.Text == null)
                    {
                        cb4.IsChecked = false;
                    }
                    if (textBox5.Text == "" || textBox5.Text == null)
                    {
                        cb5.IsChecked = false;
                    }
                    if (textBox6.Text == "" || textBox6.Text == null)
                    {
                        cb6.IsChecked = false;
                    }
                }
                else 
                {
                    AQ[0, qNum] = AQ[0, qNum].TrimStart('-');
                    textA.Visibility = Visibility.Visible;
                    isTest = false;
                    textA.Text = AQ[0, qNum];
                    textQ.Text = AQ[1, qNum];
                    AQ[0, qNum] = "-" + AQ[0, qNum];
                }
            }
            if (qNum == 0)
            {
                butBack.IsEnabled = false;
            }
            label1.Content = "Номер вопроса: " + (qNum + 1);
        }
        #endregion

            #region Далее
        private void Button_Click_2(object sender, RoutedEventArgs e)  
        {
            
            if(textQ.Text == "")
            {
                MessageBox.Show("Укажите вопрос.", "", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            string Q = textQ.Text;            
            string A;

            
            // Cохранение вопроса-ответа 
            if (isTest)
            {
                if(textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Укажите 2 или более\r варианта ответа.", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                string A1, A2, A3, A4, A5, A6;
                A1 = textBox1.Text;
                A2 = textBox2.Text;
                A3 = textBox3.Text;
                A4 = textBox4.Text;
                A5 = textBox5.Text;
                A6 = textBox6.Text;
                
               
                if(rb1.IsChecked.Value)
                {
                    A1 = "~" + A1;
                }
                else if (rb2.IsChecked.Value)
                {
                    A2 = "~" + A2;
                }
                else if (rb3.IsChecked.Value)
                {
                    A3 = "~" + A3;
                }
                else if (rb4.IsChecked.Value)
                {
                    A4 = "~" + A4;
                }
                else if (rb5.IsChecked.Value)
                {
                    A5 = "~" + A5;
                }
                else if (rb6.IsChecked.Value)
                {
                    A6 = "~" + A6;
                }
                else 
                {
                    MessageBox.Show("Укажите верный ответ");
                    return;
                }

                A = A1 + "$" + A2;

                if(A3 != "")
                {
                    A = A + "$" + A3;
                }
                if (A4 != "")
                {
                    A = A + "$" + A4;
                }
                if (A5 != "")
                {
                    A = A + "$" + A5;
                }
                if (A6 != "")
                {
                    A = A + "$" + A6;
                }

                AQ[0, qNum] = "@" + A;
                AQ[1, qNum] = Q;
                qNum++;
            }
            else
            {
                if (textA.Text == "")
                {
                    MessageBox.Show("Укажите ответ.", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                A = textA.Text;
                Q = textQ.Text;
                AQ[0, qNum] = "-" + A;
                AQ[1, qNum] = Q;
                qNum++;
                
            }
            
            
            // Чтение следующего вопроса-ответа, если тот указан
            if (AQ[0, qNum] != null && AQ[0, qNum] != "")
            {
                if (AQ[0, qNum][0] == '@')
                {
                    cb1.IsChecked = true;
                    cb2.IsChecked = true;
                    cb3.IsChecked = true;
                    cb4.IsChecked = true;
                    cb5.IsChecked = true;
                    cb6.IsChecked = true;
                    textQ.Text = AQ[1, qNum];
                    textA.Visibility = Visibility.Hidden;
                    isTest = true;
                    int i = 0;
                    string[] As = AQ[0, qNum].Split(new char[] { '$' });
                    foreach (string s in As)
                    {
                        if (s[0] == '~')
                        {
                            switch (i + 1)
                            {
                                case 1:
                                    rb1.IsChecked = true;
                                    break;
                                case 2:
                                    rb2.IsChecked = true;
                                    break;
                                case 3:
                                    rb3.IsChecked = true;
                                    break;
                                case 4:
                                    rb4.IsChecked = true;
                                    break;
                                case 5:
                                    rb5.IsChecked = true;
                                    break;
                                case 6:
                                    rb6.IsChecked = true;
                                    break;
                            }

                        }
                        switch (i + 1)
                        {
                            case 1:
                                textBox1.Text = s.Trim('~', '@');
                                break;
                            case 2:
                                textBox2.Text = s.Trim('~', '@');
                                break;
                            case 3:
                                textBox3.Text = s.Trim('~', '@');
                                break;
                            case 4:
                                textBox4.Text = s.Trim('~', '@');
                                break;
                            case 5:
                                textBox5.Text = s.Trim('~', '@');
                                break;
                            case 6:
                                textBox6.Text = s.Trim('~', '@');
                                break;
                        }
                        i++;
                    }
                    if (textBox1.Text == "" || textBox1.Text == null)
                    {
                        cb1.IsChecked = false;
                    }
                    if (textBox2.Text == "" || textBox2.Text == null)
                    {
                        cb2.IsChecked = false;
                    }
                    if (textBox3.Text == "" || textBox3.Text == null)
                    {
                        cb3.IsChecked = false;
                    }
                    if (textBox4.Text == "" || textBox4.Text == null)
                    {
                        cb4.IsChecked = false;
                    }
                    if (textBox5.Text == "" || textBox5.Text == null)
                    {
                        cb5.IsChecked = false;
                    }
                    if (textBox6.Text == "" || textBox6.Text == null)
                    {
                        cb6.IsChecked = false;
                    }
                }
                else
                {
                    isTest = false;
                    textA.Visibility = Visibility.Visible;
                    textA.Text = AQ[0, qNum].Trim('-');
                    textQ.Text = AQ[1, qNum];
                }
            }
            else
            {
                textA.Text = "";
                textQ.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
            }
            butBack.IsEnabled = true;
            label1.Content = "Номер вопроса: " + (qNum + 1);
            
        }
        #endregion

            #region Тип задания
        private void typeChangeBut_Click(object sender, RoutedEventArgs e)
        {
            if (isTest)
            {
                typeChangeBut.Content = "Тестовое задание";
                textA.Visibility = Visibility.Visible;
                isTest = !isTest;
            }
            else
            {
                typeChangeBut.Content = "    Полный ответ";
                textA.Visibility = Visibility.Hidden;
                isTest = !isTest;
            }

        }
        #endregion

            #region Сохранение
        private void butSave_Click(object sender, RoutedEventArgs e)
        {
            string Q = textQ.Text;
            string A;
            if (textBox1.Text != "" &&
                textBox2.Text != "" &&
                textQ.Text != "")
            {


                if (isTest)
                {

                    string A1, A2, A3, A4, A5, A6;
                    A1 = textBox1.Text;
                    A2 = textBox2.Text;
                    A3 = textBox3.Text;
                    A4 = textBox4.Text;
                    A5 = textBox5.Text;
                    A6 = textBox6.Text;


                    if (rb1.IsChecked.Value)
                    {
                        A1 = "~" + A1;
                    }
                    else if (rb2.IsChecked.Value)
                    {
                        A2 = "~" + A2;
                    }
                    else if (rb3.IsChecked.Value)
                    {
                        A3 = "~" + A3;
                    }
                    else if (rb4.IsChecked.Value)
                    {
                        A4 = "~" + A4;
                    }
                    else if (rb5.IsChecked.Value)
                    {
                        A5 = "~" + A5;
                    }
                    else if (rb6.IsChecked.Value)
                    {
                        A6 = "~" + A6;
                    }
                    else
                    {
                        MessageBox.Show("Укажите верный ответ");
                        return;
                    }

                    A = A1 + "$" + A2;

                    if (A3 != "")
                    {
                        A = A + "$" + A3;
                    }
                    if (A4 != "")
                    {
                        A = A + "$" + A4;
                    }
                    if (A5 != "")
                    {
                        A = A + "$" + A5;
                    }
                    if (A6 != "")
                    {
                        A = A + "$" + A6;
                    }

                    AQ[0, qNum] = "@" + A;
                    AQ[1, qNum] = Q;

                }
                else
                {

                    A = textA.Text;
                    Q = textQ.Text;
                    AQ[0, qNum] = "-" + A;
                    AQ[1, qNum] = Q;


                }
            }


            if (!Directory.Exists("tests/"))
            {
                Directory.CreateDirectory("tests/");
            }
            try
            {
                string path = "tests/" + Microsoft.VisualBasic.Interaction.InputBox("Введите название теста:") + ".ttr";
                var dstEncoding = Encoding.UTF8;

                FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                DESCryptoServiceProvider cryptic = new DESCryptoServiceProvider();

                cryptic.Key = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH");
                cryptic.IV = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH");

                CryptoStream crStream = new CryptoStream(stream, cryptic.CreateEncryptor(), CryptoStreamMode.Write);
                StreamWriter writer = new StreamWriter(crStream);
                

                for (int i = 0; i < 1000; i++)
                {
                    byte[] data;
                    if (i == 999)
                    {
                        data = dstEncoding.GetBytes(AQ[0, i] + "|" + AQ[1, i]);
                    }
                    else 
                    {
                        data = dstEncoding.GetBytes(AQ[0, i] + "|" + AQ[1, i] + "#");
                    }
                    crStream.Write(data, 0, data.Length);
                }
                
                crStream.Close();
                stream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
        #endregion  


        #endregion



        #region Свойства контролов
        private void Window_Closed(object sender, EventArgs e)
        {

        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow MW = new MainWindow();
            MW.Show();
        }
        private void cb1_Checked(object sender, RoutedEventArgs e)
        {
            rb1.IsEnabled = true;
            textBox1.IsEnabled = true;
        }
        private void cb2_Checked(object sender, RoutedEventArgs e)
        {
            rb2.IsEnabled = true;
            textBox2.IsEnabled = true;
        }
        private void cb3_Checked(object sender, RoutedEventArgs e)
        {
            rb3.IsEnabled = true;
            textBox3.IsEnabled = true;
            
            
        }
        private void cb4_Checked(object sender, RoutedEventArgs e)
        { 
            rb4.IsEnabled = true;
            textBox4.IsEnabled = true;
            
        }
        private void cb5_Checked(object sender, RoutedEventArgs e)
        {
            rb5.IsEnabled = true;
            textBox5.IsEnabled = true;
            
        }
        private void cb6_Checked(object sender, RoutedEventArgs e)
        {
            rb6.IsEnabled = true;
            textBox6.IsEnabled = true;
            
        }
        private void cb1_Unchecked(object sender, RoutedEventArgs e)
        {
            cb1.IsChecked = true;
            
        }
        private void cb2_Unchecked(object sender, RoutedEventArgs e)
        {
            cb2.IsChecked = true;
            
        }
        private void cb3_Unchecked(object sender, RoutedEventArgs e)
        {
            rb3.IsEnabled = false;
            textBox3.IsEnabled = false;
            
        }
        private void cb4_Unchecked(object sender, RoutedEventArgs e)
        {
            
            rb4.IsEnabled = false;
            textBox4.IsEnabled = false;
            
            
        }
        private void cb5_Unchecked(object sender, RoutedEventArgs e)
        {
            rb5.IsEnabled = false;
            textBox5.IsEnabled = false;
            
        }
        private void cb6_Unchecked(object sender, RoutedEventArgs e)
        {
            rb6.IsEnabled = false;
            textBox6.IsEnabled = false;

        }
        private void rb1_Checked(object sender, RoutedEventArgs e)
        {
            rb2.IsChecked = false;
            rb3.IsChecked = false;
            rb4.IsChecked = false;
            rb5.IsChecked = false;
            rb6.IsChecked = false;
        }
        private void rb2_Checked(object sender, RoutedEventArgs e)
        {
            rb1.IsChecked = false;
            rb3.IsChecked = false;
            rb4.IsChecked = false;
            rb5.IsChecked = false;
            rb6.IsChecked = false;
        }
        private void rb3_Checked(object sender, RoutedEventArgs e)
        {
            rb1.IsChecked = false;
            rb2.IsChecked = false;
            rb4.IsChecked = false;
            rb5.IsChecked = false;
            rb6.IsChecked = false;
        }
        private void rb4_Checked(object sender, RoutedEventArgs e)
        {
            rb1.IsChecked = false;
            rb2.IsChecked = false;
            rb3.IsChecked = false;
            rb5.IsChecked = false;
            rb6.IsChecked = false;
        }
        private void rb5_Checked(object sender, RoutedEventArgs e)
        {
            rb1.IsChecked = false;
            rb2.IsChecked = false;
            rb3.IsChecked = false;
            rb4.IsChecked = false;
            rb6.IsChecked = false;
        }
        private void rb6_Checked(object sender, RoutedEventArgs e)
        {
            rb1.IsChecked = false;
            rb2.IsChecked = false;
            rb3.IsChecked = false;
            rb4.IsChecked = false;
            rb5.IsChecked = false;
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
           
        }      
        private void textQ_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
           
        }
        private void textA_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if(e.Text == "#" || e.Text == "$" || e.Text == "|" || e.Text == "~")
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}
