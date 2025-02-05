using System.IO.MemoryMappedFiles;
using System.Net.Sockets;
using System.Text.Json;
using System.Text.Json.Nodes;
using Flurl.Http;

namespace Powerplay.Lib.Legacy.Shadowplay;

public class ShadowplayController
{

	/*
	   app.post('/ShadowPlay/v.1.0/InstantReplay/Enable'
	   app.get('/ShadowPlay/v.1.0/InstantReplay/Enable'
	   app.get('/ShadowPlay/v.1.0/InstantReplay/Running'
	   app.get('/ShadowPlay/v.1.0/InstantReplay/Settings'
	   app.post('/ShadowPlay/v.1.0/InstantReplay/Settings'
	   app.post('/ShadowPlay/v.1.0/InstantReplay/Save'
	   app.get('/ShadowPlay/v.1.0/InstantReplay/BufferLength'
	   app.post('/ShadowPlay/v1.0/OSC/GetCustomize/InstantReplay'
	   app.post('/ShadowPlay/v.1.0/Record/Enable'
	   app.get('/ShadowPlay/v.1.0/Record/Enable'
	   app.get('/ShadowPlay/v.1.0/Record/Running'
	   app.get('/ShadowPlay/v.1.0/Record/Settings'
	   app.post('/ShadowPlay/v.1.0/Record/Settings'
	   app.get('/ShadowPlay/v.1.0/Record/Concurrency/:mode'
	   app.post('/ShadowPlay/v1.0/OSC/GetCustomize/Record'
	   app.post('/ShadowPlay/v.1.0/Broadcast/Enable'
	   app.post('/ShadowPlay/v.1.0/Broadcast/Pause'
	   app.get('/ShadowPlay/v.1.0/Broadcast/Enable'
	   app.get('/ShadowPlay/v.1.0/Broadcast/Running'
	   app.get('/ShadowPlay/v.1.0/Broadcast/Support'
	   app.get('/ShadowPlay/v.1.0/Broadcast/Settings'
	   app.post('/ShadowPlay/v.1.0/Broadcast/Settings'
	   app.post('/ShadowPlay/v.1.0/Broadcast/SessionParam'
	   app.post('/ShadowPlay/v.1.1/Broadcast/SessionParam/:type'
	   app.get('/ShadowPlay/v.1.0/Broadcast/LastProvider'
	   app.post('/ShadowPlay/v.1.0/Broadcast/LastProvider'
	   app.get('/ShadowPlay/v.1.0/Broadcast/Provider'
	   app.post('/ShadowPlay/v.1.0/Broadcast/Provider'
	   app.get('/ShadowPlay/v.1.0/Broadcast/Title'
	   app.post('/ShadowPlay/v.1.0/Broadcast/Viewers'
	   app.post('/ShadowPlay/v.1.0/Broadcast/Viewers/Max'
	   app.post('/ShadowPlay/v.1.0/Broadcast/IngestServer'
	   app.get('/ShadowPlay/v.1.0/Broadcast/IngestServer'
	   app.get('/ShadowPlay/v.1.0/Broadcast/2KSupport'
	   app.get('/ShadowPlay/v.1.0/Broadcast/2KEnable'
	   app.get('/ShadowPlay/v.1.0/Broadcast/FBLiveSupport'
	   app.post('/ShadowPlay/v1.0/OSC/GetCustomize/Broadcast'
	   app.post('/ShadowPlay/v.1.0/OpenOsc'
	   app.post('/ShadowPlay/v.1.0/OpenOscPreferences'
	   app.post('/ShadowPlay/v.1.0/OpenOscState'
	   app.post('/ShadowPlay/v.1.0/OscNotification'
	   app.get('/ShadowPlay/v.1.0/OSC/Init'
	   app.post('/ShadowPlay/v.1.0/OSC/MainView'
	   app.post('/ShadowPlay/v.1.0/Launch'
	   app.get('/ShadowPlay/v.1.0/Launch'
	   app.get('/ShadowPlay/v.1.0/GetHDRState'
	   app.post('/ShadowPlay/v.1.0/GetSupported'
	   app.post('/ShadowPlay/v.1.0/Video/Trim'
	   app.post('/ShadowPlay/v.1.0/Webcam/Enable'
	   app.post('/ShadowPlay/v.1.0/Webcam/Toggle'
	   app.get('/ShadowPlay/v.1.0/Webcam/Enable'
	   app.get('/ShadowPlay/v.1.0/Webcam/Shown'
	   app.get('/ShadowPlay/v.1.0/Webcam/Present'
	   app.post('/ShadowPlay/v.1.0/Webcam/Settings'
	   app.get('/ShadowPlay/v.1.0/Webcam/Settings'
	   app.post('/ShadowPlay/v.1.0/Microphone'
	   app.get('/ShadowPlay/v.1.0/Microphone'
	   app.post('/ShadowPlay/v.1.0/Microphone/PTT'
	   app.get('/ShadowPlay/v.1.0/Microphone/Present'
	   app.get('/ShadowPlay/v.1.0/Microphone/:index/Settings'
	   app.get('/ShadowPlay/v.1.0/Microphone/Settings'
	   app.post('/ShadowPlay/v.1.0/Microphone/:index/Settings'
	   app.post('/ShadowPlay/v.1.0/Audio'
	   app.get('/ShadowPlay/v.1.0/Audio'
	   app.post('/ShadowPlay/v.1.0/AudioSettings'
	   app.get('/ShadowPlay/v.1.0/AudioSettings'
	   app.get('/ShadowPlay/v.1.0/4KSupport'
	   app.get('/ShadowPlay/v.1.0/8k60'
	   app.get('/ShadowPlay/v.1.0/BitRates/:quality/:resolution'
	   app.get('/ShadowPlay/v.1.0/Resolutions'
	   app.get('/ShadowPlay/v.1.0/Resolutions/:quality/'
	   app.get('/ShadowPlay/v.1.0/Framerates'
	   app.get('/ShadowPlay/v.1.0/Framerates/:quality/'
	   app.post('/ShadowPlay/v.1.0/RecordPaths'
	   app.get('/ShadowPlay/v.1.0/RecordPaths'
	   app.get('/ShadowPlay/v.1.0/Capture/State'
	   app.get('/ShadowPlay/v.1.0/Capture/PIDMode'
	   app.get('/ShadowPlay/v.1.0/Capture/ProcessInfo/:PID/'
	   app.post('/ShadowPlay/v.1.0/CoPlay/Enable'
	   app.get('/ShadowPlay/v.1.0/CoPlay/Enable'
	   app.get('/ShadowPlay/v.1.0/CoPlay/Support'
	   app.get('/ShadowPlay/v.1.0/Indicator/:id/Settings'
	   app.post('/ShadowPlay/v.1.0/Indicator/:id/Settings'
	   app.get('/ShadowPlay/v.1.0/Indicator/:id/Support'
	   app.post('/ShadowPlay/v.1.0/DesktopCapture/Enable'
	   app.get('/ShadowPlay/v.1.0/DesktopCapture/Enable'
	   app.get('/ShadowPlay/v.1.0/DesktopCapture/Support'
	   app.get('/ShadowPlay/v.1.0/DesktopCapture/Support/Reason'
	   app.get('/ShadowPlay/v.1.0/CustomOverlay/Enable'
	   app.post('/ShadowPlay/v.1.0/CustomOverlay/Enable'
	   app.get('/ShadowPlay/v.1.1/CustomOverlay/Enable/:index'
	   app.post('/ShadowPlay/v.1.1/CustomOverlay/Enable/:index'
	   app.get('/ShadowPlay/v.1.0/CustomOverlay/Path'
	   app.post('/ShadowPlay/v.1.0/CustomOverlay/Path'
	   app.get('/ShadowPlay/v.1.1/CustomOverlay/Path/:index'
	   app.post('/ShadowPlay/v.1.1/CustomOverlay/Path/:index'
	   app.get('/ShadowPlay/v.1.0/CustomOverlay/Support'
	   app.get('/ShadowPlay/v.1.0/CustomOverlay/DefaultPath'
	   app.get('/ShadowPlay/v.1.0/CustomOverlay/Display'
	   app.post('/ShadowPlay/v.1.0/Hotkey/:hk'
	   app.get('/ShadowPlay/v.1.0/Hotkey/:hk'
	   app.post('/ShadowPlay/v.1.0/Osc'
	   app.get('/ShadowPlay/v.1.0/Screenshot/Support'
	   app.post('/ShadowPlay/v.1.0/Screenshot/Capture'
	   app.post('/ShadowPlay/v.1.0/Input'
	   app.post('/ShadowPlay/v.1.0/Highlights/Customize'
	   app.get('/ShadowPlay/v.1.0/Highlights/Customize'
	   app.post('/ShadowPlay/v.1.0/Highlights/GalleryImport'
	   app.get('/ShadowPlay/v.1.0/Highlights/Session'
	   app.post('/ShadowPlay/v.1.0/Screenshot/NGXShot'
	   app.post('/ShadowPlay/v.1.0/Screenshot/NGXCancelShot'

	 *
	 */

	internal static readonly JsonSerializerOptions s_jsonSerializerOptions = new(JsonSerializerDefaults.General)
	{
		PropertyNameCaseInsensitive = true
	};

	public FlurlClient Client { get; }

	public ServerConfig Config { get; }

	public ShadowplayController(ServerConfig config)
	{
		Config = config;

		Client = new FlurlClient($"http://localhost:{Config.Port}")
		{
			Headers =
			{
				{ "X_LOCAL_SECURITY_COOKIE", Config.Secret }
			},
		};

		InstantReplay = new InstantReplayEndpoint(Client);

	}

	public ShadowplayController() : this(ServerConfig.GetConfig()) { }

	public InstantReplayEndpoint InstantReplay { get; }

}