using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

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
        int offset;
        if (index == currentCharacterPosition)
        {
            course = new []{waypoints[currentCharacterPosition]};
        }
        else if (index > currentCharacterPosition)
        { 
            offset = (!characterMovement.isIdle && characterMovement.isAscending) ? 1 : 0;
            course = waypoints[(currentCharacterPosition+offset)..(index+1)];
        }
        else
        {
            offset = (!characterMovement.isIdle && !characterMovement.isAscending) ? 0 : 1;
            course = waypoints[index..(currentCharacterPosition+offset)].Reverse().ToArray();
        }
        
        characterMovement.SetCourse(course);
    }
}
