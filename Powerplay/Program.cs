using Powerplay.Lib;

namespace Powerplay;

public static class Program
{

	public static async Task Main(string[] args)
	{
		Console.WriteLine(Nv.GetConfig());
		var nv = new Nv();
		await nv.InstantReplay.Enable(new NvStatus(true));
		Console.WriteLine();
	}

}