// Author: Deci | Project: Powerplay.Lib | Name: AppController.cs
// Date: 2025/02/05 @ 14:02:37

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Powerplay.Lib.App;

// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
public class NvApplication
{

	[JsonPropertyName("LocalId")]
	public int LocalId { get; set; }

	[JsonPropertyName("Application")]
	public NvApplicationEntry Application { get; set; }

}

public class NvApplicationEntry
{

	[JsonPropertyName("CmsId")]
	public int CmsId { get; set; }

	[JsonPropertyName("CmsVersion")]
	public int CmsVersion { get; set; }

	[JsonPropertyName("DisplayName")]
	public string DisplayName { get; set; }

	[JsonPropertyName("ShortName")]
	public string ShortName { get; set; }

	[JsonPropertyName("Version")]
	public string Version { get; set; }

	[JsonPropertyName("Distributor")]
	public string Distributor { get; set; }

	[JsonPropertyName("InstallDirectory")]
	public string InstallDirectory { get; set; }

	[JsonPropertyName("DetectedFiles")]
	public List<string> DetectedFiles { get; set; }

	[JsonPropertyName("ImageFiles")]
	public List<string> ImageFiles { get; set; }

	[JsonPropertyName("LaunchCmd")]
	public string LaunchCmd { get; set; }

	[JsonPropertyName("IsOpsSupported")]
	public bool IsOpsSupported { get; set; }

	[JsonPropertyName("UseDesktopResolution")]
	public bool UseDesktopResolution { get; set; }

	[JsonPropertyName("UseLowResolutions")]
	public bool UseLowResolutions { get; set; }

	[JsonPropertyName("HypersamplingQuality")]
	public int HypersamplingQuality { get; set; }

	[JsonPropertyName("HypersamplingFactors")]
	public List<int> HypersamplingFactors { get; set; }

	[JsonPropertyName("IsStreamingSupported")]
	public bool IsStreamingSupported { get; set; }

	[JsonPropertyName("StreamingCmdLine")]
	public string StreamingCmdLine { get; set; }

	[JsonPropertyName("StreamingCaption")]
	public string StreamingCaption { get; set; }

	[JsonPropertyName("StreamingClassName")]
	public string StreamingClassName { get; set; }

	[JsonPropertyName("StreamingAutomatedLaunch")]
	public bool StreamingAutomatedLaunch { get; set; }

	[JsonPropertyName("DriverProfile")]
	public string DriverProfile { get; set; }

	[JsonPropertyName("IsCreativeApplication")]
	public bool IsCreativeApplication { get; set; }

	[JsonPropertyName("SendTelemetryForGFESupportedApps")]
	public bool SendTelemetryForGFESupportedApps { get; set; }

	[JsonPropertyName("UseDRSForTelemetry")]
	public bool UseDRSForTelemetry { get; set; }

	[JsonPropertyName("ChromaAppId")]
	public string ChromaAppId { get; set; }

	[JsonPropertyName("InitialTimeISO")]
	public DateTime InitialTimeISO { get; set; }

	[JsonPropertyName("LastLaunchTimeISO")]
	public DateTime LastLaunchTimeISO { get; set; }

	[JsonPropertyName("IsManuallyAdded")]
	public bool IsManuallyAdded { get; set; }

	[JsonPropertyName("IsFingerprintDetected")]
	public bool IsFingerprintDetected { get; set; }

	[JsonPropertyName("Disable_FG_Override")]
	public bool Disable_FG_Override { get; set; }

	[JsonPropertyName("Disable_RR_Override")]
	public bool Disable_RR_Override { get; set; }

	[JsonPropertyName("Disable_SR_Override")]
	public bool Disable_SR_Override { get; set; }

	[JsonPropertyName("Disable_RR_Model_Override")]
	public bool Disable_RR_Model_Override { get; set; }

	[JsonPropertyName("Disable_SR_Model_Override")]
	public bool Disable_SR_Model_Override { get; set; }

	[JsonPropertyName("QuietModePopsFactor")]
	public double? QuietModePopsFactor { get; set; }

	[JsonPropertyName("BatteryBoost2PopsFactorTPPLow")]
	public double? BatteryBoost2PopsFactorTPPLow { get; set; }

	[JsonPropertyName("BatteryBoost2PopsFactorTPPHigh")]
	public double? BatteryBoost2PopsFactorTPPHigh { get; set; }

	[JsonPropertyName("UwpPackageFamilyName")]
	public string UwpPackageFamilyName { get; set; }

}

public class NvAppApplicationsRoot
{

	[JsonPropertyName("Applications")]
	public List<NvApplication> Applications { get; set; }

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

	public async Task<NvAppApplicationsRoot> Applications()
	{
		var fs = File.OpenRead(NvidiaAppSettings);
		var obj = JsonSerializer.Deserialize<NvAppApplicationsRoot>(fs);

		return obj;
	}

}