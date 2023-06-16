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

            FabricarPj.mostrarPersonaje(listaPersonajes[i]);

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

        FabricarPj.mostrarPersonaje(Pj);

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







