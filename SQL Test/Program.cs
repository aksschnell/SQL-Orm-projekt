using System;
using System.Data.SqlClient;
using SQL_Test.Model;


namespace SQL_Test
{
    class Program
    {
        static void Main(string[] args)
        {

            string connectionString = "Server=localhost; Database=Vet;Uid=August;Pwd=1234";
            SqlConnection conn = new SqlConnection(connectionString);
            
            DyrTyper dyrtype = new DyrTyper(conn);
            BehandlingsType behandlingstype = new BehandlingsType(conn);
            Patienter patienter = new Patienter(conn);
            Behandlinger behandlinger = new Behandlinger(conn);
            Byer byer = new Byer(conn);



            //BehandlingsType
            void behandlingsTypeSave(string _type)
            {
                behandlingstype.Type = _type;
                behandlingstype.Save();
            }

            void behandlingsTypeDelete(int _id)
            {
                behandlingstype.ID = _id;
                behandlingstype.Delete();
            }

            //Dyrtype
            void dyrTypeSave(string _type)
            {
                dyrtype.Type = _type;
                dyrtype.Save();
            }

            void dyrTypeDelete(int _id)
            {
                dyrtype.ID = _id;
                dyrtype.Delete();
            }

            //Patienter
            void patienterSave(string _navn, int _ejerid, int _type)
            {
                patienter.PatientNavn = _navn;
                patienter.EjerID = _ejerid;
                patienter.Type = _type;
                patienter.Save();
            }

            void patienterDelete(int _id)
            {
                patienter.ID = _id;
                patienter.Delete();
            }

            void behandlingerSave(int _patientid, int _EjerID, int _Behandling, DateTime _dato, int _pris)
            {
                behandlinger.PatientID = _patientid;
                behandlinger.EjerID = _EjerID;
                behandlinger.Behandling = _Behandling;
                behandlinger.Dato = _dato;
                behandlinger.Pris = _pris;
                behandlinger.Save();
            }

            void behandlingerDelete(int _id)
            {
                behandlinger.ID = _id;
                behandlinger.Delete();
            }

            void byerSave(int _postnummer , string _by)
            {
                byer.Postnummer = _postnummer;
                byer.By = _by;
                byer.Save();
            }
            
            void byerDelete(int _postnummer)
            {
                byer.ID = _postnummer;
                byer.Delete();
            }

            do
            {

                Console.WriteLine("(1 Behandlinger");
                Console.WriteLine("(2 BehandlingsType");
                Console.WriteLine("(3 Byer");
                Console.WriteLine("(4 DyrTyper");
                Console.WriteLine("(5 Patienter");
                Console.WriteLine("(6 Luk programmet");

                string input = Console.ReadLine();

                if(int.Parse(input) == 6)
                {
                    Environment.Exit(0);
                }
                

                Console.WriteLine("Tryk 1 for save, tryk 2 for delete");
                string input2 = Console.ReadLine();
                string input3;


                switch (int.Parse(input))
                {

                    case 1:

                        if (int.Parse(input2) == 1)
                        {

                            Console.WriteLine("Indtast patientens ID");
                            string patientID = Console.ReadLine();

                            Console.WriteLine("Indtast Ejer ID");
                            string ejerID = Console.ReadLine();

                            Console.WriteLine("Indtast behandlingstype ID");
                            string behandlingsTypeID = Console.ReadLine();

                            Console.WriteLine("Indtast dag fx 25");
                            string dag = Console.ReadLine();

                            Console.WriteLine("Indtast måned");
                            string måned = Console.ReadLine();

                            Console.WriteLine("Indtast år");
                            string år = Console.ReadLine();
                                
                            DateTime date1 = new DateTime (int.Parse(år), int.Parse(måned), int.Parse(dag));

                            Console.WriteLine("Indtast pris");

                            string pris = Console.ReadLine();

                            behandlingerSave(int.Parse(patientID), int.Parse(ejerID), int.Parse(behandlingsTypeID), date1, (int.Parse(pris)));
                            Console.WriteLine("Behandlingen blev gemt");

                        }

                        else if (int.Parse(input2) == 2)
                        {                 
                            Console.WriteLine("Indtast ID'et på den behandling du ønsker at slette");
                            input3 = Console.ReadLine();
                            behandlingerDelete(int.Parse(input3));
                            Console.WriteLine("Behandlingen blev slettet");
                            Console.WriteLine("");
                                                       
                        }

                        break;
                    case 2:

                        if (int.Parse(input2) == 1)
                        {
                            Console.WriteLine("Indtast den nye behandlingsType navn");
                            input3 = Console.ReadLine();
                            behandlingsTypeSave(input3);
                            Console.WriteLine("Behandlingstypen blev gemt");
                            Console.WriteLine("");

                        }

                        if (int.Parse(input2) == 2)
                        {

                            Console.WriteLine("Indtast ID'et på den behandlingsType du ønsker at slette");
                            input3 = Console.ReadLine();
                            behandlingsTypeDelete(int.Parse(input3));
                            Console.WriteLine("Behandlingstypen blev slettet");
                            Console.WriteLine("");
                        }

                        break;
                    case 3:


                        if (int.Parse(input2) == 1)
                        {
                            Console.WriteLine("Indtast den nye bys postnummer");
                            input3 = Console.ReadLine();
                            Console.WriteLine("Indtast byens navn");
                            string by = Console.ReadLine();
                            byerSave(int.Parse(input3), by);
                            Console.WriteLine("Byen blev gemt");

                        }

                        if(int.Parse(input2) == 2)
                        {
                            Console.WriteLine("Indtast byens postnummer du ønsker at slette");
                            input3 = Console.ReadLine();
                            byerDelete(int.Parse(input3));
                            Console.WriteLine("Byen blev slettet");
                        }


                        break;
                    case 4:


                        if(int.Parse(input2) == 1)
                        {
                            Console.WriteLine("Indtast dyrtype navn");
                            input3 = Console.ReadLine();
                            dyrTypeSave(input3);
                            Console.WriteLine("Dyrtypen blev gemt");
                        }

                        if(int.Parse(input2) == 2)
                        {
                            Console.WriteLine("Indtast dyrtypens ID du ønsker at slette");
                            input3 = Console.ReadLine();
                            dyrTypeDelete(int.Parse(input3));
                            Console.WriteLine("Dyrtpen blev slettet");
                        }                                           
                        

                        break;
                    case 5:


                        if(int.Parse(input2) == 1)
                        {
                            Console.WriteLine("Indtast patientens navn");
                            string navn = Console.ReadLine();
                            Console.WriteLine("Indtast patientens ejerID");
                            string ejerID = Console.ReadLine();
                            Console.WriteLine("Indtast dyrtype ID");
                            string type = Console.ReadLine();
                            patienterSave(navn, int.Parse(ejerID), int.Parse(type));
                            Console.WriteLine("Patienten blev gemt");

                        }

                        if(int.Parse(input2) == 2)
                        {
                            Console.WriteLine("Indtast patientens ID som du ønsker at slette");
                            input3 = Console.ReadLine();
                            patienterDelete(int.Parse(input3));
                            Console.WriteLine("Patienten blev slettet");

                        }

                        break;

                    case 6:
                        Environment.Exit(0);
                        break;

                }

            } while (true);

        }
    }
}
