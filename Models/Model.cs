using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Models
{
    public abstract class Model
    {
        public int taille { get; set; }
        public int poids { get; set; }
        public string nom { get; set; }
    }
}
