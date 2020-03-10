using System;

namespace Catalog.API.Dto
{
    public class Product
    {
        public string id { get; set; }
        public string modelId { get; set; }
        public string name { get; set; }
        public string shopUrl { get; set; }
        public string color { get; set; }
        public bool available { get; set; }
        public string season { get; set; }
        public string seasonYear { get; set; }
        public DateTime activationDate { get; set; }
        public string[] additionalInfos { get; set; }
        public string[] genders { get; set; }
        public string[] ageGroups { get; set; }
        public Brand brand { get; set; }
        public string[] categoryKeys { get; set; }
        public Attribute[] attributes { get; set; }
        public Unit[] units { get; set; }
        public Media media { get; set; }
    }
}
