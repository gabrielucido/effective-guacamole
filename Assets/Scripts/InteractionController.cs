using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InteractionController : MonoBehaviour
{
    [SerializeField] private Sprite overlaySprite;
    [SerializeField] private Vector3 offset = new Vector3(0, 1.2f, 0);

    private bool _isInteractable = false;
    private GameObject _imageObject;
    private GameObject _overlayCanvas;
    private Camera _mainCamera;

    private void Start()
    {
        if (overlaySprite == null)
        {
            throw new NotImplementedException("Interactable Objects must have a overlay sprite set!");
        }

        if (Camera.main == null)
        {
            throw new NotImplementedException("Main Camera not found!");
        }

        _mainCamera = Camera.main;
        _overlayCanvas = GetComponentInChildren<Canvas>().gameObject;
        _imageObject = _overlayCanvas.gameObject.GetComponentInChildren<Image>().gameObject;
        _imageObject.GetComponent<Image>().sprite = overlaySprite;
        _overlayCanvas.SetActive(false);
    }

    private void Update()
    {
        if (_isInteractable)
        {
            _imageObject.transform.position = GetUiActionHintPosition();
            if (Input.GetButtonDown("Interact"))
            {
                Debug.Log("Interaction!!!");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _overlayCanvas.SetActive(false);
        _isInteractable = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _overlayCanvas.SetActive(true);
        _isInteractable = true;
    }

    private Vector3 GetUiActionHintPosition()
    {
        return _mainCamera.WorldToScreenPoint(transform.position + offset);
    }
}