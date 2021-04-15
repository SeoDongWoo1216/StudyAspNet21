using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _210414_DotNetNote.Models
{
    // 게시판 쓸때의 폼 타입을 정의
    public enum BoardWriteFormType
    {
        Write,   // 글쓰기모드
        Modify,  // 글 수정모드
        Reply    // 댓글 모드
    }

    public enum ContentEncodingType
    {
        Text,    // 일반텍스트
        Html,    // HTML 입력모드
        Mixed    // HTML 입력 + 엔터키 모드
    }




}