using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum OBJECT_TYPE
{
    NONE,
    //MONSTER
    MONSTERBATTYPE,
    ITEMTYPE,
    COINTYPE,
    //EFFECT
    EFFECTFIREBALLTYPE,
}

public class ObjectPool : MonoSingleton<ObjectPool>
{
    private GameObject monsterBat;
    private GameObject item;
    private GameObject coin;
    private GameObject effectFireBall;

    private Queue<GameObject> monsterBatQueue = new Queue<GameObject>();
    private string batNameData = "Monster_Bat_Data";
    private int bat_Create_Count = 100;
    private GameObject batParent;

    private Queue<GameObject> fireBallQueue = new Queue<GameObject>();
    private string fireBallNameData = "EffectFireBall_Data";
    private int fireBall_Create_Count = 100;
    private GameObject fireBallParent;

    private void Awake()
    {
        monsterBat = Resources.Load(batNameData) as GameObject;
        effectFireBall = Resources.Load(fireBallNameData) as GameObject;

        //////////////////

        monsterBat.SetActive(false);
        effectFireBall.SetActive(false);

        //////////////////

        batParent = CreateLocalObject(batNameData);
        fireBallParent = CreateLocalObject(fireBallNameData); 

        for (int i = 0; i < bat_Create_Count; i++)
        {
            GameObject go = Instantiate(monsterBat);
            go.transform.SetParent(batParent.transform);
            monsterBatQueue.Enqueue(go);
        }

        for (int i = 0;i < fireBall_Create_Count; i++)
        {
            GameObject go = Instantiate(effectFireBall);
            go.transform.SetParent(fireBallParent.transform);
            fireBallQueue.Enqueue(go);
        }
    }

    public T Get<T>(OBJECT_TYPE _type)
    {
        T data = default(T);
        GameObject go = null;

        
        switch (_type)
        {
            case OBJECT_TYPE.MONSTERBATTYPE:
                {
                    if(monsterBatQueue.Count == 0) 
                    {
                        go = Instantiate(monsterBat);
                        go.transform.SetParent(batParent.transform);
                    }
                    else
                    {
                        go = monsterBatQueue.Dequeue();
                    }
                }
                break;

            case OBJECT_TYPE.EFFECTFIREBALLTYPE:
                {
                    if(fireBallQueue.Count == 0)
                    {
                        go = Instantiate(effectFireBall);
                        go.transform.SetParent(fireBallParent.transform);
                    }
                    else
                    {
                        go = fireBallQueue.Dequeue();
                    }
                }
                break;
        }

        go.SetActive(true);
        data = go.GetComponent<T>();

        return data;
    }

    public void Recycle<T>(OBJECT_TYPE type, GameObject go)
    {
        if(go == null)
        {
            throw new System.Exception("go data is null");
        }

        go.SetActive(false);

        switch (type)
        {
            case OBJECT_TYPE.MONSTERBATTYPE:
                {
                    monsterBatQueue.Enqueue(go);
                }
                break;
            case OBJECT_TYPE.ITEMTYPE:
                break;
            case OBJECT_TYPE.COINTYPE:
                break;
            case OBJECT_TYPE.EFFECTFIREBALLTYPE:
                break;
        }
    }

    public GameObject CreateLocalObject(string localName)
    {
        GameObject go = new GameObject(localName);
        go.transform.SetParent(this.transform);

        return go;
    }
}
