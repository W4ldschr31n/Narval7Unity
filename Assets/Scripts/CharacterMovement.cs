using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterMovement : MonoBehaviour
{
    public Waypoint currentDestination;
    public float speed;
    public Queue<Waypoint> destinations;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        if (currentDestination != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentDestination.transform.position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, currentDestination.transform.position) <= 0.1f)
            {
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
        }
        else
        {
            if (currentDestination != null)
            {
                currentDestination.Interact();
            }
            currentDestination = null;
        }
    }
    
    public void SetCourse(Waypoint[] _destinations)
    {
        destinations = new Queue<Waypoint>(_destinations);
        NextDestination();
    }
}
