using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace wcfOnDb
{
    [DataContract]
    public class car
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int number { set; get; }

        [DataMember]
        public decimal price { set; get; }

        [DataMember]
        public string original { set; get; }

        [DataMember]
        public int daBan { set; get; }

        [DataMember]
        public int conLai { set; get; }
    }
}
