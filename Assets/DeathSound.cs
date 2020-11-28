using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathSound : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D other)
    {
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
    