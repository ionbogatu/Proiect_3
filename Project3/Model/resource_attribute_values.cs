namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class resource_attribute_values
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public resource_attribute_values()
        {
            resource_eav = new HashSet<resource_eav>();
        }

        public int Id { get; set; }

        public int attribute_id { get; set; }

        [Required]
        public string value { get; set; }

        public int resource_attributesId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<resource_eav> resource_eav { get; set; }

        public virtual resource_attributes resource_attributes { get; set; }
    }
}
