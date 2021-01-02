
namespace RentACar.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class cars
    {
        public int id { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string color { get; set; }
        public Nullable<int> km { get; set; }
        public Nullable<decimal> price { get; set; }
        public string period { get; set; }
        public string title { get; set; }
        public string img { get; set; }
        public string modelyear { get; set; }
        public Nullable<int> rank { get; set; }
    }
}
