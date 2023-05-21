using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataManager
{
    public Dictionary<int, ItemEXP> expData = new Dictionary<int, ItemEXP>();
    private int expUID = -1;

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
    #endregion
}
