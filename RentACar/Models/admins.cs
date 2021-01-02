
namespace RentACar.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class admins
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string token { get; set; }
    }
}
