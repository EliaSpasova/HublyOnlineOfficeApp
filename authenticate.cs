using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static HublyProject.authenticate;

namespace HublyProject
{
    public static class CurrentUserContext
    {
        public static User1 CurrentUser { get; set; } //same as instance?
    }
    public class authenticate
    {
        public class User1
        {
            private static User1 instance;
            public int userID { get; set; }
            public string Username { get; set; }

            public string Email { get; set; }

            public string Role { get; set; }
            public string Password { get; set; }
            public int Age { get; set; }
            public byte[] Picture { get; set; }
            public Image PictureImage { get; set; }
            public DateTime Created { get; set; }
            public string Location { get; set; }
            public User1() { }
            public static User1 GetInstance()
            {
                if (instance == null)
                {
                    instance = new User1();
                }
                return instance;
            }
        }

        public class DatabaseManager
        {

            public static bool AuthenticateUser(string username, string password)
            {
                // Attempt to retrieve user information and update the Singleton instance
                bool isAuthenticated = RetrieveUserInformation(username, password);

                return isAuthenticated;
            }

            private static bool RetrieveUserInformation(string username, string password)
            {
                using (SqlConnection sqlCon = new SqlConnection(@"Data Source=ELIASPASOVA\SQLEXPRESS; Initial Catalog=Hubly; Integrated Security=True;"))
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM UserInfo WHERE username = @username AND password1 = @password";

                    using (SqlCommand cmd = new SqlCommand(query, sqlCon))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Get the Singleton instance of User1
                                User1 user = User1.GetInstance();

                                // Update its properties
                                user.userID = (int)reader["userID"];
                                user.Username = reader["Username"].ToString();
                                user.Email = reader["Email"].ToString();
                                user.Role = reader["role1"].ToString();
                                user.Age =(int)reader["age"];
                                user.Location = reader["location1"].ToString();
                                user.Password = password; // Assuming you want to keep it, though it's generally not recommended
                                var dateAndTimeOfClick = System.DateTime.Now;
                                user.Created = dateAndTimeOfClick;
                                return true; // Authentication successful
                            }
                        }
                    }
                }

                return false; // Authentication failed
            }

            public static User1 RetrieveUserInformationForChats(string username) //only for CHATS
            {
                using (SqlConnection sqlCon = new SqlConnection(@"Data Source=ELIASPASOVA\SQLEXPRESS; Initial Catalog=Hubly; Integrated Security=True;"))
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM UserInfo WHERE username = @username";

                    using (SqlCommand cmd = new SqlCommand(query, sqlCon))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        int ID;
                        string Username;
                        string Email;
                        string Role;
                        string Password;
                        int Age;
                        string location;
                        DateTime created;
                        byte[] picture;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Get the Singleton instance of User1
                                User1 user = User1.GetInstance();

                                // Update its properties
                               ID = (int)reader["userID"];
                               Username = reader["Username"].ToString();
                               Email = reader["Email"].ToString();
                               Role = reader["role1"].ToString();
                               Age = (int)reader["age"];
                                location = reader["location1"].ToString();
                                Password = reader["password1"].ToString(); // Assuming you want to keep it, though it's generally not recommended
                               //created = Convert.ToDateTime(reader["dateJoined"]);
                                //FIX THE PIXTURE
                                return new User1{ userID = ID, Username = Username, Email = Email, Role = Role, Age = Age, Password = Password , Picture = null, Location = location};
                            }
                        }
                    }
                }

                return null; // Authentication failed
            }

            public static byte[] ImageToByteArray(Image image)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, image.RawFormat);
                    return ms.ToArray();
                }
            }
        }

    }
}
