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
        public bool SearchMode { get; set; } = false;
        public string SearchField { get; set; }
        public string SearchQuery { get; set; }

        public int RecordCount = 0;  // 총 레코드(게시물) 수
        public int PageIndex = 0;    // 페이징할때 값, 현재 보여줄 페이지 번호
        
        public BoardList() // 생성자 생성
        {
            _repo = new DbRepository();  // SqlConnection 생성
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // 검색모드 결정 true 검색, false 일반모드
            SearchMode = (!string.IsNullOrEmpty(Request["SearchField"]) &&
                          !string.IsNullOrEmpty(Request["SearchQuery"]));

            if (SearchMode)
            {
                SearchField = Request["SearchField"];
                SearchQuery = Request["SearchQuery"];
            }


            if (!SearchMode) // 검색모드가 아닐때
            {
                RecordCount = _repo.GetCountAll();  // 전체 게시판의 Note 글 개수가 나옴.
            }
            else
            {
                RecordCount = _repo.GetCountBySearch(SearchField, SearchQuery);
            }
            

            LblTotalRecord.Text = $"Total Record : {RecordCount}";


            if(Request["Page"] != null)
            {
                PageIndex = Convert.ToInt32(Request["Page"]) - 1;
            }
            else
            {
                PageIndex = 0;    // 1페이지
            }

            // TODO : 쿠키를 사용해서 리스트 페이지번호 유지

            // 페이징 처리
            PagingControl.PageIndex = PageIndex;
            PagingControl.RecordCount = RecordCount;

            if (!Page.IsPostBack)  // 최초로 게시판 사이트를 열었으면
            {
                DisplayData();
            }
        }

        private void DisplayData()  // 데이터 출력
        {
            if (!SearchMode) // 검색모드가 아닐때
            {
                GrvNotes.DataSource = _repo.GetAll(PageIndex); // 페이지 출력(0부터 시작)
            }
            else
            {
                GrvNotes.DataSource = _repo.GetSeachAll(PageIndex, SearchField, SearchQuery);  // 검색 결과 리스트
            }

            GrvNotes.DataBind(); // 데이터바인딩 끝
        }
    }
}