using System;
using System.Collections.Generic;
using System.Security;
using System.Threading;

class Myrstack
{
	List<Myra> myror = new List<Myra>();

	public void Start()
	{
		Console.WriteLine("Press any key to start!");
		Console.ReadKey();
		Loading();
		Console.Clear();
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

	public void Sort()
	{
		myror.Sort();
	}

	public void Clear()
	{
		Console.Clear();
		Console.WriteLine("Enter command: ");
	}

	public void Add(string name, string legs)
	{
		Myra myra = new Myra(name, int.Parse(legs).ToString());
		CheckDuplicate(myra);
		myror.Add(myra);
	}

	public void Find(string[] search)
	{
		if (search.Length > 2)
		{
			SyntaxError();
		}
		else
		{
			try
			{
				for (int i = myror.Count - 1; i >= 0; i--)
				{
					if (myror[i].GetName().ToLower() == search[1].ToLower())
					{
						Console.ForegroundColor = ConsoleColor.Cyan;
						Console.WriteLine(myror[i].ToString() + " Exists!");
						Console.ResetColor();
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.WriteLine("There is no myra with that name");
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

	public void FindLegs(string[] searchlegs)
	{
		if (searchlegs.Length > 2)
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
					if (myror[i].legs == searchlegs[1])
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
						myror.RemoveAt(i);
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

	public void List()
	{
		Console.WriteLine(myror.Count);
	}

	public void Help()
	{
		Console.ForegroundColor = ConsoleColor.Cyan;
		Console.WriteLine("type 'help' for a list of commands \ntype 'exit' to exit \ntype find [name] to check if a myra with that name exists \ntype listmyra to list all the myror \ntype list to list the amount of ants \ntype add [name] [legs] to add a myra \ntype remove [name] to remove a myra \ntype 'clear' to clear the console");
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

	static void Loading()
	{
		for (int i = 0; i <= 100; i++)
		{
			Console.Write($"\nProgress: {i}%");
			Thread.Sleep(5);
		}

		Console.Write("\nDone!");
	}

	private static SecureString Pass()
	{
		Console.WriteLine("Enter Password");
		SecureString pass = new SecureString();
		ConsoleKeyInfo KeyInfo;
		do
		{
			KeyInfo = Console.ReadKey(true);
			if (!char.IsControl(KeyInfo.KeyChar))
			{
				pass.AppendChar(KeyInfo.KeyChar);
				Console.Write("*");
			}
			else if (KeyInfo.Key == ConsoleKey.Backspace && pass.Length > 0)
			{
				pass.RemoveAt(pass.Length - 1);
				Console.Write("\b \b");
			}
		}
		while (KeyInfo.Key != ConsoleKey.Enter);
		{
			return pass;
		}
	}
}

class MyraAlreadyExistException : Exception
{

}