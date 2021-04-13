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
    public partial class FrmMemoView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request["Num"]))  // 리퀘스트 Num이 널값이면
            {
                Response.Write("잘못된 요청입니다.");
                Response.End();
            }
            else
            {
                // 1 은 모두 똑같은 구문임
                var connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString; // 1
                using(var conn = new SqlConnection(connString))    // 1 
                {
                    if (conn.State == System.Data.ConnectionState.Closed) conn.Open();  // 1

                    SqlCommand cmd = new SqlCommand("ViewMemo", conn);  // 저장 프로시저에서 ViewMemo 를 호출
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Num", Convert.ToInt32(Request["Num"]));

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        LblNum.Text = Request["Num"];
                        LblName.Text = reader["Name"].ToString();
                        LblEmail.Text = reader["Email"].ToString();
                        LblTitle.Text = reader["Title"].ToString();
                        LblPostDate.Text = reader["PostDate"].ToString();
                        LblPostIP.Text = reader["PostIP"].ToString();
                    }

                    reader.Close();

                }
            }
        }
    }
}