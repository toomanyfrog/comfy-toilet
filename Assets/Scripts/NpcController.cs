using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : EventAbstractClass
{
    
   

    
    // Start is called before the first frame update
    void Start()
    {
        state = EventState.idle;
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
    protected override void EventActive()
    {
        transform.Translate(new Vector3(0f,0f,Speed));
    }
    protected override void MoveBack()
    {
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
