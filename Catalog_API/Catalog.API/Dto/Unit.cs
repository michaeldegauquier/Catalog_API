namespace Catalog.API.Dto
{
    public class Unit
    {
        public string id { get; set; }
        public string size { get; set; }
        public Price price { get; set; }
        public Price originalPrice { get; set; }
        public bool available { get; set; }
        public int stock { get; set; }
    }
}
