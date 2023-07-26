using Personaje;
using EspacioPokemon;
using EspacioMenu;

//INSTANCIA DE CLASES

FabricaDePersonajes FabricarPj = new FabricaDePersonajes();

personaje Pj;

List<personaje> listaPersonajes = new List<personaje>();

Mostrar mostrar = new Mostrar();

//MENU PRINCIPAL

int op;

bool againMenu = true;

do
{
    Console.Clear();

    Console.WriteLine(mostrar.menuPrincipal);

    Console.WriteLine("Seleccione una opcion: ");

    if (int.TryParse(Console.ReadLine(), out op))
    {
        if (op > 0 && op < 4)
        {
            againMenu = false;
        }
        else
        {
            Console.WriteLine($"Ingreso inválido. Debes ingresar un número entre 1 y 3");
            Thread.Sleep(2000);
        }
    }
    else
    {
        Console.WriteLine($"Ingreso inválido. Debes ingresar un número entre 1 y 3");
        Thread.Sleep(2000);
    }

} while (againMenu);


switch (op)
{
    case 1:
        for (int i = 0; i < 10; i++)
        {
            Pj = FabricarPj.crearPersonaje();

            listaPersonajes.Add(Pj);
        }

        FabricarPj.mostrarListaPersonajes(listaPersonajes);

        break;

    case 2:
        bool again = true;
        do
        {

            FabricaDePersonajes.PersonajesJson pJson = new FabricaDePersonajes.PersonajesJson();


            string[] archivos = Directory.GetFiles(Directory.GetCurrentDirectory() + @"\save");

            Console.WriteLine($"Archivos encontrados en {Directory.GetCurrentDirectory()}:");

            foreach (string archivo in archivos)
            {
                Console.WriteLine(archivo);
            }
            Console.WriteLine();

            Console.WriteLine("Ingrese la direccion del archivo guardado :");

            string? archivoCargado = Console.ReadLine();

            if (pJson.Existe(archivoCargado))
            {
                listaPersonajes = pJson.LeerPersonajes(archivoCargado);

                Console.WriteLine();

                again = false;
            }
            else
            {
                Console.WriteLine($"La direccion ingresada no existe : {archivoCargado} \n Por favor ingresar nuevamente...");
            }
        } while (again);

        break;

    case 3:
        Environment.Exit(0);
        break;

}

int guardado;

bool againGuardado = true;

if (op != 2)
{
    do
    {
        Console.WriteLine("\n\nDesea guardar los personajes?\n1-SI\n2-NO");

        if (int.TryParse(Console.ReadLine(), out guardado))
        {
            if (guardado == 1)
            {
                FabricaDePersonajes.PersonajesJson pJson = new FabricaDePersonajes.PersonajesJson();

                Console.WriteLine("Ingrese como se llamara la direccion de guardado :");

                string? archivoGuardado = Console.ReadLine();

                pJson.GuardarPersonajes(listaPersonajes, archivoGuardado);

                againGuardado = false;
            }
            else if (guardado == 2)
            {
                againGuardado = false;
            }
            else
            {
                Console.WriteLine($"Ingreso una opcion invalida");
                Thread.Sleep(2000);
            }
        }
        else
        {
            Console.WriteLine($"Ingreso una opcion invalida");
            Thread.Sleep(2000);
        }

    } while (againGuardado);
}



//GAMEPLAY

//Seleccion de personajes

do
{
    FabricarPj.mostrarListaPersonajes(listaPersonajes);

    int pj1;

    bool againPj1 = true;

    int longuitud = listaPersonajes.Count - 1;

    do
    {

        Console.WriteLine("Seleccione el primer pokemon :");

        if (int.TryParse(Console.ReadLine(), out pj1))
        {
            if (pj1 <= listaPersonajes.Count && pj1 >= 0)
            {
                Console.WriteLine($"Has seleccionado el primer pokemon: {pj1}");

                againPj1 = false;
            }
            else
            {
                Console.WriteLine($"Ingreso inválido. Debes ingresar un número entre 0 y {longuitud}");
            }
        }
        else
        {
            Console.WriteLine($"Ingreso inválido. Debes ingresar un número entre 0 y {longuitud}");
        }

    } while (againPj1);

    int pj2;

    bool againPj2 = true;
    do
    {

        Console.WriteLine("Seleccione el segundo pokemon :");

        if (int.TryParse(Console.ReadLine(), out pj2))
        {
            if (pj2 <= listaPersonajes.Count && pj2 >= 0)
            {
                if (pj1 != pj2)
                {
                    Console.WriteLine($"Has seleccionado el segundo pokemon: {pj2}");

                    againPj2 = false;
                }
                else
                {
                    Console.WriteLine("No puede seleccionar ese Pokemon, es el mismo seleccionado anteriormente, intenta nuevamente...");
                }
            }
            else
            {
                Console.WriteLine($"Ingreso inválido. Debes ingresar un número entre 0 y {longuitud}");
            }
        }
        else
        {
            Console.WriteLine($"Ingreso inválido. Debes ingresar un número entre 0 y {longuitud}");
        }

    } while (againPj2);

    personaje personaje1 = listaPersonajes[pj1];

    personaje personaje2 = listaPersonajes[pj2];

    //=====================================

    //COMBATE

    int j = 0;

    int constAjuste = 500;

    Random rdn = new Random();

    while (personaje1.Salud > 0 && personaje2.Salud > 0)
    {

        Console.WriteLine("\n\n\n\tTurno " + (j + 1));

        Console.WriteLine($"Pokemon 1 salud : {personaje1.Salud} --- Pokemon 2 salud : {personaje2.Salud}");

        Console.WriteLine("\tAtaca Pokemon 1");

        Console.WriteLine(mostrar.ataquePokemon1);

        Thread.Sleep(2000);

        int ataquePj1 = personaje1.Destreza * personaje1.Fuerza * personaje1.Nivel;

        int efectividadPj1 = rdn.Next(0, 101);

        int defensaPj2 = personaje2.Armadura * personaje2.Velocidad;

        int dañoProvocadoPj1 = ((ataquePj1 * efectividadPj1) - defensaPj2) / constAjuste;

        personaje2.Salud = personaje2.Salud - dañoProvocadoPj1;

        Console.WriteLine($"Pokemon 1 salud : {personaje1.Salud} --- Pokemon 2 SALUD : {personaje2.Salud} !!!");

        if (personaje2.Salud > 0)
        {

            Console.WriteLine("\tAtaca Pokemon 2");

            Console.WriteLine(mostrar.ataquePokemon2);

            Thread.Sleep(2000);

            int ataquePj2 = personaje2.Destreza * personaje2.Fuerza * personaje2.Nivel;

            int efectividadPj2 = rdn.Next(0, 101);

            int defensaPj1 = personaje1.Armadura * personaje1.Velocidad;

            int dañoProvocadoPj2 = ((ataquePj2 * efectividadPj2) - defensaPj1) / constAjuste;

            personaje1.Salud = personaje1.Salud - dañoProvocadoPj2;

            Console.WriteLine($"Pokemon 1 SALUD : {personaje1.Salud}!!! --- Pokemon 2 salud : {personaje2.Salud}");

            Thread.Sleep(2000);

        }

        j++;

    }

    if (personaje1.Salud < 0)
    {

        Console.WriteLine($"\n\n\t===== El ganador es el Pokemon {personaje2.Nombre} =====");

        Console.WriteLine(mostrar.ganadorPokemon2);

        FabricarPj.mostrarPersonaje(personaje2);

        listaPersonajes.RemoveAt(pj1);

        Thread.Sleep(5000);

        Console.Clear();
    }
    else
    {

        Console.WriteLine($"\n\n\t====== El ganador es el Pokemon {personaje1.Nombre} =====");

        Console.WriteLine(mostrar.ganadorPokemon1);

        FabricarPj.mostrarPersonaje(personaje1);

        listaPersonajes.RemoveAt(pj2);

        Thread.Sleep(5000);

        Console.Clear();
    }

} while (listaPersonajes.Count >= 2);

if (listaPersonajes.Count == 1)
{
    personaje personaje = listaPersonajes[0];

    Console.WriteLine($"\n\n\t====== El ganador del Torneo Pokemon es el Pokemon {personaje.Nombre}, felicitaciones =====");

    Console.WriteLine(mostrar.ganadorTorneo);
}






























/*
//CARGA DE ARCHIVO 

Console.WriteLine("\n\nDesea cargar personajes?\n1-SI\n2-NO");

int cargado = int.Parse(Console.ReadLine());

bool again = true;

if (cargado == 1)
{
    do
    {

        FabricaDePersonajes.PersonajesJson pJson = new FabricaDePersonajes.PersonajesJson();


        string[] archivos = Directory.GetFiles(Directory.GetCurrentDirectory() + @"\save");

        Console.WriteLine($"Archivos encontrados en {Directory.GetCurrentDirectory()}:");

        foreach (string archivo in archivos)
        {
            Console.WriteLine(archivo);
        }
        Console.WriteLine();

        Console.WriteLine("Ingrese la direccion del archivo guardado :");

        string? archivoCargado = Console.ReadLine();

        if (pJson.Existe(archivoCargado))
        {
            listaPersonajes = pJson.LeerPersonajes(archivoCargado);

            Console.WriteLine();

            again = false;
        }
        else
        {
            Console.WriteLine($"La direccion ingresada no existe : {archivoCargado} \n Por favor ingresar nuevamente...");
        }
    } while (again);
}
else //CREACION DE UN NUEVA LISTA DE PERSONAJES
{
    for (int i = 0; i < 10; i++)
    {
        Pj = FabricarPj.crearPersonaje();

        FabricarPj.mostrarPersonaje(Pj);

        listaPersonajes.Add(Pj);
    }

    //GUARDADO DE LISTA DE PERSONAJES

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

do
{
    FabricarPj.mostrarListaPersonajes(listaPersonajes);

    int pj1;

    bool againPj1 = true;

    int longuitud = listaPersonajes.Count - 1;

    do
    {

        Console.WriteLine("Seleccione el primer pokemon :");

        if (int.TryParse(Console.ReadLine(), out pj1))
        {
            if (pj1 <= listaPersonajes.Count && pj1 >= 0)
            {
                Console.WriteLine($"Has seleccionado el primer pokemon: {pj1}");

                againPj1 = false;
            }
            else
            {
                Console.WriteLine($"Ingreso inválido. Debes ingresar un número entre 0 y {longuitud}");
            }
        }
        else
        {
            Console.WriteLine($"Ingreso inválido. Debes ingresar un número entre 0 y {longuitud}");
        }

    } while (againPj1);

    int pj2;

    bool againPj2 = true;
    do
    {

        Console.WriteLine("Seleccione el segundo pokemon :");

        if (int.TryParse(Console.ReadLine(), out pj2))
        {
            if (pj2 <= listaPersonajes.Count && pj2 >= 0)
            {
                if (pj1 != pj2)
                {
                    Console.WriteLine($"Has seleccionado el primer pokemon: {pj2}");

                    againPj2 = false;
                }
                else
                {
                    Console.WriteLine("No puede seleccionar ese Pokemon, es el mismo seleccionado anteriormente, intenta nuevamente...");
                }
            }
            else
            {
                Console.WriteLine($"Ingreso inválido. Debes ingresar un número entre 0 y {longuitud}");
            }
        }
        else
        {
            Console.WriteLine($"Ingreso inválido. Debes ingresar un número entre 0 y {longuitud}");
        }

    } while (againPj2);

    personaje personaje1 = listaPersonajes[pj1];

    personaje personaje2 = listaPersonajes[pj2];

    //=====================================

    //COMBATE

    int j = 0;

    int constAjuste = 500;

    Random rdn = new Random();

    while (personaje1.Salud > 0 && personaje2.Salud > 0)
    {

        Console.WriteLine("\n\n\n\tTurno " + (j + 1));

        Console.WriteLine($"Pokemon 1 salud : {personaje1.Salud} --- Pokemon 2 salud : {personaje2.Salud}");

        Console.WriteLine("\tAtaca Pokemon 1");

        Thread.Sleep(2000);

        int ataquePj1 = personaje1.Destreza * personaje1.Fuerza * personaje1.Nivel;

        int efectividadPj1 = rdn.Next(0, 101);

        int defensaPj2 = personaje2.Armadura * personaje2.Velocidad;

        int dañoProvocadoPj1 = ((ataquePj1 * efectividadPj1) - defensaPj2) / constAjuste;

        personaje2.Salud = personaje2.Salud - dañoProvocadoPj1;

        Console.WriteLine($"Pokemon 1 salud : {personaje1.Salud} --- Pokemon 2 salud : {personaje2.Salud}");

        if (personaje2.Salud > 0)
        {

            Console.WriteLine("\tAtaca Pokemon 2");

            Thread.Sleep(2000);

            int ataquePj2 = personaje2.Destreza * personaje2.Fuerza * personaje2.Nivel;

            int efectividadPj2 = rdn.Next(0, 101);

            int defensaPj1 = personaje1.Armadura * personaje1.Velocidad;

            int dañoProvocadoPj2 = ((ataquePj2 * efectividadPj2) - defensaPj1) / constAjuste;

            personaje1.Salud = personaje1.Salud - dañoProvocadoPj2;

            Console.WriteLine($"Pokemon 1 salud : {personaje1.Salud} --- Pokemon 2 salud : {personaje2.Salud}");

            Thread.Sleep(2000);

        }

        j++;

    }

    if (personaje1.Salud < 0)
    {

        Console.WriteLine($"\n\n\t===== El ganador es el Pokemon {personaje2.Nombre} =====");

        FabricarPj.mostrarPersonaje(personaje2);

        listaPersonajes.RemoveAt(pj1);

        Thread.Sleep(5000);

    }
    else
    {

        Console.WriteLine($"\n\n\t====== El ganador es el Pokemon {personaje1.Nombre} =====");

        FabricarPj.mostrarPersonaje(personaje1);

        listaPersonajes.RemoveAt(pj2);

        Thread.Sleep(5000);

    }

} while (listaPersonajes.Count >= 2);

if (listaPersonajes.Count == 1)
{
    personaje personaje = listaPersonajes[0];

    Console.WriteLine($"\n\n\t====== El ganador del Torneo Pokemon es el Pokemon {personaje.Nombre}, felicitaciones =====");
}

*/




