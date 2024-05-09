// Author: Deci | Project: Powerplay.Lib | Name: NvServerConfig.cs
// Date: 2024/05/09 @ 09:05:26

using System.Text.Json.Serialization;

namespace Powerplay.Lib;

public readonly struct NvServerConfig
{

	public long Port { get; }

	public string Secret { get; }

	[JsonConstructor]
	public NvServerConfig(long port, string secret)
	{
		Port   = port;
		Secret = secret;
	}

	public override string ToString()
	{
		return $"{nameof(Port)}: {Port} | {nameof(Secret)}: {Secret}";
	}

}