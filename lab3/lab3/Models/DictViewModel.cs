using System.Text;
using System.Text.Json;

namespace lab3.Models;
using System.Text.Json.Serialization;

public class DictViewModel
{
    public SortedDictionary<string, string> PhoneDictionary;

    public SortedDictionary<string, string>? ReadFromFile()
    {
        using (var fs = new FileStream("./Data/Dict.json", FileMode.OpenOrCreate))
        {
            SortedDictionary<string, string>? dict = JsonSerializer.Deserialize<SortedDictionary<string, string>>(fs);

            if (dict != null)
            {
                return dict;
            }
            else return null;
        }
    }

    public bool WriteToFile()
    {
        File.Delete("./Data/Dict.json");
        using (var fs = new FileStream("./Data/Dict.json", FileMode.OpenOrCreate))
        {
            var json = JsonSerializer.Serialize(PhoneDictionary);
            fs.Write(new ReadOnlySpan<byte>(UnicodeEncoding.UTF8.GetBytes(json)));
            return true;
        }
    }
    
    public DictViewModel()
    {
        PhoneDictionary = ReadFromFile() ?? new SortedDictionary<string, string>();
    }

    public void Add(string name, string number)
    {
        PhoneDictionary.Add(name, number);
        WriteToFile();
    }

    public bool Remove(string name)
    {
        PhoneDictionary.Remove(name);
        WriteToFile();
        return true;
    }

    public bool Update(string name, string number)
    {
        if (PhoneDictionary.ContainsKey(name))
        {
            PhoneDictionary[name] = number;
            WriteToFile();
            return true;
        }
        else
        {
            return false;
        }
    }
    
}