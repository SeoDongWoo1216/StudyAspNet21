using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _210409_FirstWebApp
{
    public partial class FrmFileUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Expires = 20;
            // 캐싱출력
            LblCached.Text = DateTime.Now.ToLongTimeString();
        }

        public static string GetCurrenTime(HttpContext context)
        {
            return DateTime.Now.ToLongTimeString();
        }

        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            if (CtlUpload.HasFile)
            {
                CtlUpload.SaveAs(Server.MapPath(".") + "\\Files\\" + CtlUpload.FileName);

                LblResult.Text = $"<a href='{"./Files/"}{Server.UrlEncode(CtlUpload.FileName)}'>{Server.UrlEncode(CtlUpload.FileName)}</a>";
                // 파일 업로드
                // 파일을 선택하고, 파일업로드 버튼을 클릭하면 파일을 다운받을수있게된다.
            }
        }
    }
}