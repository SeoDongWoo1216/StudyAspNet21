using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _210413_DBHandlingWebApp.Models
{
    public class Memos
    {
        // Memos 테이블의 데이터를 저장할 생성자 생성(엔티티 프레임워크 추가했을때 만들어지는 클래스임.)
        // 반대로 말하면 엔티티 프레임워크를 안쓰면 우리가 직접 만들어 줘야함.
        public int Num { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public DateTime PostDate { get; set; }
        public string PostIP { get; set; }
    }
}