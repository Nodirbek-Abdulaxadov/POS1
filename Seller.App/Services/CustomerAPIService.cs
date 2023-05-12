using BLL.Dtos.CustomerDtos;
using BLL.Dtos.ProductDtos;
using Newtonsoft.Json;
using Seller.App.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Seller.App.Services;

public class CustomerAPIService : IDisposable
{

    HttpClient _client;
    TokenService tokenService;
    public CustomerAPIService()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri(Constants.BASE_URL);
        tokenService = new TokenService();
        _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenService.GetToken());
    }

    public async Task<IEnumerable<CustomerViewDto>?> GetCustomers()
    {
        var response = _client.GetStringAsync("customer");
        var res = response.Result;
        if (response != null)
        {
            return JsonConvert.DeserializeObject<List<CustomerViewDto>>(res);
        }

        return new List<CustomerViewDto>();
    }

    public async Task<bool> AddAsync(AddCustomerDto dto)
    {
        var json = JsonConvert.SerializeObject(dto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("customer", content);;
        if (response.IsSuccessStatusCode)
        {
            return true;
        }

        return false;
    }

    public void Dispose()
        => GC.SuppressFinalize(this);
}