using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : EventAbstractClass
{

    Animator anim;
    bool isOpen = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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
                EventActive();
                break;
        }
    }

    protected override void EventActive()
    {
        if (isOpen)
        {
            anim.SetTrigger("CloseWindow");
            isOpen = false;
        }
        else
        {
            LevelManager.Instance.PoopLevelUp();
        }       
    }

    public override void CompleteEvent()
    {
        if (!isOpen)
        {
            anim.SetTrigger("OpenWindow");
            isOpen = true;
            state = EventState.idle;
        }
    }
}
