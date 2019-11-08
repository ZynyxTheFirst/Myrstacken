using System;

#pragma warning disable IDE0044

class Program
{
	Myrstack myrstack = new Myrstack();

	static void Main()
	{
		Program p = new Program();
		p.Run();
	}
    
    /*
     * Robin:
     * Jag är lite osäker på hur jag ska känna kring den uppdelning av ansvar som sker här.
     * Dels så gillar jag att du har en klass (myrstack) som arbetar mot listan, och att
     * den här klassen sköter program loopen. Dock så känns det som att myrstack-klassen
     * gör så mycket mer än att arbeta mot listan. Jag skulle nog hellre sett att Program
     * sköter kontroller av kommandon och sedan sedan endast skickar det som behövs till 
     * Myrstack. Det hade gjort koden betydligt lättare att läsa och undvika 
     * kodupprepning (t.ex. kollas antalet kommandon i varje metod som tar emot command
     * arrayen).
     */
	void Run()
	{
		myrstack.Loading();
		myrstack.Start();
		while (true)
		{
			string input = Console.ReadLine().ToLower();

			string[] command = input.Split(" ");

			switch (command[0])
			{
				case "exit":
					Environment.Exit(0);
					break;
				case "change":
					myrstack.Change(command);
					break;
				case "listmyra":
					myrstack.ListMyra();
					break;
				case "list":
					myrstack.List();
					break;
				case "help":
					myrstack.Help();
					break;
				case "clear":
					myrstack.Clear();
					break;
				case "add":
					myrstack.InitialAdd(command);
					break;
				case "sort":
					myrstack.Sort(command);
					break;
				case "remove":
					myrstack.Remove(command);
					break;
				case "find":
					myrstack.Find(command);
					break;
				default:
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine("Unknown command");
					Console.ResetColor();
					break;
			}
		}
	}
}


/*
 * Robin:
 * Sammanfattning:
 * Väldigt bra jobbat! Det är en väldigt ambitiös lösning på uppgiften. Kanske lite för ambitiös.
 * Koden i sig håller en relativt god läsbarhet, med tydlig namngivning och en konsekvent kodnings-
 * stil. Dock så kunde läsbarheten förbättras genom en tydligare uppdelning av ansvar mellan 
 * klasserna.
 * 
 * Annars så är programmet robust och jag kunde inte hitta några större, uppenbara logiska fel.
 * 
 * Det har varit väldigt kul att se dig arbeta på och utanför lektionerna. Du kommunicerar kring de 
 * problem som du stöter på med ett gott bruk av relevanta termer och ställer tydliga frågor. Dock
 * så anser jag (ta detta som du vill) att det finns ett behov av att öva på att dels planera arbetet
 * lite bättre, men även att ta lite avstånd från koden. Att ta bort kod är bra om man kan behålla
 * funktionaliteten.
 * 
 * Bra jobbat! Fortsätt så här!
 */