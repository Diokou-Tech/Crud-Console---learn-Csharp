using Models;
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
            do{
            Console.WriteLine("Donner votre nom complet !");
            string nomComplet = Console.ReadLine();
            Console.WriteLine("Donner votre taille !");
            string taille = Console.ReadLine();
            Console.WriteLine("Donner votre poids !");
            string poids = Console.ReadLine();
            var per = new Person {taille = Int32.Parse(taille), poids = Int32.Parse(poids), nom = nomComplet};
            Liste.Add(per);
            show(per.ToString());
            pause();
            }while(!finish);
        }
        public static void show(string msg)
        {
            Console.WriteLine(msg);
        }
        static void iterer()
        {
            short i =0;
            while(i < 9 ){
                show($"{i} est inférieur à 9");
                i++;
            }
        }
        public static void showListe(){
            foreach (var item in Liste)
            {
                show(item.ToString());
            }
        }
        static void pause()
        {
            Console.WriteLine("Appuyer sur 1 pour continuer !");
            Console.WriteLine("Appuyer sur 0 pour quitter !");
            string ligne = Console.ReadLine();
            switch(Int32.Parse(ligne)){
                case 1:  finish = false; break;
                case 0: {
                finish = true;show("Au revoir"); break;
                } 
            }
        }
    }
}