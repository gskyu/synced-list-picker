namespace Gskyu.SyncedListPicker.Models;

public class Item
{
    public Item(string id, string name, bool completed = false)
    {
        Id = id;
        Name = name;
        Completed = completed;
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public bool Completed { get; set; }
}