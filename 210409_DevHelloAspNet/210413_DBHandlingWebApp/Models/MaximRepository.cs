using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace _210413_DBHandlingWebApp.Models
{
    public class MaximRepository
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString); 

        // 입력
        public Maxims AddMaxims(Maxims maxim)
        {
            string query = @"INSERT INTO Maxims (Name, Contents) Values (@Name, @Contents);
                             SELECT CASE(SCOPE_IDENTITY() AS INT); ";
            var id = db.Query<int>(query, maxim).Single();
            maxim.Id = id;
            return maxim;
        }

        // 조회


        // 수정


        // 삭제
    }
}