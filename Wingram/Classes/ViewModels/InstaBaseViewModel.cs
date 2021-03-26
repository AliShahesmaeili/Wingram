using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wingram.Interfaces;

namespace Wingram.Classes.ViewModels
{
    public class InstaBaseViewModel : ViewModelBase
    {
        private readonly IInstagramService _instagramService;
        private readonly ApplicationViewModel _applicationViewModel;
        public InstaBaseViewModel(IInstagramService instagramService, ApplicationViewModel applicationViewModel)
        {
            _instagramService = instagramService;
            _applicationViewModel = applicationViewModel;
        }

        public IInstagramService InstagramService => _instagramService;
        public ApplicationViewModel ApplicationViewModel => _applicationViewModel;
    }
}
