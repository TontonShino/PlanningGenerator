using PlanningGenerator.Models.Pln;
using System;
using System.Collections.Generic;


namespace PlanningGenerator.Models
{
    public class EmpRegisterd
    {
        public int IdUser { get; set; }
        public int NbCone { get; set; }
        public int ConeLeft { get; set; }
        public List<UsedCone> UsedCone { get; set; } = new List<UsedCone>();
        public Employe Employe { get; set; } = new Employe();
    }

    public class PostRegisterd
    {

        public int IdPost { get; set; }
        public Post Post { get; set; }
        public List<Dhe> Monday { get; set; } = new List<Dhe>();
        public List<Dhe> Tuesday { get; set; } = new List<Dhe>();
        public List<Dhe> Wednesay { get; set; } = new List<Dhe>();
        public List<Dhe> Thursday { get; set; } = new List<Dhe>();
        public List<Dhe> Friday { get; set; } = new List<Dhe>();
        public List<Dhe> Saturday { get; set; } = new List<Dhe>();
        public List<Dhe> Sunday { get; set; } = new List<Dhe>();

    }


    public class UsedCone
    {
        public string Hour { get; set; }
        public int Day { get; set; }
        public int Post { get; set; }

    }


    public class PlanningMananger
    {
        public List<EmpRegisterd> Emps { get; set; }
        public List<PostRegisterd> Posts { get; set; }
        static readonly Random Random = new Random();
        List<Employe> OrderAssignement { get; set; } = new List<Employe>();
        List<Employe> UnassignedEmp { get; set; } = new List<Employe>();
        Employe CurrentEmp = new Employe();
        int TotalConeEmp = new int();
        int ConeLeftEmp = new int();

        public PlanningMananger(List<EmpRegisterd> _empsRegis,List<PostRegisterd> _postRegistered)
        {
            Emps = _empsRegis;
            Posts = _postRegistered;
        }

        public PlanningMananger() { }


        //Tirage aléatoire des employés
        private int RandomEmp()
        {
            int r = Random.Next(UnassignedEmp.Count);
            Console.WriteLine($"Employé selectionné Aléatoirement: {UnassignedEmp[r].Nom}");
            return r;
        }

        private void SetUnassgnedList()
        {
            for(int e=0;e<Emps.Count;e++)
            {
                UnassignedEmp.Add(Emps[e].Employe);
            }
        }

        //Création de l'ordre de l'attribution
        private void SetOrderAssignement()
        {
            //Tant que La liste d'assignement (taille) n'est pas égale à la liste d'employé (taille)
            do
            {
                //Tirer un chiffre au hasard
                var rand = RandomEmp();

                //on ajoute l'empployé à la liste ordonné
                OrderAssignement.Add(UnassignedEmp[rand]);

                //On le retire de la liste des personnes non enregistré
                UnassignedEmp.RemoveAt(rand);

            } while (UnassignedEmp.Count !=0);
        }

        public void PostProcess()
        {
            SetUnassgnedList();
            SetOrderAssignement();
            
        }

        public void MainProcess()
        {
            //Créer curseur (selectionneur d'employé)
            CurrentEmp = OrderAssignement[0];
            SetDefautConesLeftTotal(); //Nombre de disponibilité global
            ConeLeftEmp = TotalConeEmp;

            foreach (var p in Posts)
            {

                    
                    //Todo: Avant d'attribuer le dhe vérifier la disponibilité de l'employé à cette heure précise (UsedCone)
                    //Todo: Factoriser méthode d'attribution et tenter attribution tant que disponibilité
                    //Todo: Réaliser tour complet (SetNext)

                
                //Lundi
                if (p.Monday.Count != 0)
                {
                    //Todo: si il y a pas de disponibilités
                    
                    for (int dhs = 0; dhs < p.Monday.Count; dhs++)
                    {
                        int nbOfAttemps = 0;
                        var tempEmpReg = Emps.Find(w => w.Employe == CurrentEmp);
                        int index = Emps.IndexOf(tempEmpReg);


                        bool NotAvailable;
                        bool Continue;

                        //Avant de rentrer dans la boucle vérifier qu'il reste des disponibilités global

                        do //Nexter le curseur tant le currentEmp n'est pas disponible 
                        {
                            NotAvailable = IsUsedCone(p.Monday[dhs].HourId, p.Monday[dhs].DayId, tempEmpReg.Employe.Id);

                            //Si il est disponible
                            if (NotAvailable == false && ConeLeftEmp >= 1 && tempEmpReg.ConeLeft >= 1) // et le coneLeft du currentEmp est => 1
                            {
                                //On peut attribuer
                                DayAffect(p, dhs, tempEmpReg, index, p.Monday[dhs].DayId);
                                ConeLeftEmp -= 1;
                                Continue = true; //On passe à la suite
                               
                            }
                            else
                            {

                                if(nbOfAttemps > Emps.Count || ConeLeftEmp <1)
                                {
                                    Continue = true;
                                }
                                else
                                {
                                  //On next puis on met à jour 
                                SetNextEmp();
                                tempEmpReg = Emps.Find(w => w.Employe == CurrentEmp);
                                index = Emps.IndexOf(tempEmpReg);
                                nbOfAttemps += 1;
                                    Continue = false;
                                }
                            }

                            
                            //Il suffit qu'il y ai 1 de travers pour qu'il rentre à nouveau dans la boucle
                        } while (Continue==false);
                    }
                    
                }

                //Mardi
                ConeLeftEmp = TotalConeEmp;
                SetDefaultConesEmp();

                if (p.Tuesday.Count!=0)
                    {
                    //Todo: si il y a pas de disponibilités
                    
                    for (int dhs=0; dhs< p.Tuesday.Count; dhs++)
                        {
                        int nbOfAttemps = 0;
                        var tempEmpReg = Emps.Find(w => w.Employe == CurrentEmp);
                            int index = Emps.IndexOf(tempEmpReg);
                            
                        
                            bool NotAvailable;
                            bool Continue;

                        //Avant de rentrer dans la boucle vérifier qu'il reste des disponibilités global

                        do //Nexter le curseur tant le currentEmp n'est pas disponible 
                            {
                                NotAvailable = IsUsedCone(p.Tuesday[dhs].HourId, p.Tuesday[dhs].DayId,tempEmpReg.Employe.Id );

                                //Si il est disponible
                                if (NotAvailable == false && ConeLeftEmp >= 1 && tempEmpReg.ConeLeft >= 1)
                                {
                                    //On peut attribuer
                                    DayAffect(p,dhs,tempEmpReg,index,p.Tuesday[dhs].DayId);
                                ConeLeftEmp -= 1;
                                nbOfAttemps = Emps.Count;
                                Continue = true;
                                
                                }
                                else
                                {
                                if (nbOfAttemps > Emps.Count || ConeLeftEmp < 1)
                                {
                                    Continue = true;
                                }
                                else
                                {
                                    //On next puis on met à jour 
                                    SetNextEmp();
                                    tempEmpReg = Emps.Find(w => w.Employe == CurrentEmp);
                                    index = Emps.IndexOf(tempEmpReg);
                                    nbOfAttemps += 1;
                                    Continue = false;
                                }

                                }



                            } while (Continue==false);
                        }
                    }

                //Mercredi
                ConeLeftEmp = TotalConeEmp;
                SetDefaultConesEmp();

                if (p.Wednesay.Count != 0)
                {
                    //Todo: si il y a pas de disponibilités

                    for (int dhs = 0; dhs < p.Wednesay.Count; dhs++)
                    {
                        int nbOfAttemps = 0;
                        var tempEmpReg = Emps.Find(w => w.Employe == CurrentEmp);
                        int index = Emps.IndexOf(tempEmpReg);


                        bool NotAvailable;
                        bool Continue;

                        //Avant de rentrer dans la boucle vérifier qu'il reste des disponibilités global

                        do //Nexter le curseur tant le currentEmp n'est pas disponible 
                        {
                            NotAvailable = IsUsedCone(p.Wednesay[dhs].HourId, p.Wednesay[dhs].DayId, tempEmpReg.Employe.Id);

                            //Si il est disponible
                            if (NotAvailable == false && ConeLeftEmp >= 1 && tempEmpReg.ConeLeft >= 1)
                            {
                                //On peut attribuer
                                DayAffect(p, dhs, tempEmpReg, index, p.Wednesay[dhs].DayId);
                                ConeLeftEmp -= 1;
                                nbOfAttemps = Emps.Count;
                                Continue = true;

                            }
                            else
                            {
                                if (nbOfAttemps > Emps.Count || ConeLeftEmp < 1)
                                {
                                    Continue = true;
                                }
                                else
                                {
                                    //On next puis on met à jour 
                                    SetNextEmp();
                                    tempEmpReg = Emps.Find(w => w.Employe == CurrentEmp);
                                    index = Emps.IndexOf(tempEmpReg);
                                    nbOfAttemps += 1;
                                    Continue = false;
                                }

                            }



                        } while (Continue == false);
                    }
                }

                //Jeudi
                ConeLeftEmp = TotalConeEmp;
                SetDefaultConesEmp();

                if (p.Thursday.Count != 0)
                {
                    //Todo: si il y a pas de disponibilités

                    for (int dhs = 0; dhs < p.Thursday.Count; dhs++)
                    {
                        int nbOfAttemps = 0;
                        var tempEmpReg = Emps.Find(w => w.Employe == CurrentEmp);
                        int index = Emps.IndexOf(tempEmpReg);


                        bool NotAvailable;
                        bool Continue;

                        //Avant de rentrer dans la boucle vérifier qu'il reste des disponibilités global

                        do //Nexter le curseur tant le currentEmp n'est pas disponible 
                        {
                            NotAvailable = IsUsedCone(p.Thursday[dhs].HourId, p.Thursday[dhs].DayId, tempEmpReg.Employe.Id);

                            //Si il est disponible
                            if (NotAvailable == false && ConeLeftEmp >= 1 && tempEmpReg.ConeLeft >= 1)
                            {
                                //On peut attribuer
                                DayAffect(p, dhs, tempEmpReg, index, p.Thursday[dhs].DayId);
                                ConeLeftEmp -= 1;
                                nbOfAttemps = Emps.Count;
                                Continue = true;

                            }
                            else
                            {
                                if (nbOfAttemps > Emps.Count || ConeLeftEmp < 1)
                                {
                                    Continue = true;
                                }
                                else
                                {
                                    //On next puis on met à jour 
                                    SetNextEmp();
                                    tempEmpReg = Emps.Find(w => w.Employe == CurrentEmp);
                                    index = Emps.IndexOf(tempEmpReg);
                                    nbOfAttemps += 1;
                                    Continue = false;
                                }

                            }



                        } while (Continue == false);
                    }
                }

                //Vendredi
                ConeLeftEmp = TotalConeEmp;
                SetDefaultConesEmp();

                if (p.Friday.Count != 0)
                {
                    //Todo: si il y a pas de disponibilités

                    for (int dhs = 0; dhs < p.Thursday.Count; dhs++)
                    {
                        int nbOfAttemps = 0;
                        var tempEmpReg = Emps.Find(w => w.Employe == CurrentEmp);
                        int index = Emps.IndexOf(tempEmpReg);


                        bool NotAvailable;
                        bool Continue;

                        //Avant de rentrer dans la boucle vérifier qu'il reste des disponibilités global

                        do //Nexter le curseur tant le currentEmp n'est pas disponible 
                        {
                            NotAvailable = IsUsedCone(p.Friday[dhs].HourId, p.Friday[dhs].DayId, tempEmpReg.Employe.Id);

                            //Si il est disponible
                            if (NotAvailable == false && ConeLeftEmp >= 1)
                            {
                                //On peut attribuer
                                DayAffect(p, dhs, tempEmpReg, index, p.Friday[dhs].DayId);
                                ConeLeftEmp -= 1;
                                nbOfAttemps = Emps.Count;
                                Continue = true;

                            }
                            else
                            {
                                if (nbOfAttemps > Emps.Count || ConeLeftEmp < 1 && tempEmpReg.ConeLeft >= 1)
                                {
                                    Continue = true;
                                }
                                else
                                {
                                    //On next puis on met à jour 
                                    SetNextEmp();
                                    tempEmpReg = Emps.Find(w => w.Employe == CurrentEmp);
                                    index = Emps.IndexOf(tempEmpReg);
                                    nbOfAttemps += 1;
                                    Continue = false;
                                }

                            }



                        } while (Continue == false);
                    }
                }

                //Samedi
                ConeLeftEmp = TotalConeEmp;
                SetDefaultConesEmp();

                if (p.Saturday.Count != 0)
                {
                    //Todo: si il y a pas de disponibilités

                    for (int dhs = 0; dhs < p.Saturday.Count; dhs++)
                    {
                        int nbOfAttemps = 0;
                        var tempEmpReg = Emps.Find(w => w.Employe == CurrentEmp);
                        int index = Emps.IndexOf(tempEmpReg);


                        bool NotAvailable;
                        bool Continue;

                        //Avant de rentrer dans la boucle vérifier qu'il reste des disponibilités global

                        do //Nexter le curseur tant le currentEmp n'est pas disponible 
                        {
                            NotAvailable = IsUsedCone(p.Saturday[dhs].HourId, p.Saturday[dhs].DayId, tempEmpReg.Employe.Id);

                            //Si il est disponible
                            if (NotAvailable == false && ConeLeftEmp >= 1)
                            {
                                //On peut attribuer
                                DayAffect(p, dhs, tempEmpReg, index, p.Saturday[dhs].DayId);
                                ConeLeftEmp -= 1;
                                nbOfAttemps = Emps.Count;
                                Continue = true;

                            }
                            else
                            {
                                if (nbOfAttemps > Emps.Count || ConeLeftEmp < 1 && tempEmpReg.ConeLeft >= 1)
                                {
                                    Continue = true;
                                }
                                else
                                {
                                    //On next puis on met à jour 
                                    SetNextEmp();
                                    tempEmpReg = Emps.Find(w => w.Employe == CurrentEmp);
                                    index = Emps.IndexOf(tempEmpReg);
                                    nbOfAttemps += 1;
                                    Continue = false;
                                }

                            }



                        } while (Continue == false);
                    }
                }

                //Dimache
                ConeLeftEmp = TotalConeEmp;
                SetDefaultConesEmp();

                if (p.Sunday.Count != 0)
                {
                    //Todo: si il y a pas de disponibilités

                    for (int dhs = 0; dhs < p.Sunday.Count; dhs++)
                    {
                        int nbOfAttemps = 0;
                        var tempEmpReg = Emps.Find(w => w.Employe == CurrentEmp);
                        int index = Emps.IndexOf(tempEmpReg);


                        bool NotAvailable;
                        bool Continue;

                        //Avant de rentrer dans la boucle vérifier qu'il reste des disponibilités global

                        do //Nexter le curseur tant le currentEmp n'est pas disponible 
                        {
                            NotAvailable = IsUsedCone(p.Sunday[dhs].HourId, p.Sunday[dhs].DayId, tempEmpReg.Employe.Id);

                            //Si il est disponible
                            if (NotAvailable == false && ConeLeftEmp >= 1)
                            {
                                //On peut attribuer
                                DayAffect(p, dhs, tempEmpReg, index, p.Sunday[dhs].DayId);
                                ConeLeftEmp -= 1;
                                nbOfAttemps = Emps.Count;
                                Continue = true;

                            }
                            else
                            {
                                if (nbOfAttemps > Emps.Count || ConeLeftEmp < 1 && tempEmpReg.ConeLeft >= 1)
                                {
                                    Continue = true;
                                }
                                else
                                {
                                    //On next puis on met à jour 
                                    SetNextEmp();
                                    tempEmpReg = Emps.Find(w => w.Employe == CurrentEmp);
                                    index = Emps.IndexOf(tempEmpReg);
                                    nbOfAttemps += 1;
                                    Continue = false;
                                }

                            }



                        } while (Continue == false);
                    }
                }


            }
        }

        private void DayAffect(PostRegisterd p, int dhs, EmpRegisterd tempEmpReg, int index, int dayid)
        {

            switch (dayid)
            {
                case 1:
                    p.Monday[dhs].Employe = tempEmpReg.Employe;


                    Emps[index].ConeLeft -= 1;
                    Emps[index].UsedCone.Add(new UsedCone
                    {
                        Hour = p.Monday[dhs].HourId,
                        Day = p.Monday[dhs].DayId,
                        Post = p.Monday[dhs].PostId
                    });
                    break;
                case 2:
                    p.Tuesday[dhs].Employe = tempEmpReg.Employe;


                    Emps[index].ConeLeft -= 1;
                    Emps[index].UsedCone.Add(new UsedCone
                    {
                        Hour = p.Tuesday[dhs].HourId,
                        Day = p.Tuesday[dhs].DayId,
                        Post = p.Tuesday[dhs].PostId
                    });
                    break;
                case 3:

                    p.Wednesay[dhs].Employe = tempEmpReg.Employe;


                    Emps[index].ConeLeft -= 1;
                    Emps[index].UsedCone.Add(new UsedCone
                    {
                        Hour = p.Wednesay[dhs].HourId,
                        Day = p.Wednesay[dhs].DayId,
                        Post = p.Wednesay[dhs].PostId
                    });
                    break;
                case 4:
                    p.Thursday[dhs].Employe = tempEmpReg.Employe;


                    Emps[index].ConeLeft -= 1;
                    Emps[index].UsedCone.Add(new UsedCone
                    {
                        Hour = p.Thursday[dhs].HourId,
                        Day = p.Thursday[dhs].DayId,
                        Post = p.Thursday[dhs].PostId
                    });
                    break;
                case 5:
                    p.Friday[dhs].Employe = tempEmpReg.Employe;


                    Emps[index].ConeLeft -= 1;
                    Emps[index].UsedCone.Add(new UsedCone
                    {
                        Hour = p.Friday[dhs].HourId,
                        Day = p.Friday[dhs].DayId,
                        Post = p.Friday[dhs].PostId
                    });
                    break;
                case 6:
                    p.Saturday[dhs].Employe = tempEmpReg.Employe;


                    Emps[index].ConeLeft -= 1;
                    Emps[index].UsedCone.Add(new UsedCone
                    {
                        Hour = p.Saturday[dhs].HourId,
                        Day = p.Saturday[dhs].DayId,
                        Post = p.Saturday[dhs].PostId
                    });
                    break;
                case 7:

                    p.Sunday[dhs].Employe = tempEmpReg.Employe;


                    Emps[index].ConeLeft -= 1;
                    Emps[index].UsedCone.Add(new UsedCone
                    {
                        Hour = p.Sunday[dhs].HourId,
                        Day = p.Sunday[dhs].DayId,
                        Post = p.Sunday[dhs].PostId
                    });
                    break;
            }

        }

        public bool CheckAvaibalities()
        {
            for(int e=0;e<Emps.Count; e++ )
            {
                if(Emps[e].ConeLeft > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public int GlobalCones()
        {
            int TotalOfCones = 0;
            for(int i=0;i<Emps.Count;i++)
            {
                TotalOfCones += Emps[i].ConeLeft;
            }
            return TotalOfCones;
        }

        public bool CheckAvaibility(Employe emp)
        {

            if(Emps.Find(i=>i.Employe==emp).ConeLeft != 0)
            {
                return true;
            }
            return false;
        }

        public void SetNextEmp()
        {
            int index = OrderAssignement.IndexOf(CurrentEmp)+1;
            if(!(index >= OrderAssignement.Count))
            {
                CurrentEmp = OrderAssignement[index];
            }
            else
            {
                CurrentEmp = OrderAssignement[0];
            }
        }

        private bool IsUsedCone(string hour,int day,int idEmp)
        {
            //Récuperer l'employé
            var emp = Emps.Find(e => e.IdUser == idEmp);

            //Parcourir les plots utilisés 
            for(int i=0; i < emp.UsedCone.Count; i++)
            {
                if(emp.UsedCone[i].Hour==hour && emp.UsedCone[i].Day==day)
                {
                    return true;
                }
            }

            return false;
            
        }

        private void SetDefaultConesEmp()
        {
            foreach(var e in Emps)
            {
                e.ConeLeft = e.NbCone;
            }
        }

        private void SetDefautConesLeftTotal()
        {
            TotalConeEmp = 0;

            foreach (var e in Emps)
            {
                TotalConeEmp += e.NbCone;
            }
        }

        

        
    }




}