using UnityEngine;


public abstract class Singleton<T> : MonoBehaviour
     where T : Singleton<T>
{
    private static T instance;

    public static T Get() { return instance; }

    protected virtual void Awake()
    {
        if (instance)
        {
            Destroy(this);
            throw new System.Exception("Singleton.Awake: There is already an instance of type " + this.GetType());
        }

        instance = (T)this;
    }
}