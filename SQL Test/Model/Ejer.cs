using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SQL_Test.Model
{
	class Ejer
	{
		private int id;
		private string vejNavn;
		private int PSTNR;
		private string kundeNavn;
		private string tilhørendePatient;

		private SqlConnection myConn;

		string tableName = "Ejer";

		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		public string VejNavn
		{
			get { return vejNavn; }
			set { vejNavn = value; }
		}

		public int postNummer
		{
			get { return PSTNR; }
			set { PSTNR = value; }
		}
		public string KundeNavn
		{
			get { return kundeNavn; }
			set { kundeNavn = value; }
		}

		public string TilhørendePatient
		{
			get { return tilhørendePatient; }
			set { tilhørendePatient = value; }
		}

		public Ejer(SqlConnection c)
		{
			myConn = c;
		}

		public void Save()
		{

			ArrayList values = new ArrayList()
			{

				VejNavn,
				postNummer,
				kundeNavn,
				TilhørendePatient

			};

			List<string> keys = new List<string>
			{
				"VejNavn",
				"PSTNR",
				"KundeNavn",
				"TilhørendePatienter"

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

			string Query = "delete from [" + tableName + "] where EjerID =" + id;

			myConn.Open();
			SqlCommand cmd = new SqlCommand(Query, myConn);

			cmd.ExecuteNonQuery();
			myConn.Close();

		}
	}
}
