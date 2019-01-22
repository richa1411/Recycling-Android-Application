using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace kymiraAPI.Models
{
    public class SearchFAQ 
    {
        public List<FAQ> Search(List<string> details)
        {
            StringBuilder Buildsql = new StringBuilder();

            Buildsql.Append("select * from [faq] where ");

            foreach (string value in details)

            {

                Buildsql.AppendFormat("([question] like '%{0}%' or [answer] like '%{0}%' ) and ", value);



            }
            string datasql = Buildsql.ToString(0, Buildsql.Length - 5);

            return QueryList(datasql);



        }

        protected List<FAQ> QueryList(string text)

        {

            List<FAQ> lst = new List<FAQ>();

            SqlCommand cmd = GenerateSqlCommand(text);

            using (cmd.Connection)

            {

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)

                {

                    while (reader.Read())

                    {

                        lst.Add(ReadValue(reader));



                    }



                }



            }



            return lst;



        }
        public IConfiguration Configuration { get; }
        protected SqlCommand GenerateSqlCommand(string cmdText)

        {

            SqlConnection con = new SqlConnection(Configuration.GetConnectionString("kymiraAPIContext"));

            SqlCommand cmd = new SqlCommand(cmdText, con);

            cmd.Connection.Open();

            return cmd;



        }

        protected FAQ ReadValue(SqlDataReader reader)

        {

            FAQ dt = new FAQ();

            dt.ID = (int)reader["ID"];

           

            dt.question = (string)reader["question"];

            dt.answer = (string)reader["Task"];

            return dt;



        }



    }

}
