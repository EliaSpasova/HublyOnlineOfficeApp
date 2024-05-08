using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;

namespace HublyProject
{
    public class imageUploader
    {
        public static void UploadImage(string username, byte[] image)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=ELIASPASOVA\SQLEXPRESS; Initial Catalog=Hubly; Integrated Security=True;"))
            {
                sqlCon.Open();
                string uploadImgQ = "UPDATE UserInfo SET profilePic = @profilePic WHERE username = @username";
                using (SqlCommand uploadCmd = new SqlCommand(uploadImgQ, sqlCon))
                {
                    uploadCmd.CommandType = CommandType.Text;
                    uploadCmd.Parameters.AddWithValue("@username", username);
                    uploadCmd.Parameters.AddWithValue("@profilePic", image);
                    int rowsAffected = uploadCmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // Update the user object if the database update was successful
                        //user.Picture = image;
                    }
                }
            }
        }
        public static Image ByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0)
                return null;

            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                Image image = Image.FromStream(ms);
                return image;
            }
        }
        public static byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }
        public static byte[] GetUserProfilePicture(string username)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=ELIASPASOVA\SQLEXPRESS; Initial Catalog=Hubly; Integrated Security=True;"))
                {
                    conn.Open();
                    string query = "SELECT ProfilePic FROM UserInfo WHERE Username = @Username";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                           byte[] data = (byte[])reader["ProfilePic"];
                            return data;
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log or display a message)
                System.Diagnostics.Debug.WriteLine("Failed to load image: " + ex.Message);
            }
            return null; // Return null if no image is found or on error
        }
    }
}
