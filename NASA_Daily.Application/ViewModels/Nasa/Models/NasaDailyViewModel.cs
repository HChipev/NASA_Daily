namespace NASA_Daily.Domain.ViewModels.Nasa.Models
{
    public class NasaDailyViewModel
    {
        public DateTime Date { get; set; }
        public string Explanation { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}