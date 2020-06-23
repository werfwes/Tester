using System.Windows;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using Tester.Properties;

namespace Tester
    
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            plugIco();
        }
        private void plugIco()
        {
            
            if (Properties.Settings.firstStartup)
            {
                RegistryKey classesRootKey = Registry.ClassesRoot;
                RegistryKey ttr = classesRootKey.CreateSubKey(".ttr");
                ttr.SetValue("", "Tester");
                ttr.Close();

                RegistryKey cR = Registry.ClassesRoot;
                RegistryKey tester = cR.CreateSubKey("Tester");
                RegistryKey dIco = tester.CreateSubKey("DefaultIcon");
                dIco.SetValue("", "\"C:\\Tester\\ICO\\ttr.ico\"");
                dIco.Close();

                Properties.Settings.firstStartup = false;
                
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            newTest NewTest = new newTest();
            NewTest.Show();
            this.Hide();
        }
   

       
       
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            openTest ot = new openTest();
            ot.Show();
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
