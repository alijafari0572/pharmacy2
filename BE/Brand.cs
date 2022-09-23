using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BE
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string En_Name { get; set; }
        public string Country { get; set; }
        public string En_Country { get; set; }
        [Column(TypeName = "ntext")]
        public string Introduction { get; set; }
        public string Pic { get; set; }
        [Column(TypeName = "ntext")]
        public string Detail { get; set; }
        public ICollection<Drag> Drags { get; set; } = new List<Drag>();
    }
}
