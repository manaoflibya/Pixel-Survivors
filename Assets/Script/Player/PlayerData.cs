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
    public string playerWinAnimationName = "Win";
    // ���¸� ������ �� ���������� Ŭ�������� OnExit�� ���İ����� Ȯ���ϱ� ���ؼ� ���
    public bool checkClassOnExit;
    public string playerTagName = "Player";
    
    public Sprite effectFireBallSprite;
    public Sprite effectPoisonSprite;
    public Sprite effectMagicBoltSprite;
    public Sprite effectKunaiSprite;
    public Sprite effectBounceBallSprite;
    public Sprite effectBatManSprite;

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

    private float maxhealth = 400f;
    public float MaxHealth
    {
        get { return maxhealth; }
    }

    private float health = 0f;
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

    private float playerMaxEXP = 200f;
    public float PlayerMaxEXP
    {
        get { return this.playerMaxEXP; }
        set { this.playerMaxEXP = value; }
    }

    private float playerEXP = 0f;
    public float PlayerEXP
    {
        get { return this.playerEXP; }
        set { this.playerEXP = value; }
    }

    public float playerSize = 0.5f;
    public float expIncreaseValue = 50f;

    public Vector3 playerVec = new Vector3 (0, 0, 0);
}
