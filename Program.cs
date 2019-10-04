using System;
using System.Collections.Generic;

#pragma warning disable IDE0044

/// <summary>
///  private void Run(string name) //kan bara använda private kod inom den klassen den ligger i // () är paratmer listan, namnet plus listan kallas signatur. om man ska anropa metoden måste signaturen vara med
/// </summary>


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
		Console.ForegroundColor = ConsoleColor.Cyan;
		Console.WriteLine("Welcome to Myrstacken! \nType 'help' for help");
		Console.ResetColor();

		while (true)
		{
			Console.WriteLine("Enter command: ");

			string input = Console.ReadLine();
			string[] remove = input.Split(" ");
			string[] add = input.Split(" ");
			string[] search = input.Split(" ");

			if (add[0] == "add")
			{
				if (add.Length > 3)
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine("Syntax error, to many words");
					Console.ResetColor();
				}
				else
				{
					try
					{
						//Myra myra = new Myra(add[1], int.Parse(add[2]).ToString());
						//myror.Add(myra);
						myrstack.Add(add[1], add[2]);
					}
					catch (MyraAlreadyExistException)
					{
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.WriteLine("Myra already exists");
						Console.ResetColor();
					}
					catch (Exception e)
					{
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.WriteLine("Wrong input, try again");
						Console.ResetColor();
					}
				}
			}

			else if (search[0] == "find")
			{

			}

			else if (remove[0] == "remove")
			{
				if (remove.Length > 2)
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine("Syntax error, to many words");
					Console.ResetColor();
				}
				else
				{
					try
					{
						for (int i = myror.Count - 1; i >= 0; i--)
						{
							if (myror[i].GetName().ToLower() == remove[1].ToLower())
								myror.RemoveAt(i);
						}
					}
					catch
					{
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.WriteLine("Wrong input, try again");
						Console.ResetColor();
					}
				}
			}


			else if (input == "help")
			{
				Console.WriteLine("type 'exit' to exit \ntype 'addmyra' to add a myra \ntype listmyra to list all the myror \ntype list to list the amount of ants \ntype add [name] [legs] to add a myra");
			}

			else if (input == "addmyra")
			{
				Console.WriteLine("Enter the name of the myra: ");
				string name = Console.ReadLine();

				int numlegs = 0;
				do
				{
					Console.WriteLine("Enter the number of legs on myra " + name + ":");

					string legs = Console.ReadLine();
					try
					{
						numlegs = int.Parse(legs);
						Myra myra = new Myra(name, legs);
						myror.Add(myra);
					}
					catch (Exception e)
					{
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.WriteLine("Wrong input, try again");
						Console.ResetColor();
					}
				} while (numlegs == 0);
			}

			else if (input == "list")
			{
				Console.WriteLine(myror.Count);
			}

			else if (input == "listmyra")
			{
				for (int i = 0; i < myror.Count; i++)
				{
					if (myror[i] != null)
					{
						Console.ForegroundColor = ConsoleColor.Cyan;
						Console.WriteLine(myror[i].ToString());
						Console.ResetColor();
					}

				}
			}

			else if (input == "exit")
			{
				Environment.Exit(0);

			}

			else
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("Unknown command");
				Console.ResetColor();
			}

			/*
			switch (input)
			{
				case "exit":
						break;
				case "listmyra":
					break;
				default:
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine("Unknown command");
					Console.ResetColor();   
				}
			}
			*/
		}
	}

	class Myrstack
	{
		//Myra[] myror;
		List<Myra> myror = new List<Myra>();

		//private void Add(Myra myra)
		//{
		//	try
		//	{
		//		Myra myra = new Myra(add[1], int.Parse(add[2]).ToString());
		//		myror.Add(myra);
		//	}
		//	catch (Exception e)
		//	{
		//		Console.ForegroundColor = ConsoleColor.Yellow;
		//		Console.WriteLine("Wrong input, try again");
		//		Console.ResetColor();
		//	}
		//}

		public void Add(string name, string legs)
		{
			Myra myra = new Myra(name, legs);
			CheckDuplicate(myra);
			myror.Add(myra);
			
		}


		private void CheckDuplicate(Myra myra)
		{
			for (int i = 0; i < myror.Count; i++)
			{
				if (myror[i] != null)
				{
					if (myror[i].GetName().ToLower() == myra.GetName().ToLower())
					{
						throw new MyraAlreadyExistException();
					}
				}
			}
		}
	}

	class MyraAlreadyExistException : Exception
	{

	}

	class Myra
	{
		private string name;
		private string legs;

		public Myra(string name, string legs)
		{
			this.name = name;
			this.legs = legs;
		}

		public string GetName()
		{
			return name;
		}

		public override string ToString()
		{
			name = name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
			return name + ", " + legs;
		}
	}
}
