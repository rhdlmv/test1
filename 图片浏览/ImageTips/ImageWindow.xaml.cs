using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ImageTips
{
    public partial class ImageWindow : ChildWindow
    {
        //private bool _contentLoaded;
        //internal ContentControl Content;
        //internal Grid LayoutRoot;
        private bool m_IsMouseLeftButtonDown;
        private Point m_PreviousMousePoint;

        public ImageWindow()
        {
            this.InitializeComponent();
            this.Closed += ImageWindow_Closed;
        }

        void ImageWindow_Closed(object sender, EventArgs e)
        {
            TransformGroup group = this.LayoutRoot.Resources["ImageTransformResource"] as TransformGroup;
            Point point2 = group.Inverse.Transform(m_PreviousMousePoint);
            TranslateTransform transform = group.Children[1] as TranslateTransform;
            ScaleTransform transform2 = group.Children[0] as ScaleTransform;
            transform2.ScaleX = 1; transform2.ScaleY = 1;
            transform.X = -1.0 * ((point2.X * transform2.ScaleX) - m_PreviousMousePoint.X);
            transform.Y = -1.0 * ((point2.Y * transform2.ScaleY) - m_PreviousMousePoint.Y);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            //base.set_DialogResult(false);
        }

        private void contentControl1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ContentControl control = sender as ContentControl;
            if (control != null)
            {
                control.CaptureMouse();
                this.m_IsMouseLeftButtonDown = true;
                this.m_PreviousMousePoint = e.GetPosition(control);
            }
        }

        private void contentControl1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ContentControl control = sender as ContentControl;
            if (control != null)
            {
                control.ReleaseMouseCapture();
                this.m_IsMouseLeftButtonDown = false;
            }
        }

        private void contentControl1_MouseMove(object sender, MouseEventArgs e)
        {
            ContentControl rectangle = sender as ContentControl;
            if ((rectangle != null) && this.m_IsMouseLeftButtonDown)
            {
                this.DoImageMove(rectangle, e);
            }
        }

        private void contentControl1_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            ContentControl control = sender as ContentControl;
            if (control != null)
            {
                TransformGroup group = this.LayoutRoot.Resources["ImageTransformResource"] as TransformGroup;
                Point position = e.GetPosition(control);
                float scale = (e.Delta * 2f) / 1200f;
                this.ZoomImage(group, position, scale);
            }
        }

        private void DoImageMove(ContentControl rectangle, MouseEventArgs e)
        {
            TransformGroup group = this.LayoutRoot.Resources["ImageTransformResource"] as TransformGroup;
            TranslateTransform transform = group.Children[1] as TranslateTransform;
            //TranslateTransform transform = group.get_Children().get_Item(1) as TranslateTransform;
            Point position = e.GetPosition(rectangle);
            transform.X = transform.X + position.X - this.m_PreviousMousePoint.X;
            transform.Y = transform.Y + position.Y - this.m_PreviousMousePoint.Y;
            //transform.set_X(transform.get_X() + (position.get_X() - this.m_PreviousMousePoint.get_X()));
            //transform.set_Y(transform.get_Y() + (position.get_Y() - this.m_PreviousMousePoint.get_Y()));
            this.m_PreviousMousePoint = position;
        }

        //[DebuggerNonUserCode]
        //public void InitializeComponent()
        //{
        //    if (!this._contentLoaded)
        //    {
        //        this._contentLoaded = true;
        //        Application.LoadComponent(this, new Uri("/ImageTips;component/ImageWindow.xaml", 2));
        //        this.LayoutRoot = (Grid)base.FindName("LayoutRoot");
        //        this.Content = (ContentControl)base.FindName("Content");
        //    }
        //}

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public void setImage(string uriStr)
        {
            Uri uri = new Uri(uriStr);
            Image image2 = new Image();
            BitmapImage image3 = new BitmapImage();
            image3.UriSource = uri;
            image2.Source = image3;
            //image2.Width = 570.0;
            //image2.Height = 360.0;
            image2.RenderTransform = this.LayoutRoot.Resources["ImageTransformResource"] as TransformGroup;
            //TODO:
            //image2.HorizontalAlignment = HorizontalAlignment.Center;
            //image2.VerticalAlignment = VerticalAlignment.Center;

            //image3.set_UriSource(uri);
            //image2.set_Source(image3);
            //image2.set_Width(570.0);
            //image2.set_RenderTransform(this.LayoutRoot.Resources["ImageTransformResource"] as TransformGroup);
            //image2.set_Height(360.0);
            //image2.set_HorizontalAlignment(1);
            //image2.set_VerticalAlignment(1);
            Image image = image2;
            this.Content.Content = image;//.set_Content(image);
        }

        private void ZoomImage(TransformGroup group, Point point, float scale)
        {
            Point point2 = group.Inverse.Transform(point);
            //Point point2 = group.get_Inverse().Transform(point);

            TranslateTransform transform = group.Children[1] as TranslateTransform;
            ScaleTransform transform2 = group.Children[0] as ScaleTransform;
            //TranslateTransform transform = group.get_Children().get_Item(1) as TranslateTransform;
            //ScaleTransform transform2 = group.get_Children().get_Item(0) as ScaleTransform;

            double aimScale = transform2.ScaleX + scale;
            transform2.ScaleX = transform2.ScaleY = aimScale < 0.8 ? 0.8 : (aimScale > 3.0 ? 3.0 : aimScale);
            //if (aimScale < 0.8)
            //{
            //    transform2.ScaleX = 0.8;
            //    transform2.ScaleY = 0.8;
            //}
            //else if (aimScale > 3.0)
            //{
            //    transform2.ScaleX = 3.0;
            //    transform2.ScaleY = 3.0;
            //}
            //else
            //{
            //    transform2.ScaleX = aimScale;
            //    transform2.ScaleY = aimScale;
            //}
            transform.X = -1.0 * ((point2.X * transform2.ScaleX) - point.X);
            transform.Y = -1.0 * ((point2.Y * transform2.ScaleY) - point.Y);
            //if ((transform2.ScaleX + scale) < 0.8)
            //{
            //    transform2.ScaleX = 0.8;
            //    transform2.ScaleY = 0.8;
            //    transform.X = -1.0 * ((point2.X * transform2.ScaleX) - point.X);
            //    transform.Y = -1.0 * ((point2.Y * transform2.ScaleY) - point.Y);
            //}
            //else
            //{
            //    transform2.ScaleX = transform2.ScaleX + scale;
            //    transform2.ScaleY = transform2.ScaleY + scale;
            //    transform.X = -1.0 * ((point2.X * transform2.ScaleX) - point.X);
            //    transform.Y = -1.0 * ((point2.Y * transform2.ScaleY) - point.Y);
            //}

            //oldCode
            //if ((transform2.get_ScaleX() + scale) < 0.8)
            //{
            //    transform2.set_ScaleX(0.8);
            //    transform2.set_ScaleY(0.8);
            //    transform.set_X(-1.0 * ((point2.get_X() * transform2.get_ScaleX()) - point.get_X()));
            //    transform.set_Y(-1.0 * ((point2.get_Y() * transform2.get_ScaleY()) - point.get_Y()));
            //}
            //else
            //{
            //    transform2.set_ScaleX(transform2.get_ScaleX() + scale);
            //    transform2.set_ScaleY(transform2.get_ScaleY() + scale);
            //    transform.set_X(-1.0 * ((point2.get_X() * transform2.get_ScaleX()) - point.get_X()));
            //    transform.set_Y(-1.0 * ((point2.get_Y() * transform2.get_ScaleY()) - point.get_Y()));
            //}
        }
    }
}

