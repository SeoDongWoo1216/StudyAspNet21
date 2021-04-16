using _210414_DotNetNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _210414_DotNetNote.Board
{
    public partial class BoardView : System.Web.UI.Page
    {
        private string _Id;  // 현재 게시글 번호
        protected void Page_Load(object sender, EventArgs e)
        {
            lnkDelete.NavigateUrl = $"BoardDelete.aspx?Id={Request["Id"]}";
            lnkModify.NavigateUrl = $"BoardWrite.aspx?Id={Request["Id"]}&Mode=Edit";  // 수정버튼 눌렀을때
            lnkReply.NavigateUrl = $"BoardWrite.aspx?Id={Request["Id"]}&Mode=Reply";  // 답변버튼 눌렀을때

            _Id = Request["Id"];
            if (_Id == null) Response.Redirect("BoardList.aspx");

            if (!Page.IsPostBack) DisplayData();
        }

        private void DisplayData()
        {
            var repo = new DbRepository();
            var note = repo.GetNoteById(Convert.ToInt32(_Id));

            lblNum.Text = _Id;
            lblName.Text = note.Name;
            lblEmail.Text = string.Format("<a href='mailto:{0}'>{0}</a>", note.Email);
            lblTitle.Text = note.Title;

            string Content = note.Content;

            // 인코딩 방식 : Text, Html, Mixed
            string encoding = note.Encoding;
            if (encoding == "Text")
            {
                lblContent.Text = Helpers.HtmlUility.EncodeWithTabAndSpace(Content);  // 그냥 Text일때는 탭이나 스페이스로 인코딩
            }
            else if (encoding == "HTML") 
            {
                lblContent.Text = Content.Replace("\r\n", "<br />");   // 이스케이프 시퀀스가 오면 HTML의 <br/>로 바꿔줌
            }
            else  // Html
            {
                lblContent.Text = Content;  // HTML은 변환없음.
            }

            lblReadCount.Text = note.ReadCount.ToString();
            lblHomepage.Text = $"<a href='{note.Homepage}' target='_blank'>{note.Homepage}</a>";
            // 위의 lblEmail.Text = string.Format("<a href='mailto:{0}'>{0}</a>", note.Email); 랑 똑같은 유형의 코드
            lblPostDate.Text = note.PostDate.ToString();
            lblPostIP.Text = note.PostIp.ToString();

        }
    }
}