using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : EventAbstractClass
{



    [SerializeField] bool blocked = false;
    // Start is called before the first frame update
    void Start()
    {
        state = EventState.active;
        Speed = 0.03f;
        CountDownTime = 3f;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        switch (state)
        {
            case EventState.active:
                EventActive();
                break;
            case EventState.ending:
                MoveBack();
               
                break;
              
        }
            

       

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DoorTrigger"))
        {
            Debug.Log("Door Trigger!");
            blocked = true;
        }
    }
    protected override void EventActive()
    {
        if (!blocked)
        {
            transform.Translate(new Vector3(0f, 0f, Speed));
        }
        else
        {
            LevelManager.Instance.PoopLevelUp();
        }
        
    }
    protected override void MoveBack()
    {
        blocked = false;
        transform.Translate(new Vector3(0f, 0f, -Speed));
        CountDownTime -= Time.deltaTime;
        if (CountDownTime < 0)
        {
            Debug.Log("Go to toilet");
            state = EventState.active;
            CountDownTime = 3f;
        }
    }
}
