using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Models
{
    public class Etudiant : Person
    {
        //Attributs
        public string matricule { get; init; }
        public DateTime date_naissance { get; set; }
        public string niveau { get; set; }
        public List<string> diplome_obtenus{ get; set; }
        //Methodes
        public  string ToStringFormat()
        {
            return $"{ToString()} Matricule : {matricule} \n Date de naissance : {date_naissance.ToShortDateString()} \n Niveau : {niveau} \n diplomes obtenues : {diplome_obtenus}";
        }
    }
}
