// Author: Deci | Project: Powerplay.Lib | Name: NvApplicationEntry.cs
// Date: 2025/02/05 @ 14:02:50

using System.Text.Json.Serialization;

namespace Powerplay.Lib.App;

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
	public bool SendTelemetryForGfeSupportedApps { get; set; }

	[JsonPropertyName("UseDRSForTelemetry")]
	public bool UseDrsForTelemetry { get; set; }

	[JsonPropertyName("ChromaAppId")]
	public string ChromaAppId { get; set; }

	[JsonPropertyName("InitialTimeISO")]
	public DateTime InitialTimeIso { get; set; }

	[JsonPropertyName("LastLaunchTimeISO")]
	public DateTime LastLaunchTimeIso { get; set; }

	[JsonPropertyName("IsManuallyAdded")]
	public bool IsManuallyAdded { get; set; }

	[JsonPropertyName("IsFingerprintDetected")]
	public bool IsFingerprintDetected { get; set; }

	[JsonPropertyName("Disable_FG_Override")]
	public bool DisableFgOverride { get; set; }

	[JsonPropertyName("Disable_RR_Override")]
	public bool DisableRrOverride { get; set; }

	[JsonPropertyName("Disable_SR_Override")]
	public bool DisableSrOverride { get; set; }

	[JsonPropertyName("Disable_RR_Model_Override")]
	public bool DisableRrModelOverride { get; set; }

	[JsonPropertyName("Disable_SR_Model_Override")]
	public bool DisableSrModelOverride { get; set; }

	[JsonPropertyName("QuietModePopsFactor")]
	public double? QuietModePopsFactor { get; set; }

	[JsonPropertyName("BatteryBoost2PopsFactorTPPLow")]
	public double? BatteryBoost2PopsFactorTppLow { get; set; }

	[JsonPropertyName("BatteryBoost2PopsFactorTPPHigh")]
	public double? BatteryBoost2PopsFactorTppHigh { get; set; }

	[JsonPropertyName("UwpPackageFamilyName")]
	public string UwpPackageFamilyName { get; set; }

}