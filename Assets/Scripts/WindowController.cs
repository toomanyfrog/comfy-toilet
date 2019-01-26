using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : EventAbstractClass
{
    // Start is called before the first frame update
    void Start()
    {
        Speed =1f;
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
        if (transform.rotation.eulerAngles.y < 90f)
        {
            Debug.Log(transform.rotation.eulerAngles.y);
            transform.Rotate(transform.up, Speed);
        }
        else
        {
            LevelManager.Instance.PoopLevelUp();
        }
        
        
    }

    protected override void MoveBack()
    {
        if (transform.rotation.eulerAngles.y > 0f)
        {
            transform.Rotate(transform.up, -Speed);
            
        }
        else
        {
          
            state = EventState.idle;
        }
    }
}
