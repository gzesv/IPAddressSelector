using System.Globalization;
using CommandLine;
using Microsoft.Extensions.Configuration;
using NetTools;

namespace IPAddressSelector;

internal class Program
{
    public static void Main(string[] args)
    {
        var parser = new Parser(setting => 
            setting.ParsingCulture = new CultureInfo("ru-Ru"));

        var options = new Options();
        
        while (true)
        {
            try
            {
                options = parser.ParseArguments<Options>(args).Value;
                if (Utils.OptionsIsValid(options))
                {
                    break;
                }
            }
            catch (FileNotFoundException)
            {
                Messages.FileNotExistsMessage();
                Messages.ReadFromConfigurationMessage();
            }
            catch (Exception)
            {
                Messages.NotCorrectOptionsMessage();
                Messages.ReadFromConfigurationMessage();
            }
            
            args = Console.ReadLine().Trim().Split();
            if (Utils.IsExitCommand(args))
            {
                break;
            }
            
            if (Utils.IsConfigCommand(args))
            {
                options = GetOptionsFromConfig();
                break;
            }
        }
        
        WriteFilteredAddresses(options);
    }
    
    private static void WriteFilteredAddresses(Options options)
    {
        IPAddressRange addressRange = Utils.GetIpAddressRange(options);
        
        var l = File.ReadAllLines(options.FileLog)
            .Select(AddressAndDate.Create)
            .Where(x => x.DateAndTime >= options.TimeStart
                        && x.DateAndTime <= options.TimeEnd
                        && addressRange.Contains(x.Address))
            .GroupBy(x => x.Address)
            .Select(x => $"{x.Key} - {x.Count()}")
            .ToList();
        
        File.WriteAllLines(options.FileOutput, l);
    }
    
    private static Options GetOptionsFromConfig()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        return config.GetSection("Options").Get<Options>();
    }
}