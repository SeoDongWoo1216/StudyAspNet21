using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _210409_FirstWebApp
{
    public partial class FrmStandardControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // BtnInput은 runat=""server" 가 없기때문에 C#과 연계안됨(실제로 .cs에서 BtnInput을 치면 아무것도 뜨지않는다)
            BtnHtml.Value = $"HTML 서버 컨트롤 - 버튼";

            LblDateTime.Text = DateTime.Now.ToString();  // 라벨에 현재시간 출력
            // asp:Button를 사용하거나 input, runat="server" 는 똑같다. 그냥 본인에따라 원하는거 사용하면됨.
        }

        protected void BtnServer_Click(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            var result = $"유저아이디 : {TxtUserID.Text}" +
                         $"패스워드 : {TxtPassword.Text}" +
                         $"설명 : {TxtDesc.Text}";

            Response.Write(result);
        }
    }
}