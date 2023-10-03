using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    private Vector3 _offset = new Vector3(0, 1.2f, 0);
    public GameObject _objectToMove;

    private void OnTriggerExit2D(Collider2D other)
    {
        _objectToMove.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        _objectToMove.transform.position = GetUiActionHintPosition();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _objectToMove.SetActive(true);
        _objectToMove.transform.position = GetUiActionHintPosition();
    }

    private Vector3 GetUiActionHintPosition()
    {
        return Camera.main.WorldToScreenPoint(transform.position + _offset);
    }
}