using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HIghScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var textMesh = GetComponent<TextMesh>();
        textMesh.text = "High Score: " + GetDisplayTime(GameState.HighScore());
    }
    private string GetDisplayTime(float time)
    {
        int d = (int)(time * 100.0f);
        int Bminutes = d / (60 * 100);
        int Bseconds = (d % (60 * 100)) / 100;
        int Bmilliseconds = d % 100;

        return string.Format("{0:00}:{1:00}:{2:00}", Bminutes, Bseconds, Bmilliseconds);
    }
}
