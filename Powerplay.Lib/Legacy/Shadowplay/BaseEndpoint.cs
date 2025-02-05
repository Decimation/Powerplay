// Author: Deci | Project: Powerplay.Lib | Name: BaseEndpoint.cs
// Date: 2024/05/09 @ 09:05:11

using Flurl.Http;

namespace Powerplay.Lib.Legacy.Shadowplay;

public abstract class BaseEndpoint
{

	public string Segment { get; }

	public FlurlClient Client { get; }

	public BaseEndpoint(FlurlClient client, string segment)
	{
		Segment = segment;
		Client = client;
	}

	public virtual IFlurlRequest Setup(string urlSegments)
	{
		return Client.Request(Segment, urlSegments);
	}

}