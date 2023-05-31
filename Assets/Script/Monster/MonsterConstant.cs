using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterConstant
{
    public MonsterConstant() { }


    // ��� ���� �Ÿ����� ����(max�� min���̿��� ������ �ؾ���)
    public float MaxDistance = 8f;
    public float minDistance = 5f;

    //�÷��̾�� �ּҰŸ�
    public float monsterMinDistance = (float)decimal.MinValue;

    // Monster bat
    public int monsterBatCreateCount = 5;
    public float monsterBatMaxHealth = 100f;
    public float monsterBatDamage = 2f;
    public float monsterBatSpeed = 2.5f;
    public Vector3 monsterBatSize = new Vector3(1f, 1f, 1f);

    // Monster Skeleton
    public int monsterSkeletonCreateCount = 5;
    public float monsterSkeletonMaxHealth = 150f;
    public float monsterSkeletonDamage = 3f;
    public float monsterSkeletonSpeed = 1.5f;
    public Vector3 monsterSkeletonSize = new Vector3(1f, 1f, 1f);

    // Monster Goblin
    public int monsterGoblinCreateCount = 5;
    public float mosnterGoblinMaxHealth = 180f;
    public float monsterGoblinDamage = 4f;
    public float monsterGoblinSpeed = 1.8f;
    public Vector3 monsterGoblinSize = new Vector3(1f, 1f, 1f);

    // Monster Boomber
    public int monsterBoomberCreateCount = 5;
    public float monsterBoomberMaxHealth = 80f;
    public float monsterBoomberDamage = 4f;
    public float monsterBoomberExploDamage = 20f;
    public float monsterBoomberSpeed = 2.5f;
    public Vector3 monsterBoomberSize = new Vector3(1f, 1f, 1f);


    public float currentCraeteTime = 0f;
    public float createTime = 4f;

    public float healPoint = 20f;

    public float monsterExpPoint = 10f;
    public float monsterExpPointMiddle = 30f;
    public float monsterExpPointBIG = 50f;

    [HideInInspector]
    public string monsterTagName = "Monster";
}
