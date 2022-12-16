namespace Models
{ 
class Person
{
    public int taille { get; set; }
    public int poids { get; set; }
    public string nom { get; init; }
    // init veut dire que la propriété est juste initialisable avec une valeur donnée et non modifiable tout au long du programme.

    public override string ToString()
    {
        return $" your .taille is {taille} , your weigth is {poids} and your name is {nom}";
    }
}
}