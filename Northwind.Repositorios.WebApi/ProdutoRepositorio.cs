using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Northwind.Repositorios.WebApi
{
    public class ProductRepositorio
    {
        private HttpClient httpClient = new HttpClient();
        private string _url = "http://localhost:50511/api/products";

        public async Task<ProductViewModel> Post(ProductViewModel product)
        {
            using (var resposta = await httpClient.PostAsJsonAsync(_url, product))
            {
                resposta.EnsureSuccessStatusCode();
                return await resposta.Content.ReadAsAsync<ProductViewModel>();
            }
        }

        public async Task Put(int id, ProductViewModel product)
        {
            using (var resposta = await httpClient.PutAsJsonAsync($"{_url}/{id}", product))
            {
                resposta.EnsureSuccessStatusCode();
            }
        }

        public async Task<List<ProductViewModel>> Get()
        {
            using (var resposta = await httpClient.GetAsync(_url))
            {
                return await resposta.Content.ReadAsAsync<List<ProductViewModel>>();
            }
        }

        public async Task<ProductViewModel> Get(int id)
        {
            using (var resposta = await httpClient.GetAsync($"{_url}/{id}"))
            {
                return await resposta.Content.ReadAsAsync<ProductViewModel>();
            }
        }

        public async Task Delete(int id)
        {
            using (var resposta = await httpClient.DeleteAsync($"{_url}/{id}"))
            {
                resposta.EnsureSuccessStatusCode();
            }
        }
    }
}