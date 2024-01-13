using AirQuality.Core.DAL.Abstractions;

namespace AirQuality.Core.DAL.Models
{
    public class Station : IStation
    {
        public Station()
        {
        }

        public Station(string stationId, string location)
        {
            Id = Guid.NewGuid();
            StationId = Guid.Parse(stationId);
            Location = location;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public Guid Id { get; private set; }

        public Guid StationId { get; private set; }

        public string Location { get; private set; } = null!;

        public DateTime CreatedAt { get; private set; }

        public DateTime UpdatedAt { get; private set; }
    }
}
