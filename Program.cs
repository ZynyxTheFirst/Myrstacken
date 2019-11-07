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
