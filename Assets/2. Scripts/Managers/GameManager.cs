using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("# Game Objects")]
    public ParticleManager particleManager;
    public PoolManager poolManager;
    public Spawner spawner;
    public GameObject player;
    public PathFollower pathFollower;

    [Header("# Score")]
    public int score;

    private void Awake()
    {
        Instance = this;

        Time.timeScale = 1.0f;
        score = 1;
    }

    public void Victory()
    {
        CoVictory();
    }

    IEnumerator CoVictory()
    {
        yield return new WaitForSeconds(0.1f);

        Time.timeScale = 0;
    }
}
