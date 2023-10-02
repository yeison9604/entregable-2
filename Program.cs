using System;

interface IBatalla
{
    int RealizarBatalla(PokemonBase p1, PokemonBase p2);
}

abstract class PokemonBase
{
    private string nombre;
    private string tipo;
    private int[] ataques = new int[3];
    private int defensa;

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public string Tipo
    {
        get { return tipo; }
        set { tipo = value; }
    }

    public int[] Ataques
    {
        get { return ataques; }
        set { ataques = value; }
    }

    public int Defensa
    {
        get { return defensa; }
        set { defensa = value; }
    }

    public PokemonBase()
    {
    }

    public PokemonBase(string nombre, string tipo, int[] ataques, int defensa)
    {
        this.nombre = nombre;
        this.tipo = tipo;
        this.ataques = ataques;
        this.defensa = defensa;
    }

    public abstract int Atacar();
    public abstract double Defend();
}

class Pokemon1 : PokemonBase
{
    public Pokemon1()
    {
    }

    public Pokemon1(string nombre, string tipo, int[] ataques, int defensa)
        : base(nombre, tipo, ataques, defensa)
    {
    }

    public override int Atacar()
    {
        Random rand = new Random();
        int ataqueSeleccionado = rand.Next(3);
        int multiplicador = rand.Next(2);
        int damage = Ataques[ataqueSeleccionado] * multiplicador;
        return damage;
    }

    public override double Defend()
    {
        Random rand = new Random();
        double multiplicador = rand.Next(2) == 0 ? 0.5 : 1;
        double resultado = Defensa * multiplicador;
        return resultado;
    }
}

class Pokemon2 : PokemonBase
{
    public Pokemon2()
    {
    }

    public Pokemon2(string nombre, string tipo, int[] ataques, int defensa)
        : base(nombre, tipo, ataques, defensa)
    {
    }

    public override int Atacar()
    {
        Random rand = new Random();
        int ataqueSeleccionado = rand.Next(3);
        int multiplicador = rand.Next(2);
        int damage = Ataques[ataqueSeleccionado] * multiplicador;
        return damage;
    }

    public override double Defend()
    {
        Random rand = new Random();
        double multiplicador = rand.Next(2) == 0 ? 0.5 : 1;
        double resultado = Defensa * multiplicador;
        return resultado;
    }
}

class Program : IBatalla
{
    static void Main(string[] args)
    {
        PokemonBase pokemon1 = CrearPokemon();
        PokemonBase pokemon2 = CrearPokemon();

        Console.WriteLine("¡Comienza el combate!");

        int resultado = new Program().RealizarBatalla(pokemon1, pokemon2);

        if (resultado > 0)
        {
            Console.WriteLine($"{pokemon1.Nombre} gana!");
        }
        else if (resultado < 0)
        {
            Console.WriteLine($"{pokemon2.Nombre} gana!");
        }
        else
        {
            Console.WriteLine("¡Es un empate!");
        }
    }

    public static PokemonBase CrearPokemon()
    {
        PokemonBase pokemon = null;
        string nombre, tipo;
        int[] ataques = new int[3];
        int defensa;

        Console.WriteLine("Ingresa el nombre del Pokémon:");
        nombre = Console.ReadLine();

        Console.WriteLine("Ingresa el tipo del Pokémon:");
        tipo = Console.ReadLine();

        Console.WriteLine("Ingresa los puntajes de los 3 ataques:");
        for (int i = 0; i < 3; i++)
        {
            do
            {
                Console.Write($"Ataque {i + 1}: ");
            } while (!int.TryParse(Console.ReadLine(), out ataques[i]) || ataques[i] < 0 || ataques[i] > 40);
        }

        do
        {
            Console.WriteLine("Ingresa el valor de defensa (entre 10 y 35):");
        } while (!int.TryParse(Console.ReadLine(), out defensa) || defensa < 10 || defensa > 35);

        Console.WriteLine("¿Elija el Pokémon 1 o 2?");
        int opcion;
        while (!int.TryParse(Console.ReadLine(), out opcion) || (opcion != 1 && opcion != 2))
        {
            Console.WriteLine("Opción inválida. Por favor, elija el Pokémon 1 o 2.");
        }

        if (opcion == 1)
        {
            pokemon = new Pokemon1(nombre, tipo, ataques, defensa);
        }
        else if (opcion == 2)
        {
            pokemon = new Pokemon2(nombre, tipo, ataques, defensa);
        }

        return pokemon;
    }

    public int RealizarBatalla(PokemonBase p1, PokemonBase p2)
    {
        int p1Puntos = 0;
        int p2Puntos = 0;

        for (int turno = 1; turno <= 3; turno++)
        {
            Console.WriteLine($"Turno {turno}");

            int p1Ataque = p1.Atacar();
            double p2Defensa = p2.Defend();
            Console.WriteLine($"{p1.Nombre} ataca con {p1Ataque} de daño.");
            Console.WriteLine($"{p2.Nombre} se defiende con {p2Defensa} de defensa.");

            int p2Ataque = p2.Atacar();
            double p1Defensa = p1.Defend();
            Console.WriteLine($"{p2.Nombre} ataca con {p2Ataque} de daño.");
            Console.WriteLine($"{p1.Nombre} se defiende con {p1Defensa} de defensa.");

            p1Puntos += p1Ataque > p2Defensa ? 1 : 0;
            p2Puntos += p2Ataque > p1Defensa ? 1 : 0;
        }

        return p1Puntos.CompareTo(p2Puntos);
    }
}