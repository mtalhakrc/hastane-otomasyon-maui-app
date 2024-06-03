using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;
using hastane_otomasyon_maui_app.Models;
using hastane_otomasyon_maui_app.Services;


public interface IRandevuService
{
    Task<IEnumerable<RandevuModel>> GetAllRandevularAsync();
    Task<RandevuModel> GetRandevuByIdAsync(int id);
    Task CreateRandevuAsync(RandevuModel randevu);
    Task<RandevuModel> UpdateRandevuAsync(RandevuModel randevu);
    Task<bool> DeleteRandevuAsync(int id);
}

public class RandevuService : IRandevuService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public RandevuService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    private HttpClient CreateHttpClient()
    {
        var httpClient = _httpClientFactory.CreateClient("custom-httpclient");
        return httpClient;
    }

    public async Task<IEnumerable<RandevuModel>> GetAllRandevularAsync()
    {
        var httpClient = CreateHttpClient();
        
        var result = await httpClient.GetAsync("/api/Randevu");
        if (result.StatusCode == HttpStatusCode.Unauthorized)
        {
            throw new Exception("wrong credentials");
        }

        if (result.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception("an error occured");
        }

        var response = await result.Content.ReadFromJsonAsync<IEnumerable<RandevuModel>>();
        if (response is null)
        {
            throw new Exception("internal server error");
        }
        return response;
    }

    public async Task<RandevuModel> GetRandevuByIdAsync(int id)
    {
        var httpClient = CreateHttpClient();
        
        var result = await httpClient.GetAsync($"/api/Randevu/{id}");
        if (result.StatusCode == HttpStatusCode.Unauthorized)
        {
            throw new Exception("wrong credentials");
        }

        if (result.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception("an error occured");
        }

        var response = await result.Content.ReadFromJsonAsync<RandevuModel>();
        if (response is null)
        {
            throw new Exception("internal server error");
        }
        return response;
    }

    public async Task CreateRandevuAsync(RandevuModel randevu)
    {
        var httpClient = CreateHttpClient();
        
        var result = await httpClient.PostAsJsonAsync("/api/Randevu", randevu);
        if (result.StatusCode == HttpStatusCode.Unauthorized)
        {
            throw new Exception("wrong credentials");
        }

        if (result.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception(result.ReasonPhrase);
        }

        return;
    }

    public async Task<RandevuModel> UpdateRandevuAsync(RandevuModel randevu)
    {
        var httpClient = CreateHttpClient();
        
        var result = await httpClient.PutAsJsonAsync($"/api/Randevu/{randevu.Id}", randevu);
        if (result.StatusCode == HttpStatusCode.Unauthorized)
        {
            throw new Exception("wrong credentials");
        }

        if (result.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception("an error occured");
        }

        return randevu;
    }

    public async Task<bool> DeleteRandevuAsync(int id)
    {
        var httpClient = CreateHttpClient();
        
        var result = await httpClient.DeleteAsync($"/api/Randevu/{id}");
        if (result.StatusCode == HttpStatusCode.Unauthorized)
        {
            throw new Exception("wrong credentials");
        }

        if (result.StatusCode != HttpStatusCode.NoContent)
        {
            throw new Exception("an error occured");
        }

        return true;
    }
}
