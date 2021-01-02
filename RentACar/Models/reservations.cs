
namespace RentACar.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class reservations
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string city { get; set; }
        public string reservationtime { get; set; }
        public string cars { get; set; }
        public Nullable<bool> isclose { get; set; }
        public string reservationnot { get; set; }
        public string reservationadminnot { get; set; }
        public string reservationcode { get; set; }
    }
}
