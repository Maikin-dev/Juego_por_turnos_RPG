using System;
using System.ComponentModel;

public class Caballero : Heroe
{

	private int limite;

    public int Limite { get => limite; set => limite = value; }

    public Caballero(string nombre, int hp, int xp, int damage, int limite) : base(nombre ,hp ,xp ,damage)
	{
     Limite = limite;
	}

    public override void Ataque(Heroe target)
    {
        if (XP >= 100)
        {
            Console.WriteLine("\nTu ultimate esta lista deseas utilizarla? \n Presiona 1: Si \n Presiona 2: No \n");
            int deseo = Convert.ToInt32(Console.ReadLine());
            if (deseo == 1)
            {
                XP = 0;
                Console.WriteLine($"!!!! El heroe {Nombre} ha utilizado su ultimate realizando un ataque de {Limite} puntos de daño al enemigo {target.Nombre} !!!!!\n");
                target.Hp -= Limite;
            }
            else
            {
                Console.WriteLine($"El heroe {Nombre} ha realizado un ataque de {Damage} al enemigo {target.Nombre} \n");
                target.Hp -= Damage;
                XP += 15;
            }
        }
        else
        {
            Console.WriteLine($"El heroe {Nombre} ha realizado un ataque de {Damage} al enemigo {target.Nombre} \n");
            target.Hp -= Damage;
            XP += 15;
        }
    }

    public override void Curar(List<Heroe> heroes,Heroe plus)
    {
        Console.WriteLine("Este heroe no puede curar \n" );
    }

 

    public override string ToString()
    {
        return $"Esta es la informacion de tu heroe:\nNombre: {Nombre} \nPuntos de vida: {Hp}hp \nPuntos de experiencia: {XP}xp \nPuntos de ataque: {Damage}Ap \nDaño ataque especial: {limite}Lim \n ";
    }

}
