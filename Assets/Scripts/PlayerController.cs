using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 10.0f;

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
        var verticalVelocity = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontalVelocity * _speed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalVelocity * _speed * Time.deltaTime);
    }
}
