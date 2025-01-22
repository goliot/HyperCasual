using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public void PlayParticle(int idx, Vector3 pos)
    {
        ParticleSystem particle = transform.GetChild(idx).GetComponent<ParticleSystem>();
        transform.GetChild(idx).position = pos;
        particle.Clear();
        particle.Play();
    }
}
