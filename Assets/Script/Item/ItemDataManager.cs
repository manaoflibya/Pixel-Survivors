using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataManager
{
    public Dictionary<int, ItemEXP> expData = new Dictionary<int, ItemEXP>();
    public Dictionary<int, ItemGravity> gravityData = new Dictionary<int, ItemGravity>();
    private int expUID = -1;
    private int gravityUID = -1;

    public ItemDataManager()
    {
    }

    public void InitData()
    {
        ClearData();
    }

    private void ClearData()
    {
        if (expData != null)
        {
            expData.Clear();
        }
        
        if(gravityData != null)
        {
            gravityData.Clear();
        }
    }

    #region EXP
    public bool AddExp(ref ItemEXP newData)
    {
        bool exist = true;

        newData.expUID = ++expUID;

        if(expData.ContainsKey(newData.expUID))
        {
            exist = false;
        }
        else
        {
            expData.Add(newData.expUID, newData);
        }

        return exist;
    }

    public bool DelExp(int uid)
    {
        bool exist = true;

        if(FindExp(uid) == null)
        {
            exist = false;
        }
        else
        {
            expData.Remove(uid);
        }

        return exist;
    }

    private ItemEXP FindExp(int uid)
    {
        if(expData == null)
        {
            return null;
        }

        if(expData.ContainsKey(uid))
        {
            return expData[uid];
        }
        else
        {
            return null;
        }
    }

    public List<ItemEXP> FindAllActiveEXP(ref List<ItemEXP> activeExp)
    {
        foreach(var item in expData)
        {
            activeExp.Add(item.Value);
        }

        return activeExp;
    }
    #endregion

    #region Gravity
    public bool AddGravity(ref ItemGravity newData)
    {
        bool exist = true;

        newData.gravityUID = ++gravityUID;

        if (gravityData.ContainsKey(newData.gravityUID))
        {
            exist = false;
        }
        else
        {
            gravityData.Add(newData.gravityUID, newData);
        }

        return exist;
    }

    public bool DelGravity(int uid)
    {
        bool exist = true;

        if (FindGravity(uid) == null)
        {
            exist = false;
        }
        else
        {
            gravityData.Remove(uid);
        }

        return exist;
    }

    private ItemGravity FindGravity(int uid)
    {
        if (gravityData == null)
        {
            return null;
        }

        if (gravityData.ContainsKey(uid))
        {
            return gravityData[uid];
        }
        else
        {
            return null;
        }
    }
    #endregion
}
