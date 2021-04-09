using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace _210409_FirstWebApp
{
    public partial class FrmPageLoad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 동적으로 페이지의 제목을 변경하는 방법
            Title = "제목변경";
            Page.Title = "또 제목 변경";

            // 외부 스타일시트 정의
            HtmlLink cssLink = new HtmlLink();
            cssLink.Href = "Content/main.css";
            cssLink.Attributes.Add("rel", "stylesheet");
            cssLink.Attributes.Add("type", "text/css");

            // Head 태그 정의, 외부스타일과 메타태그 등록
            HtmlHead htmlHead = Page.Header;
            htmlHead.Controls.Add(cssLink);

            // 제일 중요
            if (!Page.IsPostBack)
                Response.Write("[1] 폼이 최초로드 되었음 <br /> ");
            else
                Response.Write("[2] 폼이 다시로드 되었음 <br /> ");

            Response.Write("[3] 항상 실행.<br />");
        }

        protected void BtnPostBack_Click(object sender, EventArgs e)
        {
            var strScript = @"<script> window.alart('PostBack!') </script>";
            // Response.Write(strScript);
            ClientScript.RegisterClientScriptBlock(this.GetType(), "postScript", strScript);
        }

        protected void BtnNewLoad_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmPageLoad.aspx");
        }
    }
}