using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlayerState : GroundedPlayerState
{
    public MovingPlayerState(PlayerStateMachine fsm, PlayerMovement playerMovement, string AnimatorBool) : base(fsm, playerMovement, AnimatorBool)
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
        if(input.x == 0f && input.y == 0f)
        {
            _fsm.SetCurrentState(_fsm.GetState((int)PlayerStatesEnum._IDLE_));
        }

      

    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        _playerMovement.Move(new Vector2(input.x * Time.fixedDeltaTime, input.y * Time.fixedDeltaTime));
    }
}
