using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Web;
using System.Security.Permissions;

namespace MapTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
 
        public MainWindow()
        {
            InitializeComponent();
            
            
        }
   
        private void webView_Loaded(object sender, RoutedEventArgs e)
        {
            
        }


        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            if (webView.IsLoaded)
            {
                try
                {
                    this.webView.InvokeScript("test");
                }
                catch (Exception ex)
                {
                    string msg = "Could not call script: " +
                                 ex.Message +
                                "\n\nPlease click the 'Load HTML Document with Script' button to load.";
                    MessageBox.Show(msg);
                }
            }
        }

         private void btnTest2_Click(object sender, RoutedEventArgs e)
        {
            if (webView.IsLoaded)
            {
                try
                {
                    this.webView.InvokeScript("test2", new object[] { 114.25705, 22.734708 });
                }
                catch (Exception ex)
                {
                    string msg = "Could not call script: " +
                                 ex.Message +
                                "\n\nPlease click the 'Load HTML Document with Script' button to load.";
                    MessageBox.Show(msg);
                }
            }
        }

         private void btnTest3_Click(object sender, RoutedEventArgs e)
         {
             if (webView.IsLoaded)
             {
                 try
                 {
                     this.webView.InvokeScript("ClearOverLayer");
                 }
                 catch (Exception ex)
                 {
                     string msg = "Could not call script: " +
                                  ex.Message +
                                 "\n\nPlease click the 'Load HTML Document with Script' button to load.";
                     MessageBox.Show(msg);
                 }
             }
         }

         private void btnJpg_Click(object sender, RoutedEventArgs e)
         {
             Ping ping = new Ping();

             //PingReply pingReply = ping.Send("180.149.131.33");

             //IPAddress ipAddress
             PingReply pingReply = ping.Send("www.map.baidu.com");
             if (pingReply.Status == IPStatus.Success)
             {
                 try
                 {
                     webView.Navigate(new Uri(System.Environment.CurrentDirectory + @"/BMap.html", UriKind.RelativeOrAbsolute));

                 }
                 catch (Exception ex)
                 {

                     MessageBox.Show(ex.ToString());
                 }
             }
             else
             {
                 try
                 {
                     webView.Navigate("file:///E:\\examplemap.jpg");

                 }
                 catch (Exception ex)
                 {

                     MessageBox.Show(ex.ToString());
                 }
             }
             
         }
    }
}
