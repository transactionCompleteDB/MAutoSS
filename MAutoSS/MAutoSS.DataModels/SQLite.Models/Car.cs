using System.Collections.Generic;

namespace MAutoSS.DataModels.SQLite.Models
{
     public class Car
    {
        private ICollection<ServiceInfo> serviceInfo;

        public Car()
        {
            this.serviceInfo = new HashSet<ServiceInfo>();
        }

        public int Id { get; set; }

        public int VIN { get; set; }

        public virtual ICollection<ServiceInfo> ServiceInfo
        {
            get { return this.serviceInfo; }
            set { this.serviceInfo = value; }
        }
    }
}
