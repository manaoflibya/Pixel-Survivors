using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDataManager
{
    //public Dictionary<int, Monster> acitveMonsterData = new Dictionary<int, Monster>();
    //private int monsterUID = -1;
    public Dictionary<int, Monster> batData = new Dictionary<int, Monster>();
    private int batUID = -1;

    public MonsterDataManager() 
    {
        InitData();
    }
    
    private void InitData()
    {
        ClearBatData();
    }


    private void ClearBatData()
    {
        if(batData != null)
        {
            batData.Clear();   
        }
    }

    public bool AddMonsterBat(ref MonsterBat newData)
    {
        bool exist = true; 

        newData.batUID = ++batUID;

        if (batData.ContainsKey(newData.batUID))
        {
            exist = false;
        }
        else
        {
            batData.Add(newData.batUID, newData);
        }

        return exist;
    }

    public bool DelMonsterBat(int batUID)
    {
        bool exist = true;

        if(FindBat(batUID) == null)
        {
            exist = false;
        }
        else
        {
            batData.Remove(batUID);
        }
        
        return exist;
    }

    private MonsterBat FindBat(int batUID)
    {
        if(batData == null)
        {
            return null;
        }

        if(batData.ContainsKey(batUID))
        {
            return (MonsterBat)batData[batUID];
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// 살아있는 모든 몬스터를 찾아서 Monster List로 반환주는 함수.
    /// </summary>
    /// <param name="activeMonsters"></param>
    /// <returns></returns>
    public List<Monster> FindAllActiveMonsters(ref List<Monster> activeMonsters)
    {
        foreach (var monster in batData)
        {
            activeMonsters.Add(monster.Value);
        }

        return activeMonsters;
    }
}
