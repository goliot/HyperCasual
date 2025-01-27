using System.Collections;
using System.Collections.Generic;
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
        if(int.TryParse(valueText.text, out int num))
        {
            value = num;
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