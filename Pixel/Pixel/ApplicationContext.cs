using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Pixel
{
    class ApplicationContext : DbContext
    {
        public DbSet<VideoCard> VideoCards { get; set; }
        public DbSet<TradeTransaction> TradeTransactions { get; set; }
        public ApplicationContext() : base("DefaultConnection") { }
    }
}
