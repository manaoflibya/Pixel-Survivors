using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    protected static MonoSingleton<T> mInstance
    {
        get
        {
            if (!_mInstance)
            {
                T[] managers = GameObject.FindObjectsOfType(typeof(T)) as T[];
                if (managers.Length != 0)
                {

                    _mInstance = managers[0];
                    _mInstance.gameObject.name = typeof(T).Name;
                    return _mInstance;

                }
                GameObject gO = new GameObject(typeof(T).Name, typeof(T));
                _mInstance = gO.GetComponent<T>();
                gO.name = typeof(T).ToString() + "(SingleTon)";

                Destroy(gO);
            }

            return _mInstance;
        }
        set
        {
            _mInstance = value as T;
        }
    }
    private static T _mInstance;

    public static T Instance
    {
        get
        {
            return ((T)mInstance);
        }
        set
        {
            mInstance = value;
        }
    }

    private void Awake()
    {
        OnAwake();
    }

    protected virtual void OnAwake()
    {
        if (_mInstance != null && _mInstance != this)
        {
            //DestroyImmediate(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
        }
    }

    public virtual void Init()
    {
        mInstance = null;
    }
}
