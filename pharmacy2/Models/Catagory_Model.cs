using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace pharmacy2.Models
{
    public class Catagory_Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }

    }
}
