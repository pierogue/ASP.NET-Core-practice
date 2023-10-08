namespace lab3.Models;

public class Record
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Number { get; set; }

    public Record(string name, string number)
    {
        Name = name;
        Number = number;
    }
}