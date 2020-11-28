using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public GameObject MoonObject;
    public float TimeToScroll = 40.0f;
    private float startTime;
    private float StartingY;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        StartingY = transform.position.y;

        sr = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameState.IsPaused())
        {
            var totalToMove = (sr.bounds.size.y) - (sr.size.y);
            var timeSinceStart = Math.Min((Time.time - startTime), TimeToScroll);

            var newPosition = new Vector2(transform.position.x, StartingY - ((totalToMove / TimeToScroll) * timeSinceStart));
            var diffY = newPosition.y - transform.position.y;

            transform.position = newPosition;
            MoonObject.transform.position = new Vector3(MoonObject.transform.position.x, MoonObject.transform.position.y + diffY, transform.position.z);
        }
    }
}

