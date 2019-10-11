using System;
using UnityEngine;

[DisallowMultipleComponent]
public class MonoSingleton<TClass> : MonoBehaviour where TClass : MonoBehaviour
{
    #region Instance Handling
    private static MonoSingleton<TClass> _instance = null;

    protected virtual void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            throw new Exception("There is already an singleton instance of" + GetType().Name);
    }

    public static TClass Instance
    {
        get
        {
            if (_instance != null)
                return _instance as TClass;
            else
                throw new Exception("There is no singleton instance of" + typeof(TClass).Name);
        }
    }

    public static bool HasInstance
    {
        get { return _instance != null; }
    }
    #endregion
}
