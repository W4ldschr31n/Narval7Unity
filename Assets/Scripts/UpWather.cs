using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpWather : MonoBehaviour
{
    Respiration GM;
    public int speedWather;

    private void Start()
    {
        GM = FindObjectOfType<Respiration>();
    }
    void Update()
    {
        if (transform.position.y < 0)
        {
            transform.Translate(Vector2.up * speedWather * Time.deltaTime);
        }
        else
        {
            GM.IsInWather = true;
        }

    }
}
