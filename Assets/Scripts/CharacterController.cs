using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(LevelManager.Instance.State == LevelManager.LevelState.GameProgress)
        {
            gameObject.GetComponent<Animator>().speed = (1 + LevelManager.Instance.PoopLevel / 100);
        }
        
        if (LevelManager.Instance.PoopLevel >= 100.0f)
        {
            gameObject.GetComponent<Animator>().speed = 1;
            gameObject.GetComponent<Animator>().SetBool("Lose", true);
        }
        else if(LevelManager.Instance.PoopLevel < 100.0f && LevelManager.Instance.State == LevelManager.LevelState.GameEnd)
        {
            gameObject.GetComponent<Animator>().speed = 1.5f;
            gameObject.GetComponent<Animator>().SetBool("Win", true);
        }
    }
}
