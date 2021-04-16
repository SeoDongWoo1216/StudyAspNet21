using _210414_DotNetNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _210414_DotNetNote.Controls
{
    public partial class CommentControl : System.Web.UI.UserControl
    {

        private DbRepository _repo;

        public CommentControl()
        {
            _repo = new DbRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ctlCommentList.DataSource = _repo.GetNoteComments(Convert.ToInt32(Request["Id"]));
                ctlCommentList.DataBind();
            }
        }

        protected void btnWriteComment_Click(object sender, EventArgs e)
        {
            NoteComment commnet = new NoteComment();
            commnet.BoardId = Convert.ToInt32(Request["Id"]);  // 게시글 번호
            commnet.Name = txtName.Text;
            commnet.Password = txtPassword.Text;
            commnet.Opinion = txtOpinion.Text; // 댓글 내용

            _repo.AddNoteComment(commnet);   // DB에 저장

            Response.Redirect($"{Request.ServerVariables["SCRIPT_NAME"]}?Id={Request["Id"]}");  // BoardView.aspx 등 동적으로 웹페이지 이름을 할당


        }
    }
}