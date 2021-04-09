using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _210409_FirstWebApp
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnClick_Click(object sender, EventArgs e)
        {
            LblResult.Text = $"안녕하세요, {TxtDisplay.Text}!"; // 라벨에 텍스트박스의 값을 들고옴

            // 웹은 리퀘스트, 리스폰스의 객체가 존재함.
            Response.Write("반갑습니다.<br />");
        }
    }
}