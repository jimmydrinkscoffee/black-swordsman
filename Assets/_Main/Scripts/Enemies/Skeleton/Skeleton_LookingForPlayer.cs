using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_LookingForPlayer : LookingForPlayer
{
    private Skeleton enemy;

    public Skeleton_LookingForPlayer(Entity entity, FiniteStateMachine FSM, string animationName, LookingForPlayerData data, Skeleton enemy) : base(entity, FSM, animationName, data)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();

        // enemy.InitSign();
        // TODO: Add icon about looking for player
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isPlayerInMinAgroRange)
        {
            FSM.ChangeState(enemy.playerDetectedState);
        }
        else if (doneAllTurns)
        {
            FSM.ChangeState(enemy.patrolState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Check()
    {
        base.Check();
    }
}