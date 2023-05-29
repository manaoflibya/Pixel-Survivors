using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingUIDataManager
{
    public FloatingUIDataManager()
    {

    }

    public Dictionary<int, FloatingUI> floatingUIData = new Dictionary<int, FloatingUI>();

    private int floatingUID = -1;

    private void InitData()
    {
        ClearData();
    }

    private void ClearData()
    {
        if(floatingUIData  != null)
        {
            floatingUIData.Clear();
        }
    }

    public bool AddFloatingUI(ref FloatingUI newData)
    {
        bool exist = true;

        newData.floatingUID = ++floatingUID;

        if(floatingUIData.ContainsKey(newData.floatingUID))
        {
            exist = false;
        }
        else
        {
            floatingUIData.Add(newData.floatingUID, newData);
        }

        return exist;
    }

    public bool DelFloatingUI(int uid)
    {
        bool exist = true;

        if(FindFloatingUI(uid) == null)
        {
            exist = false;
        }
        else
        {
            floatingUIData.Remove(uid);
        }

        return exist;
    }

    public FloatingUI FindFloatingUI(int uid)
    {
        if(floatingUIData == null)
        {
            return null;
        }

        if(floatingUIData.ContainsKey(uid))
        {
            return floatingUIData[uid]; 
        }
        else
        {
            return null;
        }
    }
}
