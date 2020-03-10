using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SQL_Test.Model
{
	class Patienter
	{
		private int id;
		private string patientnavn;
		private int ejerid;
		private int type;
		

		private SqlConnection myConn;

		string tableName = "Patienter";

		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		public string PatientNavn
		{
			get { return patientnavn; }
			set { patientnavn = value; }
		}	

		public int EjerID
		{
			get { return ejerid; }
			set { ejerid = value; }
		}

		public int Type
		{
			get { return type; }
			set { type = value; }
		}

		public Patienter(SqlConnection c)
		{
			myConn = c;
		}

		public void Save()
		{


			ArrayList values = new ArrayList()
			{
				PatientNavn,
				EjerID,
				Type

			};

			List<string> keys = new List<string>
			{
				"PatientNavn",
				"EjerID",
				"Type"
				
			};

			Insert(keys, values);

		
		}

		private void Insert(List<string> keys, ArrayList values)
		{
			string k = String.Join(",", keys);
			string p = "@" + String.Join(",@", keys);

			string query = "INSERT INTO " + tableName +" (" + k + ") " +
			"VALUES " + "(" + p + " )";
			
			SqlCommand cmd = new SqlCommand(query, myConn);

			for (int i = 0; i < values.Count; i++)
			{
				cmd.Parameters.AddWithValue("@" + keys[i], values[i]);
			}

			myConn.Open();
			cmd.ExecuteNonQuery();
			myConn.Close();
		}

		public void Delete()
		{

			string Query = "delete from [" + tableName + "] where ID =" + id;

			myConn.Open();
			SqlCommand cmd = new SqlCommand(Query, myConn);

			cmd.ExecuteNonQuery();
			myConn.Close();


		}
	}
}
