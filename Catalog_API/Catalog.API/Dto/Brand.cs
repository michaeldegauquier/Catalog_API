namespace Catalog.API.Dto
{
    public class Brand
    {
        public string key { get; set; }
        public string name { get; set; }
        public string logoUrl { get; set; }
        public string logoLargeUrl { get; set; }
        public Brandfamily brandFamily { get; set; }
        public string shopUrl { get; set; }
    }
}
