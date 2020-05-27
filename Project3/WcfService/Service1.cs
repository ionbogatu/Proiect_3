using API;
using Model;
using System.Collections.Generic;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public List<resource> getActiveResources()
        {
            ResourceRepository resourceRepository = new ResourceRepository();

            return resourceRepository.getActiveResources();
        }
    }
}
