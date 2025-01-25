using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pathway : MonoBehaviour
{
    public Transform[] waypoints;
    public CharacterMovement characterMovement;
    public int currentCharacterPosition;

    private void Awake()
    {
        waypoints = transform.Cast<Transform>().ToArray();;
        characterMovement = FindObjectOfType<CharacterMovement>();
    }

    void Start()
    {
        MoveCharacter(0);        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            currentCharacterPosition = 0;
            MoveCharacter(2);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            currentCharacterPosition = 2;
            MoveCharacter(0);
        }
    }

    public void MoveCharacter(int index)
    {
        if (index >= waypoints.Length || index < 0)
        {
            Debug.Log("Waypoint index is out of range");
            return;
        }

        if (index == currentCharacterPosition)
        {
            return;
        }
        
        Transform[] course;
        if (index > currentCharacterPosition)
        {
             course = waypoints[currentCharacterPosition..(index+1)];
        }
        else
        {
            course = waypoints[index..(currentCharacterPosition+1)].Reverse().ToArray();
        }
        
        characterMovement.SetCourse(course);
    }
}
