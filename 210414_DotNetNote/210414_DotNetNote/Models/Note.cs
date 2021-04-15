using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

// Dapper특징
// 테이블이름이 Notes인데 들어가는 클래스명은 s를 빼고 작업해야지 정확하게 동작한다.

namespace _210414_DotNetNote.Models
{
    public class Note
    {

        // Required : 필수값
        [Display(Name = "번호")]
        public int Id { get; set; }
        [Display(Name = "작성자")]
        [Required(ErrorMessage = "* 이름을 작성해 주세요.")]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "이메일을 정확인 입력하세요.")]
        public string Email { get; set; }
        [Display(Name = "제목")]
        [Required(ErrorMessage = "* 제목을 작성해 주세요.")]
        public string Title { get; set; }
        [Display(Name = "작성일")]
        public DateTime PostDate { get; set; }
        public string PostIp { get; set; }
        [Display(Name = "내용")]
        [Required(ErrorMessage = "* 내용을 작성해 주세요.")]
        public string Content { get; set; }
        [Display(Name = "비밀번호")]
        [Required(ErrorMessage = "* 비밀번호를 작성해 주세요.")]
        public string Password { get; set; }
        [Display(Name = "조회수")]
        public int ReadCount { get; set; }
        [Display(Name = "인코딩")]
        public string Encoding { get; set; } = "Text";
        public string Homepage { get; set; }
        public DateTime ModifyDate { get; set; }
        public string ModifyIp { get; set; }
        [Display(Name = "파일")]
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public int DownCount { get; set; }
        public int Ref { get; set; }
        public int Step { get; set; }
        public int RefOrder { get; set; }
        public int AnswerNum { get; set; }
        public int ParentNum { get; set; }
        public int CommentCount { get; set; }
        public string Category { get; set; } = "Free"; // 자유게시판(Free) 기본
    }
}