using System;
using System.ComponentModel;

public class Magos : Heroe
{

	private int pocimas;

    public int Pocimas { get => pocimas; set => pocimas = value; }

    public Magos(string nombre, int hp, int xp, int damage, int pocimas) : base(nombre, hp, xp, damage)
	{
        Pocimas = pocimas;
    }

    public override void Ataque(Heroe target) //Con el objetivo obtenido se realizan los cambios aritmeticos
    {
        Console.WriteLine($"El heroe {Nombre} ha realizado un ataque de {Damage} al enemigo {target.Nombre} \n");
        target.Hp -= Damage;
        XP += 20;
    }


    public override void Curar(List<Heroe> heroes,Heroe plus) //Con el objetivo obtenido se realizan los cambios aritmeticos
    {
        //Esta la condicion principal la cual es el saber si el heroe cuenta con mas de 100 puntos de experiencia.
        if(XP >= 100){
            Console.WriteLine("Tu ulti esta lista deseas utilizarla? \n Presiona 1: Si \n Presiona 2: No \n"); // Si el heroe tiene exp. suficiente le preguntara...
            int deseo = Convert.ToInt32(Console.ReadLine());                                                  // ... Este decidira si utilizar la ultimate.
            if (deseo == 1)
            {                   //Si el jugador presiona 1 se realizara una curacion estandar.
                int curas = 15;
                Console.WriteLine($"El heroe {Nombre} ha restaurado {curas} puntos de vida extras a {plus.Nombre} \n");
                plus.Hp += curas;
                XP += 20;
                                                     //También se ejecutaran los cambios de la ultimate que consiste en curar a todos los heroes de la lista. 
                for (int i = 0; i < heroes.Count;i++) 
                {
                    XP = 0;
                    int vida = 35;
                    Console.WriteLine($"El heroe {Nombre} activo su ultimate y ha restaurado {vida} puntos de vida a {heroes[i].Nombre} \n");
                    heroes[i].Hp += vida;
                    XP += 20;
                }
            }
            else  // Si el jugador decide no utilizar la ultimate en todo caso se realizara una condicion en la cual se comprueba el numero de pociones.
            {
                if (Pocimas > 0)
                {
                    int curas = 15;
                    Console.WriteLine($"El heroe {Nombre} ha restaurado {curas} puntos de vida a {plus.Nombre} \n");
                    plus.Hp += curas;
                    Pocimas -= 1;
                    XP += 20;
                }
                else
                {
                    Console.WriteLine("No tienes pocimas para curar \n");
                    XP += 20;
                }
            }
        }
        else  // Si el heroe no cuenta más de 100 puntos de experiencia se ejecutara otra condición
        {       
            if (Pocimas > 0) //En esta condición se establece que dependiendo de la cantidad de pociones se realizaran los siguientes cambios
            { 
                int curas = 15;
                Console.WriteLine($"El heroe {Nombre} ha restaurado {curas} puntos de vida a {plus.Nombre} \n");
                plus.Hp += curas;
                Pocimas -= 1;
                XP += 20;
            }
            else
            {
                Console.WriteLine("No tienes pocimas para curar \n");
                XP += 20;
            }
        }
    }

    public override string ToString()
    {
        return $"Esta es la informacion de tu heroe:\nNombre: {Nombre} \nPuntos de vida: {Hp}hp \nPuntos de experiencia: {XP}xp \nPuntos de ataque: {Damage}Dp \nCantidad de pocimas: {Pocimas} \n ";
    }

}
