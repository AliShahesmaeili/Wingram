using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wingram.Views.Controls
{
    /// <summary>
    /// Interaction logic for ShadowControl.xaml
    /// </summary>
    /// 
    //[ContentProperty("InnerContent")]
    public partial class ShadowControl : Grid
    {
        public ShadowControl()
        {
            InitializeComponent();
            //BackgroundShadow = new LinearGradientBrush(Color.FromArgb(1, 244, 246, 247), Color.FromArgb(1, 238, 239, 240), new Point(0.5, 0), new Point(0.5, 1));
        }

         public static readonly DependencyProperty InnerContentProperty =
        DependencyProperty.Register("InnerContent", typeof(object), typeof(ShadowControl));

        public static readonly DependencyProperty ShadowDepthProperty =
      DependencyProperty.Register("ShadowDepthContent", typeof(double), typeof(ShadowControl),
        new PropertyMetadata(10.0));

        public static readonly DependencyProperty BackgroundShadowProperty =
     DependencyProperty.Register("BackgroundShadow", typeof(Brush), typeof(ShadowControl),
       new PropertyMetadata(new LinearGradientBrush(Color.FromArgb(1, 244, 246, 247), Color.FromArgb(1, 238, 239, 240), new Point(0.5, 0), new Point(0.5, 1))));
        private object innerContent;
        public object InnerContent
        {
            get { return (object)GetValue(InnerContentProperty); }
            set { SetValue(InnerContentProperty, value); }
        }
        public double ShadowDepth
        {
            get => (double)GetValue(ShadowDepthProperty);
            set => SetValue(ShadowDepthProperty, value);
        }
        public Brush BackgroundShadow
        {
            get => (Brush)GetValue(BackgroundShadowProperty);
            set => SetValue(BackgroundShadowProperty, value);
        }
    }
}
