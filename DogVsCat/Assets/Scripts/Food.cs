using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private void OnEnable()
    {
        transform.localPosition = new Vector3(0, 2, 0);
    }

    private void Update()
    {
        if(transform.position.y > Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y)
            ObjectPool.ReturnObject(this);
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(0.0f, 0.5f, 0.0f);
    }
}
