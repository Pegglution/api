using System.ComponentModel;
using System.Text.Json;
using Models;

namespace Pegglution
{
    public partial class API
    {
        private enum Method
        {
            GET,
            POST,
        };

        WebApplicationBuilder Builder;
        WebApplication App;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public API()
        {
            Builder = WebApplication.CreateBuilder();
            App = Builder.Build();

            MapPaths();

            App.Run();
        }

        private void MapPaths()
        {
            var apiGroup = App.MapGroup("/api");

            apiGroup.MapGet("/", (HttpRequest req, HttpResponse res) =>
            {
                res.WriteAsync(GenerateResponse(new Error("hi")));
            });

            apiGroup.MapGet($"/get/{{what}}/{{method}}/{{*query}}", Get);
            apiGroup.MapPost($"/post", Post);
        }

        private string GenerateResponse<T>(T data)
        {
            return JsonSerializer.Serialize(data);
        }
    }
}
