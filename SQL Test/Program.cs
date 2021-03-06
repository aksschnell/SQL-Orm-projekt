﻿using System;
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
            Ejer ejer = new Ejer(conn);

            //Cunstructor til hver table for effektivitet

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

            void behandlingsTypeUpdate(int _id, string _type)
            {
                behandlingstype.ID = _id;
                behandlingstype.Type = _type;
                behandlingstype.Update();
            }


            //Dyrtype
            void dyrTypeSave(string _type)
            {
                dyrtype.Type = _type;
                dyrtype.Save();
            }

            void dyrTypeUpdate(int _id, string _type)
            {
                dyrtype.ID = _id;
                dyrtype.Type = _type;
                dyrtype.Update();
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

            void patienterUpdate(int _id, string _navn, int _ejerid, int _type)
            {
                patienter.ID = _id;
                patienter.PatientNavn = _navn;
                patienter.EjerID = _ejerid;
                patienter.Type = _type;
                patienter.Update();
            }

            void patienterDelete(int _id)
            {
                patienter.ID = _id;
                patienter.Delete();
            }


            //Behandlinger
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

            void behandlingerUpdate(int _id, int _patientid, int _EjerID, int _Behandling, DateTime _dato, int _pris)
            {
                behandlinger.ID = _id;
                behandlinger.PatientID = _patientid;
                behandlinger.EjerID = _EjerID;
                behandlinger.Behandling = _Behandling;
                behandlinger.Dato = _dato;
                behandlinger.Pris = _pris;
                behandlinger.Update();
            }

            //Byer
            void byerSave(int _postnummer , string _by)
            {
                byer.Postnummer = _postnummer;
                byer.By = _by;
                byer.Save();
            }

            void byerUpdate(int _id, int _postnummer, string _by)
            {

                byer.ID = _id;
                byer.Postnummer = _postnummer;
                byer.By = _by;
                byer.Update();

            }
                     
            void byerDelete(int _postnummer)
            {
                byer.ID = _postnummer;
                byer.Delete();
            }

            //Ejer
            void ejerSave(string _kundeNavn, string _vejNavn, int _postnummer, string _tilhørendePatient)
            {
             
                ejer.VejNavn = _vejNavn;
                ejer.postNummer = _postnummer;
                ejer.TilhørendePatient = _tilhørendePatient;
                ejer.KundeNavn = _kundeNavn;
                ejer.Save();

            }

            void ejerUpdate(int _id, string _kundeNavn, string _vejNavn, int _postnummer, string _tilhørendePatient)
            {

                ejer.ID = _id;
                ejer.VejNavn = _vejNavn;
                ejer.postNummer = _postnummer;
                ejer.TilhørendePatient = _tilhørendePatient;
                ejer.KundeNavn = _kundeNavn;
                ejer.Update();

            }


            void ejerDelete(int _id)
            {
                ejer.ID = _id;
                ejer.Delete();
            }

            //Looper det næste igennem indtil brugeren lukker programmet ved at skrive "7"

            do
            {
                Console.WriteLine("(1 Behandlinger");
                Console.WriteLine("(2 BehandlingsType");
                Console.WriteLine("(3 Byer");
                Console.WriteLine("(4 DyrTyper");
                Console.WriteLine("(5 Patienter");
                Console.WriteLine("(6 Ejer");
                Console.WriteLine("(7 Luk programmet");

                string actionChoice = Console.ReadLine();

                //Tjekker til at starte med om man vil lukke programmet, så det ikke spørger om man vil save eller delete når man vil lukke

                if(int.Parse(actionChoice) == 7)
                {
                    Environment.Exit(0);
                }
                

                Console.WriteLine("Tryk 1 for save, tryk 2 for delete, tryk 3 for update");
                string saveOrDelete = Console.ReadLine();         


                switch (int.Parse(actionChoice))
                {
                    //Vælger en af følgende cases afhængig af hvad brugeren har indtastet
                    case 1:

                        //Behandlinger save
                        if (int.Parse(saveOrDelete) == 1)
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

                        //Behandlinger delete
                        else if (int.Parse(saveOrDelete) == 2)
                        {                 
                            Console.WriteLine("Indtast ID'et på den behandling du ønsker at slette");
                            string id = Console.ReadLine();
                            behandlingerDelete(int.Parse(id));
                            Console.WriteLine("Behandlingen blev slettet");
                            Console.WriteLine("");
                                                       
                        }

                        //Behandlinger update
                        if (int.Parse(saveOrDelete) == 3)
                        {

                            Console.WriteLine("Indtast behandlingens ID som du ønsker at opdatere");
                            string id = Console.ReadLine();

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

                            DateTime date1 = new DateTime(int.Parse(år), int.Parse(måned), int.Parse(dag));

                            Console.WriteLine("Indtast pris");

                            string pris = Console.ReadLine();

                            behandlingerUpdate(int.Parse(id), int.Parse(patientID), int.Parse(ejerID), int.Parse(behandlingsTypeID), date1, (int.Parse(pris)));
                            Console.WriteLine("Behandlingen blev opdateret");

                        }


                        break;
                    case 2:

                        //Behandlingstype save
                        if (int.Parse(saveOrDelete) == 1)
                        {
                            Console.WriteLine("Indtast den nye behandlingsType navn");
                            string navn = Console.ReadLine();
                            behandlingsTypeSave(navn);
                            Console.WriteLine("Behandlingstypen blev gemt");
                            Console.WriteLine("");

                        }
                        
                        //Behandlingstype delete
                        if (int.Parse(saveOrDelete) == 2)
                        {

                            Console.WriteLine("Indtast ID'et på den behandlingsType du ønsker at slette");
                            string id = Console.ReadLine();
                            behandlingsTypeDelete(int.Parse(id));
                            Console.WriteLine("Behandlingstypen blev slettet");
                            Console.WriteLine("");
                        }

                        if (int.Parse(saveOrDelete) == 3)
                        {
                            Console.WriteLine("Indtast behandlingstypens ID som du ønsker at opdatere");
                            string id = Console.ReadLine();
                            Console.WriteLine("Indtast behandlingstypens nye navn");
                            string navn = Console.ReadLine();
                            behandlingsTypeUpdate(int.Parse(id), navn);
                            Console.WriteLine("Behandlingstypen blev gemt");
                            Console.WriteLine("");

                        }


                        break;
                    case 3:

                        //Postnummer save
                        if (int.Parse(saveOrDelete) == 1)
                        {
                            Console.WriteLine("Indtast den nye bys postnummer");
                            string postnummer = Console.ReadLine();
                            Console.WriteLine("Indtast byens navn");
                            string by = Console.ReadLine();
                            byerSave(int.Parse(postnummer), by);
                            Console.WriteLine("Byen blev gemt");

                        }

                        //Postnummer delete
                        if(int.Parse(saveOrDelete) == 2)
                        {
                            Console.WriteLine("Indtast byens postnummer du ønsker at slette");
                            string postnummer = Console.ReadLine();
                            byerDelete(int.Parse(postnummer));
                            Console.WriteLine("Byen blev slettet");
                        }

                        if(int.Parse(saveOrDelete) == 3)
                        {
                            Console.WriteLine("Indtast den bys postnummer du vil opdatere");
                            string updatePostnummer = Console.ReadLine();
                            Console.WriteLine("Indtast byens nye postnummer");
                            string newPostnummer = Console.ReadLine();
                            Console.WriteLine("Indtast byens nye navn");
                            string newNavn = Console.ReadLine();

                            byerUpdate(int.Parse(updatePostnummer), int.Parse(newPostnummer), newNavn);

                            Console.WriteLine("Byen blev opdateret");

                        }

                        break;
                    case 4:


                        //Dyrtype save
                        if(int.Parse(saveOrDelete) == 1)
                        {
                            Console.WriteLine("Indtast dyrtype navn");
                            string navn = Console.ReadLine();
                            dyrTypeSave(navn);
                            Console.WriteLine("Dyrtypen blev gemt");
                        }
                                              


                        //Dyrtype delete
                        if (int.Parse(saveOrDelete) == 2)
                        {
                            Console.WriteLine("Indtast dyrtypens ID du ønsker at slette");
                            string id = Console.ReadLine();
                            dyrTypeDelete(int.Parse(id));
                            Console.WriteLine("Dyrtpen blev slettet");
                        }

                        //Dyrtpe update
                        if (int.Parse(saveOrDelete) == 3)
                        {

                            Console.WriteLine("Indtast dyrtypens id du ønsker at opdatere");
                            string id = Console.ReadLine();
                            Console.WriteLine("Indtast dyrtypens nye navn");
                            string navn = Console.ReadLine();
                            dyrTypeUpdate(int.Parse(id),navn);
                            Console.WriteLine("Dyrtypen blev opdateret");
                        }



                        break;
                    case 5:


                        //Patient save
                        if(int.Parse(saveOrDelete) == 1)
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

                        //Patient delete
                        if(int.Parse(saveOrDelete) == 2)
                        {
                            Console.WriteLine("Indtast patientens ID som du ønsker at slette");
                            string id = Console.ReadLine();
                            patienterDelete(int.Parse(id));
                            Console.WriteLine("Patienten blev slettet");
                            
                        }

                        //Patient Update
                        if (int.Parse(saveOrDelete) == 3)
                        {
                            Console.WriteLine("Indtast patientens id som du vil opdatere");
                            string id = Console.ReadLine();
                            Console.WriteLine("Indtast patientens navn");
                            string navn = Console.ReadLine();
                            Console.WriteLine("Indtast patientens ejerID");
                            string ejerID = Console.ReadLine();
                            Console.WriteLine("Indtast dyrtype ID");
                            string type = Console.ReadLine();
                            patienterUpdate(int.Parse(id), navn, int.Parse(ejerID), int.Parse(type));
                            Console.WriteLine("Patienten blev gemt");

                        }

                        break;

                    case 6:


                        //Ejer Save
                        if(int.Parse(saveOrDelete) == 1)
                        {

                            Console.WriteLine("Indtast kundens navn");
                            string navn = Console.ReadLine();
                            Console.WriteLine("Indtast postnummer");
                            string postnummer = Console.ReadLine();
                            Console.WriteLine("Indtast kundens vejnavn");
                            string vejnavn = Console.ReadLine();
                            Console.WriteLine("Indtast tilhørende patient");
                            string tilhørendepatient = Console.ReadLine();

                            ejerSave(navn,vejnavn,int.Parse(postnummer),tilhørendepatient);
                            Console.WriteLine("Ejeren blev gemt");                                                  

                        }
                        
                        //Ejer Delete 
                        if(int.Parse(saveOrDelete) == 2)
                        {

                            Console.WriteLine("Indtast kunden du ønsker at slette");
                            string id = Console.ReadLine();
                            ejerDelete(int.Parse(id));
                            Console.WriteLine("Ejeren blev slettet");

                        }

                        if (int.Parse(saveOrDelete) == 3)
                        {

                            Console.WriteLine("Indtast den kunde du ønsker at opdateres ID");
                            string id = Console.ReadLine();
                            Console.WriteLine("Indtast kundens navn");
                            string navn = Console.ReadLine();
                            Console.WriteLine("Indtast postnummer");
                            string postnummer = Console.ReadLine();
                            Console.WriteLine("Indtast kundens vejnavn");
                            string vejnavn = Console.ReadLine();
                            Console.WriteLine("Indtast tilhørende patient");
                            string tilhørendepatient = Console.ReadLine();

                            ejerUpdate(int.Parse(id), navn, vejnavn, int.Parse(postnummer), tilhørendepatient);
                            Console.WriteLine("Ejeren blev opdateret");

                        }


                        break;

                        //Lukker programmet direkte
                    case 7:
                        Environment.Exit(0);
                        break;

                }

            } while (true);

        }
    }
}
