using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectConstant
{
    public EffectConstant()
    {

    }

    public float effectCoolTime = 0.5f;
    public float currentCoolTime = 0f;
    public int effectCreateCount = 1;

    // fireBall
    public float effectFireBallSpeed = 15f;
    public float effectFireBallDamage = 30f;
    public Vector3 effectFireBallSize = new Vector3(1f, 1f, 1f);

    // magicbolt
    public float effectMagicBoltSpeed = 5f;
    public float effectMagicBoltDamage = 20f;
    public Vector3 effectMagicBoltSize = new Vector3(2f, 2f, 2f);

    // kunai
    public float kunaiCoolTime = 6f;
    public float kunaiCurrentCoolTime = 5f;
    public int kunaiCreateCount = 2;

    public Vector3 effectKunaiAsix = Vector3.back;
    public float effectKunaiSpeed = 130f;
    public float effectKunaiAngle = 10f;
    public float effectKunaiDamage = 20f;
    public float effectKunaiDuration = 4f;
    public Vector3 effectKunaiSize = new Vector3(2f, 2f, 2f);

    // poison
    public float poisonCoolTime = 4f;
    public float poisonCurrentCoolTime = 0f;
    public int poisonCreateCount = 5;

    public Vector3 effectPoisondir = Vector3.back;
    public float effectPoisonSpeed = 2f;
    public float effectPoisonAngle = 10f;
    public float effectPoisonDamage = 10f;
    public float effectPoisonDuration = 3f;
    public Vector3 effectPoisonSize = new Vector3(1.5f, 1.5f, 1.5f);

    // BounceBall
    public float bounceBallCoolTime = 0.5f;
    public float bounceBallCurrentCoolTime = 0f;
    public int bounceCreateCount = 1;

    public float effectBounceBallSpeed = 5f;
    public float effectBounceBallDamage = 25f;
    public float effectBounceBallDuration = 2f;
    public Vector3 effectBounceBallSize = new Vector3(2f,2f,2f);

    // BatMan
    public float batmanCoolTime = 1f;
    public float batManCurrentCoolTime = 0f;
    public int batManCreateCount = 1;
    public int batManHitCount = 3;
    public float effectBatManSpeed = 5f;
    public float effectBatManDamage = 30f;
    public Vector3 effectBatManSize = new Vector3(1.5f, 1.5f, 1.5f);
}
