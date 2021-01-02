
namespace RentACar.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class rentacarEntities : DbContext
    {
        public rentacarEntities()
            : base("name=rentacarEntities")     // bağlantı adı rentacarentities, connection bağlantı adına karşılık gelecek
        {
        }
    
       
        // Veritabanına aktarılacak tablolar
        public virtual DbSet<announcements> announcements { get; set; }
        public virtual DbSet<cars> cars { get; set; }
        public virtual DbSet<reservations> reservations { get; set; }
        public virtual DbSet<admins> admins { get; set; }
    }
}
