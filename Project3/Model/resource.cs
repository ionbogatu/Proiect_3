namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class resource
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public resource()
        {
            resource_eav = new HashSet<resource_eav>();
        }

        public int Id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string fullpath { get; set; }

        [Required]
        public string description { get; set; }

        public bool is_deleted { get; set; }

        public DateTime created_at { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<resource_eav> resource_eav { get; set; }
    }
}
