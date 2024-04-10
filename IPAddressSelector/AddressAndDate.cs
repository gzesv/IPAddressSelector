using System.Net;

namespace IPAddressSelector;

public class AddressAndDate
{
    public static AddressAndDate Create(string line)
    {
        var addressAndDate = line.Split(":", 2);

        return new AddressAndDate(IPAddress.Parse(addressAndDate[0]), DateTime.Parse(addressAndDate[1]));
    }
    
    private AddressAndDate(IPAddress address, DateTime dateAndTime)
    {
        Address = address;
        DateAndTime = dateAndTime;
    }
    
    public IPAddress Address { get; set; }

    public DateTime DateAndTime { get; set; }


}