using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wingram.Classes.ViewModels;
using Wingram.Enums;

namespace Wingram.Classes.Commons
{
    public class PopupMessage
    {
        private static PopupMessageViewModel _popupMessageViewModel;
        private static TaskCompletionSource<(ContentDialogResultEnum, string)> _dialogTaskCompletionSource;

        public static async Task<(ContentDialogResultEnum, string)> ShowAsync(string message, string title = null, string primary = null, string secondary = null, string primaryParameter = null, string secondaryParameter = null)
        {
            _popupMessageViewModel = InstaContainer.Current.Resolve<PopupMessageViewModel>();
            _dialogTaskCompletionSource = new TaskCompletionSource<(ContentDialogResultEnum, string)>();

            _popupMessageViewModel.Message = message;
            _popupMessageViewModel.Title = title;
            _popupMessageViewModel.TaskCompletionSource = _dialogTaskCompletionSource;
            _popupMessageViewModel.DialogVisibility = System.Windows.Visibility.Visible;
            _popupMessageViewModel.PrimaryButtonText = primary ?? string.Empty;
            _popupMessageViewModel.SecondaryButtonText = secondary ?? string.Empty;

            _popupMessageViewModel.PrimaryButtonParameter = primaryParameter;
            _popupMessageViewModel.SecondaryButtonParameter = secondaryParameter;

            _popupMessageViewModel.SecondaryButtonVisibility = secondary == null ? Visibility.Collapsed : Visibility.Visible;
            var result = await _dialogTaskCompletionSource.Task;
            _popupMessageViewModel.DialogVisibility = System.Windows.Visibility.Collapsed;

            return result;
        }


        public static async Task<(ContentDialogResultEnum, string)> ShowAsync(string message, string title, List<Instagram.Classes.Button> buttons)
        {
            _popupMessageViewModel = InstaContainer.Current.Resolve<PopupMessageViewModel>();
            _dialogTaskCompletionSource = new TaskCompletionSource<(ContentDialogResultEnum, string)>();

            _popupMessageViewModel.Message = message;
            _popupMessageViewModel.Title = title;
            _popupMessageViewModel.TaskCompletionSource = _dialogTaskCompletionSource;
            _popupMessageViewModel.DialogVisibility = System.Windows.Visibility.Visible;

            if (buttons != null)
            {

                _popupMessageViewModel.PrimaryButtonText = buttons[0]?.Title ?? "Ok";
                _popupMessageViewModel.PrimaryButtonParameter = buttons[0]?.Action ?? null;

                if (buttons[1] != null)
                {
                    _popupMessageViewModel.SecondaryButtonText = buttons[1].Title ?? string.Empty;

                    _popupMessageViewModel.SecondaryButtonParameter = buttons[1].Action ?? null;

                    _popupMessageViewModel.SecondaryButtonVisibility = Visibility.Visible;
                }
                else _popupMessageViewModel.SecondaryButtonVisibility = Visibility.Collapsed;
            }


            var result = await _dialogTaskCompletionSource.Task;
            _popupMessageViewModel.DialogVisibility = System.Windows.Visibility.Collapsed;

            return result;
        }
    }
}
