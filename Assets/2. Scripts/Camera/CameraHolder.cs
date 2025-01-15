using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private Vector3 initialRotatoin;

    private void Awake()
    {
        initialRotatoin = transform.eulerAngles;
    }

    private void Update()
    {
        transform.position = playerTransform.position;

        transform.eulerAngles = new Vector3(playerTransform.eulerAngles.x + initialRotatoin.x, playerTransform.eulerAngles.y + initialRotatoin.y, 0);
    }
}