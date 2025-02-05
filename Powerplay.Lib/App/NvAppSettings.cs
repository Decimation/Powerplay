// Author: Deci | Project: Powerplay.Lib | Name: NvAppApplicationsRoot.cs
// Date: 2025/02/05 @ 14:02:40

using System.Text.Json.Serialization;

namespace Powerplay.Lib.App;

public class NvAppSettings
{

	[JsonPropertyName("Applications")]
	public List<NvApplication> Applications { get; set; }

}