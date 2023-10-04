using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingPlayerState : GroundedPlayerState
{
    public DyingPlayerState(PlayerStateMachine fsm, PlayerMovement playerMovement, string AnimatorBool) : base(fsm, playerMovement, AnimatorBool)
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
       
         _playerMovement.isDying = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
          _fsm.SetCurrentState(_fsm.GetState((int)PlayerStatesEnum._DYING_));
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
