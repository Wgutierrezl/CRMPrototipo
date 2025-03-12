
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Text.Json;

namespace CRMFronted.Servicios
{
    public class ServiciosClientes : IServiciosClientes
    {
        private readonly HttpClient _httpclient;
        private readonly IJSRuntime _jsRuntime; // Inyectamos JS para acceder a sessionStorage
        private JsonSerializerOptions _serialice = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public ServiciosClientes(HttpClient httpclient, IJSRuntime jsRuntime)
        {
            _httpclient = httpclient;
            _jsRuntime = jsRuntime;
        }

        private async Task AgregarTokenAsync()
        {
            var token = await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "authToken");

            if (!string.IsNullOrEmpty(token))
            {
                Console.WriteLine($"Token enviado: {token}");
                _httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim('"'));
            }
            else
            {
                Console.WriteLine("⚠ No se encontró token en sessionStorage.");
            }
        }

        public async Task<HttpResponseWrapper<object>> DeleteClientes(string url)
        {
            var responsehttp=await _httpclient.DeleteAsync(url);
            var content=await responsehttp.Content.ReadAsStringAsync();
            return new HttpResponseWrapper<object>(content,!responsehttp.IsSuccessStatusCode,responsehttp);
        }

        public async Task<HttpResponseWrapper<TActionResponse>> DeleteClientes<T, TActionResponse>(string url)
        {
            var responsehttp = await _httpclient.DeleteAsync(url);
            var content=await responsehttp.Content.ReadAsStringAsync();
            if (responsehttp.IsSuccessStatusCode)
            {
                var response=JsonSerializer.Deserialize<TActionResponse>(content,_serialice);
                return new HttpResponseWrapper<TActionResponse>(response,false,responsehttp);
            }
            return new HttpResponseWrapper<TActionResponse>(default,true,responsehttp);
        }

        public async Task<HttpResponseWrapper<T>> GetClientes<T>(string url)
        {
            await AgregarTokenAsync();
            var responsehttp=await _httpclient.GetAsync(url);
            var content=await responsehttp.Content.ReadAsStringAsync();
            if (responsehttp.IsSuccessStatusCode)
            {
                var response=JsonSerializer.Deserialize<T>(content,_serialice);
                return new HttpResponseWrapper<T>(response,false,responsehttp);
            }
            return new HttpResponseWrapper<T>(default,!responsehttp.IsSuccessStatusCode, responsehttp);
        }

        public async Task<HttpResponseWrapper<object>> PostClientes<T>(string url, T model)
        {
            var MessageBody = JsonSerializer.Serialize(model);
            var MessageContent=new StringContent(MessageBody,Encoding.UTF8,"application/json");
            var responsehttp = await _httpclient.PostAsync(url, MessageContent);
            var content=await responsehttp.Content.ReadAsStringAsync();
            return new HttpResponseWrapper<object>(content,!responsehttp.IsSuccessStatusCode,responsehttp);
        }

        public async Task<HttpResponseWrapper<TActionResponse>> PostClientes<T, TActionResponse>(string url, T model)
        {
            var MessageBody = JsonSerializer.Serialize(model);
            var MessageContent = new StringContent(MessageBody, Encoding.UTF8, "application/json");
            var responsehttp = await _httpclient.PostAsync(url, MessageContent);
            var content = await responsehttp.Content.ReadAsStringAsync();
            if (responsehttp.IsSuccessStatusCode)
            {
                var response = JsonSerializer.Deserialize<TActionResponse>(content, _serialice);
                return new HttpResponseWrapper<TActionResponse>(response,false,responsehttp);
            }
            return new HttpResponseWrapper<TActionResponse>(default,!responsehttp.IsSuccessStatusCode, responsehttp);
        }

        public async Task<HttpResponseWrapper<object>> PutClientes<T>(string url, T model)
        {
            var MessageBody=JsonSerializer.Serialize(model);
            var MessageContent=new StringContent(url, Encoding.UTF8, "application/json");
            var ResponseHttp=await _httpclient.PutAsync(url, MessageContent);
            var content = await ResponseHttp.Content.ReadAsStringAsync();
            return new HttpResponseWrapper<object>(content,!ResponseHttp.IsSuccessStatusCode,ResponseHttp);
        }

        public async Task<HttpResponseWrapper<TActionResponse>> PutClientes<T, TActionResponse>(string url, object model)
        {
            var MessageBody = JsonSerializer.Serialize(model);
            var MessageContent = new StringContent(url, Encoding.UTF8, "application/json");
            var ResponseHttp = await _httpclient.PutAsync(url, MessageContent);
            var content = await ResponseHttp.Content.ReadAsStringAsync();
            if(ResponseHttp.IsSuccessStatusCode)
            {
                var response = JsonSerializer.Deserialize<TActionResponse>(content, _serialice);
                return new HttpResponseWrapper<TActionResponse>(response, false, ResponseHttp);
            }
            return new HttpResponseWrapper<TActionResponse>(default, true, ResponseHttp);
        }
    }
}
