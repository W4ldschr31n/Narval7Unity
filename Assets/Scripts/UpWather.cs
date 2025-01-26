using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpWather : MonoBehaviour
{

    public int speedWather;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0)
        {
            transform.Translate(Vector2.up * speedWather * Time.deltaTime);
        }
    }
}
