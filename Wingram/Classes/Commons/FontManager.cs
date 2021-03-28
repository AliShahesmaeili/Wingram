using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Wingram.Classes.Commons
{
    public class FontManager
    {
        public static Dictionary<string, FontFamily> FontFamilies = new()
        {
            { "Persian", new FontFamily("IranSans") },
            { "English", new FontFamily("Roboto") }
        };

        public static FontFamily GetSuitableFontFamily() => LocalizationManager.Instance.CurrentCulture.EnglishName switch
        {
            "Persian" => FontFamilies["Persian"],
            _ => FontFamilies["Roboto"],
        };
    }
}
