using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wingram.Classes.Commons;
using Wingram.Enums;

namespace Wingram.Classes.ViewModels
{
    public class PopupMessageViewModel : BindableBase
    {
        #region Constructors
        public PopupMessageViewModel()
        {
            PrimaryCommand = new RelayCommand(PrimaryExecute);
            SecondaryCommand = new RelayCommand(SecondaryExecute);
        }
        #endregion

        public RelayCommand PrimaryCommand { get; }
        public RelayCommand SecondaryCommand { get; }


        private TaskCompletionSource<(ContentDialogResultEnum, string)> taskCompletionSource;
        public TaskCompletionSource<(ContentDialogResultEnum, string)> TaskCompletionSource
        {
            get => taskCompletionSource;
            set => Set(ref taskCompletionSource, value);
        }

        private string message;
        public string Message
        {
            get => message;
            set => Set(ref message, value);

        }
        private Visibility dialogVisibility = Visibility.Collapsed;
        public Visibility DialogVisibility
        {
            get => dialogVisibility;
            set => Set(ref dialogVisibility, value);
        }
        private string primaryButtonText;
        public string PrimaryButtonText
        {
            get => primaryButtonText;
            set => Set(ref primaryButtonText, value);
        }

        private string secondaryButtonText;
        public string SecondaryButtonText
        {
            get => secondaryButtonText;
            set => Set(ref secondaryButtonText, value);
        }

        private string secondaryButtonParameter;
        public string SecondaryButtonParameter
        {
            get => secondaryButtonParameter;
            set => Set(ref secondaryButtonParameter, value);
        }
        private string primaryButtonParameter;
        public string PrimaryButtonParameter
        {
            get => primaryButtonParameter;
            set => Set(ref primaryButtonParameter, value);
        }

        private Visibility secondaryButtonVisibility = Visibility.Collapsed;
        public Visibility SecondaryButtonVisibility
        {
            get => secondaryButtonVisibility;
            set => Set(ref secondaryButtonVisibility, value);
        }

        private string title;
        public string Title
        {
            get=>  title;
            set => Set(ref title, value);
        }
       
        private void PrimaryExecute()
        {
            TaskCompletionSource.TrySetResult((ContentDialogResultEnum.Primary, PrimaryButtonParameter));
        }
        private void SecondaryExecute()
        {
            TaskCompletionSource.TrySetResult((ContentDialogResultEnum.Secondary, SecondaryButtonParameter));
        }
    }
}
