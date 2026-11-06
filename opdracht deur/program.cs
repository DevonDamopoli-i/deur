using System;

class Program
{
    static void Main()
    {
        // Verwachte output
        Deur deur1 = new Deur("Voordeur");
        try { Console.WriteLine(deur1.SleutelGebruiken("links")); }
        catch (Exception e) { Console.WriteLine(e.Message); }
        try { Console.WriteLine(deur1.DeurOpenen()); }
        catch (Exception e) { Console.WriteLine(e.Message); }
        try { Console.WriteLine(deur1.DoorDeurLopen()); }
        catch (Exception e) { Console.WriteLine(e.Message); }

        Console.WriteLine();

        // Verwachte foutmelding pt.1 (ontgrendeld, maar niet geopend)
        Deur deur2 = new Deur("Voordeur");
        try { Console.WriteLine(deur2.SleutelGebruiken("links")); }
        catch (Exception e) { Console.WriteLine(e.Message); }
        try { Console.WriteLine(deur2.DoorDeurLopen()); }
        catch (Exception e) { Console.WriteLine(e.Message); }

        Console.WriteLine();

        // Verwachte foutmelding pt.2 (deur blijft op slot)
        Deur deur3 = new Deur("Voordeur");
        try { Console.WriteLine(deur3.SleutelGebruiken("rechts")); }
        catch (Exception e) { Console.WriteLine(e.Message); }
        try { Console.WriteLine(deur3.DeurOpenen()); }
        catch (Exception e) { Console.WriteLine(e.Message); }
        try { Console.WriteLine(deur3.DoorDeurLopen()); }
        catch (Exception e) { Console.WriteLine(e.Message); }
    }
}

public class Deur
{
    private bool opSlot;
    private bool deurOpen;
    public string deurNaam;

    public Deur(string deurNaam)
    {
        this.opSlot = true;      // De deur is op slot
        this.deurOpen = false;   // De deur is dicht
        this.deurNaam = deurNaam;
    }

    public string SleutelGebruiken(string richting)
    {
        switch (richting)
        {
            case "links":
                opSlot = false;
                return "Deur is ontgrendeld";

            case "rechts":
                if (opSlot)
                    throw new Exception($"{deurNaam} is nog op slot");
                if (deurOpen)
                    throw new Exception("Deur is open en kan niet op slot");
                opSlot = true;
                return "Deur is vergrendeld";

            default:
                throw new Exception("De sleutel kan alleen naar links of rechts worden gedraaid");
        }
    }

    public string DeurOpenen()
    {
        if (opSlot)
            throw new Exception("Deur is nog op slot en kan niet open");
        deurOpen = true;
        return "Deur is geopend!";
    }

    public string DoorDeurLopen()
    {
        if (!deurOpen)
            throw new Exception($"Je stoot tegen de {deurNaam}!");
        return "Je bent in je huiskamer!";
    }
}