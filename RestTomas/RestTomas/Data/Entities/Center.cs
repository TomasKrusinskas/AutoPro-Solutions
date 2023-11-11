using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RestTomas.Data.Dtos.Auth;

namespace RestTomas.Data.Entities
{
    public class Center
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public string UserId { get; set; }
        public DemoRestUser User { get; set; }
        //
    }
}
