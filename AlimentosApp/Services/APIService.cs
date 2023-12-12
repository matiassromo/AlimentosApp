using AlimentosApp.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace AlimentosApp.Services
{
    public class APIService
    {
        public static string _baseUrl;
        public HttpClient _httpClient;


        public APIService()
        {

            _baseUrl = "https://apiproductos20231211110203.azurewebsites.net";
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);
        }


        public async Task<bool> DeleteAlimento(int IdProducto)
        {
            var response = await _httpClient.DeleteAsync($"/api/Alimento/{IdProducto}");
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }

        public async Task<Alimento> GetAlimento(int IdProducto)
        {
            var response = await _httpClient.GetAsync($"/api/Alimento/{IdProducto}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Alimento alimento = JsonConvert.DeserializeObject<Alimento>(json_response);
                return alimento;
            }
            return new Alimento();
        }

        public async Task<List<Alimento>> GetAlimentos()
        {
            var response = await _httpClient.GetAsync("/api/Alimento");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                List<Alimento> alimentos = JsonConvert.DeserializeObject<List<Alimento>>(json_response);
                return alimentos;
            }
            return new List<Alimento>();

        }

        public async Task<Alimento> PostProducto(Alimento alimento)
        {
            var content = new StringContent(JsonConvert.SerializeObject(alimento), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Alimento/", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Alimento producto2 = JsonConvert.DeserializeObject<Alimento>(json_response);
                return producto2;
            }
            return new Alimento();
        }

        public async Task<Alimento> PutAlimento(int IdProducto, Alimento producto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/Alimento/{IdProducto}", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Alimento producto2 = JsonConvert.DeserializeObject<Alimento>(json_response);
                return producto2;
            }
            return new Alimento();
        }
    }
}
