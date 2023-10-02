using System;
using System.Collections.Generic;

namespace SeleccionJugadoresBasket
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Jugador> jugadores = new List<Jugador>()
            {
                new Jugador("Yeison", "Base", 8),
                new Jugador("Felipe", "Ala-Pívot", 7),
                new Jugador("Alexander", "Escolta", 9),
                new Jugador("Miguel", "Pívot", 6),
                new Jugador("Jhonatan", "Alero", 8),
                new Jugador("Camilo", "Base", 7),
            };

            Equipo equipo1 = new Equipo();
            Equipo equipo2 = new Equipo();
            Random random = new Random();

            
            while (equipo1.CantidadJugadores < 3 || equipo2.CantidadJugadores < 3)
            {
                int index = random.Next(jugadores.Count);
                Jugador jugadorElegido = jugadores[index];
                jugadores.RemoveAt(index);

                if (equipo1.CantidadJugadores < 3)
                {
                    equipo1.AgregarJugador(jugadorElegido);
                }
                else if (equipo2.CantidadJugadores < 3)
                {
                    equipo2.AgregarJugador(jugadorElegido);
                }
            }

            Console.WriteLine("Equipo 1:");
            Console.WriteLine(equipo1);

            Console.WriteLine("\nEquipo 2:");
            Console.WriteLine(equipo2);

            Console.WriteLine("\n¡Equipos completos! Comenzando el partido...");

            int puntajeEquipo1 = equipo1.CalcularPuntaje();
            int puntajeEquipo2 = equipo2.CalcularPuntaje();

            Console.WriteLine($"Equipo 1 - Puntaje: {puntajeEquipo1}");
            Console.WriteLine($"Equipo 2 - Puntaje: {puntajeEquipo2}");

            if (puntajeEquipo1 > puntajeEquipo2)
            {
                Console.WriteLine("\n¡Equipo 1 gana el partido!");
            }
            else if (puntajeEquipo2 > puntajeEquipo1)
            {
                Console.WriteLine("\n¡Equipo 2 gana el partido!");
            }
            else
            {
                Console.WriteLine("\n¡El partido termina en empate!");
            }

            Console.ReadKey();
        }
    }

    class Jugador
    {
        private string nombre;
        private string posicion;
        private int rendimiento;

        public Jugador(string nombre, string posicion, int rendimiento)
        {
            this.nombre = nombre;
            this.posicion = posicion;
            this.rendimiento = rendimiento;
        }

        public string ObtenerNombre()
        {
            return nombre;
        }

        public string ObtenerPosicion()
        {
            return posicion;
        }

        public int ObtenerRendimiento()
        {
            return rendimiento;
        }

        public override string ToString()
        {
            return $"{nombre} ({posicion}, Rendimiento: {rendimiento})";
        }
    }

    class Equipo
    {
        private List<Jugador> jugadores = new List<Jugador>();

        public int CantidadJugadores => jugadores.Count;

        public void AgregarJugador(Jugador jugador)
        {
            if (CantidadJugadores < 3)
            {
                jugadores.Add(jugador);
            }
        }

        public int CalcularPuntaje()
        {
            int puntaje = 0;
            foreach (var jugador in jugadores)
            {
                puntaje += jugador.ObtenerRendimiento();
            }
            return puntaje;
        }

        public override string ToString()
        {
            string jugadoresEquipo = "";
            foreach (var jugador in jugadores)
            {
                jugadoresEquipo += $"{jugador}\n";
            }
            return jugadoresEquipo;
        }
    }
}