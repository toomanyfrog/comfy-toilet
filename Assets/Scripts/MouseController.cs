using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                //StartCoroutine(ScaleMe(hit.transform));
                if (hit.transform.gameObject.GetComponent<EventAbstractClass>() != null)
                {
                    Debug.Log(hit.transform.gameObject.GetComponent<EventAbstractClass>().GetType().Name);
                    if (hit.transform.gameObject.GetComponent<EventAbstractClass>().state == EventAbstractClass.EventState.active)
                    {

                        //active method
                        hit.transform.gameObject.GetComponent<EventAbstractClass>().CompleteEvent();
                        Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                    }
                   
                    

                }
            }
           
            
        }
    }
    IEnumerator ScaleMe(Transform objTr)
    {
        objTr.localScale *= 1.2f;
        yield return new WaitForSeconds(0.5f);
        objTr.localScale /= 1.2f;
    }

}
