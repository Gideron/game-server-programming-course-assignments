using System;

public class Item
{
    enum ItemType {
        SWORD, POTION, SHIELD
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Score { get; set; }
    public int Level { get; set; }
    public ItemType Type { get; set; }
    public DateTime CreationTime { get; set; }
}