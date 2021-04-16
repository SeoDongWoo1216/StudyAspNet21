using _210414_DotNetNote.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _210414_DotNetNote.Board
{
    public partial class BoardWrite : System.Web.UI.Page
    {
        public BoardWriteFormType FormType { get; set; } = BoardWriteFormType.Write;  // 기본값을 글쓰기로 해놓음.

        private string _Id;    // 리스트에서 넘겨주는 번호
        // private string _Mode;  // 뷰에서 넘겨주는 모드 값 // Edit, reply

        private string _BaseDir = "";   // GitRepository\StrudyAspNET21\... Files  를 처리할것임.
        private string _FileName = "";  // 파일명
        private int _FileSize = 0;      // 파일사이즈

        protected void Page_Load(object sender, EventArgs e)
        {
            _Id = Request["Id"];      //  GET / POST를 모두다 받음

            if (!Page.IsPostBack)
            {
                ViewState["Mode"] = Request["Mode"];  //  Edit 값이 넘어옴.
                if (ViewState["Mode"].ToString() == "Edit") FormType = BoardWriteFormType.Modify;
                else if (ViewState["Mode"].ToString() == "Reply") FormType = BoardWriteFormType.Reply;
                else FormType = BoardWriteFormType.Write;

                switch (FormType)
                {
                    case BoardWriteFormType.Write:
                        LblTitleDescription.Text = "글 쓰기 - 다음 필드들을 입력하세요";
                        break;

                    case BoardWriteFormType.Modify:
                        LblTitleDescription.Text = "글 수정 - 아래 필드들을 수정하세요";
                        DisplayDataForModify();
                        break;

                    case BoardWriteFormType.Reply:
                        LblTitleDescription.Text = "글 답변 - 다음 필드들을 입력하세요";
                        DisplayDataForReply();
                        break;
                }
            }
        }

        private void DisplayDataForModify()  // DB처리부분
        {
            var repo = new DbRepository();
            Note note = repo.GetNoteById(Convert.ToInt32(_Id));

            txtName.Text = note.Name;
            txtEmail.Text = note.Email;
            txtHomepage.Text = note.Homepage;
            txtTitle.Text = note.Title;
            txtContent.Text = note.Content;

            // Encoding 처리
            string encoding = note.Encoding;
            if(encoding == "Text")       rdoEncoding.SelectedIndex = 0;
            else if(encoding == "Mixed") rdoEncoding.SelectedIndex = 2;
            else                         rdoEncoding.SelectedIndex = 1;

            // TODO : 파일처리

        }

        private void DisplayDataForReply()
        {
            var repo = new DbRepository();
            Note note = repo.GetNoteById(Convert.ToInt32(_Id));

            txtTitle.Text = $"답변 : {note.Title}";
            txtContent.Text = $"\n\n작성일: {note.PostDate}, 작성자:'{note.Name}'\n----------------------\n>" + 
                $"{note.Content.Replace("\n", "\n>")}\n-------------------\n";
        }

        protected void chkUpload_CheckedChanged(object sender, EventArgs e)
        {
            pnlFile.Visible = !pnlFile.Visible;
        }

        protected void btnWrite_Click(object sender, EventArgs e)
        {
            if (IsImageTextCorrect())
            {
                if (ViewState["Mode"].ToString() == "Edit") FormType = BoardWriteFormType.Modify;
                else if (ViewState["Mode"].ToString() == "Reply") FormType = BoardWriteFormType.Reply;
                else FormType = BoardWriteFormType.Write;

                UploadFile();  // 파일업로드

                Note note = new Note();
                note.Id = Convert.ToInt32(_Id);  // 값이 없으면 0
                note.Name = txtName.Text;    // 필수
                note.Email = txtEmail.Text;
                note.Title = txtTitle.Text;  // 필수
                note.Homepage = txtHomepage.Text;
                note.Content = txtContent.Text;  // 필수
                note.FileName = _FileName;
                note.FileSize = _FileSize;
                note.Password = txtPassword.Text;
                note.PostIp = Request.UserHostAddress;
                note.Encoding = rdoEncoding.SelectedValue; // Text, Html, Mixed 가 들어감

                DbRepository repo = new DbRepository();

                switch (FormType)
                {
                    case BoardWriteFormType.Write:
                        repo.Add(note);
                        Response.Redirect("BoardList.aspx"); // BoardList.aspx 화면 다시 보여줌
                        break;

                    case BoardWriteFormType.Modify:
                        note.ModifyIp = Request.UserHostAddress;

                        // TODO : file 처리
                        note.FileName = ViewState["FileName"].ToString();
                        note.FileSize = Convert.ToInt32(ViewState["FileSize"]);

                        if (repo.UpdateNote(note) > 0) Response.Redirect($"BoardView.aspx?Id={_Id}");
                        else lblError.Text = "업데이트 실패, 암호를 확인하세요.";
                        break;

                    case BoardWriteFormType.Reply:
                        note.ParentNum = Convert.ToInt32(_Id);
                        repo.ReplyNote(note);
                        Response.Redirect("BoardList.aspx");
                        break;

                    default:
                        repo.Add(note);
                        Response.Redirect("BoardList.aspx");
                        break;
                }
            }

            else
            {
                lblError.Text = "보안코드가 틀립니다. 다시 입력하세요.";
            }
        }

        /// <summary>
        /// 추가 : 파일업로드 처리
        /// </summary>
        private void UploadFile()
        {
            _BaseDir = Server.MapPath("../Files");  // /Files 가 있는 디렉터리 앞의 모든 경로가 들어감.
            // 들어가는 경로 : 'D:\GitRepository\StudyAspNet21\210414_DotNetNote\210414_DotNetNote'   \Files
            _FileName = "";
            _FileSize = 0;

            if(txtFileName.PostedFile != null)
            {
                if(txtFileName.PostedFile.FileName.Trim().Length != 0
                    && txtFileName.PostedFile.ContentLength > 0)  // 파일의 이름이 있으면
                {
                   if(FormType == BoardWriteFormType.Modify)  // 폼타입이 'Modify' 일 경우
                    {
                        // ViewState 페이지가 떠있는동안 담아놓는 전역 변수 값
                        ViewState["FileName"] = Helpers.FileUtility.GetFileNameWithNumbering(_BaseDir, txtFileName.PostedFile.FileName);
                        ViewState["FileSize"] = txtFileName.PostedFile.ContentLength;

                        // 업로드
                        txtFileName.PostedFile.SaveAs(Path.Combine(_BaseDir, ViewState["FileName"].ToString()));
                    }
                    else  // 폼타입이 'Write', 'Reply' 일 경우
                    {
                        // 파일저장에있어 가장 중요한 핵심 프로세스
                        // 폴더에 이미 test.txt 있으면 test(1).txt 로 변경해줌.
                        _FileName = Helpers.FileUtility.GetFileNameWithNumbering(_BaseDir, Path.GetFileName(txtFileName.PostedFile.FileName));
                        //  Path.GetFileName 를 통해 파일의 경로를빼고 파일이름만 가져와줌.

                        _FileSize = txtFileName.PostedFile.ContentLength;

                        // 업로드
                        txtFileName.PostedFile.SaveAs(Path.Combine(_BaseDir, _FileName));   // Path.Combin e을통해 경로와 파일이름을 합쳐줌.
                    }
                }
            }
        }

        private bool IsImageTextCorrect()
        {
            if (Page.User.Identity.IsAuthenticated) // 이미 로그인한 상태일 경우
            {
                return true;
            }
            else
            {
                if (Session["ImageText"] != null)
                {
                    return (txtImageText.Text == Session["ImageText"].ToString());
                }
            }
            return false;  // 보안코드가 일치하지 않음(이도저도아니면 false 반환)
        }
    }
}