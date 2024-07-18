using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GetIt
{
    private static Dictionary<Type, object> instances = new Dictionary<Type, object>();

    public static void registerSingleton<T>(T instance)
    {
        if (instances.ContainsKey(typeof(T)))
        {
            //throw new Exception($"Try to register existing singltone {typeof(T)}");
            Debug.LogError($"Try to register existing singltone {typeof(T)}");
        }

        instances[typeof(T)] = instance;
    }

    public static T get<T>()
    {
        if (!instances.ContainsKey(typeof(T)))
        {
            throw new Exception($"Try to get non existing singltone {typeof(T)}");
            //Debug.LogError($"Try to get non existing singltone {typeof(T)}");
        }

        object instanse = instances[typeof(T)];

        return (T)instanse;
    }
}
