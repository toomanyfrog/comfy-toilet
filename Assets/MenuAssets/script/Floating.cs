using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    [SerializeField] Transform title;
    int dir = 1;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FlipDirection", 0f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(title.position, dir * Vector3.up, 5 * Time.deltaTime);
    }

    void FlipDirection()
    {
        dir *= -1;
    }
}
