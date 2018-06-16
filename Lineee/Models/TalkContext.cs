using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lineee.Models
{
    public class TalkContext : DbContext
    {
        public DbSet<Talk> Talk { get; set; }

        public TalkContext(DbContextOptions<TalkContext> options) : base(options)
        {

        }
    }
}
