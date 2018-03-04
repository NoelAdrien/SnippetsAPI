
namespace SnippetsAPI.Service
{
    using SnippetsAPI.Domain;
    using System.Collections.Generic;
    using System;
    using System.Data.SqlClient;
    using System.Data;

    public class SnippetDal : IDisposable
    {
        private string _connString;
        private SqlConnection sqlConn;

        public SnippetDal(string conn)
        {
            this._connString = conn;
            sqlConn = new SqlConnection(conn);
        }

        public IEnumerable<Snippet> GetSnippets()
        {
            List<Snippet> snippets = new List<Snippet>();

            string sqlRequest = "SELECT * FROM SNIPPET";
            SqlCommand cmd = new SqlCommand(sqlRequest);
            cmd.Connection = sqlConn;

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Snippet snippet = new Snippet
                {
                    Id = Guid.Parse(dr["Id"].ToString()),
                };
                snippets.Add(snippet);
            }

            return snippets;
        }

        public void Dispose()
        {
            if (sqlConn != null && sqlConn.State == ConnectionState.Open)
            {
                sqlConn.Close();
            }
        }
    }
}