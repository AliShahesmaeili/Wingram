using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wingram.Enums;
using Wingram.Interfaces;
using Wingram.Views.Controls;

namespace Wingram.Classes.ViewModels
{
    public class ApplicationViewModel : ViewModelBase
    {
        #region Privates
        private bool isLoding;
        private object frameContent;
        private Dictionary<Type, InstaPage> pageHistories;
        #endregion

        #region Publics
        public bool IsLoading
        {
            get => isLoding;
            set => Set(ref isLoding, value);
        }
        public object FrameContent
        {
            get => frameContent;
            set => Set(ref frameContent, value);
        }
        #endregion

        #region Constractors
        public ApplicationViewModel(IInstagramService instagramService)
        {
            pageHistories = new Dictionary<Type, InstaPage>();
        }
        #endregion

        #region Functions
        public void Navigate(Type instaPageType, bool newPage = true, Dictionary<string, object> parameters = null)
        {
            var pageLoadEnum = PageLoadEnum.New;
            InstaPage instaPage = null;
            if (newPage)
            {
                FrameContent = instaPage = Activator.CreateInstance(instaPageType) as InstaPage;
                pageHistories.Add(instaPageType, instaPage);
            }
            else if (pageHistories.ContainsKey(instaPageType))
            {
                FrameContent = instaPage = pageHistories[instaPageType];
                pageLoadEnum = PageLoadEnum.Refresh;
            }
            else
            {
                FrameContent = instaPage = Activator.CreateInstance(instaPageType) as InstaPage;
                pageHistories.Add(instaPageType, instaPage);
            }


            instaPage.PageLoad(pageLoadEnum, parameters);
        }
        #endregion
    }
}
