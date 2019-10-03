using System;
using System.Collections.Generic;

public class Player : IPlayer
{
    public Guid Id { get; set; }
    public int Score { get; set; }
    public List<Item> Items { get; set; }

    public Item GetHighestLevelItem(){
        Item rtrn = Items[0];
        foreach(Item i in Items){
            //if()
        }
        return null;
    }
}