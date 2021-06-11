
using Data.CosmosDb.Models;
using Microsoft.EntityFrameworkCore;


namespace Data.CosmosDb
{
    public class OptionTraderContext : DbContext
    {
        public DbSet<OptionTransaction> Transactions { get; set; }
        public OptionTraderContext(){ }     
    }
    
}