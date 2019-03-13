namespace NSKKTicaret.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VariantOption
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VariantOption()
        {
            ProductVariants = new HashSet<ProductVariant>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string VariantOptionName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public int VariantTypeID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductVariant> ProductVariants { get; set; }

        public virtual VariantType VariantType { get; set; }
    }
}
