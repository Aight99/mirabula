using UnityEngine;

public static class BootLoader
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Exeucte() =>
        Object.DontDestroyOnLoad(Object.Instantiate(Resources.Load("BootLoader/Systems")));
}
