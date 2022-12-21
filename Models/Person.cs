namespace HelloWorld.Models
{ 
public class Person
{
    public int taille { get; set; }
    public int poids { get; set; }
    public string nom { get; set; }
    // init veut dire que la propriété est juste initialisable avec une valeur donnée et non modifiable tout au long du programme.
    public override string ToString()
    {
        return $"\n Nom :  {nom} \n Taille : {taille} \n Poids : {poids}  \n";
    }
}
}