using System.Text.Json;
using System.Text.Json.Serialization;


namespace Personaje
{




    class personaje
    {

        //CARACTERISTICAS

        private int velocidad;

        private int destreza;

        private int fuerza;

        private int nivel;

        private int armadura;

        private int salud;

        //Encapsulamiento 

        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Armadura { get => armadura; set => armadura = value; }
        public int Salud { get => salud; set => salud = value; }



        //DATOS

        private string? tipo;

        private string? nombre;

        private string? apodo;

        private DateTime fechaNac;

        private int edad;

        //Encapsulamiento

        public string? Tipo { get => tipo; set => tipo = value; }
        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Apodo { get => apodo; set => apodo = value; }
        public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
        public int Edad { get => edad; set => edad = value; }

    }

    class FabricaDePersonajes
    {


        public personaje crearPersonaje()
        { //Metodo para la creacion de personajes

            Random rdn = new Random();

            personaje pj = new personaje();

            pj.Velocidad = rdn.Next(1, 11);
            pj.Destreza = rdn.Next(1, 6);
            pj.Fuerza = rdn.Next(1, 11);
            pj.Nivel = rdn.Next(1, 11);
            pj.Armadura = rdn.Next(1, 11);
            pj.Salud = 100;

            string[] nombresTipo = new string[] { "Arquero", "Hechicero", "Vikingo", "Guerrero", "Asesino" };

            pj.Tipo = nombresTipo[rdn.Next(nombresTipo.Length)];

            string[] nombresPersonaje = new string[] { "Mario", "Luigi", "Peach", "Bowser", "Armando", "Juan" };

            pj.Nombre = nombresPersonaje[rdn.Next(nombresPersonaje.Length)];

            string[] apodosMedievales = new string[] { "El Valiente", "El Sabio", "El Justiciero", "El Intrépido", "El Noble", "El Legendario" };

            pj.Apodo = apodosMedievales[rdn.Next(apodosMedievales.Length)];

            int dia = rdn.Next(1, 29);

            int mes = rdn.Next(1, 13);

            int anio = rdn.Next(475, 1493);

            DateTime fechaNacimiento = new DateTime(anio, mes, dia);

            pj.FechaNac = fechaNacimiento;

            pj.Edad = rdn.Next(0, 301);

            return pj;

        }

        public void mostrarPersonaje(personaje pj, int i)
        {

            Console.WriteLine("\n\nPersonaje " + i);

            Console.WriteLine($"El personaje {pj.Nombre} o mejor llamado {pj.Apodo} que es de tipo {pj.Tipo}, estas son sus estadisticas:");

            Console.WriteLine($"Velocidad: {pj.Velocidad}\nDestreza: {pj.Destreza}\nFuerza: {pj.Fuerza}\nNivel: {pj.Nivel}\nArmadura: {pj.Armadura}\nSalud: {pj.Salud}");

        }

        public class PersonajesJson
        {

            public void GuardarPersonajes(List<personaje> Pj, string archivo)
            {

                //Serializacion

                string json = JsonSerializer.Serialize(Pj);

                File.WriteAllText(archivo + ".json", json);


            }

            public List<personaje> LeerPersonajes(string archivo)
            {

                //Deserializacion

                string jsonString = File.ReadAllText(archivo + ".json");

                List<personaje> listaPersonaje = new List<personaje>();

                listaPersonaje = JsonSerializer.Deserialize<List<personaje>>(jsonString);

                return listaPersonaje;

            }

            public bool Existe(string archivo)
            {

                if (File.Exists(archivo + ".json"))
                {

                    return true;

                }
                else
                {

                    return false;

                }

            }


        }







    }



}