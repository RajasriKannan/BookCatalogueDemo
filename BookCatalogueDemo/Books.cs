using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BookCatalogueDemo
{
    [DataContract(Namespace = "http://RajasriVenkat/2021/02/04")]
    public class Books
    {
        [DataMember(Name ="ID", Order = 1)]
        public int BookId { get; set; }
        [DataMember(Order = 3)]
        public string Author { get; set; }
        [DataMember(Order = 2)]
        public string BookName { get; set; }
        [DataMember(Order = 4)]
        public decimal Price { get; set; }
    }
}
