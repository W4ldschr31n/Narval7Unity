using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pathway : MonoBehaviour
{
    public Waypoint[] waypoints;
    public CharacterMovement characterMovement;
    public int currentCharacterPosition;

    private void Awake()
    {
        waypoints = new Waypoint[transform.childCount];
        int i = 0;
        foreach (Waypoint wp in GetComponentsInChildren<Waypoint>())
        {
            wp.index = i;
            waypoints[i] = wp;
            i++;
        }
        characterMovement = FindObjectOfType<CharacterMovement>();
    }

    void Start()
    {
               
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveCharacter(int index)
    {
        if (index >= waypoints.Length || index < 0)
        {
            Debug.Log("Waypoint index is out of range");
            return;
        }

        Waypoint[] course;
        if (index == currentCharacterPosition)
        {
            course = new []{waypoints[currentCharacterPosition]};
        }
        else if (index > currentCharacterPosition)
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
