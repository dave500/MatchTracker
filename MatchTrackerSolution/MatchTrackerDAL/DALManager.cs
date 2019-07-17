using Dapper;
using MatchTrackerLib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchTrackerDAL
{
    public class DALManager
    {
        private readonly static string _localSqlServerConnection = @"Data Source =.\; Initial Catalog = Accabuilder; Integrated Security = True";


        private SqlConnection CreateSqlServerConnection()
        {
            SqlConnection connection = new SqlConnection();

            if (!String.IsNullOrEmpty(_localSqlServerConnection))
            {
                connection.ConnectionString = _localSqlServerConnection;

                connection.Open();
                return connection;
            }
            else
            {
                //StringBuilder connectionString = new StringBuilder();

                //connectionString.Append("Server=");
                //connectionString.Append(_sqlServerConnectionParams.Server);
                //connectionString.Append(";Database=");
                //connectionString.Append(_sqlServerConnectionParams.Database);
                //connectionString.Append(";User Id=");
                //connectionString.Append(_sqlServerConnectionParams.UserId);
                //connectionString.Append(";Password=");
                //connectionString.Append(_sqlServerConnectionParams.PassWord);

                //connection.ConnectionString = connectionString.ToString();

                //connection.Open();

                //return connection;

                throw new NotImplementedException();
            }


        }

        public bool UpdateMatches(List<Match> matches)
        {
            try
            {
                using (SqlConnection conn = CreateSqlServerConnection())
                {
                  //  conn.Open();

                    foreach (var match in matches)
                    {
                        UpdateLocalMatch(conn, match);
                    }
                }
            }
            catch (Exception ex)
            {

                return false;
            }

            return true;
        }

        private void UpdateLocalMatch(SqlConnection conn, Match match)
        {
            using (SqlCommand cmd = new SqlCommand())
            {

                cmd.Parameters.Clear();

                cmd.Connection = conn;
                cmd.CommandText = @"UPDATE Match SET Name = @name WHERE Id = @id";
                cmd.Parameters.Add(new SqlParameter("@id", match.Id));
                cmd.Parameters.Add(new SqlParameter("@name", match.Name));
                cmd.ExecuteNonQuery();
            }
        }



        /// <summary>
        /// Returns List of running competitions. That have games
        /// </summary>
        /// <returns></returns>
        public List<Competition> CurrentCompetitions()
        {
            var competitions = new List<Competition>();

            StringBuilder selectBuilder = new StringBuilder();

            string selectStatement = String.Format("SELECT ");

            selectBuilder.Append(selectStatement);
            selectBuilder.Append("c.Id, c.Code, c.Name ");
            selectBuilder.Append("From Competition c ");
            selectBuilder.Append("WHERE  c.Code in (SELECT Distinct(m.CompetitionCode) FROM Match m)");

            try
            {
                using (SqlConnection conn = CreateSqlServerConnection())
                {
                    competitions = conn.Query<Competition>(selectBuilder.ToString()).ToList();
                }
            }
            catch (Exception ex)
            {
                return competitions;
            }


            return competitions;
        }

        public List<Match> GetMatchesForCompetition(int Code)
        {
            var matches = new List<Match>();

            StringBuilder selectBuilder = new StringBuilder();

            string whereStatement = String.Format("WHERE CompetitionCode = {0}; ", Code.ToString());

            selectBuilder.Append("SELECT ");
            selectBuilder.Append("Id, Name, MatchDate, HomeWin, AwayWin, Draw, ");
            selectBuilder.Append("FracHome, FracDraw, FracAway, CompetitionCode, HasComment, MatchKickOff ");
            selectBuilder.Append("From Match ");
            selectBuilder.Append(whereStatement);

            try
            {
                using (SqlConnection conn = CreateSqlServerConnection())
                {
                    matches = conn.Query<Match>(selectBuilder.ToString()).ToList();
                }
            }
            catch (Exception ex)
            {
                return matches;
            }

            return matches;
        }

        /// Potentially handy
        //private SqlConnection CreateSqlServerConnection2()
        //{
        //    SqlConnection connection = new SqlConnection();

        //    StringBuilder connectionString = new StringBuilder();

        //    connectionString.Append("Server=");
        //    connectionString.Append(_sqlServerConnectionParams.Server);
        //    connectionString.Append(";Database=");
        //    connectionString.Append(_sqlServerConnectionParams.Database);
        //    connectionString.Append(";User Id=");
        //    connectionString.Append(_sqlServerConnectionParams.UserId);
        //    connectionString.Append(";Password=");
        //    connectionString.Append(_sqlServerConnectionParams.PassWord);

        //    connection.ConnectionString = connectionString.ToString();

        //    connection.Open();

        //    return connection;
        //}
    }

    
}
