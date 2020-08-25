using System;
using UnityEngine;
using static Utilities;

public class WalkAround : BaseState
{
    private Drone _drone;

    private Vector3 _destination;
    private Vector3 _direction; 

    private float area = 24f;

    private readonly LayerMask _layerMask = LayerMask.NameToLayer("stage");

    private float _rayDistance = 0.5f;

    public WalkAround(Drone drone) : base(drone.gameObject)
    {
        this._drone = drone;
    }

    public override Type Tick()
    {
        //buscar una nueva destinacion si no tiene
        if (_destination == null || _destination == Vector3.zero) {
            FoundNextTargetPointInCircle();
        }

        //moverse hacia esa destinacion 
        MoveToDestination();

        //validando si un enemigo se encuentra en su radio de fuego
        if (CheckNearEnemy()) {
            return typeof(ShootState);
        }

        return null;
    }

    private bool CheckNearEnemy() {


        if (Physics.SphereCast(transform.position, 1f, _direction,out RaycastHit hitInfo, 5f)) {

            if (hitInfo.collider.tag == "drone" /*&& _drone.Target == null*/) {
                Team colliderDroneColor = hitInfo.collider.gameObject.GetComponent<Drone>().Team;

                if (_drone.Team != colliderDroneColor) {
                    Debug.Log("Found enemy;");

                    _drone.TargetEnemy = hitInfo.collider.gameObject.GetComponent<Transform>();

                    _drone.Target = hitInfo.collider.gameObject.GetComponent<Transform>();

                    return true;
                }

            }

        }
        return false;
    }


    private void FoundNextTargetPointInCircle() {
        float RandomPosX = Mathf.Round(UnityEngine.Random.Range(-1 * (area), area)); 
        float RandomPosZ = Mathf.Round(UnityEngine.Random.Range(-1 * (area),  area));
        Vector3 newWayPoint = new Vector3(RandomPosX, transform.position.y, RandomPosZ);

        //transform.LookAt(newWayPoint);
        //Debug.Log($"Next target {gameObject.name}: {newWayPoint.x} - {newWayPoint.y} - {newWayPoint.z}" );
        _destination = newWayPoint;
    }


    private void MoveToDestination() {
        float step = GameSettings.DroneSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _destination, step);

        // prevent wall and obstacle collision
        if (PreventWallCollision())
        {
            FoundNextTargetPointInCircle();
        }

        if (_destination.x == transform.position.x || _destination.z == transform.position.z) {
            _destination = Vector3.zero;
        }
    }

    public bool PreventWallCollision() {
        _direction = Vector3.Normalize(_destination - transform.position);
        _direction = new Vector3(_direction.x, 0f, _direction.z);

        //para ver la direccion del drone 
        Debug.DrawRay(transform.position, _direction * _rayDistance, Color.red);
        RaycastHit hit;
        bool result = Physics.Raycast(transform.position, _direction, out hit, _rayDistance);

        if (result) {

            FoundNextTargetPointInCircle();
        }

        return result;
    }


}
