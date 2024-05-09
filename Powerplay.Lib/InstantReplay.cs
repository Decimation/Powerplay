// Author: Deci | Project: Powerplay.Lib | Name: InstantReplay.cs
// Date: 2024/05/09 @ 09:05:19

using System.Net.Http.Json;
using Flurl.Http;

namespace Powerplay.Lib;

public class InstantReplay : BaseEndpoint
{

	public InstantReplay(FlurlClient client) : base(client, "/ShadowPlay/v.1.0/InstantReplay") { }

	public async Task<NvStatus> Enable()
	{
		var req = Setup("Enable");
		req.Verb = HttpMethod.Get;
		var res = await Client.SendAsync(req);
		var str = await res.GetJsonAsync<NvStatus>();
		return str;
	}

	public async Task Enable(NvStatus status)
	{
		var req = Setup("Enable");
		req.Verb = HttpMethod.Post;
		req.Content = JsonContent.Create(status);
		var res = await Client.SendAsync(req);

	}

}