using Personaje;

FabricaDePersonajes FabricarPj = new FabricaDePersonajes();

personaje Pj;

List<personaje> listaPersonajes = new List<personaje>();

Console.WriteLine("\n\nDesea cargar personajes?\n1-SI\n2-NO");

int cargado = int.Parse(Console.ReadLine());

if (cargado == 1)
{

    FabricaDePersonajes.PersonajesJson pJson = new FabricaDePersonajes.PersonajesJson();

    Console.WriteLine("Ingrese como se llamara la direccion de guardado :");

    string? archivoCargado = Console.ReadLine();

    if (pJson.Existe(archivoCargado))
    {

        listaPersonajes = pJson.LeerPersonajes(archivoCargado);

        for (int i = 0; i < 10; i++)
        {

            FabricarPj.mostrarPersonaje(listaPersonajes[i], i);

        }

    }
    else
    {

        Console.WriteLine($"La direccion ingresada no existe : {archivoCargado}");

    }



}
else
{

    for (int i = 0; i < 10; i++)
    {

        Pj = FabricarPj.crearPersonaje();

        FabricarPj.mostrarPersonaje(Pj, i);

        listaPersonajes.Add(Pj);

    }

    Console.WriteLine("\n\nDesea guardar los personajes?\n1-SI\n2-NO");

    int guardado = int.Parse(Console.ReadLine());

    if (guardado == 1)
    {

        FabricaDePersonajes.PersonajesJson pJson = new FabricaDePersonajes.PersonajesJson();

        Console.WriteLine("Ingrese como se llamara la direccion de guardado :");

        string? archivoGuardado = Console.ReadLine();

        pJson.GuardarPersonajes(listaPersonajes, archivoGuardado);


    }

}

//GAMEPLAY

//Seleccion de personajes

Console.WriteLine("Seleccione el primer personaje:");

int pj1 = int.Parse(Console.ReadLine());

Console.WriteLine("Seleccione el segundo personaje:");

int pj2 = int.Parse(Console.ReadLine());

personaje personaje1 = listaPersonajes[pj1];

personaje personaje2 = listaPersonajes[pj2];

//=====================================

//COMBATE

int j = 0;

int constAjuste = 500;

Random rdn = new Random();

while (personaje1.Salud > 0 && personaje2.Salud > 0)
{

    Console.WriteLine("Turno" + j);

    Console.WriteLine($"Personaje 1 salud : {personaje1.Salud} --- Personaje 2 salud : {personaje2.Salud}");

    //Ataca personaje1

    Console.WriteLine("Ataca Personaje 1");

    int ataquePj1 = personaje1.Destreza * personaje1.Fuerza * personaje1.Nivel;

    int efectividadPj1 = rdn.Next(0, 101);

    int defensaPj2 = personaje2.Armadura * personaje2.Velocidad;

    int dañoProvocadoPj1 = ((ataquePj1 * efectividadPj1) - defensaPj2) / constAjuste;

    personaje2.Salud = personaje2.Salud - dañoProvocadoPj1;

    Console.WriteLine($"Personaje 1 salud : {personaje1.Salud} --- Personaje 2 salud : {personaje2.Salud}");

    if (personaje2.Salud > 0)
    {

        Console.WriteLine("Ataca Personaje 2");

        int ataquePj2 = personaje2.Destreza * personaje2.Fuerza * personaje2.Nivel;

        int efectividadPj2 = rdn.Next(0, 101);

        int defensaPj1 = personaje1.Armadura * personaje1.Velocidad;

        int dañoProvocadoPj2 = ((ataquePj2 * efectividadPj2) - defensaPj1) / constAjuste;

        personaje1.Salud = personaje1.Salud - dañoProvocadoPj2;

        Console.WriteLine($"Personaje 1 salud : {personaje1.Salud} --- Personaje 2 salud : {personaje2.Salud}");

    }

    j++;

}






