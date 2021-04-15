using _210414_DotNetNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _210414_DotNetNote.Board
{
    public partial class BoardList : System.Web.UI.Page
    {
        private DbRepository _repo;

        // 검색모드일때 true, 보통은 false
        public bool SearchMode { get; set; }

        public int RecordCount = 0;   // 총 레코드 수
        public BoardList() // 생성자 생성
        {
            _repo = new DbRepository();  // SqlConnection 생성
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SearchMode) // 검색모드가 아닐때
            {
                RecordCount = _repo.GetCountAll();  // 전체 게시판의 Note 글 개수가 나옴.
            }
            LblTotalRecord.Text = $"Total Record : {RecordCount}";

            if (!Page.IsPostBack)  // 최초로 게시판 사이트를 열었으면
            {
                DisplayData();
            }

        }

        private void DisplayData()  // 데이터 출력
        {
            if (!SearchMode) // 검색모드가 아닐때
            {
                GrvNotes.DataSource = _repo.GetAll(0);
            }

            GrvNotes.DataBind(); // 데이터바인딩 끝
        }
    }
}