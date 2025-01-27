using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerAnimation : MonoBehaviour
{
    [SerializeField]
    private RectTransform[] destinations;
    [SerializeField]
    private float speed;

    private RectTransform rect;
    private bool bIsMovingLeft;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        MoveToDestination();
    }

    void MoveToDestination()
    {
        int dest = System.Convert.ToInt32(bIsMovingLeft);
        rect.DOMoveX(destinations[dest].position.x, Vector2.Distance(rect.position, destinations[dest].position) / speed).SetEase(Ease.OutSine)
            .OnComplete(() =>
            {
                bIsMovingLeft = !bIsMovingLeft;
                MoveToDestination();
            });
    }
}
