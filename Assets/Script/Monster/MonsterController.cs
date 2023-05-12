using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.TextCore.LowLevel;

public class MonsterController : MonoBehaviour
{
    public MonsterConstant constant;

    private ObjectFactory monsterFactory;
    private MonsterDataManager monsterDataManager;

    private void Awake()
    {
        monsterFactory = new MonsterFactory();
        monsterDataManager = new MonsterDataManager();
    }

    public Vector3 FindClosestMonster()
    {
        Vector3 monsterDir = Vector3.right;
        float distance = float.MaxValue;
        List<Monster> activeMonsters = new List<Monster>();

        //Debug�� ���� �ؾ���.
        Vector3 testVec3 = Vector3.zero;
        //
        

        foreach(var monster in monsterDataManager.FindAllActiveMonsters(ref activeMonsters))
        {
            Vector3 monVec = monster.gameObject.transform.position;
            testVec3 = monVec;
            if (Vector3.Distance(monVec, PlayerController.Instance.GetPlayerVec()) <= distance)
            {
                distance = Vector3.Distance(monVec, PlayerController.Instance.GetPlayerVec());
                monsterDir = monVec - PlayerController.Instance.GetPlayerVec();
            }
        }
        monsterDir.Normalize();

        Debug.DrawLine(PlayerController.Instance.GetPlayerVec(), testVec3, Color.yellow,1f);

        activeMonsters.Clear();

        return monsterDir;
    }

    /// <summary>
    /// ī�޶� ���̴� ������Ʈ �� �������� ������Ʈ �ϳ� ��ȯ
    /// </summary>
    /// <returns></returns>
    public GameObject FindCameraVisibleMonsters()
    {
        GameObject go = null;
        List<Monster> activeMonster = new List<Monster>();
        List<Monster> findVisibleMonsters = new List<Monster>();

        activeMonster = monsterDataManager.FindAllActiveMonsters(ref activeMonster);
        
        if(activeMonster.Count == 0)
        {
            Debug.LogError("Monster List has nothing.");
            return go;
        }

        // ����ִ� ���͸� ���ڷ� �ְ� ���߿��� �ϳ��� ������Ʈ�� ��ȯ.
        findVisibleMonsters = PixelGameManager.Instance.cameraController.GetObjectVisibleInCamera(activeMonster);

        if (findVisibleMonsters == null || findVisibleMonsters.Count == 0)
        {
            return go;
        }

        go = findVisibleMonsters[Random.Range(0, findVisibleMonsters.Count)].gameObject;
        
        return go;
    }

    public void OnSetMonsterBat(int createBatCount)
    {
        for (int i = 0; i < createBatCount; i++)
        {
            MonsterBat bat = null;
            GameObject go = null;
            Vector3 vec = Vector3.zero;

            //Map���� SpawnObject���� �ִµ� �ű� �߿��� �÷��̾�� ������ �Ÿ� Max, Min ���� �ȿ� �ִ� SpawnObject ��ġ�� �����ϱ� ���� Foreach��
            foreach (var data in MapController.Instance.mapData.currentSpawnPoints)
            {
                Vector3 spawnVec = MapController.Instance.mapData.currentSpawnPoints[Random.Range(0, MapController.Instance.mapData.currentSpawnPoints.Length - 1)].transform.position;
                Vector3 playerVec = PlayerController.Instance.GetPlayerVec();
                
                if (Vector3.Distance(spawnVec, playerVec) < constant.MaxDistance && Vector3.Distance(spawnVec, playerVec) > constant.minDistance)
                {
                    vec = spawnVec;
                    break;
                }
            }

            go = monsterFactory.AddObject(OBJECT_TYPE.MONSTERBATTYPE, vec, DeleteMonsterData, constant.batHealth, constant.batSpeed);

            go.TryGetComponent<MonsterBat>(out bat);

            monsterDataManager.AddMonsterBat(ref bat);
        }
    }

    private void DeleteMonsterData(OBJECT_TYPE type, int uid)
    {
        switch (type)
        {
            case OBJECT_TYPE.MONSTERBATTYPE:
                {
                    monsterDataManager.DelMonsterBat(uid);
                }
                break;
        }
    }
}
