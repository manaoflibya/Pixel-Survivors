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
    // ���¸� ������ �� ���������� Ŭ�������� OnExit�� ���İ����� Ȯ���ϱ� ���ؼ� ���
    public bool checkClassOnExix;
    public string playerTagName = "Player";


    private bool allowMove;
    public bool AllowMove
    {
        get { return allowMove; } 
        set { allowMove = value; }
    }

    private float speed = 1.5f;
    public float Speed
    {
        get { return speed; } 
        set { this.speed = value; } 
    }

    private float health;
    public float Health
    {
        get { return health; }
        set { this.health = value; }
    }

    public float playerSize = 0.5f;

    public Vector3 playerVec = new Vector3 (0, 0, 0);
}
