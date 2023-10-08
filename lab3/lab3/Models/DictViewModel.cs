using System.Text;
using System.Text.Json;
using lab3.Database;

namespace lab3.Models;
using System.Text.Json.Serialization;

public class DictViewModel
{
    // public SortedDictionary<int, Record> PhoneDictionary;
    // public SortedDictionary<string, string>? ReadFromFile()
    // {
    //     using (var fs = new FileStream("./Data/Dict.json", FileMode.OpenOrCreate))
    //     {
    //         SortedDictionary<string, string>? dict = JsonSerializer.Deserialize<SortedDictionary<string, string>>(fs);
    //
    //         if (dict != null)
    //         {
    //             return dict;
    //         }
    //         else return null;
    //     }
    // }

    // public bool WriteToFile()
    // {
    //     File.Delete("./Data/Dict.json");
    //     using (var fs = new FileStream("./Data/Dict.json", FileMode.OpenOrCreate))
    //     {
    //         var json = JsonSerializer.Serialize(PhoneDictionary);
    //         fs.Write(new ReadOnlySpan<byte>(UnicodeEncoding.UTF8.GetBytes(json)));
    //         return true;
    //     }
    // }
    public SortedDictionary<int, Record> GetDictionary()
    {
        using (var db = new ApplicationContext())
        {
            return new SortedDictionary<int, Record>
                (db.Records.ToDictionary(k=>k.Id, l=>l));
        }
    }
    public SortedDictionary<int, Record> ReadFromDatabase()
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            return new SortedDictionary<int, Record>
                (db.Records.ToDictionary(i => i.Id, r => r));
        }
    }

    public void WriteToDatabase(Record record)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            db.Records.Add(record);
            db.SaveChanges();
        }
    }

    public void Add(string name, string number)
    {
        WriteToDatabase(new Record(name, number));
    }

    public bool Remove(int id)
    {
        using (var db = new ApplicationContext())
        {
            var rec = db.Records.Find(id);
            if (rec == null) return false;
            db.Remove(rec);
            db.SaveChanges();
            return true;
        }
    }

    public bool Update(int id, string name, string number)
    {
        using (var db = new ApplicationContext())
        {
            var rec = db.Records.Find(id);
            if (rec is null) return false;
            rec.Name = name;
            rec.Number = number;
            db.SaveChanges();
            return true;
        }
    }
    
}