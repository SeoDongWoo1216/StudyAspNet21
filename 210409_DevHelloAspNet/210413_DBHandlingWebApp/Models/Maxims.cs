using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _210413_DBHandlingWebApp.Models
{
    public class Maxims
    {
        // Maxims 테이블의 데이터를 저장할 생성자 생성
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contents { get; set; }
        public DateTime RegDate { get; set; }
    }
}