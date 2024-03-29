using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates
{
    private string animBoolName;
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected bool finishAnim;
    protected float horizontalInput;
    protected float verticalInput;
    protected Rigidbody rb;
    public PlayerStates(Player _player, PlayerStateMachine _stateMachine, string _animeBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animeBoolName;
    }
    public virtual void Enter()
    {
        player.anim.SetBool(animBoolName, true);
        finishAnim = false;
        rb = player.rb;
    }
    public virtual void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);
        finishAnim = true;
    }
    public void SetFinishAnim()
    {
        this.finishAnim = true;
    }
}
