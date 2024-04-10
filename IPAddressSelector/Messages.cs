namespace IPAddressSelector;

public class Messages
{
    public static void NotCorrectOptionsMessage()
    {
        Console.WriteLine("""
                          Некорректные параметры. Введите параметры в формате:
                          --file-log <log_file_path> --file-output <output_file_path> --address-start <address start> --address-mask <address mask> --time-start <start_time> --time-end <end_time>
                          Для завершение работы введите: «exit».
                          """);
    }
    
    public static void FileNotExistsMessage()
    {
        Console.WriteLine("""
                          Файл по указанному пути отсутствует.
                          Для завершение работы введите: «exit».
                          """);
    }
    
    public static void ReadFromConfigurationMessage()
    {
        Console.WriteLine("""
                          Параметры можно прочитать из файла конфиуграции.
                          Для чтения из файла конфигурации введите: «config».
                          """);
    }
}