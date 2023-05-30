using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData : MonoBehaviour
{
    public Map[] maps;

    public Vector3 initLeftPos;
    public Vector3 initCenterPos;
    public Vector3 initRightPos;


    [HideInInspector]
    public string center = "Center";
    [HideInInspector]
    public string left = "Left";
    [HideInInspector]
    public string right = "Right";
}
