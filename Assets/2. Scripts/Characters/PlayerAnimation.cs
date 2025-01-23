using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Block")
        {
            if (GameManager.Instance.score > other.gameObject.GetComponent<Block>().hp)
            {
                anim.SetTrigger("kick");
                other.gameObject.GetComponent<Block>().Explode();
                GameManager.Instance.score -= other.gameObject.GetComponent<Block>().hp;
            }
            else
            {
                GameManager.Instance.score = 0;
                GameManager.Instance.pathFollower.speed = 0;
                anim.SetTrigger("die");
            }
        }
    }
}
