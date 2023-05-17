using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EffectController : MonoBehaviour
{
   // public EffectConstant constant;

    private ObjectFactory effectFactory;
    private EffectDataManager effectDataManager;

    private void Awake()
    {
        effectFactory = new EffectFactory();
        effectDataManager = new EffectDataManager();

    }

    public void OnEffectFireBall(int createCount,Vector3 spawnPos, GameObject target, float speed, float damage,Vector3 size)
    {
        for(int i = 0; i < createCount; i++)
        {
            EffectFireBall fireBall = null;
            GameObject go = null;

            go = effectFactory.AddObject(OBJECT_TYPE.EFFECTFIREBALLTYPE,spawnPos, target, DelEffect, speed,damage,size);

            go.TryGetComponent<EffectFireBall>(out fireBall);

            fireBall.OnReset();

            effectDataManager.AddEffectFireBall(ref fireBall);
        }
    }

    public void OnEffectMagicBolt(int createCount, Vector3 spawnPos, Vector3 dir, float speed, float damage, Vector3 size)
    {
        for(int i = 0;i < createCount;i++)
        {
            EffectMagicBolt magicBolt = null;
            GameObject go = null;

            go = effectFactory.AddObject(OBJECT_TYPE.EFFECTMAGICBOLTTYPE,spawnPos, dir, DelEffect, speed, damage,size);
            go.TryGetComponent<EffectMagicBolt>(out magicBolt);

            magicBolt.OnReset();

            effectDataManager.AddEffectMagicBolt(ref magicBolt);
        }
    }

    public void OnEffectKunai(int createCount,Vector3 spawnPos, Transform parent, Vector3 axis, float angle, float speed, float damage, float duration, Vector3 size)
    {
        float angleStep = 360f / createCount;

        for (int i = 0; i < createCount;i++)
        {
            EffectKunai effectKunai = null;
            GameObject go = null;

            //go = effectFactory.AddObject(OBJECT_TYPE.EFFECTKUNAITYPE, spawnPos , parent, axis, angle * angleStep * i, DelEffect, damage, duration, size);
            go = effectFactory.AddObject(OBJECT_TYPE.EFFECTKUNAITYPE, spawnPos , parent, axis, angleStep * i, DelEffect,speed, damage, duration, size);
            go.TryGetComponent<EffectKunai>(out effectKunai);

            effectKunai.OnReset();

            effectDataManager.AddEffectKuani(ref effectKunai);
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

        }

        effectFactory.RecycleObject(type, go);
    }
}
