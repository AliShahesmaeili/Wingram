using Instagram.API;
using Instagram.API.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wingram.Interfaces;

namespace Wingram.Classes.Services
{
    public class InstagramService : IInstagramService
    {
        private IInstaApi instaApi;
        public InstagramService()
        {
            Initialize();
        }

        private void Initialize()
        {
            instaApi = InstaApiBuilder.CreateBuilder().Build();
        }
        public IInstaApi InstagramApi()
        {
            return instaApi;
        }
    }
}
