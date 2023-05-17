using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectConstant
{
    public float effectCoolTime = 0.5f;
    public float currentCoolTime = 0f;
    public int effectCreateCount = 1;

    public float effectFireBallSpeed = 15f;
    public float effectFireBallDamage = 30f;
    public Vector3 effectFireBallSize = new Vector3(1f, 1f, 1f);

    public float effectMagicBoltSpeed = 5f;
    public float effectMagicBoltDamage = 20f;
    public Vector3 effectMagicBoltSize = new Vector3(2f, 2f, 2f);


    public float kunaiCoolTime = 7f;
    public float kunaiCurrentCoolTime = 5f;
    public int kunaiCreateCount = 2;

    public Vector3 effectKunaiAsix = Vector3.back;
    //public float effectKunaiAngle = 250f;
    public float effectKunaiSpeed = 130f;
    public float effectKunaiAngle = 10f;
    public float effectKunaiDamage = 20f;
    public float effectKunaiDuration = 3.5f;
    public Vector3 effectKunaiSize = new Vector3(2f, 2f, 2f);
}
