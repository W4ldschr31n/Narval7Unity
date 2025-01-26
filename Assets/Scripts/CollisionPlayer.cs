using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlayer : MonoBehaviour
{
    Respiration GM;

    private void Start()
    {
        GM = FindObjectOfType<Respiration>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Collision");
        if (collision.gameObject.name == "Eau")
        {
            GM.IsInWather = true;
        }
    }
}
