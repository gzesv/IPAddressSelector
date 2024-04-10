using System.Net;
using NetTools;

namespace IPAddressSelector;

public static class Utils
{
    private const string ExitCommand = "exit";
    
    private const string ConfigCommand = "config";
    
    private static IPAddress _lowAddress = IPAddress.Parse("0.0.0.0");
    
    private static IPAddress _heightAddress = IPAddress.Parse("255.255.255.255");
        
    public static IPAddressRange GetIpAddressRange(Options options)
    {
        if (options.AddressStart != null
            && !options.AddressStart.Equals(_lowAddress))
        {
            if (options.AddressMask != -1)
            {
                return new IPAddressRange(options.AddressStart, options.AddressMask);
            }
            
            return new IPAddressRange(options.AddressStart, _heightAddress);
        }

        return new IPAddressRange(_lowAddress, _heightAddress);
    }
    
    public static bool OptionsIsValid(Options options)
    {
        if (!File.Exists(options.FileLog))
        {
            throw new FileNotFoundException();
        }

        return true;
    }
    
    public static bool IsExitCommand(string[] args)
    {
        return args.FirstOrDefault() == ExitCommand;
    }
    
    public static bool IsConfigCommand(string[] args)
    {
        return args.FirstOrDefault() == ConfigCommand;
    }
}