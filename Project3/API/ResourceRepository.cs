
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API
{
    public class ResourceRepository
    {
        private Model1 databaseEntities;

        public ResourceRepository()
        {
            databaseEntities = new Model1();
        }

        public List<resource> getActiveResources()
        {
            List<resource> resources;

            try
            {
                resources = databaseEntities.resources.Where((i) => i.is_deleted == false).ToList();
            }
            catch (ArgumentNullException)
            {
                resources = new List<resource>();
            }

            return resources;
        }

        public void saveResources(List<Dictionary<string, object>> resources)
        {
            foreach (var resource in resources)
            {
                resource res = new resource();

                if (resource.ContainsKey("id") && resource["id"] != null)
                {
                    res = databaseEntities.resources.Find(Convert.ToInt32(resource["id"]));
                    databaseEntities.Entry(res).State = System.Data.Entity.EntityState.Modified;

                    databaseEntities.resource_eav.RemoveRange(res.resource_eav);
                }
                else
                {
                    databaseEntities.Entry(res).State = System.Data.Entity.EntityState.Added;
                }

                res.name = resource["name"].ToString();
                res.description = resource["description"].ToString();
                res.fullpath = resource["imagePath"].ToString();
                res.is_deleted = false;
                res.created_at = (DateTime)resource["createdAt"];

                List<resource_eav> resourceEavCollection = SaveEavAttributes(res, resource["properties"]);

                res.resource_eav = resourceEavCollection;
            }

            databaseEntities.SaveChanges();
        }

        public void deleteResource(int id)
        {
            try
            {
                resource res = databaseEntities.resources.Where((r) => r.Id.Equals(id)).First();

                if (res != null)
                {
                    res.is_deleted = true;
                    databaseEntities.Entry(res).State = System.Data.Entity.EntityState.Modified;

                    databaseEntities.SaveChanges();
                }
            }
            catch (ArgumentNullException)
            {
                // intentionally ignored exception
            }
        }

        private List<resource_eav> SaveEavAttributes(resource res, object properties)
        {
            List<resource_eav> result = new List<resource_eav>();

            List<KeyValuePair<string, string>> props = (List<KeyValuePair<string, string>>)properties;

            foreach (var prop in props)
            {
                var resourceEav = new resource_eav();

                resource_attribute_values value = databaseEntities.resource_attribute_values.SingleOrDefault(a => a.value.ToLower().Equals(prop.Value));

                if (value == null)
                {
                    value = new resource_attribute_values();
                    value.value = prop.Value.ToLower();

                    databaseEntities.Entry(value).State = System.Data.Entity.EntityState.Added;
                }
                value.resource_eav.Add(resourceEav);

                resource_attributes attribute = databaseEntities.resource_attributes.SingleOrDefault(a => a.attribute.ToLower().Equals(prop.Key));

                if (attribute == null)
                {
                    attribute = new resource_attributes();
                    attribute.attribute = prop.Key.ToLower();

                    databaseEntities.Entry(attribute).State = System.Data.Entity.EntityState.Added;
                }
                attribute.resource_eav.Add(resourceEav);

                if (!attribute.resource_attribute_values.Contains(value))
                {
                    attribute.resource_attribute_values.Add(value);
                }

                result.Add(resourceEav);
            }

            return result;
        }
    }
}
