using Gskyu.SyncedListPicker.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Gskyu.SyncedListPicker.Pages;

public partial class SyncedListPicker : ComponentBase
{
    protected List<Item> ItemList { get; set; }

    protected EditContext AddItemContext { get; set; }
    protected Item ItemToAdd { get; set; }

    protected string RandomlyChosenOne { get; set; }

    public SyncedListPicker()
    {
        ItemToAdd = new Item { Id = Guid.NewGuid().ToString() };
        AddItemContext = new EditContext(ItemToAdd);

        ItemList ??= new List<Item>();

        RandomlyChosenOne = string.Empty;
    }

    protected void AddItem()
    {
        ItemList.Add(new Item
        {
            Id = Guid.NewGuid().ToString(),
            Name = ItemToAdd.Name,
            Completed = false
        });
    }

    protected void UpdateItem(string id)
    {
        Console.WriteLine("called update");
    }

    protected void PickRandomItem(bool completedIncluded)
    {
        var rnd = new Random(DateTime.UtcNow.Millisecond);
        RandomlyChosenOne = (completedIncluded ? ItemList : ItemList.Where(i => !i.Completed)?.ToList())?
            [rnd.Next(0, ItemList.Count - 1)].Name ?? "N/A";
    }

    protected override Task OnInitializedAsync()
    {
        return base.OnInitializedAsync();
    }
}
