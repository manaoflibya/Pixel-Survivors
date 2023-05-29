using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingDamageUI : FloatingUI
{

    public override void OnReset()
    {
        base.OnReset();
    }

    private void StopFloatingDamage()
    {
        action?.Invoke(myType, floatingUID, this.gameObject);
    }
}
