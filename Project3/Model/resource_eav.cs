namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class resource_eav
    {
        public int Id { get; set; }

        public int resource_id { get; set; }

        public int attribute_id { get; set; }

        public int value_id { get; set; }

        public int resource_attribute_valuesId { get; set; }

        public int resourceId { get; set; }

        public int resource_attributes_Id { get; set; }

        public virtual resource_attribute_values resource_attribute_values { get; set; }

        public virtual resource_attributes resource_attributes { get; set; }

        public virtual resource resource { get; set; }
    }
}
