using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pathway : MonoBehaviour
{
    public Transform[] waypoints;
    public CharacterMovement characterMovement;

    private void Awake()
    {
        waypoints = transform.Cast<Transform>().ToArray();;
        characterMovement = FindObjectOfType<CharacterMovement>();
    }

    void Start()
    {
        characterMovement.SetCourse(waypoints);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
