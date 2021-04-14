using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace _210414_LoginWebApp.Models
{
    public class Repository
    {
        private SqlConnection conn;

        public Repository()  // 기본 생성자
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString);
        }


        internal bool IsCorrectUser(string userId, string password)
        {
            bool result = false;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE UserID = @UserId AND Password = @Password", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@Password", password);

            conn.Open();
            var dr = cmd.ExecuteReader();
            if(dr.Read())   // 값이 있으면
            {
                // 아무문제없음
                result = true;
            }
            dr.Close();
            conn.Close();

            return result;
        }


        // '회원가입' 버튼을 눌렀을때 아이디와 비밀번호가 DB에 저장됨
        public int AddUser(string userId, string password)
        {
            SqlCommand cmd = new SqlCommand("WriteUsers", conn);  // 프로시저 WriteUsers 호출(INSERT)
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", userId);
            cmd.Parameters.AddWithValue("@Password", password);

            conn.Open();
            var result = cmd.ExecuteNonQuery();
             /*
              0414 오류 : 아이디, 비번을 입력하면 데이터가 저장은되는데 프로시저호출이안됬다. UID의 ID사양을 예.로 했어야함.
              이유 => ID사양은 굳이 데이터를입력하지않아도 자동으로 데이터가 들어가는데, ID사양을 아니오. 로 했기때문에
              UID 데이터를 따로 넣어줘야해서 오류가 뜬것(3개 입력해야하는데 프로시저는 2개만 입력하라고 되있음)
             */

            conn.Close();

            return result;  // 0 or 1 반환 (ExecuteNonQuery()에서 Add 됬느냐 안됬느냐를 반환함)
        }

        public User GetUserByUserID(string userId)  // 유저 ID값으로 검색하는 실행문
        {
            var u = new User();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE UserID = @UserID", conn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@UserID", userId);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read()) // 값이 있으면
            {
                u.UID = Convert.ToInt32(reader["UID"]);
                u.UserID = reader["UserID"].ToString();
                u.Password = reader["Password"].ToString();
            }

            conn.Close();
            return u;
        }
        
    }
}