using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDataManager
{
    public EffectDataManager() 
    {

    }

    public Dictionary<int, EffectFireBall> fireBallData = new Dictionary<int, EffectFireBall>();
    private int fireBallUID = -1;


    private void InitData()
    {
        ClearData();
    }

    public void ClearData()
    {
        if (fireBallData != null)
        {
            fireBallData.Clear();
        }
    }

    public bool AddEffectFireBall(ref EffectFireBall newData)
    {
        bool exist = true;

        newData.fireBallUID = ++fireBallUID;

        if(fireBallData.ContainsKey(newData.fireBallUID))
        {
            exist = false;
        }
        else
        {
            fireBallData.Add(newData.fireBallUID, newData);
        }

        return exist;
    }

    public bool DelEffectFireBall(int fireBallUID)
    {
        bool exist = true;
        if(FindFireBall(fireBallUID) == null)
        {
            exist = false;
        }
        else
        {
            fireBallData.Remove(fireBallUID);
        }

        return exist;
    }

    public EffectFireBall FindFireBall(int fireBallUID)
    {
        if(fireBallData == null)
        {
            return null;
        }

        if(fireBallData.ContainsKey(fireBallUID))
        {
            return fireBallData[fireBallUID];
        }
        else
        {
            return null;
        }
    }
}
