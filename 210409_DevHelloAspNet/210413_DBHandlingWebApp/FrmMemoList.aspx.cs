using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _210413_DBHandlingWebApp
{
    public partial class FrmMemoList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // '리스트' 버튼을 클릭하면 그리드 뷰를 통해 데이터가 출력
            var connString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;

            using (var conn = new SqlConnection(connString))
            {
                if (conn.State == System.Data.ConnectionState.Closed) conn.Open();

                SqlCommand cmd = new SqlCommand("ListMemo", conn);  // 저장 프로시저 ListMemo 를 호출
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Memos");

                GrvMemoList.DataSource = ds;
                GrvMemoList.DataBind();
            }
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            // '리스트' 버튼을 클릭하면 그리드 뷰를 통해 데이터가 출력
            var connString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;

            using (var conn = new SqlConnection(connString))
            {
                if (conn.State == System.Data.ConnectionState.Closed) conn.Open();

                SqlCommand cmd = new SqlCommand("SearchMemo", conn);  // 저장 프로시저 SearchMemo 를 호출
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SearchField", CboSearch.SelectedValue);  // Name, Title 넘어감
                cmd.Parameters.AddWithValue("@SearchQuery", TxtSearch.Text.Replace("--", ""));  // '--' 라는 Sql쿼리의 주석을 없애겠다는 의미

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                adapter.Fill(ds, "Memos");

                GrvMemoList.DataSource = ds.Tables[0].DefaultView;
                GrvMemoList.DataBind();
            }
        }
    }
}