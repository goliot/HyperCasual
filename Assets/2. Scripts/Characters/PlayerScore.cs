using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro scoreText;

    private void Update()
    {
        scoreText.text = GameManager.Instance.score.ToString();
    }
}
