using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float x = mousePos.x;
        if(x > Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x)
            x = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        else if (x < -Camera.main.ScreenToWorldPoint(new Vector3(Screen.width , 0, 0)).x)
            x = -Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        transform.position = new Vector3(x, transform.position.y, 0);
    }
}
