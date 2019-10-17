using System;
using System.ComponentModel.DataAnnotations;

public class NewItem
{
    [Range(1, 99)]
    public int Level { get; set; }

    [EnumDataType(typeof(Item.ItemType))]
    public Item.ItemType Type { get; set; }
}