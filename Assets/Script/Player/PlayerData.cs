using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public GameObject playerGo;
    public Animator playerAnimator;

    //Player Animation
    public string playerWalkAnimationName = "Walk";
    // ���¸� ������ �� ���������� Ŭ�������� OnExit�� ���İ����� Ȯ���ϱ� ���ؼ� ���
    public bool checkClassOnExix;

    private bool allowMove;
    public bool AllowMove
    {
        get { return allowMove; } 
        set { allowMove = value; }
    }

    [SerializeField]
    private float speed = 1.5f;
    public float Speed
    {
        get { return speed; } 
        set { this.speed = value; } 
    }



}
