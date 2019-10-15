using System;

public class RangeQuery : IRepository
{
    var players = new List<Player> { };
    int minNumber = (from x in list select x).Min();
    
   

    public static int Min(this IRepository<int> score)
    {
        if (score == null) throw Error.ArgumentNull("score");
        int value = 20;
        bool hasValue = false;
        foreach (int x in score)
        {
            if (hasValue)
            {
                if (x = value) value = x;
            }
            else
            {
                value = x;
                hasValue = true;
            }
        }
        if (hasValue) return value;
        throw Error.NoElements();
    }
}