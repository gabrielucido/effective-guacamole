using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{

    public Vector2 movementInput;
    public bool interacted  = false;

    public bool escaped = false;

    
  public void OnMoveInput(InputAction.CallbackContext context)
  {
    movementInput = (context.ReadValue<Vector2>());
  }

  public void OnInteract(InputAction.CallbackContext context)
  {
    if (context.performed)
    {
        interacted = true;
    }
  }

    public bool DidInteract()
    {
        return interacted;
    }

  public void OnEscapeInput(InputAction.CallbackContext context)
  {
    if(context.performed)
    {
        escaped = true; 
    }
  }

  public bool DidLeave()
  {
    return escaped;
  }
}
