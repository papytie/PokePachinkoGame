using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static T instance = null;
    public static T Instance => instance;
    protected virtual void Awake()
    {
        InitSingleton();
    }

    void InitSingleton()
    {
        if (instance)
        {
            Destroy(this);
            return;
        }
        instance = this as T;
        instance.name += $"[{GetType().Name}]";
    } //Prevents this class to be instancied multiples times
}
