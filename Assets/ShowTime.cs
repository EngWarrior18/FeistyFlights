using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTime : MonoBehaviour
{
    private TextMesh textMesh;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameState.IsPaused())
            DisplayTime(Time.timeSinceLevelLoad);
        else
            DisplayTime(GameState.TimePaused());
    }

    private void DisplayTime(float time)
    {
        int d = (int)(time * 100.0f);
        int Bminutes = d / (60 * 100);
        int Bseconds = (d % (60 * 100)) / 100;
        int Bmilliseconds = d % 100;

        string niceTime = string.Format("{0:00}:{1:00}:{2:00}", Bminutes, Bseconds, Bmilliseconds);
        textMesh.text = niceTime;
    }
}
