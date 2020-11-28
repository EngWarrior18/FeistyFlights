using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseDeath : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    public float TimeToDie = 2.0f;

    private float startTime;
    private bool mouseOver;

    private bool mouseWasOutsideViewLastUpdate;
    private float mouseFirstOutsideView;
    private bool playerDeathStarted;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Input.mousePosition;
        if (mousePos.x < 0 ||
            mousePos.x > Screen.width ||
            mousePos.y < 0 ||
            mousePos.y > Screen.height)
        {
            if (mouseWasOutsideViewLastUpdate)
            {
                if (Time.time - mouseFirstOutsideView > TimeToDie)
                {
                    StartPlayerDeath();
                }
            }
            else
            {
                mouseWasOutsideViewLastUpdate = true;
                mouseFirstOutsideView = Time.time;
            }
        }
        else
        {
            mouseWasOutsideViewLastUpdate = false;
            mouseFirstOutsideView = 0;
        }
    }

    void OnMouseOver()
    {
        if (mouseOver)
        {
            var timeOver = Time.time - startTime;
            if (timeOver >= TimeToDie)
            {
                StartPlayerDeath();
            }
        }
        else
        {
            
            startTime = Time.time;
            mouseOver = true;

        }
    }

    void OnMouseExit()
    {
        mouseOver = false;
    }

    private void StartPlayerDeath()
    {
        if (playerDeathStarted)
            return;

        playerDeathStarted = true;
        GameState.PauseGame(Time.timeSinceLevelLoad);

        audioSource.PlayOneShot(audioClip);
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(audioClip.length);

        GameState.UnpauseGame();
        SceneManager.LoadScene("Menu");
    }
}
