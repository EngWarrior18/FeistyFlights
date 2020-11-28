using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour

{
    public GameObject WinText;
    public float TimeToWin = 40.0f;
    public float TimeToShowText = 5.0f;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(Win());
    }
    private void ShowText()
    {
        WinText.SetActive(true);
        GameState.PauseGame(Time.timeSinceLevelLoad);
    }

    IEnumerator Win()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimeToWin);
            ShowText();

            yield return new WaitForSeconds(TimeToShowText);
            RestartScene();
        }
    }

    public void RestartScene()
    {
        GameState.UnpauseGame();
        SceneManager.LoadScene("Menu");
    }
}
