using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectKunai : Effect
{
    public int kunaiUID;


    private void Start()
    {
        this.transform.position = spawnPos;
    }


}
