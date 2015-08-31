using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Divelements.SilverlightTools;

namespace SilverlightApplication3
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            //注册事件触发处理
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
            this.myHTML.Click += new RoutedEventHandler(myHTML_Click);
            this.myFlash.Click += new RoutedEventHandler(myFlash_Click);
            this.myPDF.Click += new RoutedEventHandler(myPDF_Click);
            this.myJpg.Click += new RoutedEventHandler(myJpg_Click);
        }

        void myJpg_Click(object sender, RoutedEventArgs e)
        {
            GetRichContent(@"http://192.168.10.12/tourism_trunk/AttachmentService/Files/131120/7d236f91-e3ec-4e33-b34c-914cce0c74bc.jpg", UriKind.Absolute);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            GetRichContent("http://cn.bing.com", UriKind.Absolute);
        }


        void myPDF_Click(object sender, RoutedEventArgs e)
        {
            GetRichContent(@"http://192.168.10.12/tourism_trunk/AttachmentService/Files/131120/8a3820bc-c9e1-45b9-877c-3ecf6c9ff6fd.pdf", UriKind.Absolute);
        }

        void myFlash_Click(object sender, RoutedEventArgs e)
        {
            GetRichContent("/clock.swf", UriKind.Relative);
        }

        void myHTML_Click(object sender, RoutedEventArgs e)
        {
            GetRichContent("http://cn.bing.com", UriKind.Absolute);
        }

        //获取Rich Content
        void GetRichContent(string uri, UriKind uk)
        {
            Container.Children.Clear();
            ControlHtmlHost chtml = new ControlHtmlHost();
            HtmlHost hh = chtml.FindName("htmlHost") as HtmlHost;
            hh.SourceUri = new Uri(uri, uk);
            Container.Children.Add(chtml);
        }
    }
}
