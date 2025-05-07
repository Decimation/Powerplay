// Author: Deci | Project: Powerplay.Lib | Name: AppController.cs
// Date: 2025/02/05 @ 14:02:37

using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Novus.Win32;
using Novus.Win32.Structures.AdvApi32;

namespace Powerplay.Lib.App;

// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);

public class AppController
{

	static AppController()
	{
		LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(cfg =>
		{
			cfg.AddTraceSource("TRACE")
				.AddDebug()
				.SetMinimumLevel(LogLevel.Trace);
		});


		var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

		NvidiaRootDirectory = TryGetDirectory(localAppData, "NVIDIA Corporation");
		NvidiaAppDirectory  = TryGetDirectory(NvidiaRootDirectory, "NVIDIA app");
		NvidiaAppBackend    = TryGetDirectory(NvidiaAppDirectory, "NvBackend");
		NvidiaAppSettings   = TryGetDirectory(NvidiaAppBackend, "ApplicationStorage.json");

	}

	internal static readonly ILoggerFactory LoggerFactory;

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
		using var fs = File.OpenRead(NvidiaAppSettings);

		var obj = JsonSerializer.Deserialize<NvAppSettings>(fs);

		return obj;
	}

	public void Applications(NvAppSettings settings)
	{
		using var fs = File.OpenWrite(NvidiaAppSettings);

		JsonSerializer.Serialize(fs, settings);

	}

}