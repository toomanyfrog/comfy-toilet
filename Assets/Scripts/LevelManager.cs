using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public float PoopLevel = 0;
    public GameObject LoseUI;
    public bool failed = false;
   

    [SerializeField] float PoopLevelUpSpeed =0.1f;
    [SerializeField] int numSecondsCountdown = 3;
    [SerializeField] GameObject countUI;
    [SerializeField] Transform timeUI;

    float GameTimeOrg = 10.0f;
    public float GameTime = 10.0f;
    int count = 0;
    
    public enum LevelState {
        GameStart,
        GameProgress,
        GameEnd
    }
    public LevelState State;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        GameTimeOrg = GameTime;
        State = LevelState.GameStart;
        StartCoroutine(StartGame());
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        if (State == LevelState.GameProgress)
        {
            if (GameTime > 0)
            {
                GameTime -= Time.deltaTime;
                timeUI.localScale = new Vector3((GameTimeOrg-GameTime)/GameTimeOrg, timeUI.localScale.y, timeUI.localScale.z);
            }
            else
            {

                Debug.Log("Game Over");
                State = LevelState.GameEnd;
            }
        }
    }


    public void PoopLevelUp()
    {
        if(PoopLevel < 100 && State == LevelState.GameProgress)
        {
            PoopLevel += PoopLevelUpSpeed;
            Debug.Log("Poop Level: "+ PoopLevel);
        }
        else
        {
            if (State == LevelState.GameProgress)
            {
                LoseUI.SetActive(true);
                LoseUI.GetComponent<Animator>().SetBool("GameOver", true);
                failed = true;
            }
            State = LevelState.GameEnd;
        }
    }
   
    IEnumerator StartGame()
    {        
        countUI.SetActive(true);
        while (count < numSecondsCountdown)
        {
            count++;
            countUI.transform.position -= new Vector3(0, 15, 0);
            yield return new WaitForSeconds(1);

        }
        countUI.SetActive(false);
        State = LevelState.GameProgress;
    }
}
