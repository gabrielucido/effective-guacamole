using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SittingPlayerState : GroundedPlayerState
{
    public SittingPlayerState(PlayerStateMachine fsm, PlayerMovement playerMovement, string AnimatorBool) : base(fsm, playerMovement, AnimatorBool)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
      base.Enter();
      _playerMovement.Move(Vector2.zero);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        // if(input.x != 0f)
        // {
        //     _fsm.SetCurrentState(_fsm.GetState((int)PlayerStatesEnum._MOVING_X));
        // }
        // else if(input.y != 0f)
        // {
        //     _fsm.SetCurrentState(_fsm.GetState((int)PlayerStatesEnum._MOVING_Y));
        // }

        if(input.x != 0f)
        {
            
            _fsm.SetCurrentState(_fsm.GetState((int)PlayerStatesEnum._MOVING_X));
            
        }
        
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

}
