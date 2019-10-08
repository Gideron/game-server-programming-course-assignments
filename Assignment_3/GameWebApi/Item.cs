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

    [ValidDate]
    public DateTime CreationTime { get; set; }
}

public class ValidDate : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        DateTime dt = (DateTime)value;
        bool isValid = 0 <= dt.CompareTo(DateTime.Now);
        return isValid;
    }
}