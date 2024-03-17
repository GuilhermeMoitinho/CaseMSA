using CaseMSA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaseMSA.Infrastructure.EntityConfiguration
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(m => m.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(m => m.LastName).HasMaxLength(100).IsRequired();
            builder.Property(m => m.Gender).HasMaxLength(10).IsRequired();
            builder.Property(m => m.Email).HasMaxLength(150).IsRequired();
            builder.Property(m => m.IsActive).IsRequired();

            builder.HasData(
                new Member(Guid.NewGuid(), "Guilherme", 
                                           "Moitinho", 
                                           "Masculino", 
                                           "guilhermemoitinho3165@gmail.com", 
                                           true),

                new Member(Guid.NewGuid(), "Adriano", 
                                           "Caldeira", 
                                           "Masculino", 
                                           "adrianocaldeiramsa@gmail.com", 
                                           true)
            );
        }
    }
}
