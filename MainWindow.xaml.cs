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
   
        private void webBrowserMap_Loaded(object sender, RoutedEventArgs e)
        {
            
        }


        private void mySetPosition_Click(object sender, RoutedEventArgs e)
        {
            if (webBrowserMap.IsLoaded)
            {
                try
                {
                    this.webBrowserMap.InvokeScript("SetZhengzhongPosition");
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

         private void btnAddMark_Click(object sender, RoutedEventArgs e)
        {
            if (webBrowserMap.IsLoaded)
            {
                try
                {
                    object ret = this.webBrowserMap.InvokeScript("AddMark", new object[] { 114.25705, 22.734708 });
                    MessageBox.Show(ret.ToString());
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

         private void btnClearMark_Click(object sender, RoutedEventArgs e)
         {
             if (webBrowserMap.IsLoaded)
             {
                 try
                 {
                     this.webBrowserMap.InvokeScript("ClearOverLayer");
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

         private void btnLoadMap_Click(object sender, RoutedEventArgs e)
         {
             Ping ping = new Ping();

             PingReply pingReply = ping.Send("180.149.131.33");

             //IPAddress ipAddress
            // PingReply pingReply = ping.Send("www.map.baidu.com");
             if (pingReply.Status == IPStatus.Success)
             {
                 try
                 {
                    // /KeKe;component/Picture/图片1.png
                    webBrowserMap.Navigate(new Uri(System.Environment.CurrentDirectory + @"/../../Source/BMap.html", UriKind.RelativeOrAbsolute));
                    //webBrowserMap.Navigate(new Uri(@"../../ThirdParty/BMap.html", UriKind.RelativeOrAbsolute));
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
                     //webBrowserMap.Navigate("file:///../../Source/examplemap.jpg");

                     webBrowserMap.Navigate(new Uri(System.Environment.CurrentDirectory + @"/../../Source/examplemap.jpg", UriKind.RelativeOrAbsolute));

                 }
                 catch (Exception ex)
                 {

                     MessageBox.Show(ex.ToString());
                 }
             }
             
         }
    }
}
