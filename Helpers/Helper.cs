using System;

namespace HelloWorld.Helpers
{
    public static class Helper
    {
        //enumerations
        enum Jours : ushort { Lundi, Mardi, Mercredi, Jeudi, Vendredi, Samedi, Dimanche };
        public static DateTime dateCurrent { get; set; } = DateTime.UtcNow;
        public static string langue { get; set; } = "Wolof";
        public static string devise { get; set; } = "XOF";
        public static string continent { get; set; } = "Afrique";
        public static void sendEmail(string email)
        {
            Console.WriteLine($"Envoyer un mail à cette adresse : {email}");
        }
        public static string logger(ref string email, string password)
        {
            email = "zola@gmail.com";
            password = "passer1234";
            return $"Identifiants : {email} {password}";
        }
        public static void testEnumeration()
        {
            Console.WriteLine("Apuyez sur une touche !");
            Console.WriteLine("1 sur une Lundi !");
            Console.WriteLine("2 sur une Mardi !");
            Console.WriteLine("3 sur une Mercredi !");
            Console.WriteLine("4 sur une Jeudi !");
            Console.WriteLine("5 sur une Vendredi !");
            string ligne = Console.ReadLine();
            Console.WriteLine((Jours)UInt32.Parse(ligne));
        }
        public static void tester()
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
            //string sexe = clavier("Votre sexe svp !");
            //string civilite = sexe switch
            //{
            //    "M" => "Monsieur",
            //    "F" => "Madame",
            //    _ => "Madame / Monsieur"
            //};
            //show(civilite);

            //show(ligne.ToString());
            //int b = int.MaxValue;
            //int c = int.MinValue;

            //show($"max value : {b} and min value : {c}");
            //Fin du programme
            ConsoleKeyInfo ligne = Console.ReadKey();
        }
    }
}