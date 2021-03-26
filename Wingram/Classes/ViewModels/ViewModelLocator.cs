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

        public ViewModelLocator()
        {
            _container = InstaContainer.Current;
        }
        public async Task ConfigureNewAccount()
        {
            using var context = new WingramContext();
            var entityEntry = await context.Account.AddAsync(new Instagram.Classes.Account());
            await context.SaveChangesAsync();
            Configure(entityEntry.Entity.Id);
        }
        public async void LoadSessionsAsync()
        {
            using var context = new WingramContext();
            foreach (var account in await context.Account.ToListAsync())
            {
                Configure(account.Id);
            }
        }
        private IContainer Configure(int id)
        {
            return _container.Build(id, (builder, session) =>
            {
                builder.RegisterType<InstagramService>().As<IInstagramService>().SingleInstance();
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
