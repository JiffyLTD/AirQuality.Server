namespace AirQuality.DAL.DTOs
{
    public class DBResponse
    {
        public DBResponse(object? dtoModel, string message)
        {
            DtoModel = dtoModel;
            Message = message;
        }

        public object? DtoModel { get; set; }
        public string Message { get; set; } 
    }
}
