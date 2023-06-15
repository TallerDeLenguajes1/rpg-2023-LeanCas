using Personaje;

FabricaDePersonajes FabricarPj = new FabricaDePersonajes();

personaje Pj;

List<personaje> listaPersonajes = new List<personaje>();

for(int i=0 ; i<10 ; i++){

    Pj = FabricarPj.crearPersonaje();

    Console.WriteLine($"El nombre del personaje es {Pj.Nombre} y su apodo es {Pj.Apodo} su edad es {Pj.Edad} y sus habilidades son, nivel:{Pj.Nivel} y su armadura es {Pj.Armadura}");

    listaPersonajes.Add(Pj);

}




