using System.Net;
using CommandLine;

namespace IPAddressSelector;

public class Options
{
    [Option("file-log", Required = true, HelpText = "Путь к файлу с логами.")]
    public string FileLog { get; set; }

    [Option("file-output", Required = true, HelpText = "Путь к файлу с результатом.")]
    public string FileOutput { get; set; }
    
    [Option("address-start", Required = false, HelpText = "Нижняя граница диапазона адресов.")]
    public IPAddress AddressStart { get; set; }
    
    [Option("address-mask", Required = false, HelpText = "Маска подсети", Default = -1)]
    public int AddressMask { get; set; }
    
    [Option("time-start", Required = true, HelpText = "Нижняя граница временного интервала.")]
    public DateTime TimeStart { get; set; }
    
    [Option("time-end", Required = true, HelpText = "Верхняя граница временного интервала.")]
    public DateTime TimeEnd { get; set; }
}