using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _210409_FirstWebApp
{
    public partial class FrmButton : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) TxtNum.Text = "0";  // 맨 처음 페이지에 접근했을 때 텍스트박스를 0으로 초기화
            // 포스트백 : 자신의 페이지가 새로고침이 일어나는 현상
            // Page_Load 이벤트에서 페이지 요청이 있을때마다 해당 페이지를 초기화하는 작업이 비효율적이라서
            // IsPostBack 를 사용해서 이 값이 False면 처음 로드된것으로 간주해서 한번만 초기화해주는 코드를 넣어주면 된다.
        }

        protected void BtnInc_Click(object sender, EventArgs e)
        {
            TxtNum.Text = $"{int.Parse(TxtNum.Text) + 1}";
        }

        protected void BtnDec_Click(object sender, EventArgs e)
        {
            TxtNum.Text = $"{int.Parse(TxtNum.Text) - 1}";

        }

        protected void BtnLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://www.naver.com");
        }

        protected void BtnImage_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}