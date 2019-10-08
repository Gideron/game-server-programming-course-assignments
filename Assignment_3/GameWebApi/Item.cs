using System;
using System.ComponentModel.DataAnnotations;

public class Item
{
    public enum ItemType {
        SWORD, POTION, SHIELD
    }

    public Guid Id { get; set; }

    [Range(1, 99)]
    public int Level { get; set; }

    [EnumDataType(typeof(ItemType))]
    public ItemType Type { get; set; }

    public DateTime CreationTime { get; set; }
}