using System.Net.Http;
using System.Threading.Tasks;
using VidAutoFrontEnd.Config;

namespace VidAutoFrontEnd.Handlers
{
    public class ApiHandler
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<HttpResponseMessage> PostAssetAsync(string filePath)
        {
            using (var content = new MultipartFormDataContent())
            {
                content.Add(new ByteArrayContent(System.IO.File.ReadAllBytes(filePath)), "file", "upload");
                return await client.PostAsync($"{ApiConfig.ApiBaseUrl}/upload", content);
            }
        }
    }
}
