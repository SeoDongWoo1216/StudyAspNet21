using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _210409_FirstWebApp
{
    public partial class FrmServer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LblServerPath.Text = Server.MapPath(".");                      // 페이지 경로(이미지나 파일 업로드할때 저장할때 써라. 용도로 씀)
            LblRequestPath.Text = Request.ServerVariables["SCRIPT_NAME"];  // URL
        }
    }
}