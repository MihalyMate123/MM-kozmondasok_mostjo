using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void beolv(string txt, List<string> reszek)
    {
        StreamReader be = new StreamReader(txt);
        string sor;
        while ((sor = be.ReadLine()) != null)
        {
            reszek.Add(sor);
        }
    }

    static void leghosszabbsor(List<string> reszek)
    {
        string leghossz = reszek.OrderByDescending(x => x.Length).First();
        Console.WriteLine(leghossz);
    }

    static void kozos(List<string> elso, List<string> masodik, List<string> kozos)
    {
        foreach (string line in elso)
            kozos.Add(line);

        foreach (string line in masodik)
            kozos.Add(line);
    }

    static void abc_sorrend(List<string> kozos, List<string> abc)
    {
        abc.AddRange(kozos.OrderBy(x => x).ToList());
    }

    static int nem_szokoz(List<string> reszek)
    {
        return reszek.Sum(a => a.Count(x => !char.IsWhiteSpace(x)));
    }

    static void kulonfile(string txt, List<string> reszek)
    {
        StreamWriter writer = new StreamWriter(txt);
        foreach (string line in reszek)
        {
            writer.WriteLine(line);
        }
        writer.Close();
    }
    static void Main()
    {
        /*
        Közmondások
        MM - 2025.01.31.
        */

        string fejlec = "Közmondások";
        Console.WriteLine(fejlec);
        for (int i = 0; i < fejlec.Length; i++) Console.Write('-');
        Console.WriteLine();

        
        
        List<string> elso = new List<string>();
        List<string> masodik = new List<string>();
        List<string> kozoslista = new List<string>();
        List<string> abc_sor = new List<string>();


        beolv("szoveg1.txt", elso);
        beolv("szoveg2.txt", masodik);

        Console.WriteLine("1.feladat:");
        Console.WriteLine($"Az első állomány {elso.Count} sort tartalmaz, a második {masodik.Count} sort tartalmaz.");

        Console.WriteLine("--------------------");
        Console.WriteLine("2.feladat:");
        Console.Write("Az első állomány leghosszabb sora: ");
        leghosszabbsor(elso);

        Console.Write("A második állomány leghosszabb sora: ");
        leghosszabbsor(masodik);

        kozos(elso, masodik, kozoslista);
        abc_sorrend(kozoslista, abc_sor);

        Console.WriteLine("--------------------");
        Console.WriteLine("4.feladat:");
        foreach (string lines in abc_sor)
            Console.WriteLine(lines);

        var nemszokoz =  nem_szokoz(kozoslista);
        Console.WriteLine("--------------------");
        Console.WriteLine("5.feladat:");
        Console.WriteLine($"A nem szóköz karakterek száma: {nemszokoz}");

        kulonfile("kozmondasok.txt", abc_sor);
        Console.WriteLine();
        Console.WriteLine("Kilépéshez nyomja meg az ENTER-t");
        Console.ReadLine();
    }


}
//nig