using System;
using System.Collections.Generic;

namespace Myrstacken
{
	class Program
	{
		/*
        const int max_length = 10;
        Myra[] myror = new Myra[max_length];
		*/

		List<Myra> myror = new List<Myra>();


		static void Main()
		{
			Program p = new Program();
			p.Run();
		}

		/*
		Boolean isPresent(string name)
		{
			
		}
		*/

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

							Myra myra = new Myra(add[1], int.Parse(add[2]).ToString());
							myror.Add(myra);

							/*
							for (int i = 0; i < myror.Count; i++)
                            {
                                Myra myra = new Myra(add[1], int.Parse(add[2]).ToString());
                                if (myror[i] == null)
                                {
                                    myror[i] = myra;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Succes!");
                                    Console.ResetColor();
                                    break;
                                }
                            }
							*/
						}
						catch (Exception e)
						{
							Console.ForegroundColor = ConsoleColor.Yellow;
							Console.WriteLine("Wrong input, try again");
							Console.ResetColor();
						}
					}
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

					/*

					Console.WriteLine("Enter the number of legs on myra " + name + ":");

					string legs = Console.ReadLine();
					try
					{
						int numlegs = int.Parse(legs);
						for (int i = 0; i < myror.Length; i++)
						{
							Myra myra = new Myra(name, legs);
							if (myror[i] == null)
							{
								myror[i] = myra;
								break;
							}	
						}
					}
					catch (Exception e)
					{
						Console.WriteLine(e.GetType().ToString() + ": Error");
					}

					*/

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
			Myra[] myror;
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
}