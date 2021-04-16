using _210414_DotNetNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _210414_DotNetNote.Board
{
    // 댓글 삭제 구현
    public partial class BoardCommentDelete : System.Web.UI.Page
    {
        public int BoardId { get; set; }
        public int Id { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request["BoardId"] != null && Request["Id"] != null)
            {
                BoardId = Convert.ToInt32(Request["BoardId"]);
                Id = Convert.ToInt32(Request["Id"]);
            }
            else
            {
                Response.End();
            }
        }

        protected void btnCommentDelete_Click(object sender, EventArgs e)
        {
            var repo = new DbRepository();
            if(repo.GetCountBy(BoardId, Id, txtPassword.Text) > 0)  // GetCountBy를 통해 패스워드, Id, BoardID가 전부 같으면 1 반환
            {
                repo.DeleteNoteComment(BoardId, Id, txtPassword.Text);
                Response.Redirect($"BoardView.aspx?Id={BoardId}");
            }
            else
            {
                lblError.Text = "암호가 틀렸습니다. 다시 입력하세요.";
            }
        }
    }
}