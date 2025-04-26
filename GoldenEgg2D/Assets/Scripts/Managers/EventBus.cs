using System;
using System.Collections.Generic;
using UnityEngine;

public static class EventBus
{
    private static readonly Dictionary<Type, Delegate> eventTable = new();

    public static void Subscribe<T>(Action<T> callback)
    {
        if (eventTable.TryGetValue(typeof(T), out var del))
            eventTable[typeof(T)] = Delegate.Combine(del, callback);
        else
            eventTable[typeof(T)] = callback;
    }

    public static void Unsubscribe<T>(Action<T> callback)
    {
        if (eventTable.TryGetValue(typeof(T), out var del))
        {
            var currentDel = Delegate.Remove(del, callback);
            if (currentDel == null)
                eventTable.Remove(typeof(T));
            else
                eventTable[typeof(T)] = currentDel;
        }
    }

    public static void Publish<T>(T publishedEvent)
    {
        if (eventTable.TryGetValue(typeof(T), out var del))
        {
            var callback = del as Action<T>;
            callback?.Invoke(publishedEvent);
        }
    }

}
