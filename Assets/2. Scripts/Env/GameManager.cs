using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("# Game Objects")]
    public PoolManager poolManager;
    public Spawner spawner;
    public GameObject player;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        Time.timeScale = 1.0f;
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
