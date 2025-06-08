
namespace CityBreaks.Web.Data.Configurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.Property(p => p.Name)
                   .HasMaxLength(200); 
            builder.Property(p => p.PricePerNight)
                   .HasColumnType("decimal(18,2)"); 
            builder.Property(p => p.CityId)
                   .HasColumnName("CityId"); 

            builder.HasData(
                new Property { Id = 1, Name = "Apartamento Luxo Centro", PricePerNight = 250.00m, CityId = 1 }, 
                new Property { Id = 2, Name = "Hotel Copacabana Palace", PricePerNight = 800.00m, CityId = 2 }, 
                new Property { Id = 3, Name = "Studio Times Square", PricePerNight = 350.00m, CityId = 3 }, 
                new Property { Id = 4, Name = "Casa de Praia Malibu", PricePerNight = 1200.00m, CityId = 4 }, 
                new Property { Id = 5, Name = "Apto com Vista para o Mar", PricePerNight = 300.00m, CityId = 5 },
                new Property { Id = 6, Name = "Flat Próximo ao Big Ben", PricePerNight = 400.00m, CityId = 6 }, 
                new Property { Id = 7, Name = "Loft Moderno Shoreditch", PricePerNight = 320.00m, CityId = 6 }, 
                new Property { Id = 8, Name = "Casa de Férias Manchester", PricePerNight = 180.00m, CityId = 7 } 
            );
        }
    }
}