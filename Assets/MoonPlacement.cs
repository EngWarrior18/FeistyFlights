using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonPlacement : MonoBehaviour
{
    public GameObject moonPrefab;
    public float respawnTime = 1.0f;
    public float timeBeforeSpeedUp = 0.0f;
    public float speedUpPercentage = 0.0f;

    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(moonWave());
    }
    private void spawnEnemy()
    {
        if (!GameState.IsPaused())
        {
            GameObject a = Instantiate(moonPrefab) as GameObject;
            a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y);
        }
    }

    IEnumerator moonWave() 
    {
        var currentSpeed = respawnTime;
        var timePassed = 0.0f;

        while (true)
        {
            yield return new WaitForSeconds(currentSpeed);

            timePassed += currentSpeed;

            if (timePassed > timeBeforeSpeedUp)
            {
                timePassed -= timeBeforeSpeedUp;
                currentSpeed = currentSpeed * (1.0f - speedUpPercentage);
            }
            spawnEnemy();
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
