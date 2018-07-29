

namespace AirportClient.Models
{
    public class AirplaneType : IModel
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public int Capacity { get; set; }

        public int Cargo { get; set; }

        public int AirplaneId { get; set; }
    }
}
