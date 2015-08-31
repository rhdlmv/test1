using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace ImageTips
{
    public class Animation
    {
        public static Storyboard SlideImageEffect(UIElement controlToAnimate, double positionToMove)
        {
            DoubleAnimation animation = new DoubleAnimation();

            animation.Duration = new Duration(TimeSpan.FromSeconds(0.3));
            //animation.set_Duration(new Duration(TimeSpan.FromSeconds(0.3)));

            Storyboard storyboard = new Storyboard();

            storyboard.Duration = new Duration(TimeSpan.FromSeconds(0.3));
            //storyboard.set_Duration(new Duration(TimeSpan.FromSeconds(0.3)));

            storyboard.Children.Add(animation);
            //storyboard.get_Children().Add(animation);

            Storyboard.SetTarget(animation, controlToAnimate);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)", new object[0]));

            animation.To = new double?(positionToMove);
            //animation.set_To(new double?(positionToMove));
            return storyboard;
        }
    }
}

