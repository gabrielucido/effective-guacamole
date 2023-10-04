using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        HandleInteraction();
        UpdateLayoutHintPosition();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (ValidateTrigger(other))
        {
            var playerController = other.gameObject.GetComponent<PlayerController>()!;
            playerController.interactablesWithDistances.Add(getNewInteractableWithDistanceDict(other));

            var closestInteractableGameObject = playerController.getClosestInteractableGameObject();
            if (closestInteractableGameObject == gameObject)
            {
                EnableInteraction();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (ValidateTrigger(other))
        {
            var playerController = other.gameObject.GetComponent<PlayerController>()!;
            playerController.interactablesWithDistances.RemoveAll(x => x.ContainsKey(gameObject));
            playerController.interactablesWithDistances.Add(getNewInteractableWithDistanceDict(other));

            var closestInteractableGameObject = playerController.getClosestInteractableGameObject();
            if (closestInteractableGameObject == gameObject)
            {   
                EnableInteraction();
            } else
            {
                DisableInteraction();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (ValidateTrigger(other))
        {
            var playerController = other.gameObject.GetComponent<PlayerController>()!;
            playerController.interactablesWithDistances.RemoveAll(x => x.ContainsKey(gameObject));
            DisableInteraction();
        }
    }


    private bool ValidateTrigger(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var playerController = other.gameObject.GetComponent<PlayerController>();
            if (playerController == null)
            {
                throw new NotImplementedException("PlayerController not found on Player!");
            }

            return true;
        }

        return false;
    }

    private Vector3 GetUiActionHintPosition()
    {
        return _mainCamera.WorldToScreenPoint(transform.position + offset);
    }

    private void EnableInteraction()
    {
        _overlayCanvas.SetActive(true);
        _isInteractable = true;
    }

    private void DisableInteraction()
    {
        _overlayCanvas.SetActive(false);
        _isInteractable = false;
    }

    private void UpdateLayoutHintPosition()
    {
        if (_isInteractable)
        {
            _imageObject.transform.position = GetUiActionHintPosition();
        }
    }

    private void HandleInteraction()
    {
        if (_isInteractable && Input.GetButtonDown("Interact"))
        {
            Debug.Log("Interaction!!!");
        }
    }

    private Dictionary<GameObject, float> getNewInteractableWithDistanceDict(Collider2D other)
    {
        return new Dictionary<GameObject, float>()
        {
            {
                gameObject,
                Vector3.Distance(gameObject.GetComponentInChildren<SpriteRenderer>().gameObject.transform.position,
                    other.gameObject.transform.position)
            }
        };
    }
}