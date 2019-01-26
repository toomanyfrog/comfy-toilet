using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventAbstractClass : MonoBehaviour
{
    [SerializeField] public float CountDownTime;
    [SerializeField] public float Speed;

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
       
        
    }

    protected virtual void EventActive()
    {
        
    }
    protected virtual void MoveBack()
    {
        
    }
}
