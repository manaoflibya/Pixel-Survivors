using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FloatingUI : MonoBehaviour
{
    public OBJECT_TYPE myType;
    public Vector3 spawnPos = new Vector3();
    //Color 도 추가해야함.
    public Color myColor = Color.red;
    public int floatingUID = 0;
    public int myValue = 0;

    public Action<OBJECT_TYPE, int, GameObject> action;

    public TextMesh myTextMesh;

    public virtual void OnReset()
    {
        this.transform.position = spawnPos;
        myTextMesh.text = myValue.ToString();
        myTextMesh.color = myColor;
    }
}
