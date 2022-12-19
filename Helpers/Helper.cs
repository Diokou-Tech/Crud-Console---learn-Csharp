using System;

namespace HelloWorld.Helpers{
    public static class Helper
    {
        public static string langue {get; set;} = "Wolof";
        public static string devise {get; set;} = "XOF";
        public static string continent {get; set;} = "Afrique";
        public static void sendEmail(string email){
            Console.WriteLine($"Envoyer un mail à cette adresse : {email}");
        }
    }
}