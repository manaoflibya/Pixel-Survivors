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
    EFFECTMAGICBOLTTYPE,
}

public class ObjectPool : MonoSingleton<ObjectPool>
{
    private GameObject item;
    private GameObject coin;

    private Queue<GameObject> monsterBatQueue = new Queue<GameObject>();
    private string batNameData = "Monster_Bat_Data";
    private int bat_Create_Count = 100;
    private GameObject batParent;
    private GameObject monsterBat;

    private Queue<GameObject> fireBallQueue = new Queue<GameObject>();
    private GameObject effectFireBall;
    private GameObject fireBallParent;
    private string fireBallNameData = "EffectFireBall_Data";
    private int fireBall_Create_Count = 100;

    private Queue<GameObject> magicBoltQueue = new Queue<GameObject>();
    private GameObject magicBolt;
    private GameObject magicBoltParent;
    private string magicBoltNameData = "EffectMagicBolt_Data";
    private int magicBolt_Create_Count = 100;

    private void Awake()
    {
        monsterBat = Resources.Load(batNameData) as GameObject;
        effectFireBall = Resources.Load(fireBallNameData) as GameObject;
        magicBolt = Resources.Load(magicBoltNameData) as GameObject;

        //////////////////

        monsterBat.SetActive(false);
        effectFireBall.SetActive(false);
        magicBolt.SetActive(false);

        //////////////////

        batParent = CreateLocalObject(batNameData);
        fireBallParent = CreateLocalObject(fireBallNameData); 
        magicBoltParent = CreateLocalObject(magicBoltNameData);

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

        for(int i = 0; i < magicBolt_Create_Count; i++)
        {
            GameObject go = Instantiate(magicBolt);
            go.transform.SetParent(magicBoltParent.transform);
            magicBoltQueue.Enqueue(go);
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
            case OBJECT_TYPE.EFFECTMAGICBOLTTYPE:
                {
                    if(magicBoltQueue.Count == 0)
                    {
                        go = Instantiate(magicBolt);
                        go.transform.SetParent(magicBoltParent.transform); 
                    }
                    else
                    {
                        go = magicBoltQueue.Dequeue();
                    }
                }
                break;
        }

        go.SetActive(true);
        data = go.GetComponent<T>();

        return data;
    }

    /// <summary>
    /// 다 사용한 오브젝트를 해당 QueueData에 다시 넣기위해 사용하는 함수.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="type"></param>
    /// <param name="go"></param>
    /// <exception cref="System.Exception"></exception>
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
                {
                    fireBallQueue.Enqueue(go);
                }
                break;
            case OBJECT_TYPE.EFFECTMAGICBOLTTYPE:
                {
                    magicBoltQueue.Enqueue(go);
                }
                break;
        }
    }

    /// <summary>
    /// ObjectPool GameObject부모 아래 생성하기 위해서 사용하는 함수.
    /// </summary>
    /// <param name="localName"></param>
    /// <returns></returns>
    public GameObject CreateLocalObject(string localName)
    {
        GameObject go = new GameObject(localName);
        go.transform.SetParent(this.transform);

        return go;
    }
}
