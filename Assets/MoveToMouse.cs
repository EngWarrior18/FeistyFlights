using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class MoveToMouse : MonoBehaviour
{
    public float speed;
    public float rotationOffset;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameState.IsPaused())
        {
            var mousePosx = Input.mousePosition.x;
            var mousePosy = Input.mousePosition.y;
            
            if (mousePosx < 0.0f)
            {
                mousePosx = 0.0f;
            }
            if (mousePosy < 0.0f)
            {
                mousePosy = 0.0f;
            }
            if (mousePosx > Screen.width)
            {
                mousePosx = Screen.width;
            }
            if (mousePosy > Screen.height)
            {
                mousePosy = Screen.height;
            }
          
            var mousePos = new Vector3(mousePosx, mousePosy, 0);
            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + rotationOffset));
            var ActualmousePos = new Vector3(mousePosx, mousePosy, 0);
            Vector3 targetPos = Camera.main.ScreenToWorldPoint(ActualmousePos);
            targetPos.z = transform.position.z;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        }
    }
}