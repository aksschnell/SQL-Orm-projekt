using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SQL_Test.Model
{
    class DyrTyper
    {
		private int id;
		private string type;

		private SqlConnection myConn;

		public int ID
		{
			get { return id; }
			set { id = value; }
		}		

		public string Type
		{
			get { return type; }
			set { type = value; }
		}

		public DyrTyper(SqlConnection c)
		{
			myConn = c;
		}

		public void Save()
		{
			string Query = "insert into [DyrTyper] ( [Type]) Values (@Type)";

			myConn.Open();
			SqlCommand cmd = new SqlCommand(Query, myConn);
			cmd.Parameters.AddWithValue("@Type", Type);

			cmd.ExecuteNonQuery();
			myConn.Close();
		}

		public void Delete()
		{

			string Query = "delete from [DyrTyper] where ID =" + id;

			myConn.Open();
			SqlCommand cmd = new SqlCommand(Query, myConn);
			
			cmd.ExecuteNonQuery();
			myConn.Close();


		}
	}
}
