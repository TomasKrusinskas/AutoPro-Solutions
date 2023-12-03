using System;
using System.ComponentModel.DataAnnotations;
using RestTomas.Data.Dtos.Auth;
using RestTomas.Auth.Model;

namespace RestTomas.Data.Entities
{
    public class Center : IUserOwnedResource
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //[Required]
        public string UserId { get; set; }
        public DemoRestUser User { get; set; }
        //
    }
}
