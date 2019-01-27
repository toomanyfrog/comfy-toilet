using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventAbstractClass : MonoBehaviour
{
    [SerializeField] public float CountDownTimeOrg;
    [SerializeField] public float Speed;
    [SerializeField] public float CountDownTime;
    public enum EventState
    {
        idle,
        active,
        ending
        
    }
    public EventState state;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CountDown()
    {
        CountDownTime -= Time.deltaTime;
        if (CountDownTime < 0)
        {
            
            state = EventState.active;
            CountDownTime = CountDownTimeOrg;

        }

    }

    protected virtual void EventActive()
    {
        
    }
    public virtual void CompleteEvent()
    {
        
    }
}
