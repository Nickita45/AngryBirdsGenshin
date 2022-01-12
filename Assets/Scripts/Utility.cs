using System.Collections;
using System.Collections.Generic;
using System;
public static class Utility
{
    public static List<T> ToList<T>(this ArrayList arrayList)
    {
        List<T> list = new List<T>(arrayList.Count);
        if(list.Count == 0)
        foreach (T instance in arrayList)
        {
            list.Add(instance);
        }
        return list;
    }
}