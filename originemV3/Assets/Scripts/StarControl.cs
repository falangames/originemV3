using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarControl : MonoBehaviour
{
    GameObject[] target;

    void Start()
    {
        Time.timeScale = 1;
    }
    int i = 0;
    void FixedUpdate()
    {
        if (i != 500)
        {
            i += 1;
            target = GameObject.FindGameObjectsWithTag("StarsBreakPoint");
            transform.position = Vector3.Lerp(transform.position, target[0].transform.position, Time.deltaTime * 8f);
        }
    }
}
