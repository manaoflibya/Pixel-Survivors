using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterConstant : MonoBehaviour
{
    // ��� ���� �Ÿ����� ����(max�� min���̿��� ������ �ؾ���)
    [HideInInspector]
    public float MaxDistance = 8f;
    [HideInInspector]
    public float minDistance = 5f;
    // ��� ����?
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
    //�÷��̾�� �ּҰŸ�
    [HideInInspector]
    public float monsterMinDistance = (float)decimal.MinValue;




    [HideInInspector]
    public string monsterTagName = "Monster";

}
