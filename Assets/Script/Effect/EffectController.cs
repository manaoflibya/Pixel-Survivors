using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    public EffectConstant constant;

    private ObjectFactory effectFactory;
    private EffectDataManager effectDataManager;

    private void Awake()
    {
        effectFactory = new EffectFactory();
        effectDataManager = new EffectDataManager();

    }

    private void Start()
    {
        
    }

    public void OnEffectFireBall(int createCount,Vector3 spawnPos, GameObject target, float speed, float damage,float size)
    {
        for(int i = 0; i < createCount; i++)
        {
            EffectFireBall fireBall = null;
            GameObject go = null;

            go = effectFactory.AddObject(OBJECT_TYPE.EFFECTFIREBALLTYPE,spawnPos, target, DelEffect, speed,damage);

            go.TryGetComponent<EffectFireBall>(out fireBall);
            
            effectDataManager.AddEffectFireBall(ref fireBall);
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
        }
        effectFactory.RecycleObject(type, go);
    }
}
