using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 20.0f;

    void Start()
    {
    }


    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        var horizontalVelocity = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalVelocity * _speed * Time.deltaTime);
    }
}