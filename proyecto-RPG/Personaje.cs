using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using EspacioPokemon;


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

        private DateTime fechaNac;

        private int edad;

        //Encapsulamiento

        public string? Tipo { get => tipo; set => tipo = value; }
        public string? Nombre { get => nombre; set => nombre = value; }
        public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
        public int Edad { get => edad; set => edad = value; }

    }

    class FabricaDePersonajes
    {

        public personaje crearPersonaje()
        { //Metodo para la creacion de personajes

            Random rdn = new Random();

            personaje pj = new personaje();

            PersonajesJson pjson = new PersonajesJson();

            pj.Velocidad = rdn.Next(1, 11);
            pj.Destreza = rdn.Next(1, 11);
            pj.Fuerza = rdn.Next(4, 11);
            pj.Nivel = rdn.Next(1, 11);
            pj.Armadura = rdn.Next(1, 11);
            pj.Salud = 100;

            string[] nombresTipo = new string[] { "Fuego", "Tierra", "Agua", "Viento" };

            pj.Tipo = nombresTipo[rdn.Next(nombresTipo.Length)];

            pj.Nombre = pjson.Get();

            int dia = rdn.Next(1, 29);

            int mes = rdn.Next(1, 13);

            int anio = rdn.Next(475, 1493);

            DateTime fechaNacimiento = new DateTime(anio, mes, dia);

            pj.FechaNac = fechaNacimiento;

            pj.Edad = rdn.Next(0, 301);

            return pj;

        }

        public void mostrarListaPersonajes(List<personaje> listaPersonaje)
        {

            int i = 0;
            foreach (var pj in listaPersonaje)
            {
                Console.WriteLine($"=============== POKEMON {i} =================== ");

                Console.WriteLine($"El pokemon {pj.Nombre} de tipo {pj.Tipo}");

                Console.WriteLine($"Velocidad: {pj.Velocidad}\nDestreza: {pj.Destreza}\nFuerza: {pj.Fuerza}\nNivel: {pj.Nivel}\nArmadura: {pj.Armadura}\nSalud: {pj.Salud}");

                i++;
            }

        }

        public void mostrarPersonaje(personaje pj)
        {

            Console.WriteLine("==================================");

            Console.WriteLine($"El pokemon {pj.Nombre} de tipo {pj.Tipo}");

            Console.WriteLine($"Velocidad: {pj.Velocidad}\nDestreza: {pj.Destreza}\nFuerza: {pj.Fuerza}\nNivel: {pj.Nivel}\nArmadura: {pj.Armadura}\nSalud: {pj.Salud}");

        }

        public class PersonajesJson
        {

            public void GuardarPersonajes(List<personaje> Pj, string archivo)
            {
                //Serializacion

                string path = Directory.GetCurrentDirectory();

                if (!Directory.Exists(path + @"/save"))
                {

                    Directory.CreateDirectory(path + @"/save");
                }

                string json = JsonSerializer.Serialize(Pj);

                File.WriteAllText(path + @"/save/" + archivo + ".json", json);
            }

            public List<personaje> LeerPersonajes(string archivo)
            {

                //Deserializacion

                string path = Directory.GetCurrentDirectory();

                path = path + @"/save/";

                string jsonString = File.ReadAllText(@"save/" + archivo + ".json");

                List<personaje> listaPersonaje = new List<personaje>();

                listaPersonaje = JsonSerializer.Deserialize<List<personaje>>(jsonString);

                return listaPersonaje;

            }

            public bool Existe(string archivo)
            {
                string path = Directory.GetCurrentDirectory();

                if (File.Exists(path + @"/save/" + archivo + ".json"))
                {

                    return true;

                }
                else
                {

                    return false;

                }

            }

            public string Get()
            {
                var url = $"https://pokeapi.co/api/v2/pokemon?offset=0&limit=100";
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Accept = "application/json";

                Random random = new Random();

                try
                {

                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream strReader = response.GetResponseStream())
                        {
                            if (strReader != null)
                            {
                                using (StreamReader sr = new StreamReader(strReader))
                                {
                                    string responseBody = sr.ReadToEnd();

                                    Pokemon pokemonClase = JsonSerializer.Deserialize<Pokemon>(responseBody);

                                    string nombre = pokemonClase.results[random.Next(0, 100)].name;

                                    return nombre;

                                }
                            }
                        }
                    }

                }
                catch (WebException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return null;
            }

        }

    }



}