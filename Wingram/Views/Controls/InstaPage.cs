using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Wingram.Views.Controls
{
    public class InstaPage : Page
    {
        public InstaPage()
        {
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                FlowDirection = Classes.Constants.ApplicationFlowDirection;
                FontFamily = Classes.Constants.ApplicationFontFamily;
            }
        }
    }
}
