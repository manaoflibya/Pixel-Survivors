using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public CameraData cameraData;

    public void InitCameraController()
    {

    }

    public List<Monster> GetObjectVisibleInCamera(List<Monster> objects)
    {
        if (objects == null || objects.Count == 0)
        {
            return null;
        }

        List<Monster> activeMonsters = new List<Monster>();

        foreach (var go in objects)
        {
            var bounds = go.GetComponent<CapsuleCollider2D>().bounds;
            cameraData.planes = GeometryUtility.CalculateFrustumPlanes(cameraData.playGameCamera);

            if (GeometryUtility.TestPlanesAABB(cameraData.planes, bounds))
            {
                activeMonsters.Add(go);
            }
        }

        return activeMonsters;
    }

    private void OnDisable()
    {
        CheckObjectListClear();
    }

    private void CheckObjectListClear()
    {
        cameraData.cameraCheckGo.Clear();
    }
}
