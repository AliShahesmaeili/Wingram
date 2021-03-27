using Autofac;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wingram.Classes.Commons;
using Wingram.Classes.Services;
using Wingram.Interfaces;

namespace Wingram.Classes.ViewModels
{
    public class ViewModelLocator
    {
        private InstaContainer _container;
        private int num = 1;
        public ViewModelLocator()
        {
            _container = InstaContainer.Current;
        }
        public async Task ConfigureNewAccount()
        {
            using var context = new WingramContext();
            var entityEntry = await context.Account.AddAsync(new Instagram.Classes.Account());
            await context.SaveChangesAsync();
            Configure(num + 1, entityEntry.Entity.Id);
        }
        public async void LoadSessions()
        {
            using var context = new WingramContext();
            var accounts = await context.Account.ToListAsync();

            foreach (var account in accounts)
            {
                Configure(num, account.Id);
                num++;
            }
            if (accounts.Count == 0)
                await ConfigureNewAccount();
        }
        private IContainer Configure(int number, int accountId)
        {
            return _container.Build(number, (builder, session) =>
            {
                builder.RegisterType<InstagramService>().As<IInstagramService>().WithParameter("accountId", accountId).SingleInstance();
                builder.RegisterType<InstaBaseViewModel>().SingleInstance();
                builder.RegisterType<LoginViewModel>().SingleInstance();
                builder.RegisterType<PopupMessageViewModel>().SingleInstance();
                builder.RegisterType<ApplicationViewModel>().SingleInstance();


                return builder.Build();
            });
        }


        public LoginViewModel LoginViewModel => InstaContainer.Current.Resolve<LoginViewModel>();
        public PopupMessageViewModel PopupMessageViewModel => InstaContainer.Current.Resolve<PopupMessageViewModel>();
        public ApplicationViewModel ApplicationViewModel => InstaContainer.Current.Resolve<ApplicationViewModel>();

    }
}
