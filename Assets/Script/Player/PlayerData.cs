using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public GameObject playerGo;
    public GameObject scaleGo;
    public Animator playerAnimator;

    //Player Animation
    public string playerWalkAnimationName = "Walk";
    public string playerDeadAnimationName = "Dead";
    // ���¸� ������ �� ���������� Ŭ�������� OnExit�� ���İ����� Ȯ���ϱ� ���ؼ� ���
    public bool checkClassOnExit;
    public string playerTagName = "Player";


    private bool allowMove;
    public bool AllowMove
    {
        get { return allowMove; } 
        set { allowMove = value; }
    }

    private float speed = 3f;
    public float Speed
    {
        get { return speed; } 
        set { this.speed = value; } 
    }

    private float health = 100f;
    public float Health
    {
        get { return health; }
        set { this.health = value; }
    }

    private bool playerDead = false;
    public bool PlayerDead
    {
        get { return playerDead; }
        set { this.playerDead = value; }
    }

    public float playerSize = 0.5f;

    public Vector3 playerVec = new Vector3 (0, 0, 0);
}
