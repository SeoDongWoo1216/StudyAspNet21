using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _210414_LoginWebApp.Models
{
    public class User
    {
        // DB와 연계하기위한 모델 생성
        public int UID { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }

    }
}