using UnityEngine;
using System.Collections;
using System;

public class AttackState : BaseState
{
    private Drone _drone;

    private float _attackReadyTimer;

    public AttackState(Drone drone) : base(drone.gameObject)
    {
        this._drone = drone;
    }

    public override Type Tick()
    {
        if (_drone.Target == null)
        {
            return typeof(WanderState);
        }

        _attackReadyTimer -= Time.deltaTime;

        if (_attackReadyTimer <= 0f) {
            Debug.Log("Attack Enemy");
            _drone.FireWeapon(_drone.Target.position);
        }

        return null;
    }
}
