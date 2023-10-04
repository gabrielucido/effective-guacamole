using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlePlayerState : GroundedPlayerState
{
    public IdlePlayerState(PlayerStateMachine fsm, PlayerMovement playerMovement, string AnimatorBool) : base(fsm, playerMovement, AnimatorBool)
    {
    }

    
    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
      base.Enter();
      _playerMovement._animator.SetFloat("LastMoveX",_playerMovement.lastDirection.x);
      _playerMovement._animator.SetFloat("LastMoveY",_playerMovement.lastDirection.y);
      _playerMovement.Move(Vector2.zero);      
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(input.x != 0f)
        {
            _fsm.SetCurrentState(_fsm.GetState((int)PlayerStatesEnum._MOVING_X));
        }
        else if(input.y != 0f)
        {
             _fsm.SetCurrentState(_fsm.GetState((int)PlayerStatesEnum._MOVING_Y));
        }
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    

}
