using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerStates
{
    public PlayerRunState(Player _player, PlayerStateMachine _stateMachine, string _animeBoolName) : base(_player, _stateMachine, _animeBoolName)
    {
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
        if (horizontalInput == 0 && verticalInput == 0)
            stateMachine.ChangeState(player.idleState);
        //else if(player.CheckCollideObj())
        //    stateMachine.ChangeState(player.idleState);
        else
            //rb.AddForce(new Vector3(player.moveSpeed * horizontalInput * player.orientation.position.normalized.x, rb.velocity.y, player.moveSpeed * verticalInput * player.orientation.position.normalized.z), ForceMode.Force);
            rb.velocity = player.moveSpeed * (verticalInput * player.orientation.forward + horizontalInput * player.orientation.right).normalized;
            //player.transform.Translate(new Vector3(player.moveSpeed * horizontalInput * player.orientation.position.normalized.x * Time.deltaTime, 0f, player.moveSpeed * verticalInput * player.orientation.position.normalized.z * Time.deltaTime));
    }
}
