using System;
using System.Collections.Generic;
using System.Linq;

namespace RegistroTorneoFutbol
{
    
    // Clase Jugador que representa a un futbolista.
    // Incluye nombre, edad, posición y número de camiseta.
   
    public class Jugador
    {
        private string nombre;
        private int edad;
        private string posicion;
        private int numeroCamiseta;

        // Constructor que inicializa todos los campos
        public Jugador(string nombre, int edad, string posicion, int numeroCamiseta)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.posicion = posicion;
            this.numeroCamiseta = numeroCamiseta;
        }

        // Métodos get y set
        public string getNombre() { return nombre; }
        public void setNombre(string value) { nombre = value; }

        public int getEdad() 
        { return edad; }
        public void setEdad(int value)
         { edad = value; }

        public string getPosicion()
         { return posicion; }
        public void setPosicion(string value) 
        { posicion = value; }

        public int getNumeroCamiseta()
         { return numeroCamiseta; }
        public void setNumeroCamiseta(int value) 
        { numeroCamiseta = value; }

        // Sobrescribimos Equals y GetHashCode para evitar duplicados.
        // Aquí consideramos que dos jugadores son iguales si coinciden 
        // nombre, edad, posición y número de camiseta.
        public override bool Equals(object obj)
        {
            if (obj is Jugador otro)
            {
                // Nombre, edad, posición y número de camiseta
                bool mismoNombre = this.nombre.Equals(otro.nombre, StringComparison.OrdinalIgnoreCase);
                bool mismaEdad = (this.edad == otro.edad);
                bool mismaPosicion = this.posicion.Equals(otro.posicion, StringComparison.OrdinalIgnoreCase);
                bool mismoNumeroCamiseta = (this.numeroCamiseta == otro.numeroCamiseta);

                return mismoNombre && mismaEdad && mismaPosicion && mismoNumeroCamiseta;
            }
            return false;
        }

        public override int GetHashCode()
        {
            // Combinamos nombre, edad, posición y número de camiseta en minúsculas para generar un hash
            string combinacion = (this.nombre + this.edad + this.posicion + this.numeroCamiseta).ToLower();
            return combinacion.GetHashCode();
        }

        public override string ToString()
        {
            return $"Nombre: {nombre}, Edad: {edad}, Posición: {posicion}, Camiseta: {numeroCamiseta}";
        }
    }

    
    // Clase principal que contiene toda la lógica:
    //Registrar equipos
    //Agregar jugadores (con numero de camiseta)
    //Visualizar y consultar datos

    class Program
    {
        // Diccionario (Mapa):
        // Clave = nombre del equipo (string)
        // Valor = HashSet<Jugador>, para evitar duplicados
        private static Dictionary<string, HashSet<Jugador>> equipos =
            new Dictionary<string, HashSet<Jugador>>(StringComparer.OrdinalIgnoreCase);

        static void Main(string[] args)
        {
            bool salir = false;

            do
            {
                 Console.WriteLine("\n========== UNIVERSIDAD ESTATAL AMAZONICA (UEA) ==========");
                  Console.WriteLine("\n********* INGENIERIA EN TECNOLOGIAS DE LA INFORMACION ******");
                   Console.WriteLine("\nAPLICACION PARA EL REGISTRO DE JUGADORES Y EQUIPOS  PARA UN TORNEO.");
                Console.WriteLine("\n========== MENÚ PRINCIPAL ==========");
                Console.WriteLine("1. Registrar un nuevo equipo");
                Console.WriteLine("2. Agregar un jugador a un equipo");
                Console.WriteLine("3. Visualizar todos los equipos");
                Console.WriteLine("4. Consultar jugadores de un equipo");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción (1-5): ");

                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                    Console.Clear();
                        RegistrarEquipo();
                        break;

                    case "2":
                    Console.Clear();
                        AgregarJugadorAEquipo();
                        break;

                    case "3":
                    Console.Clear();
                        VisualizarEquipos();
                        break;

                    case "4":
                        ConsultarJugadoresDeUnEquipo();
                        break;

                    case "5":
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opción inválida. Intente de nuevo.");
                        break;
                }

            } while (!salir);

            Console.WriteLine("\nGracias por usar el sistema. ¡Hasta pronto!");
        }

       
        //Opción 1: Registrar un nuevo equipo pidiendo el nombre por teclado.
       
        static void RegistrarEquipo()
        {
            Console.WriteLine("\n--- REGISTRAR NUEVO EQUIPO ---");
            Console.Write("Ingrese el nombre del equipo: ");
            string nombreEquipo = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nombreEquipo))
            {
                Console.WriteLine("El nombre no puede estar vacío.");
                return;
            }

            // Verificamos si ya existe el equipo
            if (equipos.ContainsKey(nombreEquipo))
            {
                Console.WriteLine($"El equipo '{nombreEquipo}' ya está registrado.");
            }
            else
            {
                equipos[nombreEquipo] = new HashSet<Jugador>();
                Console.WriteLine($"Equipo '{nombreEquipo}' registrado exitosamente.");
            }
        }

       
        //Opción 2: Agregar un jugador (incluyendo número de camiseta) a un equipo existente.
       
        static void AgregarJugadorAEquipo()
        {
            Console.WriteLine("\n--- AGREGAR JUGADOR A UN EQUIPO ---");
            Console.Write("Nombre del equipo: ");
            string nombreEquipo = Console.ReadLine();

            // Verificamos que el equipo exista
            if (!equipos.ContainsKey(nombreEquipo))
            {
                Console.WriteLine($"No existe el equipo '{nombreEquipo}'. Regístrelo primero.");
                return;
            }

            // Pedimos los datos del jugador
            Console.Write("Nombre del jugador: ");
            string nombreJugador = Console.ReadLine();

            Console.Write("Edad del jugador (número): ");
            if (!int.TryParse(Console.ReadLine(), out int edad))
            {
                Console.WriteLine("Error: la edad debe ser un número válido.");
                return;
            }

            Console.Write("Posición del jugador: ");
            string posicion = Console.ReadLine();

            Console.Write("Número de camiseta (número): ");
            if (!int.TryParse(Console.ReadLine(), out int numeroCamiseta))
            {
                Console.WriteLine("Error: el número de camiseta debe ser un número válido.");
                return;
            }

            // Creamos el objeto Jugador con número de camiseta
            Jugador nuevoJugador = new Jugador(nombreJugador, edad, posicion, numeroCamiseta);

            // Agregamos el jugador al HashSet correspondiente
            bool agregado = equipos[nombreEquipo].Add(nuevoJugador);

            if (agregado)
            {
                Console.WriteLine($"Jugador '{nombreJugador}' agregado al equipo '{nombreEquipo}'.");
            }
            else
            {
                Console.WriteLine($"El jugador '{nombreJugador}' (camiseta {numeroCamiseta}) ya existe en el equipo '{nombreEquipo}'.");
            }
        }

   
        //Opción 3: Visualizar todos los equipos registrados, mostrando la cantidad de jugadores.
      
        static void VisualizarEquipos()
        {
            Console.WriteLine("\n--- LISTA DE EQUIPOS REGISTRADOS ---");

            if (equipos.Count == 0)
            {
                Console.WriteLine("No hay equipos registrados.");
                return;
            }

            List<string> nombresEquipos = equipos.Keys.ToList();
            for (int i = 0; i < nombresEquipos.Count; i++)
            {
                string nombreEquipo = nombresEquipos[i];
                HashSet<Jugador> jugadores = equipos[nombreEquipo];
                Console.WriteLine($"- {nombreEquipo} (Jugadores: {jugadores.Count})");
            }
        }

   
        //Opción 4: Consultar los jugadores de un equipo específico, mostrando todos sus datos (incluyendo número de camiseta).
       
        static void ConsultarJugadoresDeUnEquipo()
        {
            Console.WriteLine("\n--- CONSULTAR JUGADORES DE UN EQUIPO ---");
            Console.Write("Ingrese el nombre del equipo: ");
            string nombreEquipo = Console.ReadLine();

            if (!equipos.ContainsKey(nombreEquipo))
            {
                Console.WriteLine($"No existe el equipo '{nombreEquipo}'.");
                return;
            }

            HashSet<Jugador> jugadoresDelEquipo = equipos[nombreEquipo];
            if (jugadoresDelEquipo.Count == 0)
            {
                Console.WriteLine($"El equipo '{nombreEquipo}' no tiene jugadores registrados.");
                return;
            }

            Console.WriteLine($"Lista de jugadores del equipo '{nombreEquipo}':");

            //Convertimos el HashSet
            List<Jugador> listaJugadores = jugadoresDelEquipo.ToList();
            for (int i = 0; i < listaJugadores.Count; i++)
            {
                Jugador jug = listaJugadores[i];
                Console.WriteLine($" - {jug.ToString()}");
            }
        }
    }
}

