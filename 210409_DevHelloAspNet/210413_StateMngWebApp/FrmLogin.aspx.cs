using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _210413_StateMngWebApp
{
    public partial class FrmLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) // 최초 로드이면
            {
                if (Request.Cookies["UserID"] != null) // 유저아이디 값이 null이 아니면
                {
                    ChkSaveUserID.Checked = true;
                    TxtUserID.Text = Server.UrlEncode(Request.Cookies["UserID"].Value);
                    Page.SetFocus(TxtPassword);
                }
            }
        }

        // 쿠키는 브라우저 자체에 파일로 존재하는 것임.
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            if(ChkSaveUserID.Checked)  // 체크박스에 체크가 됬으면
            {
                HttpCookie cookie = new HttpCookie("UserID", Server.UrlEncode(TxtUserID.Text));
                cookie.Expires = DateTime.Now.AddDays(10);     // 10일간 쿠키를 저장 만료 일자
                Response.Cookies.Add(cookie);
            }
            else
            {
                HttpCookie cookie = new HttpCookie("UserID", Server.UrlEncode(TxtUserID.Text));
                cookie.Expires = DateTime.Now.AddDays(01);     // 쿠키 삭제
                Response.Cookies.Add(cookie);
            }

            Response.Write("<script>alert('로그인 성공!')</script>");

        }
    }
}