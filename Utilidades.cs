using System;
using System.Collections.Generic;
using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;

public static class Acciones
{

    public static void AtkOrc(List<Heroe> heroes, List<Heroe> Villanos)
    {
        /*Quise automatizar los ataques de los orcos por lo que asigne un random el cual sera utilizado como el indice de cada objetivo por lo que
         asigne el numero maximo en el rango del numero random el tamaño de la lista*/
        Random ataque = new Random();
        int ATK;

        for (int i = 0; i < Villanos.Count; i++)  //En este bucle se asegura que cada villano en la lista realice un ataque.
        {
            ATK = ataque.Next(0, heroes.Count); // Aqui se Actualiza el número random para que los orcos puedan realizar ataques a heroes diferentes.

            if (Villanos[i].XP >= 100) // Esta es una condición que simula el ataque especial de los orcos.
            {
                Villanos[i].XP -= 100; // Actualización de experiencia al utilizar el ataque especial.
                if (Villanos[i] is Orco Villain) //Condicion para acceder a los objetos de la clase.
                {
                    Console.WriteLine($"{Villain.Nombre} ha realizado un ataque de {Villanos[i].Damage} puntos daños extra a {heroes[ATK].Nombre}");
                    heroes[ATK].Hp -= Villain.Damage;  //Se le resta la vida con los puntos de daño del orco 
                    for (int j = 0; j < heroes.Count; j++) // Se realiza un bucle en la lista de los heroes para que se realice un ataque a cada uno de ellos.
                    {
                        Console.WriteLine($"{Villanos[i].Nombre} ha utilizado su ultimate realizando un ataque de {Villain.OrcPower} al enemigo {heroes[j].Nombre}");
                        heroes[j].Hp -= Villain.OrcPower;

                        Villain.XP += 15; 
                    }
                    Console.WriteLine("");
                }
            }
            else //Si este no tiene la cantidad de experiencia necesaria se realizara un ataque básico.
            {
                Console.WriteLine($" {Villanos[i].Nombre} ha realizado un ataque de {Villanos[i].Damage} puntos daños a {heroes[ATK].Nombre} \n ");
                heroes[ATK].Hp -= Villanos[i].Damage;
                Villanos[i].XP += 15;
            }
        }
    }

    // En esta función se ejecuta una función en el cual si una de las 2 listas no contiene ningún personaje se determina el final del juego.
    public static bool EndGame(List<Heroe> heroes, List<Heroe> Villanos)
    {
        if (heroes.Count <= 0) //Lista de heroes
        {
            Console.WriteLine("Haz perdido :( \nHan acabado con todos tus heroes \nsuerte para la proxima \n");
            return false;
        }
        else if (Villanos.Count <= 0) //Lista de villanos
        {
            Console.WriteLine("!!! Haz Ganado felicidades !!! \nHaz acabado con todos los villanos \n");
            return false;
        }
        return true; // Si ninguna lista esta vacía se devuelve true
    }

    //En esta función se confirma la muerte de algún heroe.
    public static void DeathHero(List<Heroe> heroes)  
    {
        for (int i = 0; i < heroes.Count; i++) // se itera sobre la lista y realiza una condición para saber si la vida esta por debajo 1.
        {
            if (heroes[i].Hp <= 0)
            {
                Console.WriteLine($" El heroe {heroes[i].Nombre} ha muerto \n");
                heroes.Remove(heroes[i]);
            }
        }
    }

    //En esta función se confirma la muerte de algún villano.
    public static void DeathVillain(List<Heroe> Villanos)
    {
        for (int i = 0; i < Villanos.Count; i++) // se itera sobre la lista y realiza una condición para saber si la vida esta por debajo 1.
        {
            if (Villanos[i].Hp <= 0)
            {
                Console.WriteLine($" El Villano: {Villanos[i].Nombre} ha muerto \n");
                Villanos.Remove(Villanos[i]);
            }
        }
    }


    public static Heroe Curacion(List<Heroe> heroes) //Esta funcion permite seleccionar el objetivo al cual ira dirigido la curacion.
    {
        Console.WriteLine("\nSelecciona a un aliado para curarlo:");

        for (int i = 0; i < heroes.Count; i++) // se itera sobre la lista.
        {
            Console.WriteLine($"{i + 1}. {heroes[i].Nombre}"); // se agrega un uno sobre el indice real de la pocision...
        }                                                         // ...para hacerlo mas amigable a la vista del usuario.

        int Heals = Convert.ToInt32(Console.ReadLine()) - 1;  // Se toma el digito y se le resta 1 para que tenga coherencia con el...
                                                              // ...índice que tienen la lista.
        return heroes[Heals];

    }

    public static Heroe Objetivo(List<Heroe> Villanos) //Esta funcion permite seleccionar el objetivo al cual ira dirigido el ataque.
    {
        Console.WriteLine("\nSelecciona un objetivo para el ataque:");

        for (int i = 0; i < Villanos.Count; i++) // se itera sobre la lista.
        {
            Console.WriteLine($"{i + 1}. {Villanos[i].Nombre}"); // se agrega un uno sobre el indice real de la pocision...
        }                                                           // ...para hacerlo mas amigable a la vista del usuario.

        int targetIndex = Convert.ToInt32(Console.ReadLine()) - 1; // Se toma el digito y se le resta 1 para que tenga coherencia con el...
                                                                    // ...índice que tienen la lista.
        return Villanos[targetIndex];
    }

    //Funcion en la cual hay multiples condiciones en las cuales se itera sobre las diferentes listas.
    public static void Informacion(List<Heroe> heroes, List<Heroe> Villanos, Heroe heroeActivo ) 
    {
        Console.WriteLine("\nSi deseas ver la informacion detallada de los heroes y villanos presiona 1  ");
        Console.WriteLine("Si deseas ver la informacion resumida de los heroes y villanos presiona presiona 2 ");
        Console.WriteLine("Si deseas ver la informacion detallada del heroe activo presiona 3 ");
        Console.WriteLine("Si no te interesa ver la informacion presiona 4\n");
        int num = Convert.ToInt32(Console.ReadLine());
        if (num == 1)
        {
            Console.WriteLine("\nLista de Héroes Guardados:");
            foreach (var heroe in heroes)
            {
                Console.WriteLine(heroe);
            }
            Console.WriteLine("\nLista de Villanos Guardados:");
            foreach (var villians in Villanos)
            {
                Console.WriteLine(villians);
            }
        }
        else if (num == 2)
        {
            Console.WriteLine("\nLista de Héroes Guardados:");
            foreach (var heroe in heroes)
            {
                Console.WriteLine(heroe.heroResume());
            }
            Console.WriteLine("\nLista de Villanos Guardados:");
            foreach (var villians in Villanos)
            {
                Console.WriteLine(villians.heroResume());
            }
        }
        else if (num == 3)
        {
            Console.WriteLine(heroeActivo);
        }
        else
        {
            Console.WriteLine("\n \n");
        }
    }

    public static void LimReady(List<Heroe> heroes)  //Esta funcion se encarga de indicar cuando haya un ataque especial aliado disponible
    {
        for (int i = 0; i < heroes.Count; i++) // Bucle para recorrer la lista de heroes
        {
            if (heroes[i].XP >= 100) // Condicion en la cual se verifica que el heroe tenga una cantidad igual o superior a 100
            {
                Console.WriteLine($"El heroe {heroes[i].Nombre} tiene su ultimate listo \n"); // Mensaje
            }
        }
    }
}

