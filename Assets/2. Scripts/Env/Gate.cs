using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro valueText;

    private int value;
    private char operation;

    private void Awake()
    {
        operation = valueText.text[0];
        string numberPart = Regex.Match(valueText.text, @"\d+").Value;
        if (int.TryParse(numberPart, out int num))
        {
            value = num;
        }
        else
        {
            Debug.LogWarning("Failed to parse value from valueText.text");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(gameObject.name + operation);
            switch (operation)
            {
                case '+':
                    GameManager.Instance.score += value;
                    break;
                case '-':
                    GameManager.Instance.score += value;
                    break;
                case '*':
                    GameManager.Instance.score *= value;
                    break;
                case '¡À':
                    GameManager.Instance.score /= value;
                    break;
            }
        }
    }
}