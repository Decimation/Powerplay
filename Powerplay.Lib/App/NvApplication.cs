// Author: Deci | Project: Powerplay.Lib | Name: NvApplication.cs
// Date: 2025/02/05 @ 14:02:47

using System.Text.Json.Serialization;

namespace Powerplay.Lib.App;

public class NvApplication
{

	[JsonPropertyName("LocalId")]
	public int LocalId { get; set; }

	[JsonPropertyName("Application")]
	public NvApplicationEntry Application { get; set; }

}