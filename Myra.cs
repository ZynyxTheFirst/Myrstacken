using System;

class Myra : IComparable
{
	public string name;
	public string legs;

	public Myra(string name, string legs)
	{
		this.name = name;
		this.legs = legs;
	}

	public string GetName()
	{
		return name;
	}

	public string GetLegs()
	{
		return legs;
	}

	public override string ToString()
	{
		name = name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
		return name + ", " + legs;
	}

	public int CompareTo(object obj)
	{
		return this.name.CompareTo(((Myra)obj).name);
	}
}