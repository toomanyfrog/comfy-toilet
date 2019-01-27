using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooBarController : MonoBehaviour
{
    public GameObject PooLevelFill;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(LevelManager.Instance.PoopLevel / 100.0f);
        PooLevelFill.transform.localScale = new Vector3( 1.0f, LevelManager.Instance.PoopLevel / 100.0f,1.0f);
    }
}
