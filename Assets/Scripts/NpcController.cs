using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : EventAbstractClass
{



    [SerializeField] bool blocked = false;
    [SerializeField] bool Inverted = false;
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
            case EventState.idle:
                CountDown();
                
                break;
            case EventState.active:
                if (Inverted)
                {
                    gameObject.transform.RotateAround(gameObject.transform.position, gameObject.transform.up, 180f);
                    Inverted = false;
                }
                

                EventActive();
                break;

            case EventState.ending:
                CompleteEvent();
                break;
              
        }

        SpeedUp();
            

       

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DoorTrigger"))
        {
            Debug.Log("Door Trigger!");
            blocked = true;
            gameObject.GetComponent<Animator>().SetBool("TryOpen", true);
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
    public override void CompleteEvent()
    {
        if(state != EventState.ending)
        {
            gameObject.GetComponent<Animator>().SetBool("TryOpen", false);
            blocked = false;
            state = EventState.ending;
        }
        
        if (!Inverted)
        {
            gameObject.transform.RotateAround(gameObject.transform.position,gameObject.transform.up,180f);
            Inverted = true;
        }



        if(gameObject.transform.position.x < 28.0f)
        {
            
            transform.Translate(new Vector3(0f, 0f, Speed));
        }
        else
        {
            state = EventState.idle;
        }
       


            
    }
    
}
