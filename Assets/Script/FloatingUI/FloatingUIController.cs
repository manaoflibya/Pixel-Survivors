using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FloatingUIController : MonoBehaviour
{
    private FloatingUIFactory floatingUIFactory;
    private FloatingUIDataManager floatingUIDataManager;

    private void Awake()
    {
        floatingUIFactory = new FloatingUIFactory();
        floatingUIDataManager = new FloatingUIDataManager();    
    }

    public void OnFloatingDamageUI(Vector3 spawnPos,int value)
    {
        FloatingUI floatingUI = null;
        GameObject go = null;
        Color color = Color.red;

        go = floatingUIFactory.AddObject(OBJECT_TYPE.FLOATINGDAMAGETYPE, spawnPos, DelFloatingUI, color, value);
        
        go.TryGetComponent<FloatingUI>(out floatingUI);

        floatingUI.OnReset();

        floatingUIDataManager.AddFloatingUI(ref floatingUI);
    }

    public void OnFloatingHealthUI(Vector3 spawnPos, int value)
    {
        FloatingUI floatingUI = null;
        GameObject go = null;
        Color color = Color.green;

        go = floatingUIFactory.AddObject(OBJECT_TYPE.FLOATINGDAMAGETYPE, spawnPos, DelFloatingUI, color, value);

        go.TryGetComponent<FloatingUI>(out floatingUI);

        floatingUI.OnReset();

        floatingUIDataManager.AddFloatingUI(ref floatingUI);
    }

    private void DelFloatingUI(OBJECT_TYPE myType, int uid, GameObject go)
    {
        switch(myType) 
        {
            case OBJECT_TYPE.FLOATINGDAMAGETYPE:
                {
                    floatingUIDataManager.DelFloatingUI(uid);
                }
                break;
        }

        floatingUIFactory.RecycleObject(myType, go);
    }
}
