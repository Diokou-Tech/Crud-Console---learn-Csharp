using HelloWorld.Helpers;
using HelloWorld.Models;
using System;
using System.Collections.Generic;

namespace HelloWorld
{
    class Program
    {
        public static bool finish = false;
        public static List<Person> Liste = new List<Person>();
        static void Main(string[] args)
        {
            //init();
            show($"Bienvenue sur l'appli C2 (Crud-Console) \n Langue: {Helper.langue} \n Monnaie: {Helper.devise} \n");
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
            Console.WriteLine(msg);
        }
        static string menu()
        {
            show("Appuyer sur la touche \n");
            show("1 : Ajouter une nouvelle personne ");
            show("2 : Afficher la liste ");
            show("3 : Rechercher une personne");
            show("4 : Supprimer une personne de la liste");
            show("5 : Modifier une personne une personne \n");
            show("0 : Quitter \n");
            var ligne = Console.ReadLine();
            return ligne;
        }
        public static void showListe()
        {
            if (listeIsNotEmpty())
            {
                show("Affichage des éléves enregistrés ");
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
                show("Donner le nom recherché ");
                string nom = Console.ReadLine();
                Person trouve = null;
                foreach (Person item in Liste)
                {
                    if (item.nom == nom)
                    {
                        trouve = item;
                    }
                }
                if (trouve is not null)
                {
                    show(trouve.ToString());
                }
                else
                {
                    show($"Aucune personne n'est trouvé avec cet nom : {nom}");
                }
            }
        }
        static void deletePersonByNom()
        {
            if (listeIsNotEmpty())
            {
            show("Donner le nom pour supprimer ");
            string ligne = Console.ReadLine();
            Person trouve = null;
            int index;
            for (int i = 0; Liste.Count > i; i++){
                if (Liste[i].nom == ligne)
                {
                   trouve = Liste[i];
                   index = i;
                }
            }
            if (trouve is not null)
            {
            // delete a item
                show($"A supprimer {trouve.ToString()}");
                Liste.Remove(trouve);
                    show("Suppression avec succès");
            }
            else
            {
                show($"Aucune personne n'est trouvé avec cet nom : {ligne}");
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
                show("Donner le nom recherché ");
                string nom = Console.ReadLine();
                Person trouve = null;
                foreach (Person item in Liste)
                {
                    if (item.nom == nom)
                    {
                        trouve = item;
                    }
                }
                if (trouve is not null)
                {
                    show($"Modification du nom : {trouve.nom}");
                    string new_nom = Console.ReadLine();
                    show($"Modification de la taile : {trouve.taille}");
                    string new_taille = Console.ReadLine();
                    show($"Modification du poids : {trouve.poids}");
                    string new_poids = Console.ReadLine();
                    Person new_person = new Person();
                    // Modification du nom
                    if (new_nom is null)
                    {
                        new_person.nom = trouve.nom;
                    }
                    else
                    {
                        new_person.nom = new_nom;
                    }
                    // Modification du poids
                    if (new_poids is null)
                    {
                        new_person.poids = trouve.poids;
                    }
                    else
                    {
                        new_person.poids = Int32.Parse(new_poids);
                    }
                    // Modification du poids
                    if (new_taille is null)
                    {
                        new_person.taille = trouve.taille;
                    }
                    else
                    {
                       new_person.taille = Int32.Parse(new_taille);
                    }
                    // supprimer et ajouter à nouveau
                    Liste.Remove(trouve);
                    Liste.Add(new_person);
                }
                else
                {
                    show($"Aucune personne n'est trouvé avec cet nom : {nom}");
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
        //static void init()
        //{
        //    Person p1 = new Person { nom = "cheikh", poids = 80, taille = 190 };
        //    Person p2 = new Person { nom = "zola", poids = 70, taille = 170 };
        //    Liste.Add(p1);
        //    Liste.Add(p2);
        //}
    }
}