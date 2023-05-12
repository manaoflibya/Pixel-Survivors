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

    public void OnEffectFireBall(int createCount,Vector3 spawnPos, GameObject target, float speed, float damage)
    {
        for(int i = 0; i < createCount; i++)
        {
            EffectFireBall fireBall = null;
            GameObject go = null;

            go = effectFactory.AddObject(OBJECT_TYPE.EFFECTFIREBALLTYPE,spawnPos, target, speed,damage);

            go.TryGetComponent<EffectFireBall>(out fireBall);
            
            effectDataManager.AddEffectFireBall(ref fireBall);
        }
    }
    //public void OnEffectFireBall(int createCount, Vector3 spawnPos, Vector3 dir, float speed, float damage)
    //{
    //    for (int i = 0; i < createCount; i++)
    //    {
    //        EffectFireBall fireBall = null;
    //        GameObject go = null;

    //        dir.Normalize();

    //        go = effectFactory.AddObject(OBJECT_TYPE.EFFECTFIREBALLTYPE, spawnPos, dir, speed, damage);

    //        go.TryGetComponent<EffectFireBall>(out fireBall);

    //        effectDataManager.AddEffectFireBall(ref fireBall);
    //    }
    //}
}
