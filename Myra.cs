using System;

class Myra : IComparable
{
	private string name;
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

	public override string ToString()
	{
		name = name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
		return name + ", " + legs;
	}

	public int CompareTo(object obj)
	{
		throw new NotImplementedException();
	}
}