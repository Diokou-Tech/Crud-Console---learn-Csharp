using HelloWorld.Helpers;
using HelloWorld.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;

namespace HelloWorld
{
    class Program
    {
    
        public static bool finish = false;
        public static List<Person> Liste = new List<Person>();
        public static ArrayList ListeTotale = new ArrayList();
        static void Main(string[] args)
        {
            //init();
            show($"Bienvenue sur l'appli C2 (Crud-Console) \n Langue: {Helper.langue} \n Monnaie: {Helper.devise} \n Date : {Helper.dateCurrent.ToShortDateString()} \n Heure : {Helper.dateCurrent.ToShortTimeString()} \n");
            test();
            do
            {
                try
                {
                    string ligne = menu();
                    switch (Int32.Parse(ligne))
                    {
                        case 1: addPersonne(); break;
                        case 2: showListe(); break;
                        case 3: serchByNom(); break;
                        case 4: deletePersonByNom(); break;
                        case 5: editPerson(); break;
                        case 6: exportCSV(); break;
                        case 0: quit(); break;
                    }
                }
                catch (Exception e)
                {
                    show("Parametre non attendu !" + e.Message);
                }
            } while (!finish);
        }

        //cette methode permet de raccourcir l'ancience methode
        public static void show(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(msg);
        }
        static string menu()
        {
            show("Appuyer sur la touche \n");
            show("1 : Ajouter une nouvelle personne ");
            show("2 : Afficher la liste ");
            show("3 : Rechercher une personne");
            show("4 : Supprimer une personne de la liste");
            show("5 : Modifier une personne une personne ");
            show("6 : Exporter le fichier csv \n");
            show("0 : Quitter \n");
            var ligne = Console.ReadLine();
            return ligne;
        }
        public static void showListe()
        {
            if (listeIsNotEmpty())
            {
                show("Affichage des personnes enregistrées ");
                foreach (var item in Liste)
                {
                    show(item.ToString());
                }
            }
            else
            {
                show("Aucun élève n'est enregistré pour l'instant ");
            }
        }
        static void addPersonne()
        {
            bool isFinish = false;
            do
            {
                show("Ajout de nouvelle personne ");
                show(" Donner votre nom complet ");
                string nomComplet = Console.ReadLine();
                show(" Donner votre taille (cm) ");
                string taille = Console.ReadLine();
                show(" Donner votre poids (kg) ");
                string poids = Console.ReadLine();
                var per = new Person { taille = Int32.Parse(taille), poids = Int32.Parse(poids), nom = nomComplet };
                Liste.Add(per);
                show(per.ToString());
                show(" 1 : Ajouter à nouveau");
                show(" 2: Terminé");
                string ligne = Console.ReadLine();
                switch (Int32.Parse(ligne))
                {
                    case 1: isFinish = false; break;
                    case 2: isFinish = true; break;
                }
            } while (!isFinish);
        }
        static void serchByNom()
        {
            if (!listeIsNotEmpty())
            {
                show("Aucune personne n'est encore renseignée ");
            }
            else
            {
                Person trouve = getByNom();
                if (trouve is not null)
                {
                    show(trouve.ToString());
                }
                else
                {
                    show($"Aucune personne n'est trouvé avec cet nom");
                }
            }
        }
        static void deletePersonByNom()
        {
            if (listeIsNotEmpty())
            {
                Person trouve = getByNom();
                if (trouve is not null){
                // delete a item
                show($"A supprimer \n {trouve.ToString()}");
                Liste.Remove(trouve);
                show("Suppression avec succès");
                }else{
                show($"Aucune personne n'est trouvé avec cet nom ");
                }
            }else{
                show("Aucune personne n'est encore renseignée, Liste vide ");
            }
        }
        static void editPerson()
        {
            if (!listeIsNotEmpty())
            {
                show("Aucune personne n'est encore renseignée ");
            }else{
                Person trouve = getByNom();
                if (trouve is not null)
                {
                    show($"Modification du nom : {trouve.nom}");
                    string new_nom = Console.ReadLine();
                    show($"Modification de la taile : {trouve.taille}");
                    string new_taille = Console.ReadLine();
                    show($"Modification du poids : {trouve.poids}");
                    string new_poids = Console.ReadLine();
                    Person new_person = new Person { 
                        nom = new_nom is not null ? new_nom : trouve.nom , 
                        poids = new_poids is not null ? Int32.Parse(new_poids) : trouve.poids, 
                        taille = new_taille is not null ? Int32.Parse(new_taille) : trouve.taille
                    };
                    // supprimer et ajouter à nouveau
                    Liste.Remove(trouve);
                    Liste.Add(new_person);
                }else{
                    show($"Aucune personne n'est trouvé avec cet nom ");
                }
            }
        }
        static bool listeIsNotEmpty()
        {
            return Liste.Count > 0;
        }
        static bool quit()
        {
            return finish = true;
        }
        public static void exportCSV()
        {
            if (!listeIsNotEmpty())
            {
                show("Aucune personne n'est encore renseignée \n");
            }
            else
            {
                show("Importation Data success \n");
                var test = new List<string>();
                foreach (Person item in Liste)
                {
                    test.Add($"nom: {item.nom}, poids : {item.poids}, taille: {item.taille}");
                }
                File.WriteAllLines("data.csv", test);
            }
        }
        static Person getByNom()
        {
            show("Donner le nom recherché ");
            string nom = Console.ReadLine();
            Person trouve = null;
            foreach (Person item in Liste)
            {
                if (item.nom == nom)
                {
                    trouve = item;
                    break;
                }
            }
            return trouve;
        }
        //public static void importData()
        //{
        //var datas = JsonConverter.DeserializeObject<Person>(File.ReadAllText($"Data/users.json"));
        //}
        //static void init()
        //{
        //    Person p1 = new Person { nom = "cheikh", poids = 80, taille = 190 };
        //    Person p2 = new Person { nom = "zola", poids = 70, taille = 170 };
        //    Liste.Add(p1);
        //    Liste.Add(p2);
        //}
        static void test()
        {
            //StringBuilder adresse = new StringBuilder();
            //show("Votre continent");
            //string continent = Console.ReadLine();
            //adresse.Append(continent);
            //show("Votre pays");
            //string pays = Console.ReadLine();
            //adresse.Append(pays);
            //show(adresse.ToString());

            //var etudiant = new Etudiant { date_naissance = DateTime.Now, matricule="20150436",nom = "Cheikhou DIOKOU", niveau="licence 2 MIO", poids= 75, taille = 185};
            //show(etudiant.ToStringFormat());
            //Console.ReadLine();

            //show("entre votre email");
            //string email = Console.ReadLine();
            //show("entre votre mot de passe");
            //string password = Console.ReadLine();
            //show(email);
            //show(Helper.logger(ref email, password));
            //show(email);
            //show(password);
            //Helper.testEnumeration();
            //StringCollection joursSemeaine = new StringCollection(); 
            //for(int i = 0; i < 6; i++)
            //{
            //    show($"Ajouter une nouvelle chaine {i}");
            //    joursSemeaine.Add( Console.ReadLine() );
            //}
            //foreach(var item in joursSemeaine)
            //{
            //    show(item);
            //}
        }
    }
}