using Personaje;

FabricaDePersonajes FabricarPj = new FabricaDePersonajes();

personaje Pj = new personaje();

Pj = FabricarPj.crearPersonaje();

Console.WriteLine($"El nombre del personaje es {Pj.Nombre} y su apodo es {Pj.Apodo} su edad es {Pj.Edad} y sus habilidades son, nivel:{Pj.Nivel} y su armadura es {Pj.Armadura}");

