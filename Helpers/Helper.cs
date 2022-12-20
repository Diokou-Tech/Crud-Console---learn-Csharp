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
    }
}