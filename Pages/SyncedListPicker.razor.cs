using Gskyu.SyncedListPicker.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Text.Json;

namespace Gskyu.SyncedListPicker.Pages;

public partial class SyncedListPicker : ComponentBase
{
    protected List<Item> ItemList { get; set; }

    protected EditContext AddItemContext { get; set; }
    protected Item ItemToAdd { get; set; }

    protected string RandomlyChosenOne { get; set; }
    private bool IncludeCompletedItems { get; set; }
    private const string NA = "N/A";

    public SyncedListPicker()
    {
        ItemToAdd = new Item(Guid.NewGuid().ToString(), string.Empty);
        AddItemContext = new EditContext(ItemToAdd);

        ItemList ??= new List<Item>();
        RandomlyChosenOne = NA;
        IncludeCompletedItems = true;
    }

    protected void AddItem()
    {
        ItemList.Add(new Item(Guid.NewGuid().ToString(), ItemToAdd.Name));
    }

    protected void UpdateItem(string id)
    {
        Console.WriteLine("called update");
    }

    protected void PickRandomItem()
    {
        var rnd = new Random(DateTime.UtcNow.Millisecond);
        var eligibleChoices = IncludeCompletedItems ? ItemList : ItemList.Where(i => !i.Completed)?.ToList();
        RandomlyChosenOne = eligibleChoices?[rnd.Next(0, eligibleChoices.Count())].Name ?? NA;
    }

    protected void OnPickerRangeChanged(ChangeEventArgs e)
    {
        IncludeCompletedItems = bool.Parse(e.Value?.ToString() ?? "true");
    }

    protected override Task OnInitializedAsync()
    {
        return base.OnInitializedAsync();
    }
}
