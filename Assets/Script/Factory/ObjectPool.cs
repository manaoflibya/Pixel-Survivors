using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public enum OBJECT_TYPE
{
    NONE,
    //ITEM
    ITEMEXPTYPE,
    ITEMHPTYPE,
    ITEMBOXTYPE,
    ITEMGRAVITYTYPE,

    //MONSTER
    MONSTERBATTYPE,
    MONSTERGOBLINTYPE,
    MONSTERSKELETONTYPE,
    MONSTERBOOMBTYPE,

    //EFFECT
    EFFECTFIREBALLTYPE,
    EFFECTMAGICBOLTTYPE,
    EFFECTKUNAITYPE,
    EFFECTPOISONTYPE,
    EFFECTBOUNCEBALLTYPE,
    EFFECTBATMANTYPE,
}

public class ObjectPool : MonoSingleton<ObjectPool>
{
    private Queue<GameObject> expQueue = new Queue<GameObject>();
    private string expNameData = "Item_EXP_Data";
    private int expCreatCount = 500;
    private GameObject expParent;
    private GameObject itemExp;

    private Queue<GameObject> gravityQueue = new Queue<GameObject>();
    private string gravityNameData = "Item_Gravity_Data";
    private int gravityCreatCount = 20;
    private GameObject gravityParent;
    private GameObject itemGravity;


    #region Monster
    private Queue<GameObject> batQueue = new Queue<GameObject>();
    private string batNameData = "Monster_Bat_Data";
    private int batCreateCount = 100;
    private GameObject batParent;
    private GameObject monsterBat;

    private Queue<GameObject> goblinQueue = new Queue<GameObject>();
    private string goblinNameData = "Monster_Goblin_Data";
    private int goblinCreateCount = 100;
    private GameObject goblinParent;
    private GameObject monsterGoblin;

    private Queue<GameObject> skeletonQueue = new Queue<GameObject>();
    private string skeletonNameData = "Monster_Skeleton_Data";
    private int skeletonCreateCount = 100;
    private GameObject skeletonParent;
    private GameObject monsterSkeleton;

    private Queue<GameObject> boombQueue = new Queue<GameObject>();
    private string boombNameData = "Monster_Boomb_Data";
    private int boombCreateCount = 100;
    private GameObject boombParent;
    private GameObject monsterBoomb;
    #endregion

    #region Effect
    private Queue<GameObject> fireBallQueue = new Queue<GameObject>();
    private GameObject effectFireBall;
    private GameObject fireBallParent;
    private string fireBallNameData = "EffectFireBall_Data";
    private int fireBallCreateCount = 100;

    private Queue<GameObject> magicBoltQueue = new Queue<GameObject>();
    private GameObject magicBolt;
    private GameObject magicBoltParent;
    private string magicBoltNameData = "EffectMagicBolt_Data";
    private int magicBoltCreateCount = 100;

    private Queue<GameObject> kunaiQueue = new Queue<GameObject>();
    private GameObject kunai;
    private GameObject kunaiParent;
    private string kuaniNameData = "EffectKunai_Data";
    private int kunaiCreateCount = 20;

    private Queue<GameObject> poisonQueue = new Queue<GameObject>();
    private GameObject poison;
    private GameObject poisonParent;
    private string poisonNameData = "EffectPoison_Data";
    private int poisonCreateCount = 20;

    private Queue<GameObject> bounceBallQueue = new Queue<GameObject>();
    private GameObject bounceBall;
    private GameObject bounceBallParent;
    private string bounceBallNameData = "EffectBounceBall_Data";
    private int bounceBallCreateCount = 20;

    private Queue<GameObject> batManQueue = new Queue<GameObject>();
    private GameObject batMan;
    private GameObject batManParent;
    private string batManNameData = "EffectBatMan_Data";
    private int batManCreateCount = 10;
#endregion

    private void Awake()
    {
        itemExp = Resources.Load(expNameData) as GameObject;
        itemGravity = Resources.Load(gravityNameData) as GameObject;

        monsterBat = Resources.Load(batNameData) as GameObject;
        monsterGoblin = Resources.Load(goblinNameData) as GameObject;
        monsterSkeleton = Resources.Load(skeletonNameData) as GameObject;
        monsterBoomb = Resources.Load(boombNameData) as GameObject;

        effectFireBall = Resources.Load(fireBallNameData) as GameObject;
        magicBolt = Resources.Load(magicBoltNameData) as GameObject;
        kunai = Resources.Load(kuaniNameData) as GameObject;
        poison = Resources.Load(poisonNameData) as GameObject;
        bounceBall = Resources.Load(bounceBallNameData) as GameObject;
        batMan = Resources.Load(batManNameData) as GameObject;

        //////////////////
        itemExp.SetActive(false);
        itemGravity.SetActive(false);

        monsterBat.SetActive(false);
        monsterGoblin.SetActive(false);
        monsterSkeleton.SetActive(false);
        monsterBoomb.SetActive(false);

        effectFireBall.SetActive(false);
        magicBolt.SetActive(false);
        kunai.SetActive(false);
        poison.SetActive(false);
        bounceBall.SetActive(false);
        batMan.SetActive(false);

        ////////////////// 
        expParent = CreateLocalObject(expNameData);
        gravityParent = CreateLocalObject(gravityNameData);

        batParent = CreateLocalObject(batNameData);
        goblinParent = CreateLocalObject(goblinNameData);
        skeletonParent = CreateLocalObject(skeletonNameData);
        boombParent = CreateLocalObject(boombNameData);

        fireBallParent = CreateLocalObject(fireBallNameData); 
        magicBoltParent = CreateLocalObject(magicBoltNameData);
        kunaiParent = CreateLocalObject(kuaniNameData);
        poisonParent = CreateLocalObject(poisonNameData);
        bounceBallParent = CreateLocalObject(bounceBallNameData);
        batManParent = CreateLocalObject(batManNameData);

        /////////////////
        
        for(int i =  0; i < expCreatCount; i++)
        {
            GameObject go = Instantiate(itemExp);
            go.transform.SetParent(expParent.transform);
            expQueue.Enqueue(go);
        }

        for (int i = 0; i < gravityCreatCount; i++)
        {
            GameObject go = Instantiate(itemGravity);
            go.transform.SetParent(gravityParent.transform);
            gravityQueue.Enqueue(go);
        }

        for (int i = 0; i < batCreateCount; i++)
        {
            GameObject go = Instantiate(monsterBat);
            go.transform.SetParent(batParent.transform);
            batQueue.Enqueue(go);
        }       
        
        for (int i = 0; i < goblinCreateCount; i++)
        {
            GameObject go = Instantiate(monsterGoblin);
            go.transform.SetParent(goblinParent.transform);
            goblinQueue.Enqueue(go);
        }

        for (int i = 0; i < skeletonCreateCount; i++)
        {
            GameObject go = Instantiate(monsterSkeleton);
            go.transform.SetParent(skeletonParent.transform);
            skeletonQueue.Enqueue(go);
        }

        for (int i = 0; i < boombCreateCount; i++)
        {
            GameObject go = Instantiate(monsterBoomb);
            go.transform.SetParent(boombParent.transform);
            boombQueue.Enqueue(go);
        }

        for (int i = 0;i < fireBallCreateCount; i++)
        {
            GameObject go = Instantiate(effectFireBall);
            go.transform.SetParent(fireBallParent.transform);
            fireBallQueue.Enqueue(go);
        }

        for(int i = 0; i < magicBoltCreateCount; i++)
        {
            GameObject go = Instantiate(magicBolt);
            go.transform.SetParent(magicBoltParent.transform);
            magicBoltQueue.Enqueue(go);
        }

        for (int i = 0; i < kunaiCreateCount; i++)
        {
            GameObject go = Instantiate(kunai);
            go.transform.SetParent(kunaiParent.transform);
            kunaiQueue.Enqueue(go);
        }

        for (int i = 0; i < poisonCreateCount; i++)
        {
            GameObject go = Instantiate(poison);
            go.transform.SetParent(poisonParent.transform);
            poisonQueue.Enqueue(go);
        }

        for (int i = 0; i < bounceBallCreateCount; i++)
        {
            GameObject go = Instantiate(bounceBall);
            go.transform.SetParent(bounceBallParent.transform);
            bounceBallQueue.Enqueue(go);
        }        
        
        for (int i = 0; i < batManCreateCount; i++)
        {
            GameObject go = Instantiate(batMan);
            go.transform.SetParent(batManParent.transform);
            batManQueue.Enqueue(go);
        }
    }

    public T Get<T>(OBJECT_TYPE _type)
    {
        T data = default(T);
        GameObject go = null;

        switch (_type)
        {
            #region ITEM
            case OBJECT_TYPE.ITEMEXPTYPE:
                {
                    if (expQueue.Count == 0)
                    {
                        go = Instantiate(itemExp);
                        go.transform.SetParent(expParent.transform);
                    }
                    else
                    {
                        go = expQueue.Dequeue();
                    }
                }
                break;
            case OBJECT_TYPE.ITEMGRAVITYTYPE:
                {
                    if (gravityQueue.Count == 0)
                    {
                        go = Instantiate(itemGravity);
                        go.transform.SetParent(gravityParent.transform);
                    }
                    else
                    {
                        go = gravityQueue.Dequeue();
                    }
                }
                break;
            #endregion

            #region Monster
            case OBJECT_TYPE.MONSTERBATTYPE:
                {
                    if(batQueue.Count == 0) 
                    {
                        go = Instantiate(monsterBat);
                        go.transform.SetParent(batParent.transform);
                    }
                    else
                    {
                        go = batQueue.Dequeue();
                    }
                }
                break;

            case OBJECT_TYPE.MONSTERGOBLINTYPE:
                {
                    if (goblinQueue.Count == 0)
                    {
                        go = Instantiate(monsterGoblin);
                        go.transform.SetParent(goblinParent.transform);
                    }
                    else
                    {
                        go = goblinQueue.Dequeue();
                    }
                }
                break;

            case OBJECT_TYPE.MONSTERSKELETONTYPE:
                {
                    if (skeletonQueue.Count == 0)
                    {
                        go = Instantiate(monsterSkeleton);
                        go.transform.SetParent(skeletonParent.transform);
                    }
                    else
                    {
                        go = skeletonQueue.Dequeue();
                    }
                }
                break;

            case OBJECT_TYPE.MONSTERBOOMBTYPE:
                {
                    if (boombQueue.Count == 0)
                    {
                        go = Instantiate(monsterBoomb);
                        go.transform.SetParent(boombParent.transform);
                    }
                    else
                    {
                        go = boombQueue.Dequeue();
                    }
                }
                break;
            #endregion

            #region Effect
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
            case OBJECT_TYPE.EFFECTKUNAITYPE:
                {
                    if(kunaiQueue.Count == 0)
                    {
                        go = Instantiate(kunai);
                        go.transform.SetParent(kunaiParent.transform);
                    }
                    else
                    {
                        go = kunaiQueue.Dequeue();
                    }
                }
                break;
            case OBJECT_TYPE.EFFECTPOISONTYPE:
                {
                    if (poisonQueue.Count == 0)
                    {
                        go = Instantiate(poison);
                        go.transform.SetParent(poisonParent.transform);
                    }
                    else
                    {
                        go = poisonQueue.Dequeue();
                    }
                }
                break; 
            case OBJECT_TYPE.EFFECTBOUNCEBALLTYPE:
                {
                    if (bounceBallQueue.Count == 0)
                    {
                        go = Instantiate(bounceBall);
                        go.transform.SetParent(bounceBallParent.transform);
                    }
                    else
                    {
                        go = bounceBallQueue.Dequeue();
                    }
                }
                break;            
            case OBJECT_TYPE.EFFECTBATMANTYPE:
                {
                    if (batManQueue.Count == 0)
                    {
                        go = Instantiate(batMan);
                        go.transform.SetParent(batManParent.transform);
                    }
                    else
                    {
                        go = batManQueue.Dequeue();
                    }
                }
                break;
                #endregion
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
            Debug.LogError("go is null");
        }

        go.SetActive(false);

        switch (type)
        {
            case OBJECT_TYPE.ITEMEXPTYPE:
                {
                    expQueue.Enqueue(go);
                }
                break;
            case OBJECT_TYPE.ITEMGRAVITYTYPE:
                {
                    gravityQueue.Enqueue(go);
                }
                break;
            case OBJECT_TYPE.MONSTERBATTYPE:
                {
                    batQueue.Enqueue(go);
                }
                break;
            case OBJECT_TYPE.MONSTERGOBLINTYPE:
                {
                    goblinQueue.Enqueue(go);
                }
                break;
            case OBJECT_TYPE.MONSTERSKELETONTYPE:
                {
                    skeletonQueue.Enqueue(go);
                }
                break;
            case OBJECT_TYPE.MONSTERBOOMBTYPE:
                {
                    boombQueue.Enqueue(go);
                }
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
            case OBJECT_TYPE.EFFECTKUNAITYPE:
                {
                    go.transform.SetParent(kunaiParent.transform);
                    kunaiQueue.Enqueue(go);
                }
                break;
            case OBJECT_TYPE.EFFECTPOISONTYPE:
                {
                    poisonQueue.Enqueue(go);
                }
                break;        
            case OBJECT_TYPE.EFFECTBOUNCEBALLTYPE:
                {
                    bounceBallQueue.Enqueue(go);
                }
                break;           
            case OBJECT_TYPE.EFFECTBATMANTYPE:
                {
                    go.transform.SetParent(batManParent.transform);
                    batManQueue.Enqueue(go);
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
