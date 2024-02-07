using System.Text.Json;

namespace projekt_pole_10x10
{
    internal class Program
    {
        static int x;

        static void Main(string[] args)
        {
            int[,] hracipole = new int[10, 10];
            char[] pismena = new char[10];
            NaplnPismena(pismena);
            VypisPismena(pismena);
            NaplnPole(hracipole);
            VypisPole(hracipole);
            hra(hracipole, pismena);
        }
        //--------------------------------------MAIN---------------------------------------//
        static void hra(int[,] hracipole, char[] pismena)   // odehrava se tady hra
        {
            int UhodnuteLode = 0;
            int PocetPokusu = 0;
            while (UhodnuteLode < 4)
            {
                Console.WriteLine("Zadej souřandnice kam chceš vystřelit(např.: 6 pak C): ");
                Console.Write("řádek:  ");
                int radek = Parse();
                Console.Write("sloupec:  ");
                string pismenka = Console.ReadLine().ToUpper();

                int sloupec = ConvertChar(pismenka);

                if (hracipole[radek - 1, sloupec - 1] == 1)
                {
                    hracipole[radek - 1, sloupec - 1] = 2;
                    UhodnuteLode++;
                    PocetPokusu++;
                    Console.Write("Trefil ses!");
                }
                else
                {
                    PocetPokusu++;
                    Console.Write("netrefil ses");
                    if (PocetPokusu > 3)
                    {
                        Console.WriteLine(". Chceš nápovědu? (ano/ne)");
                        string odpoved = Console.ReadLine();
                        if (odpoved.ToLower() == "ano")
                        {
                            Console.WriteLine($"Je to na řádku {x + 1} ");
                        }
                    }
                }
                if (UhodnuteLode == 4)
                {
                    Console.Write("\n    ");
                    VypisPismena(pismena);
                    VypisPole(hracipole);
                    Console.WriteLine("Loď byla potopena. gg ");
                    Console.WriteLine($"Potřeboval jsi {PocetPokusu} pokusů na její potopení. ");
                }
                Console.WriteLine();
            }
        }
        static void VypisPole(int[,] hracipole)    // vypise pole a čísílka vlevo
        {
            Console.WriteLine("");
            for (int r = 0; r < hracipole.GetLength(0); r++)
            {
                if (r + 1 < 10)
                {
                    Console.Write($" {r + 1}| ");
                }
                else
                {
                    Console.Write($"{r + 1}| ");
                }
                for (int s = 0; s < hracipole.GetLength(1); s++)
                {
                    if (hracipole[r, s] == 0)
                    {
                        Console.Write("0 ");
                    }
                    else if (hracipole[r, s] == 1)
                    {
                        Console.Write("0 ");
                    }
                    else
                    {
                        Console.Write("X ");
                    }
                }
                Console.WriteLine();
            }
        }
        static void NaplnPole(int[,] hracipole)   //vytvoří 1 lodičku
        {
            Random random = new Random();
            x = random.Next(0, 10);
            int y = random.Next(0, 6);
            int i = 4;
            for (int r = 0; r < hracipole.GetLength(0); r++)
            {
                for (int s = 0; s < hracipole.GetLength(1); s++)
                {
                    hracipole[r, s] = 0;
                }
            }
            for (int r = 0; r < hracipole.GetLength(0); r++)
            {
                for (int s = 0; s < hracipole.GetLength(1); s++)
                {
                    if (r == x && s == y)
                    {
                        if (i > 0)
                        {
                            hracipole[r, s] = 1;
                            Console.Write($"| {x + 1};{y + 1} | ");   // napověda pro kontrolu (nemusi to tam byt)
                            i--;
                            y++;
                        }
                    }
                }
            }
        }
        static void NaplnPismena(char[] pismena) // ty písmena nad hracim polem
        {
            Console.Write("    ");
            for (int i = 0; i < pismena.Length; i++)
            {
                pismena[i] = (char)('A' + i);
            }
        }
        static void VypisPismena(char[] pismena) // tohle je zas vypise
        {
            foreach (var item in pismena)
            {
                Console.Write(item + " ");
            }
        }
        static int ConvertChar(string pismenka) // převádí písmena na čisla pro orientaci v poli
        {
            int sloupec = -1;
            switch (pismenka)
            {
                case "A":
                    sloupec = 1;
                    break;
                case "B":
                    sloupec = 2;
                    break;
                case "C":
                    sloupec = 3;
                    break;
                case "D":
                    sloupec = 4;
                    break;
                case "E":
                    sloupec = 5;
                    break;
                case "F":
                    sloupec = 6;
                    break;
                case "G":
                    sloupec = 7;
                    break;
                case "H":
                    sloupec = 8;
                    break;
                case "I":
                    sloupec = 9;
                    break;
                case "J":
                    sloupec = 10;
                    break;
                default:
                    Console.WriteLine("Špatně zadané hodnoty.");
                    break;
            }
            return sloupec;
        }
        static int Parse() //tryparse metoda
        {
            int num;
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("špatně zadané hodnoty");
            }
            return num;
        }
    }
}