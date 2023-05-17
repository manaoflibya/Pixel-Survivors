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
    public Dictionary<int, EffectKunai> kunaiData = new Dictionary<int, EffectKunai>();
    public Dictionary<int, EffectPoison> poisonData = new Dictionary<int, EffectPoison>();
    public Dictionary<int, EffectBounceBall> bounceBallData = new Dictionary<int, EffectBounceBall>();

    private int fireBallUID = -1;
    private int magicBoltUID = -1;
    private int kunaiUID = -1;
    private int poisonUID = -1;
    private int bounceBallUID = -1;


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

        if (kunaiData != null)
        {
            kunaiData.Clear();
        }

        if (poisonData != null)
        {
            poisonData.Clear();
        }        
        
        if (bounceBallData != null)
        {
            bounceBallData.Clear();
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

    public bool DelEffectFireBall(int uid)
    {
        bool exist = true;
        if(FindFireBall(uid) == null)
        {
            exist = false;
        }
        else
        {
            fireBallData.Remove(uid);
        }

        return exist;
    }

    public EffectFireBall FindFireBall(int uid)
    {
        if(fireBallData == null)
        {
            return null;
        }

        if(fireBallData.ContainsKey(uid))
        {
            return fireBallData[uid];
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

    public bool DelEffectMagicBolt(int uid)
    {
        bool exist = true;
        if (FindMagicBolt(uid) == null)
        {
            exist = false;
        }
        else
        { 
            magicBoltData.Remove(uid);
        }

        return exist;
    }

    public EffectMagicBolt FindMagicBolt(int uid)
    {
        if (magicBoltData == null)
        {
            return null;
        }

        if (magicBoltData.ContainsKey(uid))
        {
            return magicBoltData[uid];
        }
        else
        {
            return null;
        }
    }
    #endregion

    #region Kunai
    public bool AddEffectKuani(ref EffectKunai newData)
    {
        bool exist = true;

        newData.kunaiUID = ++kunaiUID;

        if (kunaiData.ContainsKey(newData.kunaiUID))
        {
            exist = false;
        }
        else
        {
            kunaiData.Add(newData.kunaiUID, newData);
        }

        return exist;
    }

    public bool DelEffectKuani(int uid)
    {
        bool exist = true;
        if (FindKunai(uid) == null)
        {
            exist = false;
        }
        else
        {
            kunaiData.Remove(uid);
        }

        return exist;
    }

    public EffectKunai FindKunai(int uid)
    {
        if (kunaiData == null)
        {
            return null;
        }

        if (kunaiData.ContainsKey(uid))
        {
            return kunaiData[uid];
        }
        else
        {
            return null;
        }
    }
    #endregion

    #region Poison
    public bool AddEffectPoison(ref EffectPoison newData)
    {
        bool exist = true;

        newData.posionUID = ++poisonUID;

        if (poisonData.ContainsKey(newData.posionUID))
        {
            exist = false;
        }
        else
        {
            poisonData.Add(newData.posionUID, newData);
        }

        return exist;
    }

    public bool DelEffectPoison(int uid)
    {
        bool exist = true;
        if (FindPosion(uid) == null)
        {
            exist = false;
        }
        else
        {
            poisonData.Remove(uid);
        }

        return exist;
    }

    public EffectPoison FindPosion(int uid)
    {
        if (poisonData == null)
        {
            return null;
        }

        if (poisonData.ContainsKey(uid))
        {
            return poisonData[uid];
        }
        else
        {
            return null;
        }
    }
    #endregion

    #region BounceBall
    public bool AddEffectBounceBall(ref EffectBounceBall newData)
    {
        bool exist = true;

        newData.bounceBallUID = ++bounceBallUID;

        if (bounceBallData.ContainsKey(newData.bounceBallUID))
        {
            exist = false;
        }
        else
        {
            bounceBallData.Add(newData.bounceBallUID, newData);
        }

        return exist;
    }

    public bool DelEffectBounceBall(int uid)
    {
        bool exist = true;
        if (FindBounceBall(uid) == null)
        {
            exist = false;
        }
        else
        {
            bounceBallData.Remove(uid);
        }

        return exist;
    }

    public EffectBounceBall FindBounceBall(int uid)
    {
        if (bounceBallData == null)
        {
            return null;
        }

        if (bounceBallData.ContainsKey(uid))
        {
            return bounceBallData[uid];
        }
        else
        {
            return null;
        }
    }
    #endregion
}
