// Author: Deci | Project: Powerplay.Lib | Name: InstantReplay.cs
// Date: 2024/05/09 @ 09:05:19

using System.Net.Http.Json;
using Flurl.Http;

namespace Powerplay.Lib.Legacy.Shadowplay;

public class InstantReplayEndpoint : BaseEndpoint
{

	private const string IR_ENABLE_SEGMENT = "Enable";

	public InstantReplayEndpoint(FlurlClient client) : base(client, "/ShadowPlay/v.1.0/InstantReplay") { }

	public async Task<bool> EnableAsync()
	{
		var req = Setup(IR_ENABLE_SEGMENT);
		req.Verb = HttpMethod.Get;
		var res = await Client.SendAsync(req);
		var str = await res.GetJsonAsync<bool>();
		return str;
	}

	public async Task EnableAsync(bool status)
	{
		var req = Setup(IR_ENABLE_SEGMENT);
		req.Verb    = HttpMethod.Post;
		req.Content = JsonContent.Create(status);
		var res = await Client.SendAsync(req);
		// todo

	}

}