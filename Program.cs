using System;
using System.Collections.Generic;

#pragma warning disable IDE0044

class Program
{
	List<Myra> myror = new List<Myra>();
	Myrstack myrstack = new Myrstack();

	static void Main()
	{
		Program p = new Program();
		p.Run();
	}

	void Run()
	{
		myrstack.Start();
		while (true)
		{
			string input = Console.ReadLine().ToLower();

			string[] command = input.Split(" ");

			if (command[0] == "add")
			{
				myrstack.InitialAdd(command);
			}
			/*
			if (command[0] == "sort")
			{
				myrstack.Sort();
			}
			*/
			if (command[0] == "find")
			{
				myrstack.Find(command);
			}

			if (command[0] == "findlegs")
			{
				myrstack.FindLegs(command);
			}

			if (command[0] == "remove")
			{
				myrstack.Remove(command);
			}

			if (command[0] == "help")
			{
				myrstack.Help();
			}

			if (command[0] == "list")
			{
				myrstack.List();
			}

			if (command[0] == "listmyra")
			{
				myrstack.ListMyra();
			}

			if (command[0] == "clear")
			{
				myrstack.Clear();
			}

			if (command[0] == "exit")
			{
				Environment.Exit(0);
			}

			switch (command[0])
			{
				case "exit":
					break;
				case "listmyra":
					break;
				case "list":
					break;
				case "help":
					break;
				case "clear":
					break;
				case "add":
					break;
				case "remove":
					break;
				case "find":
					break;
				case "findlegs":
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
