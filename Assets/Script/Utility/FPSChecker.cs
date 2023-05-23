using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSChecker : MonoBehaviour
{
    private float deltaTime = 0.0f;
    private GUIStyle guiStyle = null;
    private Rect rect;
    private Rect rectfortimeCheck;
    private float millisecond = 0.0f;
    private float fps = 0.0f;
    private float worstFps = 500.0f;
    private string text;
    private string textforTimecheck;
    private float timer = 0f;

    private void Awake()
    {
        int w = Screen.width, h = Screen.height;
        rect = new Rect(0, 0, w, h * 4 / 100);
        rectfortimeCheck = new Rect(w / 2f, 0, w, h);
        guiStyle = new GUIStyle();
        guiStyle.alignment = TextAnchor.UpperLeft;
        guiStyle.fontSize = h * 4 / 100;
        guiStyle.normal.textColor = Color.magenta;
        StartCoroutine(WorstFpsReset());
    }
    private void Start()
    {
        Application.targetFrameRate = 120;
    }
    IEnumerator WorstFpsReset()
    {
        while (true)
        {
            yield return new WaitForSeconds(5.0f);
            worstFps = 500.0f;
        }
    }

    private void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        timer += Time.deltaTime;
    }

    private void OnGUI()
    {
        millisecond = deltaTime * 1000.0f;

        fps = 1.0f / deltaTime;

        if (fps < worstFps)
            worstFps = fps;

        text = millisecond.ToString("F1") + "ms (" + fps.ToString("F1") + ") \nWorst FPS: " + worstFps.ToString("F1");
        GUI.Label(rect, text, guiStyle);
        int currentTime = (int)timer;
        textforTimecheck = "TIME : " + currentTime.ToString();
        GUI.Label(rectfortimeCheck, textforTimecheck, guiStyle);
    }
}
