using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAnimation : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NoneStick")
        {
            anim.SetBool("falan", true);
        }

        if (other.gameObject.tag == "Stick")
        {
            if (StickControl.Instance.star != 0)
            {
                StickControl.Instance.star -= 1;
                Destroy(gameObject);
            }
        }
    }
}
