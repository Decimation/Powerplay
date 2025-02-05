using System.Media;
using System.Runtime.InteropServices;
using Novus.OS;
using Novus.Win32;
using Novus.Win32.Structures.AdvApi32;
using Novus.Win32.Structures.User32;
using Powerplay.Lib;
using Powerplay.Lib.App;
using static System.Net.Mime.MediaTypeNames;

namespace Powerplay;

public static class Program
{

	public static async Task Main(string[] args)
	{
		// Console.WriteLine(Nv.GetConfig());
		// var nv = new Nv();
		// await nv.InstantReplay.Enable(new NvStatus(true));

		var ap   = new AppController();
		var apps = ap.Applications();

		NvServiceController.Control(NvServiceController.SVC_LOCAL_CONTAINER, ServiceControl.SERVICE_CONTROL_STOP,
		                            out ServiceStatus ss);

		Console.WriteLine(ss.dwCurrentState);

		// await Task.Delay(Timeout.Infinite);
		Console.ReadLine();
	}

}