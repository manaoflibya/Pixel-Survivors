using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public GameObject playerGo;
    public Animator playerAnimator;

    //Player Animation
    public string playerWalkAnimationName = "Walk";
    // 상태를 변경할 때 빠져나가는 클래스에서 OnExit를 거쳐갔는지 확인하기 위해서 사용
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
