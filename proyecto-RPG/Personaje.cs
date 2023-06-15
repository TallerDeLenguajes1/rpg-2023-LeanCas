using System.Text.Json; 
using System.Text.Json.Serialization;


namespace Personaje {

    


    class personaje{

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

    class FabricaDePersonajes{


        public personaje crearPersonaje(){ //Metodo para la creacion de personajes

            Random rdn = new Random();

            personaje pj = new personaje();

            pj.Velocidad = rdn.Next(0,11);
            pj.Destreza = rdn.Next(0,6);
            pj.Fuerza = rdn.Next(0,11);
            pj.Nivel = rdn.Next(0,11);
            pj.Armadura = rdn.Next(0,11);
            pj.Salud = 100;

            Console.WriteLine("Ingrese el tipo de personaje");

            pj.Tipo = Console.ReadLine();

            Console.WriteLine("Ingrese el nombre del personaje");

            pj.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el apodo del personaje");

            pj.Apodo = Console.ReadLine();

            Console.WriteLine("Ingrese la fecha de nacimiento del personaje");

            pj.FechaNac = DateTime.Parse(Console.ReadLine());

            pj.Edad = rdn.Next(0,301);

            return pj;

        }

        class PersonajesJson {

            public void GuardarPersonajes(List<personaje> Pj, string archivo){

                //Serializacion

                string json = JsonSerializer.Serialize(Pj);

                File.WriteAllText("personaje.json", json);


            }

            public List<personaje> LeerPersonajes(string archivo){

                //Deserializacion

                string jsonString = File.ReadAllText(archivo);

                List<personaje> listaPersonaje = new List<personaje>();

                listaPersonaje = JsonSerializer.Deserialize<List<personaje>>(jsonString);

                return listaPersonaje;

            }

            public bool Existe(string archivo){


                return;
            }


        } 




        


    }



}