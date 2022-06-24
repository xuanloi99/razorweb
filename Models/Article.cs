using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="{0} phải nhập")]
        [Column(TypeName = "nvarchar(255)")]
        [StringLength(255, MinimumLength =5, ErrorMessage ="{0} phải dài hơn {2} và nhỏ hơn {1} ký tự")]
        [DisplayName("Tiêu đề")]

        public string Title { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "{0} phải nhập")]
        [DisplayName("Ngày viết")]
        public DateTime Created { get; set; }

        [Column(TypeName = "text")]
        [DisplayName("Nội dung")]
        public string Content { get; set; }
    }
}
