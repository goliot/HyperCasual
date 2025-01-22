using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private GameObject completeBox;
    [SerializeField]
    private GameObject brokenBox;
    [SerializeField]
    private GameObject[] boxPieces;
    [SerializeField]
    private float explosionForce = 500f;
    [SerializeField]
    private float explosionRadius = 5f;
    [SerializeField]
    private Transform explosionPoint;



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Explode();
        }
    }

    void Explode()
    {
        completeBox.SetActive(false);
        brokenBox.SetActive(true);
        foreach(GameObject piece in boxPieces)
        {
            if(!piece.TryGetComponent(out Rigidbody rb))
            {
                rb = piece.AddComponent<Rigidbody>();
            }

            Collider col = piece.GetComponent<Collider>();
            if(!col)
            {
                col.enabled = true;
            }

            rb.AddExplosionForce(explosionForce, explosionPoint.position, explosionRadius);
        }

        GameManager.Instance.particleManager.PlayParticle(0, transform.position);
    }
}
