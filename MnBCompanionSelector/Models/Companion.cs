using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.SqlClient;

namespace MnBCompanionSelector.Models
{
	
	public class Companion
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string ImagePath { get; set; }
		public int Dislike1 { get; set; }
		public int Dislike2 { get; set; }
		public int Likes { get; set; }
		public string ModName { get; set; }

		public Companion()
		{
			
		}

		public Companion(SqlDataReader reader)
		{
			Id =int.Parse(reader["ID"].ToString());
			Name = reader["companionname"].ToString();
			ImagePath = reader["portrait"].ToString();
			Likes = int.Parse(reader["likes"].ToString());
			Dislike1 = int.Parse(reader["dislike1"].ToString());
			Dislike2 = int.Parse(reader["dislike2"].ToString());
			ModName = reader["modname"].ToString();
		}

	}
	public class CompanionList {
		public static List<Companion> getListfromDB()
		{
			List<Companion> tl = new List<Companion>();
			String constring="Data Source = localhost\\SQLEXPRESS; Initial Catalog = MnBWBCompanionCalc; Integrated Security = True";
			string query = "SELECT ID,companionname,portrait,likes,dislike1,dislike2,modname FROM Companion; ";/* +
				"WHERE modname==@mod;";*/
			using (SqlConnection connection = new SqlConnection(constring))
			{
				// Create the Command and Parameter objects.
				SqlCommand command = new SqlCommand(query, connection);
				//command.Parameters.AddWithValue("@mod", paramValue);

				// Open the connection in a try/catch block. 
				// Create and execute the DataReader, writing the result
				// set to the console window.
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					Companion temp = new Companion(reader);
					tl.Add(temp);
				}
				reader.Close();
			}
			return tl;
		}
	}
}