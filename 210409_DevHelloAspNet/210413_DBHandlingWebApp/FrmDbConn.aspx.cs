using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _210413_DBHandlingWebApp
{
    public partial class FrmDbConn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnConn_Click(object sender, EventArgs e)
        {
            // Sql데이터 그리드 뷰
            // Sql커맨드? 게시판

            // INSERT 쿼리로 데이터 넣기
            var connString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                if (conn.State == System.Data.ConnectionState.Closed) conn.Open();    // 연결상태가 닫혔으면 연결상태를 열어준다.

                // LblResult.Text = conn.State.ToString();
                var query = @"Insert Memos 
                              Values
                              ('서동우', 'dw6642@naver.com','서동우입니다.', GetDate(), '127.0.0.1')";

                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    LblResult.Text = "데이터 저장완료";

                }
                catch (Exception ex)
                {
                    LblResult.Text = $"오류떴지롱~ : {ex}";

                }


            }
        }
    }
}