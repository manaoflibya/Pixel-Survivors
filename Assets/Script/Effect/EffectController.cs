using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EffectController : MonoBehaviour
{
   // public EffectConstant constant;

    private EffectFactory effectFactory;
    private EffectDataManager effectDataManager;
    private EffectConstant effectConstant;

    private void Awake()
    {
        effectFactory = new EffectFactory();
        effectDataManager = new EffectDataManager();

    }

    //Gameobject Monster Target을 배열로 받아서 타겟만큼 FireBall떨어뜨려야함.

    public void OnEffectFireBall(int createCount,int upgradeCount,Vector3 spawnPos, GameObject target, float speed, float damage,Vector3 size)
    {
        Vector3 newSize = new Vector3((float)(size.x + (upgradeCount * 0.1)), (float)(size.y + (upgradeCount * 0.1)), (float)(size.z + (upgradeCount * 0.1)));

        for (int i = 0; i < createCount; i++)
        {
            EffectFireBall fireBall = null;
            GameObject go = null;

            go = effectFactory.AddObject(OBJECT_TYPE.EFFECTFIREBALLTYPE,spawnPos, target, DelEffect, speed,damage, newSize);

            go.TryGetComponent<EffectFireBall>(out fireBall);

            fireBall.OnReset();

            effectDataManager.AddEffectFireBall(ref fireBall);
        }
    }

    public void OnEffectMagicBolt(int createCount,int upgradeCount, Vector3 spawnPos, Vector3 dir, float speed, float damage, Vector3 size)
    {
        createCount += upgradeCount;

        for(int i = 0;i < createCount;i++)
        {
            EffectMagicBolt magicBolt = null;
            GameObject go = null;

            Vector3 newVec = new Vector3((float)(dir.x + (i * -0.1)), (float)(dir.y + (i * -0.1)), (float)(dir.z + (i * -0.1)));

            go = effectFactory.AddObject(OBJECT_TYPE.EFFECTMAGICBOLTTYPE,spawnPos, newVec, DelEffect, speed, damage,size);
            go.TryGetComponent<EffectMagicBolt>(out magicBolt);

            magicBolt.OnReset();

            effectDataManager.AddEffectMagicBolt(ref magicBolt);
        }
    }

    public void OnEffectKunai(int createCount,int upgradeCount,Vector3 spawnPos, Transform parent, Vector3 axis, float angle, float speed, float damage, float duration, Vector3 size)
    {
        createCount += upgradeCount;
        float angleStep = 360f / createCount;

        for (int i = 0; i < createCount;i++)
        {
            EffectKunai effectKunai = null;
            GameObject go = null;

            go = effectFactory.AddObject(OBJECT_TYPE.EFFECTKUNAITYPE, spawnPos , parent, axis, angleStep * i, DelEffect,speed, damage, duration, size);
            go.TryGetComponent<EffectKunai>(out effectKunai);

            effectKunai.OnReset();

            effectDataManager.AddEffectKuani(ref effectKunai);
        }
    }

    public void OnEffectPoison(int createCount,int upgradeCount, Vector3 spawnPos, Vector3 axis, float angle, float speed, float damage, float duration, Vector3 size)
    {
        createCount += upgradeCount;    
        float angleStep = 360 / createCount;

        for(int i = 0;i < createCount;i++)
        {
            EffectPoison effectPoison = null;
            GameObject go = null;

            go = effectFactory.AddObject(OBJECT_TYPE.EFFECTPOISONTYPE, spawnPos, axis, angleStep * i, DelEffect, speed, damage,duration, size);
            go.TryGetComponent(out effectPoison);

            effectPoison.OnReset();

            effectDataManager.AddEffectPoison(ref effectPoison);
        }
    }

    public void OnEffectBounceBall(int createCount,int upgradeCount, Vector3 spawnPos, Vector3 dir, float speed, float damage, float duration, Vector3 size)
    {
        for(int i = 0; i < createCount;i++)
        {
            EffectBounceBall effectBounceBall = null;
            GameObject go = null;

            Vector3 newVec = new Vector3((float)(dir.x + (i * 0.1)), (float)(dir.y + (i * 0.1)), (float)(dir.z + (i * 0.1)));


            go = effectFactory.AddObject(OBJECT_TYPE.EFFECTBOUNCEBALLTYPE,spawnPos, newVec, DelEffect, speed, damage,duration,size);
            go.TryGetComponent(out effectBounceBall);

            effectBounceBall.OnReset();

            effectDataManager.AddEffectBounceBall(ref effectBounceBall);
        }
    }

    public void OnEffectBatMan(int createCount,int upgradeCount, Vector3 spawnPos, Vector3 dir, int hitCount, float speed, float damage, Vector3 size)
    {
        createCount += upgradeCount;

        for (int i = 0; i < createCount; i++)
        {
            EffectBatMan effectBatMan= null;
            GameObject go = null;

            Vector3 newVec = new Vector3((float)(dir.x + (i * 0.1)), (float)(dir.y + (i * 0.1)), (float)(dir.z + (i * 0.1)));

            go = effectFactory.AddObject(OBJECT_TYPE.EFFECTBATMANTYPE, spawnPos, newVec, hitCount, DelEffect, speed, damage, size);
            go.TryGetComponent(out effectBatMan);

            effectBatMan.OnReset();

            effectDataManager.AddEffectBatMan(ref effectBatMan);
        }
    }



    private void DelEffect(OBJECT_TYPE type, int uid, GameObject go)
    {
        switch(type)
        {
            case OBJECT_TYPE.EFFECTFIREBALLTYPE:
                {
                    effectDataManager.DelEffectFireBall(uid);
                }
                break;
            case OBJECT_TYPE.EFFECTMAGICBOLTTYPE:
                {
                    effectDataManager.DelEffectMagicBolt(uid);
                }
                break;
            case OBJECT_TYPE.EFFECTKUNAITYPE:
                {
                    effectDataManager.DelEffectKuani(uid);
                }
                break;
            case OBJECT_TYPE.EFFECTPOISONTYPE:
                {
                    effectDataManager.DelEffectPoison(uid);
                }
                break;         
            case OBJECT_TYPE.EFFECTBOUNCEBALLTYPE:
                {
                    effectDataManager.DelEffectBounceBall(uid);
                }
                break;            
            case OBJECT_TYPE.EFFECTBATMANTYPE:
                {
                    effectDataManager.DelEffectBatMan(uid);
                }
                break;
        }

        effectFactory.RecycleObject(type, go);
    }
}
