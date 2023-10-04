using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedPlayerState : PlayerState
{
  private bool _isGrounded;
  protected Vector2 input;
    public GroundedPlayerState(PlayerStateMachine fsm, PlayerMovement playerMovement, string AnimatorBool) : base(fsm, playerMovement, AnimatorBool)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
      base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        input = _playerMovement._playerInputHandler.movementInput;
        
        if(_playerMovement.isDying == true)
        {
          _fsm.SetCurrentState(_fsm.GetState((int)PlayerStatesEnum._DYING_));
        }
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
