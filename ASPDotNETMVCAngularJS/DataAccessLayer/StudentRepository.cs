using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ASPDotNETMVCAngularJS.DataAccessLayer.Repositories;
using ASPDotNETMVCAngularJS.Models;

namespace ASPDotNETMVCAngularJS.DataAccessLayer
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;

        public IEnumerable<Student> GetStudents()
        {
            var students = new List<Student>();
            using(var sqlConnection = new SqlConnection(connectionString))
            {
                var sqlCommand = new SqlCommand("dbo.SelectStudent", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                var sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                var dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                if( dataSet.Tables.Count > 0 )
                    if( dataSet.Tables[0].Rows.Count > 0 )
                        foreach( DataRow row in dataSet.Tables[0].Rows )
                            students.Add(new Student
                            {
                                Name = row["Name"].ToString().Trim(),
                                Email = row["Email"].ToString().Trim(),
                                Id = int.Parse(row["Id"].ToString())
                            });
            }

            return students;
        }

        public string AddStudent(Student student)
        {
            var response = "";
            using(var sqlConnection = new SqlConnection(connectionString))
            {
                var sqlCommand = new SqlCommand("InsertStudent", sqlConnection);
                sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = student.Name;
                sqlCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = student.Email;
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                response = "Success";
                sqlConnection.Close();
            }

            return response;
        }

        public string UpdateStudent(Student student)
        {
            var response = "";
            using(var sqlConnection = new SqlConnection(connectionString))
            {
                var sqlCommand = new SqlCommand("UpdateStudent", sqlConnection);
                sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = student.Id;
                sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = student.Name;
                sqlCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = student.Email;
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                response = "Success";
                sqlConnection.Close();
            }

            return response;
        }

        public string DeleteStudent(int id)
        {
            var response = "";
            using(var sqlConnection = new SqlConnection(connectionString))
            {
                var sqlCommand = new SqlCommand("DeleteStudent", sqlConnection);
                sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                response = "Success";
                sqlConnection.Close();
            }

            return response;
        }
    }
}