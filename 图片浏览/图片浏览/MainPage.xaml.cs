using ImageTips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;

namespace 图片浏览
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            this.ImageTips.ImageUris = @"http://192.168.10.12/tourism_trunk/AttachmentService/Files/131227/9ecf765f-a20a-4aa1-9692-3ada8137f2c9.jpg;
                                         http://192.168.10.12/tourism_trunk/AttachmentService/Files/131227/6b9a834c-112b-4a38-a5a7-8ad1269025fb.jpg;
                                         http://192.168.10.12/tourism_trunk/AttachmentService/Files/131210/a292a73c-cff2-4206-b1cd-964c1e97dbed.png;
                                         http://192.168.10.12/tourism_trunk/AttachmentService/Files/131210/42d12291-d3b9-4084-881d-6ec7348b553d.jpg;
                                         http://192.168.10.12/tourism_trunk/AttachmentService/Files/131210/3e86120e-f694-40a2-8f78-1cb99fc4f36f.jpg;
                                         http://192.168.10.12/tourism_trunk/AttachmentService/Files/131209/f32b07d5-0d7a-4286-a6f8-30422cee6b03.png;
                                         http://192.168.10.12/tourism_trunk/AttachmentService/Files/131122/d0df4f14-c530-453e-bb8d-40842533883c.jpg;
                                         http://192.168.10.12/tourism_trunk/AttachmentService/Files/131204/0d389db8-9c82-40ed-9f93-2bf0ee2723f2.jpg;";
        }

        private void OnShowImageChildWindow(object sender, RoutedEventArgs e)
        {
            var view = new ImageWindow();
            view.setImage(@"http://192.168.10.12/tourism_trunk/AttachmentService/Files/131227/6b9a834c-112b-4a38-a5a7-8ad1269025fb.jpg");
            view.Show();
        }
    }
}
