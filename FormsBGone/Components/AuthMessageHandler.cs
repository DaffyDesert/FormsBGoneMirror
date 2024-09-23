using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.JSInterop;

public class AuthMessageHandler : DelegatingHandler
{
    private readonly IJSRuntime _jsRuntime;

    public AuthMessageHandler(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");

        if (token == null)
        {
            Console.WriteLine("Token retrieval failed or token is null.");
        }
        else
        {
            Console.WriteLine($"Retrieved token: {token}");
        }

        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            Console.WriteLine($"Authorization header set: Bearer {token}");
        }
        else
        {
            Console.WriteLine("No token found in local storage.");
        }

        return await base.SendAsync(request, cancellationToken);
    }
}
