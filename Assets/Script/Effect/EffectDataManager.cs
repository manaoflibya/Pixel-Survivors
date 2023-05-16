using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDataManager
{
    public EffectDataManager() 
    {

    }

    public Dictionary<int, EffectFireBall> fireBallData = new Dictionary<int, EffectFireBall>();
    public Dictionary<int, EffectMagicBolt> magicBoltData = new Dictionary<int, EffectMagicBolt>();
    private int fireBallUID = -1;
    private int magicBoltUID = -1;

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

        if(magicBoltData != null)
        {
            magicBoltData.Clear();
        }
    }

    #region FireBall
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
    #endregion

    #region MagicBolt
    public bool AddEffectMagicBolt(ref EffectMagicBolt newData)
    {
        bool exist = true;

        newData.magicBoltUID = ++magicBoltUID;

        if (magicBoltData.ContainsKey(newData.magicBoltUID))
        {
            exist = false;
        }
        else
        {
            magicBoltData.Add(newData.magicBoltUID, newData);
        }

        return exist;
    }

    public bool DelEffectMagicBolt(int magicBoltUID)
    {
        bool exist = true;
        if (FindMagicBolt(magicBoltUID) == null)
        {
            exist = false;
        }
        else
        { 
            magicBoltData.Remove(magicBoltUID);
        }

        return exist;
    }

    public EffectMagicBolt FindMagicBolt(int magicBoltUID)
    {
        if (magicBoltData == null)
        {
            return null;
        }

        if (magicBoltData.ContainsKey(magicBoltUID))
        {
            return magicBoltData[magicBoltUID];
        }
        else
        {
            return null;
        }
    }
    #endregion 

}
