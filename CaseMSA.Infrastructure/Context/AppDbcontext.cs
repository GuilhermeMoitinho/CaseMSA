using CaseMSA.Domain.Entities;
using CaseMSA.Infrastructure.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace CaseMSA.Infrastructure.Context
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options){}
        public DbSet<Member> Members { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        =>  modelBuilder.ApplyConfiguration(new MemberConfiguration());
            
        
    }
}
