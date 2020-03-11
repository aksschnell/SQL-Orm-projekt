using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SQL_Test.Model
{
	class Byer
	{
		private int id;
		private int postnummer;
		private string by;
		

		private SqlConnection myConn;

		string tableName = "Byer";

		public int ID
		{
			get { return id; }
			set { id = value; }
		}
		public int Postnummer
		{
			get { return postnummer; }
			set { postnummer = value; }
		}
		public string By
		{
			get { return by; }
			set { by = value; }
		}

		public Byer(SqlConnection c)
		{
			myConn = c;
		}

		public void Save()
		{

			string Query = "insert into [" + tableName + "] ([Postnummer],[By]) Values (@Postnummer , @By)";

			myConn.Open();
			SqlCommand cmd = new SqlCommand(Query, myConn);
			cmd.Parameters.AddWithValue("@By", By);
			cmd.Parameters.AddWithValue("@Postnummer", Postnummer);

			cmd.ExecuteNonQuery();
			myConn.Close();

		}


		public void Update()
		{
			
			string Query = "UPDATE [" + tableName + "] SET Postnummer = @Postnummer, [By] = @By Where Postnummer = @id";
			myConn.Open();
			SqlCommand cmd = new SqlCommand(Query, myConn);

			cmd.Parameters.AddWithValue("@By", By);
			cmd.Parameters.AddWithValue("@Postnummer", Postnummer);
			cmd.Parameters.AddWithValue("@id", ID);
					   			 		  			

			cmd.ExecuteNonQuery();
			myConn.Close();
		}


		public void Delete()
		{

			string Query = "delete from [" + tableName + "] where Postnummer =" + id;

			myConn.Open();
			SqlCommand cmd = new SqlCommand(Query, myConn);

			cmd.ExecuteNonQuery();
			myConn.Close();


		}


	}
}
