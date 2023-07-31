using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_Chase : Chase
{
    private Goblin enemy;

    public Goblin_Chase(Entity entity, FiniteStateMachine FSM, string animationName, ChaseData data, Goblin enemy) : base(entity, FSM, animationName, data)
    {
        this.enemy = enemy;
    }

    public override void Check()
    {
        base.Check();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isPlayerInCloseActionRange)
        {
            FSM.ChangeState(enemy.attackState);
        }
        else if (!isLedge || isWall)
        {
            // Debug.Log("EW_Chase:LogicUpdate: isLedge: " + isLedge + ", isWall: " + isWall);
            // enemy.SetVelocityX(0f);
            FSM.ChangeState(enemy.lookForPlayerState);
        }
        else if (isChaseTimeOver)
        {
            FSM.ChangeState(enemy.tiredState);
        }
    }
}