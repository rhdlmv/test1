using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ImageTips
{
    [TemplatePart(Name = "BackBtn", Type = typeof(HyperlinkButton)), TemplatePart(Name = "MainFrame", Type = typeof(Canvas)), TemplatePart(Name = "PanelHost", Type = typeof(StackPanel)), TemplatePart(Name = "NextBtn", Type = typeof(HyperlinkButton)), TemplatePart(Name = "Panel", Type = typeof(Grid))]
    public class ImageTips : Control
    {
        private HyperlinkButton BackBtn;
        public static readonly DependencyProperty ButtonRectProperty = DependencyProperty.Register("ButtonRect", typeof(double), typeof(ImageTips), new PropertyMetadata(null));
        //public static readonly DependencyProperty ImageUrisProperty = DependencyProperty.Register("ImageUris", typeof(string), typeof(ImageTips), new PropertyMetadata(new PropertyChangedCallback(null, OnImageUrisPropertyChanged)));
        public static readonly DependencyProperty ImageUrisProperty = DependencyProperty.Register("ImageUris", typeof(string), typeof(ImageTips), new PropertyMetadata(null, OnImageUrisPropertyChanged));
        private int imgSlide = 0;
        private Canvas MainFrame;
        private HyperlinkButton NextBtn;
        private int noimgMoved = 1;
        private Grid Panel;
        private StackPanel PanelHost;
        private ImageWindow window;

        public ImageTips()
        {
            this.DefaultStyleKey = typeof(ImageTips);
            //base.set_DefaultStyleKey(typeof(ImageTips.ImageTips));
        }

        private static void OnImageUrisPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ImageTips tips = d as ImageTips;
            if (tips.PanelHost != null)
            {
                // tips.PanelHost.get_Children().Clear();
                //object obj2 = e.get_OldValue();
                //if (e.get_NewValue() != null)
                tips.PanelHost.Children.Clear();
                object obj2 = e.OldValue;
                if (e.NewValue != null)
                {
                    tips.imgSlide = 0;
                    tips.noimgMoved = 1;
                    tips.PanelHost.RenderTransform.SetValue(TranslateTransform.YProperty, 0.0);
                    tips.InitImages();
                }
                else
                {
                    tips.Visibility = Visibility.Collapsed;
                    //tips.set_Visibility(1);
                }
            }
        }

        public double ButtonRect
        {
            get
            {
                return (double)base.GetValue(ButtonRectProperty);
            }
            set
            {
                base.SetValue(ButtonRectProperty, value);
            }
        }

        public ObservableCollection<Image> Images { get; set; }

        public string ImageUris
        {
            get
            {
                return (string)base.GetValue(ImageUrisProperty);
            }
            set
            {
                base.SetValue(ImageUrisProperty, value);
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.PanelHost = base.GetTemplateChild("PanelHost") as StackPanel;
            this.BackBtn = base.GetTemplateChild("BackBtn") as HyperlinkButton;
            this.NextBtn = base.GetTemplateChild("NextBtn") as HyperlinkButton;
            this.MainFrame = base.GetTemplateChild("MainFrame") as Canvas;
            this.IntiStyle();
            this.InitImages();
            this.initBtnEvents();
        }

        private void initBtnEvents()
        {
            if (this.BackBtn != null)
            {
                this.BackBtn.Click += BackBtn_Click;// new RoutedEventHandler(this, (IntPtr)this.Back_Click);
                //this.BackBtn.add_Click(new RoutedEventHandler(this, (IntPtr)this.Back_Click));
            }
            if (this.NextBtn != null)
            {
                this.NextBtn.Click += NextBtn_Click;
                // this.NextBtn.add_Click(new RoutedEventHandler(this, (IntPtr)this.Next_Click));
            }
        }

        void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.PanelHost.Children.Count != this.noimgMoved)
            {
                this.noimgMoved++;
                this.imgSlide -= (int)this.Width-20;
                Animation.SlideImageEffect(this.PanelHost, (double)this.imgSlide).Begin();
            }
        }

        void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.noimgMoved != 1)
            {
                this.noimgMoved--;
                this.imgSlide += (int)this.Width-20;
                //this.imgSlide += (int)(base.get_Height() - (this.ButtonRect * 2.0));
                Animation.SlideImageEffect(this.PanelHost, (double)this.imgSlide).Begin();
            }
        }

        private void InitImages()
        {
            if ((this.ImageUris != null) && (this.ImageUris != ""))
            {
                this.Visibility = Visibility.Visible;
                //base.set_Visibility(0);
                string[] strArray = this.ImageUris.Split(new char[] { ';' });
                foreach (string str in strArray)
                {
                    if (!(str == ""))
                    {
                        Uri uri = new Uri(str);
                        Image image2 = new Image();
                        BitmapImage image3 = new BitmapImage();
                        image3.UriSource = uri;
                        image2.Source = image3;
                        image2.Width = this.Width - 20.0;
                        image2.Height = this.Height
;                        //image3.set_UriSource(uri);
                        //image2.set_Source(image3);
                        //image2.set_Width(base.get_Width());
                        //image2.set_Height(base.get_Height() - (this.ButtonRect * 2.0));
                        Image image = image2;


                        image.MouseLeftButtonUp += image_MouseLeftButtonUp;
                        //image.add_MouseLeftButtonUp(new MouseButtonEventHandler(this, (IntPtr)this.Image_MouseLeftButtonUp));

                        this.PanelHost.Children.Add(image);
                        //this.PanelHost.get_Children().Add(image);
                    }
                }
            }
            else
            {
                this.PanelHost.Children.Clear();
                this.Visibility = Visibility.Collapsed;
                //this.PanelHost.get_Children().Clear();
                //base.set_Visibility(1);
            }
        }

        void image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            //e.set_Handled(true);
            Image image = sender as Image;
            BitmapImage image2 = image.Source as BitmapImage;
            if (this.window == null)
            {
                this.window = new ImageWindow();
            }
            this.window.setImage(image2.UriSource.AbsoluteUri);
            //this.window.setImage(image2.get_UriSource().get_AbsoluteUri());

            this.window.Show();
        }

        private void IntiStyle()
        {
            this.MainFrame.Height = this.Height - (this.ButtonRect * 2.0);
            RectangleGeometry geometry = new RectangleGeometry();
            geometry.Rect = new Rect(0.0, 0.0, this.Width, this.Height - (this.ButtonRect * 2.0));
            geometry.RadiusX = 5.0;
            geometry.RadiusY = 5.0;
            this.MainFrame.Clip = geometry;
            //this.MainFrame.set_Height(base.get_Height() - (this.ButtonRect * 2.0));
            //RectangleGeometry geometry = new RectangleGeometry();
            //geometry.set_Rect(new Rect(0.0, 0.0, base.get_Width(), base.get_Height() - (this.ButtonRect * 2.0)));
            //geometry.set_RadiusX(5.0);
            //geometry.set_RadiusY(5.0);
            //this.MainFrame.set_Clip(geometry);
        }

        //private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    e.Handled = true;
        //    //e.set_Handled(true);
        //    Image image = sender as Image;
        //    BitmapImage image2 = image.Source as BitmapImage;
        //    if (this.window == null)
        //    {
        //        this.window = new ImageWindow();
        //    }
        //    this.window.setImage(image2.UriSource.AbsoluteUri);
        //    //this.window.setImage(image2.get_UriSource().get_AbsoluteUri());

        //    this.window.Show();
        //}

        //private void Back_Click(object sender, RoutedEventArgs e)
        //{
        //    if (this.noimgMoved != 1)
        //    {
        //        this.noimgMoved--;
        //        this.imgSlide += (int)(this.Height - (this.ButtonRect * 2.0));
        //        //this.imgSlide += (int)(base.get_Height() - (this.ButtonRect * 2.0));
        //        Animation.SlideImageEffect(this.PanelHost, (double)this.imgSlide).Begin();
        //    }
        //}

        //private void Next_Click(object sender, RoutedEventArgs e)
        //{
        //    if (this.PanelHost.get_Children().get_Count() != this.noimgMoved)
        //    {
        //        this.noimgMoved++;
        //        this.imgSlide -= (int)(base.get_Height() - (this.ButtonRect * 2.0));
        //        Animation.SlideImageEffect(this.PanelHost, (double)this.imgSlide).Begin();
        //    }
        //}
    }
}

