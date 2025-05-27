namespace Agent.Models;

public record TripOption
{
    public string Id { get; init; } = string.Empty;
    public string Destination { get; init; } = string.Empty;
    public DateTime DepartureDate { get; init; }
    public DateTime ReturnDate { get; init; }
    public FlightDetails OutboundFlight { get; init; } = new();
    public FlightDetails ReturnFlight { get; init; } = new();
    public HotelDetails Hotel { get; init; } = new();
    public CarRentalDetails? CarRental { get; init; }
    public decimal TotalPrice { get; init; }
}

public record FlightDetails
{
    public string Airline { get; init; } = string.Empty;
    public string FlightNumber { get; init; } = string.Empty;
    public DateTime DepartureTime { get; init; }
    public DateTime ArrivalTime { get; init; }
    public string DepartureAirport { get; init; } = string.Empty;
    public string ArrivalAirport { get; init; } = string.Empty;
    public decimal Price { get; init; }
}

public record HotelDetails
{
    public string Name { get; init; } = string.Empty;
    public string Location { get; init; } = string.Empty;
    public DateTime CheckInDate { get; init; }
    public DateTime CheckOutDate { get; init; }
    public decimal PricePerNight { get; init; }
    public int NumberOfNights { get; init; }
    public decimal TotalPrice { get; init; }
}

public record CarRentalDetails
{
    public string Company { get; init; } = string.Empty;
    public string CarType { get; init; } = string.Empty;
    public DateTime PickupDate { get; init; }
    public DateTime ReturnDate { get; init; }
    public decimal PricePerDay { get; init; }
    public int NumberOfDays { get; init; }
    public decimal TotalPrice { get; init; }
}