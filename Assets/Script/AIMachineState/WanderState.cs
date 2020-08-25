using UnityEngine;
using System;

public class WanderState : BaseState
{
    private Vector3? _destination;
    private float stopDistance = 1f;
    private float turnSpeed = 1f;

    private readonly LayerMask _layerMask = LayerMask.NameToLayer("Stage");
    private float _rayDistance = 5.0f;

    private Quaternion _desideredRotation;
    private Vector3 _direction;
    private Drone _drone;

    public WanderState(Drone drone): base(drone.gameObject)
    {
        this._drone = drone;
    }

    public override Type Tick()
    {
        var chaseTarget = CheckForAggro();
        if (chaseTarget != null) {
            _drone.SetTarget(chaseTarget);
            return typeof(ChaseState);
        }

        if (_destination.HasValue == false || Vector3.Distance(transform.position, _destination.Value) <= stopDistance) {
            FindRandomDestination();
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, _desideredRotation, Time.deltaTime * turnSpeed);

        if (IsForwardBloked())
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, _desideredRotation, 0.2f);

        }
        else {
            transform.Translate(Vector3.forward * Time.deltaTime * GameSettings.DroneSpeed);
        }

        Debug.DrawRay(transform.position, _direction * _rayDistance, Color.red);

        while (IsPathBloked())
        {
            FindRandomDestination();
        }

        return null;

    }

    private bool IsPathBloked()
    {
        Ray ray = new Ray(transform.position,_direction);
        return Physics.SphereCast(ray, 0.5f, _rayDistance, _layerMask);
    }

    private bool IsForwardBloked()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        return Physics.SphereCast(ray, 0.5f, _rayDistance, _layerMask);
    }

    private void FindRandomDestination()
    {
        Vector3 testPosition = (transform.position + (transform.forward * 4f)) +
           new Vector3(UnityEngine.Random.Range(-4.5f, 4.5f), 0, UnityEngine.Random.Range(-4.5f, 4.5f));

        _destination = new Vector3(testPosition.x, 1f, testPosition.z);

        _direction = Vector3.Normalize(_destination.Value  -transform.position);
        _direction = new Vector3(_direction.x, 0f, _direction.z);
        _desideredRotation = Quaternion.LookRotation(_direction);
    }

    Quaternion startingAngle = Quaternion.AngleAxis(-60, Vector3.up);
    Quaternion stepAngle = Quaternion.AngleAxis(5, Vector3.up);

    private Transform CheckForAggro()
    {
        float agrroRadius = 5f;

        RaycastHit hit;

        var angle = transform.rotation * startingAngle;
        var direction = angle * Vector3.forward;

        var pos = transform.position;

        for (var i = 0; i < 24; i++)
        {

            if (Physics.Raycast(pos, direction, out hit, agrroRadius))
            {

                var drone = hit.collider.GetComponent<DroneBad>();

                if (drone != null && drone.DroneTeam != gameObject.GetComponent<DroneBad>().DroneTeam)
                {
                    Debug.DrawRay(pos, direction * hit.distance, Color.red);
                    return drone.transform;
                }
                else
                {
                    Debug.DrawRay(pos, direction * hit.distance, Color.yellow);
                }
            }
            else
            {
                Debug.DrawRay(pos, direction * agrroRadius, Color.white);
            }

            direction = stepAngle * direction;
        }

        return null;
    }
}
