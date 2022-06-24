using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class AppUser : IdentityUser
    {
        [StringLength(255)]
        [Column(TypeName ="nvarchar(255)")]
        public string HomeAddress { get; set; }
    }
}
