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


        public async Task<bool> DeletePlato(int IdPlato)
        {
            var response = await _httpClient.DeleteAsync($"/api/Plato/{IdPlato}");
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }

        public async Task<Alimento> GetPlato(int IdPlato)
        {
            var response = await _httpClient.GetAsync($"/api/Plato/{IdPlato}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Alimento alimento = JsonConvert.DeserializeObject<Alimento>(json_response);
                return alimento;
            }
            return new Alimento();
        }

        public async Task<List<Alimento>> GetPlato()
        {
            var response = await _httpClient.GetAsync("/api/Plato");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                List<Alimento> alimentos = JsonConvert.DeserializeObject<List<Alimento>>(json_response);
                return alimentos;
            }
            return new List<Alimento>();

        }

        public async Task<Alimento> PostPlato(Alimento plato)
        {
            var content = new StringContent(JsonConvert.SerializeObject(plato), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/plato/", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Alimento producto2 = JsonConvert.DeserializeObject<Alimento>(json_response);
                return producto2;
            }
            return new Alimento();
        }

        public async Task<Alimento> PutPlato(int IdPlato, Alimento producto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/plato/{IdPlato}", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Alimento plato2 = JsonConvert.DeserializeObject<Alimento>(json_response);
                return plato2;
            }
            return new Alimento();
        }
    }
}
