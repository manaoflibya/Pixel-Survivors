using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterConstant : MonoBehaviour
{
    // 어느 정도 거리에서 생성(max와 min사이에서 생성을 해야함)
    [HideInInspector]
    public float MaxDistance = 8f;
    [HideInInspector]
    public float minDistance = 5f;
    // 몇마리 생성?
    [HideInInspector]
    public int batCreateCount = 100; 
    [HideInInspector]
    public float batDamage = 2f;

    [HideInInspector]
    public float batHealth = 100f;
    [HideInInspector]
    public float batSpeed = 1.5f;
    [HideInInspector]
    public Vector3 batSize = new Vector3(1f, 1f, 1f);
    //플레이어와 최소거리
    [HideInInspector]
    public float monsterMinDistance = (float)decimal.MinValue;




    [HideInInspector]
    public string monsterTagName = "Monster";

}
