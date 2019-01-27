using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] float TimeInterval_Window = 15f;
    [SerializeField] float TimeInterval_NPC = 5f;
    [SerializeField] float TimeInterval_Battery = 27f;

    
    public GameObject Window;
    private bool CoroutineStopped = false;
    [SerializeField] Vector3 NPC_SpawnPos;

    enum EventState
    {
        Idle,
        FamilyMember,
        Window,
        Phone
    }
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(TriggerWindow());
    }

    // Update is called once per frame
    void Update()
    {
        if(LevelManager.Instance.State == LevelManager.LevelState.GameEnd && !CoroutineStopped)
        {
            StopAllCoroutines();
            Debug.Log("Coroutines stop");
            CoroutineStopped = true;
            
        }
        
    }
    /*private IEnumerator TriggerNPC()
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(TimeInterval_NPC);
            var temp = GameObject.Instantiate(NPC[0], NPC_SpawnPos, gameObject.transform.rotation, gameObject.transform);
            temp.GetComponent<EventAbstractClass>().state = EventAbstractClass.EventState.active;
        }
       
    }*/

    private IEnumerator TriggerWindow()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(TimeInterval_Window);

            Window.GetComponent<EventAbstractClass>().state = EventAbstractClass.EventState.active;
        }
        
    }

    private IEnumerator TriggerBattery()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(TimeInterval_Battery);

            Window.GetComponent<EventAbstractClass>().state = EventAbstractClass.EventState.active;

        }
    }


}
