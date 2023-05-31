using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private MonsterConstant monsterConstant;
    private MonsterFactory monsterFactory;
    private MonsterDataManager monsterDataManager;


    private void Awake()
    {
        monsterConstant = new MonsterConstant();
        monsterFactory = new MonsterFactory();
        monsterDataManager = new MonsterDataManager();
    }

    public Vector3 FindClosestMonster()
    {
        Vector3 monsterDir = Vector3.right;
        float distance = float.MaxValue;
        List<Monster> activeMonsters = new List<Monster>();

        //Debug용 삭제 해야함.
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
    /// 카메라에 보이는 오브젝트 중 램덤으로 오브젝트 하나 반환
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
            //Debug.LogError("Monster List has nothing.");
            return go;
        }

        // 살아있는 몬스터를 인자로 넣고 그중에서 하나의 오브젝트를 반환.
        findVisibleMonsters = PixelGameManager.Instance.cameraController.GetObjectVisibleInCamera(activeMonster);

        if (findVisibleMonsters == null || findVisibleMonsters.Count == 0)
        {
            return go;
        }

        go = findVisibleMonsters[Random.Range(0, findVisibleMonsters.Count)].gameObject;
        
        return go;
    }


    public void OnMonster(int createCount, OBJECT_TYPE type, float health, float damage, float speed, Vector3 size, float expPoint)
    {
        for (int i = 0; i < createCount; i++)
        {
            Monster monster = null;
            GameObject go = null;
            Vector3 vec = Vector3.zero;

            foreach (var data in MapController.Instance.GetcurrentSpawnPoints())
            {
                Vector3 spawnVec = MapController.Instance.GetcurrentSpawnPoints()[Random.Range(0, MapController.Instance.GetcurrentSpawnPoints().Length)].transform.position;
                Vector3 playerVec = PlayerController.Instance.GetPlayerVec();

                if (Vector3.Distance(spawnVec, playerVec) < monsterConstant.MaxDistance && Vector3.Distance(spawnVec, playerVec) > monsterConstant.minDistance)
                {
                    vec = spawnVec;
                    break;
                }
            }

            if(vec == Vector3.zero)
            {
                vec = MapController.Instance.GetcurrentSpawnPoints()[Random.Range(0, MapController.Instance.GetcurrentSpawnPoints().Length)].transform.position;
            }

            go = monsterFactory.AddObject(type, vec, PlayerController.Instance.GetPlayerObject(), DeleteMonsterData, health, damage, speed, size, PixelGameManager.Instance.itemController.OnItemEXP,expPoint);

            go.TryGetComponent<Monster>(out monster);

            monster.OnReset();

            monsterDataManager.AddMonster(ref monster);

        }
    }

    public MonsterConstant GetMonsterConstant()
    {
        return monsterConstant;
    }

    public void DeleteAllMonsters()
    {
        List<Monster> monsters = new List<Monster>();
        
        monsterDataManager.FindAllActiveMonsters(ref monsters);

        foreach (Monster monster in monsters)
        {
            monster.AllDead();
        }
    }

    private void DeleteMonsterData(OBJECT_TYPE type, int uid, GameObject go)
    {
        bool complete = monsterDataManager.DelMonster(uid);

        if(complete.Equals(true))
        {
            monsterFactory.RecycleObject(type, go);
        }
        else
        {
            Debug.Log($" Monster object delete failed -> ObjectType:{type}, uid:{uid}, go:{go}");
        }
    }
}
