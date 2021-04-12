using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _210409_FirstWebApp
{
    public partial class FrmRichControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // 캘린더를 선택했을때 변화는 이벤트
        protected void CalMain_SelectionChanged(object sender, EventArgs e)
        {
            Response.Write(CalMain.SelectedDate.ToShortDateString() + "<hr />");  // 캘린더에서 클릭한 날짜 출력
            // hr은 가로줄 하나 그어주는거
        }
    }
}