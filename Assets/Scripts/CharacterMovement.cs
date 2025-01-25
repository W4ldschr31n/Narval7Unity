using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterMovement : MonoBehaviour
{
    public Transform currentDestination;
    public float speed;
    public Queue<Transform> destinations;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        if (currentDestination != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentDestination.position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, currentDestination.position) <= 0.1f)
            {
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
            currentDestination = null;
        }
    }
    
    public void SetCourse(Transform[] _destinations)
    {
        destinations = new Queue<Transform>(_destinations);
        NextDestination();
    }
}
