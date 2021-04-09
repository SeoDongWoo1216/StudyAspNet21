using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _210409_FirstWebApp
{
    public partial class FrmRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strUserId = "";
            string strPassword = string.Empty;
            string strName = "";
            string strAge = "";

            //strUserId =   Request.QueryString["TxtUserID"];  // GET 형식 가져올때
            strUserId = Request.Params["TxtUserID"];
            strPassword = Request.Params["TxtPassword"];     // GET/POST 뭐든지 불러옴
            strName = Request.Form["TxtName"];           // POST 형식
            strAge = Request["TxtAge"];                 // GET.POST 뭐든지 불러옴

            /*
             Request 메서드
             Request.QueryString["문자열"]는 주소창에서 불러옴 (GET)
             Request.Form["문자열"]          텍스트박스에서 입력한 "문자열"을 불러옴(POST)
             Request.Params["문자열"] 이나 Request["문자열"] 은 무조건 값이나오니 이것을 많이 사용함.
             */


            var result = $@"입력하신 아이디는 {strUserId}이고 <br />
                            암호는 {strPassword}입니다.       <br />
                            이름은 {strName}이고,             <br />
                            나이는 {strAge}입니다.            <br />";
            LblReslt.Text = result;

            LblIpAddress.Text = Request.UserHostAddress;  // UserHostAddress는 로컬 호스트를 가져옴.(::1 은 127.0.0.1 과 같음)

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {

        }
    
    }
}