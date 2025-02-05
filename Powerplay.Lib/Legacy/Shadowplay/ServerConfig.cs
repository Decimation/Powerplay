// Author: Deci | Project: Powerplay.Lib | Name: NvServerConfig.cs
// Date: 2024/05/09 @ 09:05:26

using System.IO.MemoryMappedFiles;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Powerplay.Lib.Legacy.Shadowplay;

public readonly struct ServerConfig
{

	public long Port { get; }

	public string Secret { get; }

	[JsonConstructor]
	public ServerConfig(long port, string secret)
	{
		Port = port;
		Secret = secret;
	}

	public override string ToString()
	{
		return $"{nameof(Port)}: {Port} | {nameof(Secret)}: {Secret}";
	}

	[JsonIgnore]
	public const string CONFIG_MMF_NAME = "{8BA1E16C-FC54-4595-9782-E370A5FBE8DA}";

	public static ServerConfig GetConfig()
	{

		using var cfg = MemoryMappedFile.OpenExisting(ServerConfig.CONFIG_MMF_NAME);
		using var str = cfg.CreateViewStream();
		using var sr  = new StreamReader(str);

		var cfgData = sr.ReadToEnd().Trim('\0');

		return JsonSerializer.Deserialize<ServerConfig>(cfgData, ShadowplayController.s_jsonSerializerOptions);
	}

}