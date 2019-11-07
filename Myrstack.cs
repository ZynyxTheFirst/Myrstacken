using System;
using System.Collections.Generic;
using System.Threading;

class Myrstack
{
	List<Myra> myror = new List<Myra>();

	public void Start()
	{
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine(@"                       _             _              ");
		Console.WriteLine(@"  /\/\  _   _ _ __ ___| |_ __ _  ___| | _____ _ __  ");
		Console.WriteLine(@" /    \| | | | '__/ __| __/ _` |/ __| |/ / _ \ '_ \ ");
		Console.WriteLine(@"/ /\/\ \ |_| | |  \__ \ || (_| | (__|   <  __/ | | |");
		Console.WriteLine(@"\/    \/\__, |_|  |___/\__\__,_|\___|_|\_\___|_| |_|");
		Console.WriteLine(@"        |___/                                       ");
		Console.ForegroundColor = ConsoleColor.Cyan;
		Console.WriteLine("\nWelcome to Myrstacken! \nType 'help' for help");
		Console.ResetColor();
		Console.WriteLine("Enter command: ");
	}

	/// <summary>
	/// Compares the first element to the next. If it should be placed higher it returns a 1 if it is to be placed lower it returns a -1. Goes through every element this way until it is properly sorted.
	/// </summary>
	/// <param name="order"></param>
	/// <return>Returns the list ín the sorted order</return>
	/// <remarks>Changes the list order permanently</remarks>

	public void Sort(string[] order)
	{
		if (order.Length > 2)
		{
			SyntaxError();
		}
		else
		{
			switch (order[1])
			{
				case "nameasc":
					myror.Sort((a1, a2) => a1.GetName().CompareTo(a2.GetName()));
					ListMyra();
					break;
				case "namedesc":
					myror.Sort((a1, a2) => a2.GetName().CompareTo(a1.GetName()));
					ListMyra();
					break;
				case "legsasc":
					myror.Sort((a1, a2) => a1.GetLegs().CompareTo(a2.GetLegs()));
					ListMyra();
					break;
				case "legsdesc":
					myror.Sort((a1, a2) => a2.GetLegs().CompareTo(a1.GetLegs()));
					ListMyra();
					break;
				default:
					WrongInput();
					break;
			}
		}
	}
	
	public void Clear()
	{
		Console.Clear();
		Start();
	}

	public void Add(string name, string legs)
	{
		Myra myra = new Myra(name, int.Parse(legs).ToString());
		CheckDuplicate(myra);
		myror.Add(myra);
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("Succsesfully added");
		Console.ResetColor();
	}

	public void Change(string[] change)
	{
		if (change.Length > 4)
		{
			SyntaxError();
		}
		else
		{
			try
			{
				bool found = false;
				for (int i = myror.Count - 1; i >= 0; i--)
				{
					if (change[1] == "name")
					{
						if (myror[i].GetName().ToLower() == change[2].ToLower())
						{
							found = true;
							myror[i].name = change[3];
							Console.ForegroundColor = ConsoleColor.Green;
							Console.WriteLine("Succsesfully renamed");
							Console.ResetColor();
						}
						if (!found)
						{
							Console.ForegroundColor = ConsoleColor.Yellow;
							Console.WriteLine("There is no myra with that name");
							Console.ResetColor();
						}
					}
					else if (change[1] == "legs")
					{
						if (myror[i].GetName().ToLower() == change[2].ToLower())
						{
							try
							{
								found = true;
								myror[i].legs = int.Parse(change[3]).ToString();
								Console.ForegroundColor = ConsoleColor.Green;
								Console.WriteLine("Succsesfully changed");
								Console.ResetColor();
							}
							catch (Exception)
							{
								WrongInput();
							}
						}
						if (!found)
						{
							Console.ForegroundColor = ConsoleColor.Yellow;
							Console.WriteLine("There is no myra with that name");
							Console.ResetColor();
						}
					}
				}
			}
			catch
			{
				WrongInput();
			}
		}
	}

	/// <summary>
	/// Decides wheter to search by name or by legs. Then takes a input of desired name or desired amount of legs and searches the list for that name or amount.
	/// </summary>
	/// <param name="search"></param>
	/// <return>returns a list of the elements found</return>

	public void Find(string[] search)
	{
		if (search.Length > 3)
		{
			SyntaxError();
		}
		else if (search[1] == "name")
		{
			try
			{
				bool found = false;
				for (int i = myror.Count - 1; i >= 0; i--)
				{
					if (myror[i].GetName().ToLower() == search[2].ToLower())
					{
						Console.ForegroundColor = ConsoleColor.Cyan;
						Console.WriteLine(myror[i].ToString() + " Exists!");
						Console.ResetColor();
						found = true;
					}
				}
				if (!found)
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine("There is no myra with that name");
					Console.ResetColor();
				}
			}
			catch
			{
				WrongInput();
			}
		}
		else if (search[1] == "legs")
		{
			try
			{
				bool found = false;
				for (int i = myror.Count - 1; i >= 0; i--)
				{
					if (myror[i].legs == search[2])
					{
						Console.ForegroundColor = ConsoleColor.Cyan;
						Console.WriteLine(myror[i].ToString() + " Exists!");
						Console.ResetColor();
						found = true;
					}
				}
				if (!found)
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine("There are no myror with that number of legs");
					Console.ResetColor();
				}
			}
			catch
			{
				WrongInput();
			}
		}
	}

	public void Remove(string[] remove)
	{
		if (remove.Length > 2)
		{
			SyntaxError();
		}
		else
		{
			try
			{
				for (int i = myror.Count - 1; i >= 0; i--)
				{
					if (myror[i].GetName().ToLower() == remove[1].ToLower())
					{
						myror.RemoveAt(i);
						Console.ForegroundColor = ConsoleColor.Green;
						Console.WriteLine("Succesfully removed");
						Console.ResetColor();
					}
				}
			}
			catch
			{
				WrongInput();
			}
		}
	}

	public void InitialAdd(string[] add)
	{
		if (add.Length > 3)
		{
			SyntaxError();
		}
		else if (add.Length > 1 && add[1].Length > 10)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("Name must be less then 10 characters");
			Console.ResetColor();
		}
		else
		{
			try
			{
				Add(add[1], add[2]);
			}
			catch (MyraAlreadyExistException)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("Myra already exists");
				Console.ResetColor();
			}
			catch (Exception)
			{
				WrongInput();
			}
		}
	}

	public void ListMyra()
	{
		if (myror.Count != 0)
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
		else
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("the myrstack is empty");
			Console.ResetColor();
		}
	}

	public void List()
	{
		Console.WriteLine(myror.Count);
	}

	public void Help()
	{
		Console.ForegroundColor = ConsoleColor.Cyan;
		Console.WriteLine("type 'help' for a list of commands");
		Console.WriteLine("type 'exit' to exit");
		Console.WriteLine("type 'find 'legs'/'name' [name/legs] to check if a myra with that name or that amount of names exists exists");
		Console.WriteLine("type 'listmyra' to list all the myror ");
		Console.WriteLine("type 'list' to list the amount of ants");
		Console.WriteLine("type 'add [name] [legs]' to add a myra");
		Console.WriteLine("type 'remove [name]' to remove a myra");
		Console.WriteLine("type 'clear' to clear the console");
		Console.WriteLine("type 'change 'legs'/'name' [legs/name]' to change the name or amount of legs on a myra");
		Console.WriteLine("type 'sort 'nameasc'/'namedesc'/'legsasc'/'legsdesc'' to sort by eiter legs or name in an ascending or descending order");
		Console.ResetColor();
	}

	public void SyntaxError()
	{
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.WriteLine("Syntax error, too many words");
		Console.ResetColor();
	}

	public void WrongInput()
	{
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.WriteLine("Wrong input, try again");
		Console.ResetColor();
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

	public void Loading()
	{
		Console.WriteLine("Press any key to start!");
		Console.ReadKey();
		for (int i = 0; i <= 100; i++)
		{
			Console.Write($"\nProgress: {i}%");
			Thread.Sleep(5);
		}

		Console.Write("\nDone!");
		Console.Clear();
	}
}

class MyraAlreadyExistException : Exception
{

}