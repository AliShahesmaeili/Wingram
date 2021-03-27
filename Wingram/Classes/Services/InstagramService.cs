using Instagram.API;
using Instagram.API.Builder;
using Instagram.Classes;
using Microsoft.EntityFrameworkCore;
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
        int AccountId;
        public InstagramService(int accountId)
        {
            AccountId = accountId;
            Initialize();
        }

        private async void Initialize()
        {
            using var context = new WingramContext();
            instaApi = InstaApiBuilder.CreateBuilder().Build();
            var account = await context.Account.Include(a => a.DeviceInfo).FirstOrDefaultAsync(a => a.Id == AccountId);
            if (account.IsAuthenticated)
            {
                instaApi.LoadStateData(account);
            }
        }
        public IInstaApi InstagramApi()
        {
            return instaApi;
        }

        public async Task UpdateAccountAsync()
        {
            using var context = new WingramContext();
            var account = instaApi.GetStateData();
            account.Id = AccountId;
            context.Account.Update(account);
            await context.SaveChangesAsync();
        }
    }
}
