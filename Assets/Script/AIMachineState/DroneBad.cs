using System.Linq;
using UnityEngine;

public class DroneBad : MonoBehaviour
{
    public Team DroneTeam => _team;
    [SerializeField] private Team _team;
    [SerializeField] private LayerMask _layerMask;

    private float _attackRange = 3f;
    private float _rayDistance = 5.0f;
    private float _stoppingDistance = 5.0f;

    private Vector3 _destination;
    private Quaternion _desideredRotation;
    private Vector3 _direction;
    private DroneBad _target;
    private DroneState _currentState;


    private void Update()
    {
        switch (_currentState)
        {

            case DroneState.Wander:
                {

                    if (NeedDestination())
                    {

                        GetDestination();

                    }
                    transform.rotation = _desideredRotation;
                    transform.transform.Translate(Vector3.forward * Time.deltaTime * 5f);
                    var rayColor = IsPathBloked() ? Color.red : Color.green;
                    Debug.DrawRay(transform.position, _direction * _rayDistance, rayColor);

                    while (IsPathBloked())
                    {
                        Debug.Log("Path Bloked");
                        GetDestination();
                    }

                    var targetToAgrro = CheckForAggro();
                    if (targetToAgrro != null)
                    {
                        _target = targetToAgrro.GetComponent<DroneBad>();
                        _currentState = DroneState.Chase;
                    }

                    break;
                }
            case DroneState.Chase:
                {
                    if (_target == null)
                    {
                        _currentState = DroneState.Wander;
                        return;

                    }
                    transform.LookAt(_target.transform);
                    transform.Translate(Vector3.forward * Time.deltaTime * 5f);
                    if (Vector3.Distance(transform.position, _target.transform.position) < _attackRange)
                    {
                        _currentState = DroneState.Attack;
                    }
                    break;
                }
            case DroneState.Attack:
                {
                    if (_target != null)
                    {
                        Destroy(_target.gameObject);
                    }

                    //play laser Beam 
                    _currentState = DroneState.Wander;
                    break;
                }

        }
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

        for (var i =0; i < 24; i++) {

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
            else {
                Debug.DrawRay(pos, direction * agrroRadius, Color.white);
            }

            direction = stepAngle * direction;
        }

        return null;
    }

    private bool IsPathBloked()
    {
        Ray ray = new Ray(transform.position, _direction);
        var hitSomthing = Physics.RaycastAll(ray, _rayDistance, _layerMask);
        return hitSomthing.Any();
    }

    private void GetDestination()
    {

        Vector3 testPosition = (transform.position + (transform.forward * 4f)) +
            new Vector3(UnityEngine.Random.Range(-4.5f, 4.5f), 0, UnityEngine.Random.Range(-4.5f, 4.5f));

        _destination = new Vector3(testPosition.x, 1f, testPosition.z);

        _direction = Vector3.Normalize(_destination - transform.position);
        _direction = new Vector3(_direction.x, 0f, _direction.z);
        _desideredRotation = Quaternion.LookRotation(_direction);  
    }

    private bool NeedDestination()
    {
        if (_destination == Vector3.zero)
        {
            return true;
        }
        var distance = Vector3.Distance(transform.position, _destination);
        if (distance <= _stoppingDistance) {
            return true;
        }
        return false;
    }

    public enum Team
    {
       Red,
       Blue
    }

    enum DroneState { 
        Wander,
        Chase, 
        Attack
    }

}
