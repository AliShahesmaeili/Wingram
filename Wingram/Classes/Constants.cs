using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wingram.Classes.Commons;

namespace Wingram.Classes
{
    public class Constants
    {
        public static string ApplicationDirectory => Directory.GetCurrentDirectory();
        public static FlowDirection ApplicationFlowDirection => LocalizationManager.Instance.CurrentCulture.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
    }
}
