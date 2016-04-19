using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DDSTP.Domain.Entities;

namespace DDSTP.Domain
{
    public class CGPPOI : IPOI
    {
        [Key]
        public int ID { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Name { get; set; }
        public virtual Street MainStreet { get; set; }
        public int? Number { get; set; }
        public List<Service> Services { get; set; }

        public TypeOfPOI Type
        {
            get { return TypeOfPOI.CGP;}
            
        }

        public bool IsNear(double lat, double lon)
        {
            throw new NotImplementedException();
        }

        public bool IsAvailable()
        {
            throw new NotImplementedException();
        }
    }
}
