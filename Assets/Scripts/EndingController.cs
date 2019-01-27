using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingController : MonoBehaviour
{

    [SerializeField] Transform heaven;
    [SerializeField] float heavenYPos = 59.9f;
    [SerializeField] float delay = 0f;
    [SerializeField] float moveDuration = 3f;
    [SerializeField] Transform directional1;
    [SerializeField] Transform finalDir1;
    [SerializeField] Transform directional2;
    [SerializeField] Transform finalDir2;
    [SerializeField] float finalIntensity1 = 1.68f;
    [SerializeField] GameObject leaf;
    float timeCount = 0;
    bool isMoving = false;

    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.Instance.State == LevelManager.LevelState.GameEnd)
        {
            StartMoving();
        }
    }

    public void StartMoving()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveCoroutine());
            StartCoroutine(LightCoroutine());
            leaf.SetActive(true);
            leaf.GetComponent<Animator>().SetBool("LeafEnter", true);
            isMoving = true;
        }
    }

    IEnumerator MoveCoroutine()
    {
        yield return new WaitForSeconds(delay);
        
        while (Mathf.Abs(heaven.position.y - heavenYPos) > 1f)
        {
            heaven.position = new Vector3(heaven.position.x, Mathf.Lerp(heaven.position.y, heavenYPos, timeCount / moveDuration), heaven.position.z);
            timeCount += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator LightCoroutine()
    {
        yield return new WaitForSeconds(delay);
        float angleDiff1 = Quaternion.Angle(directional1.rotation, finalDir1.rotation);
        float angleDiff2 = Quaternion.Angle(directional2.rotation, finalDir2.rotation);
        Light l = directional1.GetComponent<Light>();


        while (angleDiff1 > 10 || angleDiff2 > 10)
        {
            directional1.rotation = Quaternion.Slerp(directional1.rotation, finalDir1.rotation, timeCount / moveDuration);
            directional2.rotation = Quaternion.Slerp(directional2.rotation, finalDir2.rotation, timeCount / moveDuration);
            l.intensity = Mathf.Lerp(l.intensity, finalIntensity1, timeCount / moveDuration);
            l.color = Color.Lerp(l.color, finalDir1.gameObject.GetComponent<Light>().color, timeCount / moveDuration);
            timeCount += Time.deltaTime;
            yield return null;
        }
    }


}
