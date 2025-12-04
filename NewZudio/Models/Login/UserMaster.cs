using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace NewZudio.Models.Login
{
    public class UserMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string UserID { get; set; }
        public string Role { get; set; }
        public string VendorNo { get; set; }
        public string BrandID { get; set; }
        public string Flag { get; set; }
    }
}