using BlazorBlogProject.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorBlogProject.Client.Services
{
    public interface IServiceInterface
    {
        Task<IEnumerable<EIGENAAR>> TotaalAantal();

        Task<EIGENAAR> VoegToe(EIGENAAR EIGENAAR);
    }

    public class ServiceMemoryClass : IServiceInterface
    {
        private List<EIGENAAR> _lijstEigenaren;
        public ServiceMemoryClass()
        {
            _lijstEigenaren = new List<EIGENAAR>()
            {
                new EIGENAAR() { ID =1, omschrijving="Sandra's auto Interne array", regio="Noord"},
                new EIGENAAR() { ID =2, omschrijving="Peter's auto Interne array", regio="Midden"},
                new EIGENAAR() { ID =3, omschrijving="Olga's auto Interne array", regio="Zuid"}
            };
        }
        public async Task<IEnumerable<EIGENAAR>> TotaalAantal()
        {
            return await Task.Run(() => _lijstEigenaren);
        }
        public async Task<EIGENAAR> VoegToe(EIGENAAR eigenaar)
        {
            eigenaar.ID = _lijstEigenaren.Max(e => e.ID) + 1;
            _lijstEigenaren.Add(eigenaar);
            return await Task.Run(() => eigenaar);
        }
    }

    public class ServiceDbClass : IServiceInterface
    {
        private readonly HttpClient _http;
        public ServiceDbClass(HttpClient http)
        {
            _http = http;
        }
        public async Task<IEnumerable<EIGENAAR>> TotaalAantal()
        {
            return await _http.GetFromJsonAsync<List<EIGENAAR>>("api/ServiceDB");
        }
        public async Task<EIGENAAR> VoegToe(EIGENAAR eigenaar)
        {
            var result = await _http.PostAsJsonAsync("api/ServiceDB", eigenaar);
            return await result.Content.ReadFromJsonAsync<EIGENAAR>();
        }
    }

}
