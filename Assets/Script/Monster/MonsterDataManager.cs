using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDataManager
{
    public Dictionary<int, Monster> monsterData = new Dictionary<int, Monster>();
    private int monsterUID = -1;

    public MonsterDataManager() 
    {

    }

    
    public void InitData()
    {
        ClearData();
    }

    private void ClearData()
    {
        if(monsterData != null)
        {
            monsterData.Clear();   
        }
    }

    public bool AddMonster(ref Monster newData)
    {
        bool exist = true;

        newData.monsterUID = ++monsterUID;

        if (monsterData.ContainsKey(newData.monsterUID))
        {
            exist = false;
        }
        else
        {

            monsterData.Add(newData.monsterUID, newData);
        }

        return exist;
    }

    public bool DelMonster(int uid)
    {
        bool exist = true;

        if(FindMonster(uid) == null)
        {
            exist = false;
        }
        else
        {
            monsterData.Remove(uid);
        }

        return exist;
    }

    private Monster FindMonster(int uid)
    {
        if(monsterData == null)
        {
            return null;
        }

        if(monsterData.ContainsKey(uid))
        {
            return monsterData[uid];
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// ����ִ� ��� ���͸� ã�Ƽ� Monster List�� ��ȯ�ִ� �Լ�.
    /// </summary>
    /// <param name="activeMonsters"></param>
    /// <returns></returns>
    public List<Monster> FindAllActiveMonsters(ref List<Monster> activeMonsters)
    {
        foreach (var monster in monsterData)
        {
            activeMonsters.Add(monster.Value);
        }

        return activeMonsters;
    }
}
