using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : State
{
    
    protected PlayerMovement _playerMovement;

    protected string _animatorBool;

    protected float _startTime;
    public PlayerState(PlayerStateMachine fsm, PlayerMovement playerMovement, string AnimatorBool) : base(fsm)
    {
        _playerMovement = playerMovement;
        _animatorBool = AnimatorBool;
    }

    public override void Enter()
    {
        DoChecks();
        _startTime = Time.time;
        _playerMovement._animator.SetBool(_animatorBool,true);
        base.Enter();
    }

    public override void Exit()
    {
         _playerMovement._animator.SetBool(_animatorBool,false);
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void FixedUpdate()
    {
        DoChecks();
        base.FixedUpdate(); 
    }

    public virtual void DoChecks()
    {

    }
}
