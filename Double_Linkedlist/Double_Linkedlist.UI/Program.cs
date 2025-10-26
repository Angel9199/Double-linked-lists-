using Double_Linkedlist.Logic;

var list = new DoubleList<string>();
int option;

do
{
    Console.Clear();
    Console.WriteLine("=== MENÚ DE LISTA DOBLEMENTE LIGADA ===");
    Console.WriteLine("1. Adicionar");
    Console.WriteLine("2. Mostrar hacia adelante");
    Console.WriteLine("3. Mostrar hacia atrás");
    Console.WriteLine("4. Ordenar descendentemente");
    Console.WriteLine("5. Mostrar moda(s)");
    Console.WriteLine("6. Mostrar gráfico");
    Console.WriteLine("7. Existe");
    Console.WriteLine("8. Eliminar una ocurrencia");
    Console.WriteLine("9. Eliminar todas las ocurrencias");
    Console.WriteLine("0. Salir");
    Console.Write("Seleccione una opción: ");

} while (!int.TryParse(Console.ReadLine(), out option) || option < 0 || option > 9);

while (option != 0)
{
    Console.Clear();
    switch (option)
    {
        case 1:
            Console.Write("Ingrese un elemento: ");
            var item = Console.ReadLine()!;
            list.AddSorted(item);
            Console.WriteLine("Elemento agregado en orden.");
            break;

        case 2:
            Console.WriteLine("Lista hacia adelante:");
            Console.WriteLine(list);
            break;

        case 3:
            Console.WriteLine("Lista hacia atrás:");
            Console.WriteLine(list.ToInvertedList());
            break;

        case 4:
            list.SortDescending();
            Console.WriteLine("Lista ordenada descendentemente.");
            break;

        case 5:
            var modas = list.GetModes();
            Console.WriteLine("Moda(s): " + string.Join(", ", modas));
            break;

        case 6:
            Console.WriteLine("Gráfico de ocurrencias:");
            Console.WriteLine(list.GetFrequencyGraph());
            break;

        case 7:
            Console.Write("Ingrese el elemento a buscar: ");
            var search = Console.ReadLine()!;
            Console.WriteLine(list.Exists(search)
                ? "El elemento existe en la lista."
                : "El elemento NO existe en la lista.");
            break;

        case 8:
            Console.Write("Ingrese el elemento a eliminar (una ocurrencia): ");
            var one = Console.ReadLine()!;
            Console.WriteLine(list.RemoveOne(one)
                ? "Elemento eliminado."
                : "Elemento no encontrado.");
            break;

        case 9:
            Console.Write("Ingrese el elemento a eliminar (todas las ocurrencias): ");
            var all = Console.ReadLine()!;
            int count = list.RemoveAll(all);
            Console.WriteLine(count > 0
                ? $"Se eliminaron {count} ocurrencia(s)."
                : "Elemento no encontrado.");
            break;
    }

    Console.WriteLine("\nPresione una tecla para continuar...");
    Console.ReadKey();
    do
    {
        Console.Clear();
        Console.WriteLine("=== MENÚ DE LISTA DOBLEMENTE LIGADA ===");
        Console.WriteLine("1. Adicionar");
        Console.WriteLine("2. Mostrar hacia adelante");
        Console.WriteLine("3. Mostrar hacia atrás");
        Console.WriteLine("4. Ordenar descendentemente");
        Console.WriteLine("5. Mostrar moda(s)");
        Console.WriteLine("6. Mostrar gráfico");
        Console.WriteLine("7. Existe");
        Console.WriteLine("8. Eliminar una ocurrencia");
        Console.WriteLine("9. Eliminar todas las ocurrencias");
        Console.WriteLine("0. Salir");
        Console.Write("Seleccione una opción: ");

    } while (!int.TryParse(Console.ReadLine(), out option) || option < 0 || option > 9);
}


