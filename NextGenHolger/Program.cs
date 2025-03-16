using System.Diagnostics;

bool loop = true;
int height = 0;
int width = 0;
Stopwatch timer = new Stopwatch();

do
{
    Console.Clear();
    Console.WriteLine("""
    Velkommen til "Find Holger".
    
    Din opgave er at finde det
    enlige '@', der er gemt i
    mængden af andre bogstaver.

    Indtast ønsket sværhedsgrad:
    "Let", "Medium" eller "Svær"
    
    """);

    string sværhedsgrad = Console.ReadLine().ToUpper();

    while (!(sværhedsgrad == "LET" || sværhedsgrad == "MEDIUM" || sværhedsgrad == "SVÆR"))
    {
        Console.Clear();
        Console.WriteLine("""
    Velkommen til "Find Holger".
    
    Din opgave er at finde det
    enlige '@', der er gemt i
    mængden af andre bogstaver.

    Indtast ønsket sværhedsgrad:
    "Let", "Medium" eller "Svær"
    """);
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Ugyldigt input. Prøv igen.");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
        sværhedsgrad = Console.ReadLine().ToUpper();
    }

    if (sværhedsgrad == "LET")
    {
        height = 16;
        width = 16;
    }
    else if (sværhedsgrad == "MEDIUM")
    {
        height = 31;
        width = 31;
    }
    else if (sværhedsgrad == "SVÆR")
    {
        height = 46;
        width = 46;
    }

    Console.Clear();
    Console.WriteLine($"""
        Du har valgt {sværhedsgrad} sværhedsgrad.
        Gør dig klar - spillet starter straks!
        """);

    Thread.Sleep(3000);

    for (int i = 5; i > 0; i--)
    {
        Console.Clear();
        Console.WriteLine(i);
        Thread.Sleep(1000);
    }

    Console.Clear();

    string[,] arr = GenerateArray(height, width);
    string[] holgerPlads = HolgerCoords();
    PlacerHolger(arr, holgerPlads);
    PrintArray(arr);
    timer.Start();

    Console.ForegroundColor = ConsoleColor.White;
    (int venstre, int top) = Console.GetCursorPosition();
    Console.WriteLine("""


    Har du fundet Holger?

    """);
    Console.Write("Indtast kolonne: ");
    string kolonne = Console.ReadLine();

    Console.Write("Indtast række:   ");
    string række = Console.ReadLine();

    Console.WriteLine();

    while (!(kolonne == holgerPlads[1] && række == holgerPlads[0]))
    {
        Console.Clear();
        PrintArray(arr);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("""


        Forkert - prøv igen!

        """);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Indtast kolonne: ");
        kolonne = Console.ReadLine();
        Console.Write("Indtast række:   ");
        række = Console.ReadLine();
        Console.WriteLine();
    }

    if (kolonne == holgerPlads[1] && række == holgerPlads[0])
    {
        timer.Stop();
        Console.WriteLine("Tillykke! Du har fundet Holger!");
        Console.WriteLine($"Din tid var: {timer.Elapsed.Minutes}m {timer.Elapsed.Seconds}s {timer.Elapsed.Milliseconds}ms");
    }

    Console.Write("Indtast dit navn for at se highscore: ");
    string navn = Console.ReadLine();

    Console.Clear();

    string filnavn = $"HolgerHighScore{sværhedsgrad}.txt";
    Directory.CreateDirectory("C:\\temp\\");

    if (!(File.Exists($"C:\\temp\\{filnavn}"))) using (FileStream fs = File.Create($"C:\\temp\\{filnavn}")) { };


    string hs = File.ReadAllText($"C:\\temp\\{filnavn}");

    List<string> list = new List<string>();

    if (hs != "") list = hs.Split(',').ToList();

    list.Add($"{timer.Elapsed.Minutes}m {timer.Elapsed.Seconds}s {timer.Elapsed.Milliseconds}ms - {navn}");

    list.Sort();

    if (list.Count == 11) list.RemoveAt(10);

    string list1 = string.Join(',', list);

    File.WriteAllText($"C:\\temp\\{filnavn}", list1);


    Console.WriteLine($"""
    Top 10 for sværhedsgraden: {sværhedsgrad}
    ___________________________________________

    """);

    int count = 1;
    foreach (string s in list)
    {
        Console.WriteLine($"{count.ToString().PadLeft(2, ' ')}: {s}");
        count++;
    }
    Console.WriteLine("___________________________________________");
    Console.WriteLine("""

    Ønsker du at spille igen?
    "Ja" eller "Nej"
    """);

    string svar = Console.ReadLine().ToLower();

    while (!(svar == "ja" || svar == "nej"))
    {
        Console.Clear();
        Console.WriteLine($"""
    Top 10 for sværhedsgraden: {sværhedsgrad}
    ___________________________________________

    """);

        count = 1;
        foreach (string s in list)
        {
            Console.WriteLine($"{count.ToString().PadLeft(2, ' ')}: {s}");
            count++;
        }
        Console.WriteLine("___________________________________________");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine();
        Console.WriteLine("Ugyldigt input");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("""

    Ønsker du at spille igen?
    "Ja" eller "Nej"
    """);
        svar = Console.ReadLine().ToLower();
    }

    if (svar == "nej") loop = false;
    else if (svar == "ja") continue;

} while (loop == true);


string[,] GenerateArray(int height, int width)
{
    Random rnd = new Random();

    string[,] arr = new string[height, width];

    arr[0, 0] = " ";

    for (int i = 1; i < height; i++)
    {
        arr[i, 0] = i.ToString();
    }
    for (int i = 1; i < width; i++)
    {
        arr[0, i] = i.ToString();
    }

    for (int i = 1; i < height; i++)
    {
        for (int j = 1; j < width; j++)
        {
            arr[i, j] = rnd.Next(1, 3) == 1 ? ((char)rnd.Next('a', 'z')).ToString() : ((char)rnd.Next('A', 'Z')).ToString();
        }
    }
    return arr;
}
void PrintArray(string[,] arrayName)
{
    Random rnd = new Random();
    for (int i = 0; i < arrayName.GetLength(0); i++)
    {
        Console.WriteLine();
        for (int j = 0; j < arrayName.GetLength(1); j++)
        {
            if (i == 0 || j == 0) Console.ForegroundColor = ConsoleColor.White;
            else Console.ForegroundColor = (ConsoleColor)rnd.Next(1, 15);
            Console.Write(arrayName[i, j].PadLeft(3, ' '));
        }
    }
}
string[] HolgerCoords()
{
    Random rnd = new Random();
    string[] coordArr = { rnd.Next(1, width).ToString(), rnd.Next(1, height).ToString() };
    return coordArr;
}
void PlacerHolger(string[,] arr, string[] holgersCoords)
{
    arr[Convert.ToInt32(holgersCoords[0]), Convert.ToInt32(holgersCoords[1])] = "@";
}