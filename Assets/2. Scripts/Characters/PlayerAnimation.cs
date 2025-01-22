using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Block")
        {
            if (GameManager.Instance.score >= other.gameObject.GetComponent<Block>().hp)
            {
                anim.SetTrigger("kick");
                other.gameObject.GetComponent<Block>().Explode();
            }
            else
            {
                anim.SetTrigger("die");
            }
        }
    }
}
