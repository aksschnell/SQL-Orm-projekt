using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SQL_Test.Model
{
	class Behandlinger
	{
		private int id;
		private int patientid;
		private int ejerid;
		private int behandling;
		private DateTime dato;
		private int pris;

		private SqlConnection myConn;

		string tableName = "Behandlinger";

		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		public int PatientID
		{
			get { return patientid; }
			set { patientid = value; }
		}

		public int EjerID
		{
			get { return ejerid; }
			set { ejerid = value; }
		}
		public int Behandling
		{
			get { return behandling; }
			set { behandling = value; }
		}

		public DateTime Dato
		{
			get { return dato; }
			set { dato = value; }
		}
		public int Pris
		{
			get { return pris; }
			set { pris = value; }
		}

		public Behandlinger(SqlConnection c)
		{
			myConn = c;
		}

		public void Save()
		{

			ArrayList values = new ArrayList()
			{
				
				PatientID,
				EjerID,
				Behandling,
				Dato, 
				pris

			};

			List<string> keys = new List<string>
			{
				
				"PatientID",
				"EjerID",
				"Behandling",
				"Dato",
				"Pris"


			};

			Insert(keys, values);
		}

		private void Insert(List<string> keys, ArrayList values)
		{
			string k = String.Join(",", keys);
			string p = "@" + String.Join(",@", keys);

			string query = "INSERT INTO " + tableName + " (" + k + ") " +
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
