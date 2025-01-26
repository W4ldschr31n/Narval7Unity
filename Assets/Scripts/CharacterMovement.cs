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
    public Animator animator;
    public Transform rig;
    public bool canMove;
    
    // Start is called before the first frame update
    void Start()
    {
        isIdle = true;
        canMove = true;
        animator = GetComponent<Animator>();
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
        animator.SetBool("walking", !isIdle);
        if(currentDestination != null)
            isAscending = currentDestination.transform.position.x > transform.position.x;
        rig.localScale = new Vector3(isAscending ? 1f:-1f, 1f, 1f);
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
        if(!canMove)
            return;
        destinations = new Queue<Waypoint>(_destinations);
        NextDestination();
    }
}
