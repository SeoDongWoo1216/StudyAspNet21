using System;
using System.ComponentModel.DataAnnotations;

namespace _210420_MyPortpolio.Models
{
    public class Manage
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "제목은 필수입니다")]
        [DataType(DataType.Text)]
        public string Subject { get; set; }
        
        [Required(ErrorMessage = "카테고리는 필수입니다")]
        [DataType(DataType.Text)]
        public string Category { get; set; }


        [Required(ErrorMessage = "내용은 필수입니다")]
        [DataType(DataType.Text)]
        public string Contents { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime RegDate { get; set; }
    }
}
