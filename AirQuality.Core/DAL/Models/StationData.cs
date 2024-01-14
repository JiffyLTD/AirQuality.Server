using AirQuality.Core.DAL.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirQuality.Core.DAL.Models
{
    public class StationData : IStationData
    {
        public StationData()
        {
        }

        public StationData(string stationId, float temperature, int humidity, int pm_1, int pm_2_5, int pm_10, int co, int pressure)
        {
            Id = Guid.NewGuid();
            StationId = Guid.Parse(stationId);
            Temperature = temperature;
            Humidity = humidity;
            Pm_1 = pm_1;
            Pm_2_5 = pm_2_5;
            Pm_10 = pm_10;
            Co = co;
            Pressure = pressure;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public Guid Id { get; private set; }

        [ForeignKey("Station")]
        public Guid StationId { get; private set; }

        public float Temperature { get; private set; }

        public int Humidity { get; private set; }

        public int Pm_1 { get; private set; }

        public int Pm_2_5 { get; private set; }

        public int Pm_10 { get; private set; }

        public int Co { get; private set; }

        public int Pressure { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime UpdatedAt { get; private set; }
    }
}
