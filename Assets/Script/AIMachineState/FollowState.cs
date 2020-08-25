using System;
using UnityEngine;

public class FollowState : BaseState
{

    private Drone _drone;

    private float nextActionTime = 0.0f;
    public float period = 2.0f;

    private Vector3 _destination;


    public FollowState(Drone drone) : base(drone.gameObject)
    {
        this._drone = drone;
    }


    public override Type Tick()
    {

        //validate enemy collision with enviroment 
        if (PreventWallCollision()) {
            return typeof(WalkAround);
        }

        if (_drone.Target != null)
        {

            if (_destination != null) {
                FollowEnemy();
            }


            if (Time.time > nextActionTime)
            {
                nextActionTime += period;

                FindLastTargetPosition();

                if (_drone.TargetEnemy != null) {

                    return typeof(ShootState);

                }
            }

        }
        else {

            return typeof(WalkAround);
        }

        return null;
    }


    private void FollowEnemy() {
        float step = GameSettings.DroneSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _destination, step);
    }

    private void FindLastTargetPosition()
    {
        _destination = _drone.Target.position;
    }

    private bool PreventWallCollision() {
     
        var direction = (_destination - transform.position).normalized;

        if (Physics.SphereCast(transform.position, 1f, direction, out RaycastHit hitInfo, 5f))
        {

            if (hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("stage"))
            {
                    return true;
            }

        }
        return false;
    }
}
