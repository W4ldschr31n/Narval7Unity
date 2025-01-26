using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterMovement : MonoBehaviour
{
    public Waypoint currentDestination;
    public float speed;
    public Queue<Waypoint> destinations;
    public bool isIdle;
    public bool isAscending;
    
    // Start is called before the first frame update
    void Start()
    {
        isIdle = true;
    }



    // Update is called once per frame
    void Update()
    {
        if (currentDestination != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentDestination.transform.position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, currentDestination.transform.position) <= 0.01f)
            {
                transform.position = currentDestination.transform.position;
                currentDestination.PlayerWalks();
                NextDestination();
            }
        }
    }

    public void NextDestination()
    {
        if (destinations.Count > 0)
        {
            currentDestination = destinations.Dequeue();
            isIdle = false;
        }
        else
        {
            if (currentDestination != null)
            {
                currentDestination.Interact();
            }
            currentDestination = null;
            isIdle = true;
        }
    }
    
    public void SetCourse(Waypoint[] _destinations)
    {
        destinations = new Queue<Waypoint>(_destinations);
        NextDestination();
    }
}
