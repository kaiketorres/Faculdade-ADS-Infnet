
namespace CityBreaks.Web.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(c => c.CountryName)
                   .HasMaxLength(100); // Exemplo de configuração que você já deve ter
            builder.Property(c => c.CountryCode)
                   .HasMaxLength(3); // Adicionei um HasMaxLength para CountryCode, se não tiver

            builder.HasData(
                new Country { Id = 1, CountryCode = "BRA", CountryName = "Brasil" },
                new Country { Id = 2, CountryCode = "USA", CountryName = "Estados Unidos" },
                new Country { Id = 3, CountryCode = "CAN", CountryName = "Canadá" },
                new Country { Id = 4, CountryCode = "GBR", CountryName = "Reino Unido" }
            );
        }
    }
}