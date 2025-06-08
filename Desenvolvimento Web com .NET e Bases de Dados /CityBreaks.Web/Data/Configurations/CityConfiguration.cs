
namespace CityBreaks.Web.Data.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(c => c.Name)
                   .HasMaxLength(100); 
            builder.Property(c => c.CountryId)
                   .HasColumnName("CountryId"); 

            builder.HasData(
                new City { Id = 1, Name = "São Paulo", CountryId = 1 }, // Brasil
                new City { Id = 2, Name = "Rio de Janeiro", CountryId = 1 }, // Brasil
                new City { Id = 3, Name = "New York", CountryId = 2 }, // EUA
                new City { Id = 4, Name = "Los Angeles", CountryId = 2 }, // EUA
                new City { Id = 5, Name = "Vancouver", CountryId = 3 }, // Canadá
                new City { Id = 6, Name = "London", CountryId = 4 }, // Reino Unido
                new City { Id = 7, Name = "Manchester", CountryId = 4 } // Reino Unido
            );
        }
    }
}