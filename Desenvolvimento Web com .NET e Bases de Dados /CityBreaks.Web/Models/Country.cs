namespace CityBreaks.Web.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryCode { get; set; } = string.Empty;
        public string CountryName { get; set; } = string.Empty;

       
        public List<City> Cities { get; set; } = new();
    }
}
