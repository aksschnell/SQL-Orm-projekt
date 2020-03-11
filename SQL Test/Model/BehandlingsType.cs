using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SQL_Test.Model
{
	class BehandlingsType
	{
		private int id;
		private string type;

		private SqlConnection myConn;

		string tableName = "BehandlingsType";

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

		public BehandlingsType(SqlConnection c)
		{
			myConn = c;
		}
		
		public void Save()
		{
					   			 			
			string Query = "insert into ["+tableName+"] ([BehandlingsTypeNavn]) Values (@Type)";

			myConn.Open();
			SqlCommand cmd = new SqlCommand(Query, myConn);
			cmd.Parameters.AddWithValue("@Type", Type);

			cmd.ExecuteNonQuery();
			myConn.Close();							

		}

		public void Update()
		{

			string Query = "UPDATE [" + tableName + "] SET BehandlingsTypeNavn = @Type Where ID = @id";
			myConn.Open();
			SqlCommand cmd = new SqlCommand(Query, myConn);

			cmd.Parameters.AddWithValue("@id", ID);
			cmd.Parameters.AddWithValue("@Type", Type);


			cmd.ExecuteNonQuery();
			myConn.Close();

		}



		public void Delete()
		{

			string Query = "delete from ["+tableName+"] where ID =" + id;

			myConn.Open();
			SqlCommand cmd = new SqlCommand(Query, myConn);

			cmd.ExecuteNonQuery();
			myConn.Close();


		}
	}
}
