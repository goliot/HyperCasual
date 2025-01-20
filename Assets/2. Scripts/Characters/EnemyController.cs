using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private GameObject target;
    private bool isDead;

    [SerializeField]
    private float speed = 10f;

    private void OnEnable()
    {
        isDead = false;
        target = GameManager.Instance.player;
    }

    private void Update()
    {
        if (isDead)
            return;

        transform.LookAt(target.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        /*Vector3 directionToTarget = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directionToTarget.x, 0, directionToTarget.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            DeadEffect();
            isDead = true;
            GameManager.Instance.poolManager.Release(gameObject);
        }
    }

    private void DeadEffect()
    {

    }
}
