// using Flurl;
// using Flurl.Http;
//
// namespace Hackathorn2024.Server.Clients;
//
// public class MakeClient(ILogger<BaseHttpClient> logger, HttpClient client) : BaseHttpClient(logger, client)
// {
//     public async Task PostFileStringAsync(MakeFileRequest request, CancellationToken token = default)
//     {
//         return await WrapRetryRequestAsync(async client =>
//         {
//             var request = client.WithHeader("Content-Type", "application/json")
//                 .Request();
//
//             request.Url = new Url("https://api.make.com")
//                 .AppendPathSegment("v1")
//                 .AppendPathSegment("make");
//
//             await request.PostAsync(cancellationToken: token);
//         });
//     }
// }
//
// public class MakeFileRequest
// {
//
// }
