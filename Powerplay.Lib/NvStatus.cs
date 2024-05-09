// Author: Deci | Project: Powerplay.Lib | Name: NvStatus.cs
// Date: 2024/05/09 @ 09:05:23

using System.Text.Json.Serialization;

namespace Powerplay.Lib;

public readonly struct NvStatus
{

	public bool Status { get; }

	[JsonConstructor]
	public NvStatus(bool status)
	{
		Status = status;
	}

	public override string ToString()
	{
		return $"{nameof(Status)}: {Status}";
	}

}