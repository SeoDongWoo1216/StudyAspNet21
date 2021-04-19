using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _210419_DBWebApp.Models
{

    
    public class Room // 부모
    {
        [Key]  // DB연동
        public int RoomId { get; set; }

        [Required]  // NotNull
        public string Name { get; set; }
        public virtual ICollection<Speaker> Speakers { get; set; }
    }


   
    public class Speaker  // 자식
    {
        [Key]
        public int SpeakerId { get; set; }

        [Required]
        public string Name { get; set; }

        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
    }
}

