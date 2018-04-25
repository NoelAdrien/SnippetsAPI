
namespace SnippetsAPI.Service
{
    using SnippetsAPI.Domain;
    using System.Collections.Generic;
    using System;
    using System.Data.SqlClient;
    using System.Data;

    public class SnippetDal : IDisposable
    {
        private string _connString { get; set; }

        private SqlConnection _sqlConn = null;

        protected SqlConnection DbConnection
        {
            get
            {
                if (_sqlConn == null || _sqlConn.State != ConnectionState.Open)
                {
                    _sqlConn = new SqlConnection(_connString);
                    _sqlConn.Open();
                }

                return _sqlConn;
            }
        }
        public SnippetDal(string conn)
        {
            this._connString = conn;
        }

        public IEnumerable<Snippet> GetSnippets()
        {
            List<Snippet> snippets = new List<Snippet>();

            string sqlQuery = $@"
                                SELECT Id AS {nameof(Snippet.Id)}, Title AS {nameof(Snippet.Title)}, Keywords AS {nameof(Snippet.Keywords)}, 
                                Code AS {nameof(Snippet.Code)}, LangageId AS {nameof(Snippet.Langage)}, isPublic AS {nameof(Snippet.isPublic)}, 
                                UserId AS {nameof(Snippet.Owner)}
                                FROM Snippet";

            using (SqlCommand cmd = DbConnection.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sqlQuery;

                using (var sqlReader = cmd.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        Snippet snip = new Snippet
                        {
                            Id = new Guid(sqlReader[nameof(Snippet.Id)].ToString()),
                            Code = sqlReader[nameof(Snippet.Code)].ToString(),
                            Title = sqlReader[nameof(Snippet.Title)].ToString(),
                            Keywords = sqlReader[nameof(Snippet.Keywords)].ToString(),
                            Langage = new Langage(),
                            isPublic = Convert.ToBoolean(sqlReader[nameof(Snippet.isPublic)].ToString()),
                            Owner = new User()
                        };

                        snippets.Add(snip);
                    }
                }
            }

            return snippets;
        }

        /// <summary>
        /// Dispose implentation
        /// </summary>
        public void Dispose()
        {
            if (_sqlConn != null)
            {
                this._sqlConn.Dispose();
            }
        }
    }
}