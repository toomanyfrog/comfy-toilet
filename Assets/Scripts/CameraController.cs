using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    Camera cam;
    [SerializeField] Transform finalPos;
    [SerializeField] float delay = 4f;
    [SerializeField] float finalFOV = 83f;
    [SerializeField] float moveDuration = 2f;
    float timeCount = 0;
    [SerializeField] bool isMoving = false;


    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
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
            StartCoroutine(ZoomCoroutine());
            isMoving = true;
        }
    }

    IEnumerator ZoomCoroutine()
    {
        yield return new WaitForSeconds(delay);
        float angleDiff = Quaternion.Angle(transform.rotation, finalPos.rotation);
        float distance = Vector3.Distance(transform.position, finalPos.position);
        while (distance > 1f || angleDiff > 10)
        {
            transform.position = Vector3.Lerp(transform.position, finalPos.position, timeCount / moveDuration);
            transform.rotation = Quaternion.Slerp(transform.rotation, finalPos.rotation, timeCount / moveDuration);
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, finalFOV, timeCount / moveDuration);
            timeCount += Time.deltaTime;
            yield return null;
        }
    }
}
