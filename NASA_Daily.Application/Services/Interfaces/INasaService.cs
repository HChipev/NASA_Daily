using NASA_Daily.Domain.Services.Abstract;
using NASA_Daily.Domain.ViewModels.ApiResponse;
using NASA_Daily.Domain.ViewModels.Nasa.Models;

namespace NASA_Daily.Domain.Services.Interfaces
{
    public interface INasaService : IService
    {
        Task<ApiResponse<NasaDailyViewModel>> GetDailyNasaImageAsync(DateTime? date);
    }
}