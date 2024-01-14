using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirQuality.Core.DAL.Abstractions
{
    public interface IStation
    {
        /// <summary>
        /// Уникальный идентификатор записи
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Уникальный идентификатор станции
        /// </summary>
        public Guid SensorId { get; }

        /// <summary>
        /// Строка содержащая данные с датчика GPS
        /// </summary>
        public string Location { get; }
        
        /// <summary>
        /// Дата создания записи
        /// </summary>
        public DateTime CreatedAt { get; }

        /// <summary>
        /// Дата обновления записи
        /// </summary>
        public DateTime UpdatedAt { get; }
    }
}
