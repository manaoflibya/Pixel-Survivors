using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraData : MonoBehaviour
{
    public Camera playGameCamera;
    public Plane[] planes = null;
    public Collider2D collider2d;
    public string cameraTagName = "MainCamera";

    // 카메라에 보이는 Monster전용 List
    public List<GameObject> cameraCheckGo = new List<GameObject>();
}
