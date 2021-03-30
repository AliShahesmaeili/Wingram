using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Wingram.Enums;

namespace Wingram.Views.Controls
{
    public abstract class InstaPage : Page
    {
        public static DependencyProperty ContentPageProperty =
    DependencyProperty.Register("ContentPage", typeof(object), typeof(InstaPage));
        public object ContentPage
        {
            get => GetValue(ContentPageProperty);
            set => SetValue(ContentPageProperty, value);
        }
        public InstaPage()
        {
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                FlowDirection = Classes.Constants.ApplicationFlowDirection;
                FontFamily = Classes.Constants.ApplicationFontFamily;
            }
            Loaded += InstaPage_Loaded;
        }

        private void InstaPage_Loaded(object sender, RoutedEventArgs e)
        {
            var transitioningContent = new TransitioningContent();
            transitioningContent.Content = ContentPage;
            transitioningContent.RunHint = TransitioningContentRunHint.All;
            transitioningContent.OpeningEffects.Add(new TransitionEffect(TransitionEffectKind.FadeIn));
            transitioningContent.OpeningEffects.Add(new TransitionEffect(TransitionEffectKind.SlideInFromLeft));
            Content = transitioningContent;
        }

        public virtual void PageLoad(PageLoadEnum pageLoadEnum, Dictionary<string, object> parameters)
        {
           
        }
    }
}
