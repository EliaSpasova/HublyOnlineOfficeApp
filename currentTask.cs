using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HublyProject
{
    public static class CurrentTaskContext
    {
        public static currentTask CurrentTask { get; set; }
    }
    public class currentTask
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int AssignedToUserID { get; set; }
        public int CreatedByUserID { get; set; }
        public string statusOfTask { get; set; }

        public string descriptionOfTask { get; set; }
        public DateTime deadline { get; set; }
    }
    public class DatabaseManagerForTask
    {
        public static currentTask cuurentTaskMethod(string nameTask)
        {
            currentTask user = RetrieveTaskInformation(nameTask); //encapsulation purposes
            return user;
        }

        internal static currentTask currentTaskMethod(string? nameTask) //that is for when you click
        {
            throw new NotImplementedException();
        }
        private static currentTask RetrieveTaskInformation(string nameTask)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=ELIASPASOVA\SQLEXPRESS; Initial Catalog=Hubly; Integrated Security=True;"))
            {
                sqlCon.Open(); //maybe should close it after
                string Query = "SELECT * FROM Tasks WHERE Title='" + nameTask +"'";
                //Usernasme
                //the @username refers to the 
                using (SqlCommand cmd = new SqlCommand(Query, sqlCon))
                {
                        cmd.CommandType = CommandType.Text;
                        int ID;
                        string Title;
                        string descriptionOfTask;
                        string statusOfTask;
                        int AssignedToUserID;
                        int CreatedByUserID;
                        DateTime deadline;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ID = Convert.ToInt32(reader["taskID"]);
                                Title = reader["Title"].ToString();                                
                                AssignedToUserID = Convert.ToInt32(reader["AssignedToUserID"]);
                                CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                                descriptionOfTask = reader["descriptionOfTask"].ToString();
                                statusOfTask = reader["statusOfTask"].ToString();

                                deadline = Convert.ToDateTime(reader["deadline"]);
                                return new currentTask { ID = ID, Title = Title, AssignedToUserID = AssignedToUserID, CreatedByUserID = CreatedByUserID, descriptionOfTask = descriptionOfTask, statusOfTask = statusOfTask, deadline = deadline };
                            }
                        }

                    

                    return null;

                }
            }
        }
    }
}
