using HelloWorld.Helpers;
using HelloWorld.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace HelloWorld
{
    class Program
    {

        public static bool finish = false;
        public static List<Person> Liste = new List<Person>();
        public static ArrayList ListeTotale;
        static void Main()
        {
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("-------------------------------------------");
            show($"\n Bienvenue sur l'appli C2  [Crud-Console]  \n Langue: {Helper.langue} \n Monnaie: {Helper.devise} \n Date : {Helper.dateCurrent.ToShortDateString()} \n Heure : {Helper.dateCurrent.ToShortTimeString()} \n");
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("-------------------------------------------");
            //test();
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
                        case 7: importData(); break;
                        case 0: quit(); break;
                    }
                }
                catch (Exception e)
                {
                    show("Parametre non attendu !" + e.Message);
                }
            } while (!finish);
        }

        //cette methode permet de raccourcir l'ancience methode System.Console
        public static void show(string msg)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(msg);
        }
        static string clavier(string msg)
        {
            show(msg);
            return Console.ReadLine();
        }
        static string menu()
        {
            show(" Appuyer sur la touche \n");
            show(" 1 : Ajouter une nouvelle personne ");
            show(" 2 : Afficher la liste ");
            show(" 3 : Rechercher une personne");
            show(" 4 : Supprimer une personne de la liste");
            show(" 5 : Modifier une personne une personne ");
            show(" 6 : Exporter le fichier csv ");
            show(" 7 : Importer données via json  \n");
            show(" 0 : Quitter \n");
            var ligne = Console.ReadLine();
            return ligne;
        }
        public static void showListe()
        {
            if (listeIsNotEmpty())
            {
                show($"Affichage des personnes enregistrées : {Liste.Count} ");
                foreach (var item in Liste)
                {
                    show(item.ToString());
                }
            }
            else
            {
                show("Aucun élève n'est enregistré pour l'instant \n");
            }
        }
        static void addPersonne()
        {
            bool isFinish = false;
            do
            {
                show("Ajout de nouvelle personne ");
                string nomComplet = clavier(" Donner votre nom complet ");
                string taille = clavier(" Donner votre taille (cm) ");
                string poids = clavier(" Donner votre poids (kg) ");
                var per = new Person { taille = Int32.Parse(taille), poids = Int32.Parse(poids), nom = nomComplet.Trim() };
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
                show("Aucune personne n'est encore renseignée \n");
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
                if (trouve is not null)
                {
                    // delete a item
                    show($"A supprimer \n {trouve.ToString()}");
                    Liste.Remove(trouve);
                    show("Suppression avec succès");
                }
                else
                {
                    show($"Aucune personne n'est trouvé avec cet nom ");
                }
            }
            else
            {
                show("Aucune personne n'est encore renseignée, Liste vide ");
            }
        }
        static void editPerson()
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
                    string new_nom = clavier($"Modification du nom : {trouve.nom}").Trim();
                    string new_taille = clavier($"Modification de la taile : {trouve.taille}");
                    string new_poids = clavier($"Modification du poids : {trouve.poids}");
                    Person new_person = new Person
                    {
                        nom = new_nom is not null ? new_nom : trouve.nom,
                        poids = new_poids is not null ? Int32.Parse(new_poids) : trouve.poids,
                        taille = new_taille is not null ? Int32.Parse(new_taille) : trouve.taille
                    };
                    // supprimer et ajouter à nouveau
                    Liste.Remove(trouve);
                    Liste.Add(new_person);
                }
                else
                {
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
            show($"\n Au revoir ! \n");
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
        static Person getByNom(string nomParam = null)
        {
            string nom;
            if (nomParam is null)
            {
            nom = clavier("Donner le nom recherché ");
            }
            else
            {
             nom = nomParam;
            }
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
        public static void importData()
        {
            //var datas = JsonConverter.DeserializeObject<Person>(File.ReadAllText($"Data/users.json"));
            var datas = JsonSerializer.Deserialize<List<Person>>(File.ReadAllText($"../../../Data/users.json"));
            show("liste des personnes importées");
            foreach (Person item in datas)
            {
                var ligne = getByNom(item.nom);
                if(ligne is null)
                {
                show(item.ToString());
                Liste.Add(item);
                }
            }
        }
        static void test()
        {
            Helper.tester();
        }
    }
}