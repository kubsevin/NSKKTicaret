namespace NSKKTicaret.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Picture
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Picture()
        {
            Brands = new HashSet<Brand>();
            Categories = new HashSet<Category>();
        }

        public int id { get; set; }

        [StringLength(250)]
        public string LargePath { get; set; }

        [StringLength(250)]
        public string MediumPath { get; set; }

        [StringLength(250)]
        public string SmallPath { get; set; }

        public bool? IsDefault { get; set; }

        public byte? SequenceNumber { get; set; }

        public int? ProductID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Brand> Brands { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> Categories { get; set; }

        public virtual Product Product { get; set; }
    }
}
