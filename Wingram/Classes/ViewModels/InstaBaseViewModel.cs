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
        public InstaBaseViewModel(IInstagramService instagramService)
        {
            _instagramService = instagramService;
        }

        public IInstagramService InstagramService => _instagramService;
    }
}
