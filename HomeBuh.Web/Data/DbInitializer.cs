using HomeBuh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBuh.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BuhContext context)
        {
            context.Database.EnsureCreated();

            if (context.Entries.Any())
            {
                return;
            }

            var accounts = new BuhAccount[]
                {
                    new BuhAccount{ ID = 1, Description = "Кошелек"},
                    new BuhAccount{ ID = 2, Description = "Сберкарта"}
                };

            foreach (var account in accounts)
            {
                context.BuhAccounts.Add(account);
            }
            context.SaveChanges();

            var entries = new Entry[]
                {
                    new Entry{ DateOperation = DateTime.Parse("2017-03-10"), BuhAccountID = 1, Description = "пирожки", Value=115},
                    new Entry{ DateOperation = DateTime.Parse("2017-03-09"), BuhAccountID = 1, Description = "пирожки", Value=70}
                };

            foreach (var entry in entries)
            {
                context.Entries.Add(entry);
            }
            context.SaveChanges();
        }
    }
}
