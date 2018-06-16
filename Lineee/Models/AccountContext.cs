using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lineee.Models
{
    public class AccountContext : DbContext
    {
        public DbSet<Account> Account { get; set; }

        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {

        }
    }
}
