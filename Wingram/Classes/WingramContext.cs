using Instagram.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wingram.Classes
{
    public class WingramContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
          => options.UseSqlite(@"Data Source=C:\Users\alish\Desktop\New folder\Wingram.db");

        public DbSet<Account> Account { get; set; }
    }
}
