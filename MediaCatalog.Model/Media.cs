using System;
using System.Collections.Generic;

namespace MediaCatalog.Model
{
    public class Media
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Summary { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public bool? HasBeenReviewed { get; set; }
        public bool? HasBeenPurchased { get; set; }
        public bool? WasDonated { get; set; }

        public byte Thumbnail { get; set; }
        public int? MediaTypeId { get; set; }
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public virtual MediaType MediaType { get; set; }
        public virtual ICollection<Staff> StaffList { get; set; }
    }
}