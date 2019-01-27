using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : EventAbstractClass
{

    Animator anim;
    bool isOpen = true;
    public GameObject Smell;
    public Animator dog;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        Smell.SetActive(false);
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
            dog.SetBool("InWindow", false);
            isOpen = false;
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Close"))
        {
            LevelManager.Instance.PoopLevelUp();
            Smell.SetActive(true);

        }       
    }

    public override void CompleteEvent()
    {
        if (!isOpen)
        {
            anim.SetTrigger("OpenWindow");
            dog.SetBool("InWindow", true);
            isOpen = true;
            state = EventState.idle;
            Smell.SetActive(false);
        }
    }
}
