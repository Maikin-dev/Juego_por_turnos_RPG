using System;

public abstract class Heroe
{
    private string nombre;
    private int hp;
    private int xp;
    private int damage;

    public string Nombre { get => nombre; set => nombre = value; }
    public int Hp { get => hp; set => hp = value; }
    public int XP { get => xp; set => xp = value; }
    public int Damage { get => damage; set => damage = value; }

    public Heroe()
    {
    }

    public Heroe(string nombre, int hp)
    {
        Nombre = nombre;
        Hp = hp;    
    }

    public Heroe(string nombre, int hp, int xp,int damage) : this(nombre, hp)
    {
        XP = xp;
        Damage = damage;

    }

    public abstract void Ataque(Heroe target);  //Funcion abstracta de la cual se sobreescribira la informacion dependiendo del heroe
    public abstract void Curar(List<Heroe> heroes, Heroe plus); //Funcion abstracta de la cual se sobreescribira la informacion dependiendo del heroe

    //Función en donde solo se muestra la salud y el nombre del Heroe
    public string heroResume()
    {
        return $"Esta es la informacion de tu heroe:\nNombre: {Nombre} \nPuntos de vida: {Hp}hp \n";
    }

    //Función donde se muestra toda la informacion concerniente a ese heroe.
    public override string ToString()
    {
        return $"Esta es la informacion de tu heroe:\nNombre: {Nombre} \nPuntos de vida: {Hp}hp \nPuntos de experiencia: {XP}xp \nPuntos de ataque: {Damage}Dp \n";
    }



}
