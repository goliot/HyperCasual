using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("# Game Objects")]
    public ParticleManager particleManager;
    public PoolManager poolManager;
    public Spawner spawner;
    public GameObject player;
    public PathFollower pathFollower;
    public PlayerAnimation playerAnimation;

    [Header("UI")]
    public GameObject arrow;
    public GameObject victoryUI;
    public GameObject defeatUI;
    public bool bIsGameStarted;

    [Header("# Score")]
    public int score;

    private void Awake()
    {
        Instance = this;

        bIsGameStarted = false;

        Time.timeScale = 1.0f;
        score = 1;
    }

    private void Update()
    {
        if (!bIsGameStarted)
        {
            return;
        }

        if (score <= 0)
        {
            Defeat();
        }
    }

    public void GameStart()
    {
        bIsGameStarted = true;
        playerAnimation.anim.SetBool("moving", true);
        arrow.SetActive(false);
    }

    public void Defeat()
    {
        playerAnimation.anim.SetTrigger("die");
        defeatUI.SetActive(true);
        bIsGameStarted = false;
    }

    public void DefeatButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Victory()
    {
        StartCoroutine(CoVictory());
    }

    IEnumerator CoVictory()
    {
        yield return new WaitForSeconds(0.5f);

        playerAnimation.anim.SetTrigger("win");
        bIsGameStarted = false;

        victoryUI.SetActive(true);
    }

    public void VictoryButton()
    {

    }
}
