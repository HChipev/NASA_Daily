using System.Globalization;
using Microsoft.Extensions.Configuration;
using NASA_Daily.Domain.Constants;
using NASA_Daily.Domain.Services.Interfaces;
using NASA_Daily.Domain.ViewModels.ApiResponse;
using NASA_Daily.Domain.ViewModels.Nasa.Models;
using Newtonsoft.Json;

namespace NASA_Daily.Domain.Services.Implementations
{
    public class NasaService : INasaService
    {
        private readonly IConfiguration _configuration;

        public NasaService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ApiResponse<NasaDailyViewModel>> GetDailyNasaImageAsync(DateTime? date)
        {
            var url = date is null
                ? _configuration["NASA:Url"]?.Replace("{ApiKey}", _configuration["NASA:ApiKey"])
                : _configuration["NASA:Url"]?.Replace("{ApiKey}", _configuration["NASA:ApiKey"])
                    .Concat($"&date={date.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)}")
                    .Aggregate("", (url, ch) => url + ch);


            if (url is null)
            {
                return new ApiResponse<NasaDailyViewModel>(false, null, ErrorMessage.Generic);
            }

            using var client = new HttpClient();
            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                return new ApiResponse<NasaDailyViewModel>(false, null, ErrorMessage.Generic);
            }

            var responseJson = await response.Content.ReadAsStringAsync();

            return new ApiResponse<NasaDailyViewModel>(true,
                JsonConvert.DeserializeObject<NasaDailyViewModel>(responseJson));
        }
    }
}