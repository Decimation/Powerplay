// Author: Deci | Project: Powerplay.Lib | Name: AppController.cs
// Date: 2025/02/05 @ 14:02:37

using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text.Json;
using Novus.Win32;
using Novus.Win32.Structures.AdvApi32;

namespace Powerplay.Lib.App;

// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);

public class NvServiceController : IDisposable
{

	public const string SVC_LOCAL_CONTAINER = "NvContainerLocalSystem";


	public static bool Control(string svcName, ServiceControl svcCode, out ServiceStatus ss)
	{
		bool ok = true;
		ss = default;
		ok = Control<bool>(svcName, (ScHandle hScManager) => Native.ControlService(hScManager, svcCode, out ss));

		return ok;
	}

	public static T Control<T>(string svcName, Func<ScHandle, T> fn)
	{
		T   ret        = default;
		var hScManager = Native.OpenSCManager(null, null, ScManagerAccessTypes.SC_MANAGER_ALL_ACCESS);


		if (!hScManager.IsNull) {
			var hSc = Native.OpenService(hScManager, svcName, ServiceAccessTypes.SERVICE_ALL_ACCESS);

			ret = fn(hScManager);

			Native.CloseServiceHandle(hScManager);
			Native.CloseServiceHandle(hSc);
		}

		return ret;
	}

	#region Implementation of IDisposable

	public void Dispose() { }

	#endregion

}

public class AppController
{

	static AppController()
	{
		var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

		NvidiaRootDirectory = TryGetDirectory(localAppData, "NVIDIA Corporation");
		NvidiaAppDirectory  = TryGetDirectory(NvidiaRootDirectory, "NVIDIA app");
		NvidiaAppBackend    = TryGetDirectory(NvidiaAppDirectory, "NvBackend");
		NvidiaAppSettings   = TryGetDirectory(NvidiaAppBackend, "ApplicationStorage.json");


	}

	private static string TryGetDirectory(params string[] segments)
	{
		var ret = Path.Combine(segments);

		if (!Path.Exists(ret)) {
			throw new DirectoryNotFoundException($"Path {ret} not found");
		}

		return ret;
	}

	public static readonly string NvidiaRootDirectory;
	public static readonly string NvidiaAppDirectory;
	public static readonly string NvidiaAppBackend;
	public static readonly string NvidiaAppSettings;

	public NvAppSettings Applications()
	{
		using var fs  = File.OpenRead(NvidiaAppSettings);
		var       obj = JsonSerializer.Deserialize<NvAppSettings>(fs);

		return obj;
	}

}