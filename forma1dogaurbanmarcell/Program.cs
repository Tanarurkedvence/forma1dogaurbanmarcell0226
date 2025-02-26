using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Pilots
{
    public string Name { get; set; }
    public string Nationality { get; set; }
    public string Team { get; set; }
    public int Position { get; set; }
    public double Time { get; set; }
    public int Points { get; set; }


    public Pilots(string name, string nationality, string team, int position, double time, int points)
    {
        Name = name;
        Nationality = nationality;
        Team = team;
        Position = position;
        Time = time;
        Points = points;
    }
}

class Program { 
        static void Main(string[] args)
        {
        List<Pilots> pilots = new List<Pilots>();
        string[] lines = File.ReadAllLines("C:\\Users\\Ny20UrbánM\\Desktop\\forma1dogaurbanmarcell\\forma1dogaurbanmarcell\\melbourne2009.txt");

        for (int i = 1; i < lines.Length; i++)
        {
            string[] data = lines[i].Split(';');

            double time;
            if (!double.TryParse(data[4].Replace(".", ","), out time))
            {
                Console.WriteLine($"Hiba a versenyidő konvertálásakor: {data[4]}");
                continue;
            }

            pilots.Add(new Pilots(
                data[0],
                data[1],
                data[2],
                int.Parse(data[3]),
                time,
                int.Parse(data[5])
            ));
        }

        Console.WriteLine("1) Célba ért pilóták száma: " + pilots.Count);
        Console.WriteLine("2) Összes kiosztott világbajnoki pont: " + pilots.Sum(p => p.Points));
        Console.WriteLine("3) Német versenyzők száma: " + pilots.Count(p => p.Nationality == "germany"));
        Console.WriteLine("4) Pontot szerző csapatok: " + string.Join(", ", pilots.Where(p => p.Points > 0).Select(p => p.Team).Distinct()));

        var bestPilot = pilots.OrderBy(p => p.Time).First();
        Console.WriteLine($"5) Legjobb versenyidőt elérő pilóta: {bestPilot.Name} - {bestPilot.Time}");
        Console.ReadKey();
    }
}
