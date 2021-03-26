using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wingram.Classes.ViewModels
{
    public class ApplicationViewModel : ViewModelBase
    {
        #region Privates
        private bool isLoding;
        #endregion

        #region Publics
        public bool IsLoading
        {
            get => isLoding;
            set => Set(ref isLoding, value);
        }
        #endregion

        #region Constractors

        #endregion
    }
}
