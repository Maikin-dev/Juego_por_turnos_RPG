using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace PRUEBA_HERENCIA //Juego por turnos hecho en consola.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Lista en donde se agregaran los heroes y villanos que desee.
           //heroes
            List<Heroe> heroes = new List<Heroe>
            {        //Campos: Nombre, vida, experiencia, daño y poder especial (En el caso del magos es la cantidad de pocimas).
            new Caballero("Finn", 300, 0, 25, 100),
            new Magos("Dumbledore", 200, 0, 20, 3), 
            new Caballero("Guts",225,0,30,125)
            };
            // villanos 
            List<Heroe> Villanos = new List<Heroe> 
            {       //Campos: Nombre, vida, experiencia, daño y poder especial.
            new Orco("Thanos", 450, 20, 40, 25),
            new Orco("Voldermort",350,35,30,30)
            };
            // Aqui se declara el turno y el estado del juego.
            int turn = 0;
            bool Game = true;

            while (Game) //Mientras el juego sea verdadero se mantendra la condicion while.
            {
                
                Heroe heroeActivo = heroes[turn % heroes.Count]; // se declara una variable de tipo Heroe donde el resultado del residuo es igual a la posicion de la lista.

                Console.WriteLine("¿Quieres saber del status de los personajes? \nPresiona 1: Sí \nPresiona 2: No \n");  // Condicion para obtener informacion de los personajes.
                int status = Convert.ToInt32(Console.ReadLine());
                if (status == 1)
                {
                    Acciones.Informacion(heroes, Villanos, heroeActivo);
                }

                bool opcionValida = false; // Booleano para darle oportunidad al usuario de elegir una opcion nuevamente si comete algun error.
                while (!opcionValida)
                {
                    Console.WriteLine("\nPresiona en el tabulador una de las siguientes opciones: ");
                    Console.WriteLine("Presiona 1: Ataque");
                    Console.WriteLine("Presiona 2: Curar");
                    Console.WriteLine("Presiona 3: Acabar Juego \n");
                    Acciones.LimReady(heroes); //Se verifica si algun heroe tienes su ultimate disponible.
                    var Control = heroeActivo.Nombre;
                    Console.WriteLine($"Es el turno de {Control}\nDecide el movimiento: \n"); //Mensaje que avisa al jugador el turno del heroe.

                    int estado = Convert.ToInt32(Console.ReadLine());
                    switch (estado) //switch para toma de decisión
                    {
                        case 1:
                            Heroe target = Acciones.Objetivo(Villanos); // Se declara variable de clase target con el villano obtenido en la función.
                            heroeActivo.Ataque(target); //Se invoca la función de ataque.
                            opcionValida = true; // Se marca como verdadero para que pueda salir del bucle.
                            break;

                        case 2:
                            if(heroeActivo is Magos)
                            {
                                Heroe plus = Acciones.Curacion(heroes); // Se declara variable de clase plus con el heroe obtenido en la función.
                                heroeActivo.Curar(heroes, plus); //Se invoca la función de ataque.
                                opcionValida = true; // Se marca como verdadero para que pueda salir del bucle.
                            }
                            else
                            {
                                Console.WriteLine("Este heroe no puede usar magia para curar\n Solo puedes hacer Ataques con este heroe.");
                                opcionValida = false; // Se marca como falso para que el usuario pueda intentarlo de nuevo.
                            }
                            break;

                        case 3:
                            Console.WriteLine("Gracias por Jugar");
                            Game = false; //Se marca como falso haciendo que se rompa el bucle original 
                            opcionValida = true; // Se marca como verdadero para que pueda salir del bucle.
                            break;

                        default:
                            Console.WriteLine("Opción inválida, intenta de nuevo.\n");
                            opcionValida = false; // Se marca como verdadero para que el usuario pueda intentarlo de nuevo.
                            break;
                    }
                }
                Acciones.DeathVillain(Villanos); //Esta función es invocada para saber si un Orco/Villano ha muerto.

                int tork = heroes.Count - 1; //Aqui simplemente se obtiene el numero de personajes en la lista de heroes en base a su indice.
                if (heroeActivo == heroes[tork]) //Esta es una condicion en la cual si los turnos del jugador fueron agotados, los orcos realizaran sus turnos.
                {
                    Console.WriteLine("\nEs turno de los orcos de realizar sus ataques: \n");
                    Acciones.AtkOrc(heroes, Villanos); //Se invoca la funcion para los ataques de los orcos
                }

                Acciones.DeathHero(heroes); //Esta función es invocada para saber si un Heroe(Caballero/Mago) ha muerto.

                if (Game == true) // En esta condicion se verifica que el juego este activo  
                {
                    Game = Acciones.EndGame(heroes, Villanos); //Se invoca la funcio
                }

                turn++; //Se incrementa el turno para dar paso al siguiente heroe
               
            }
        }
    }
}
