using System;
using System.Collections.Generic;
using UnityEngine;
using static Utilities;

public class Drone : MonoBehaviour
{
    [SerializeField] private Team _team;

    [SerializeField] private GameObject _bullet;

    public Transform Target { get; set; }

    public Transform TargetEnemy { get; set; }

    public Team Team => _team;

    public StateMachine StateMachine => GetComponent<StateMachine>();

    private void Awake()
    {
        InitializedStatemachine();
    }

    private void InitializedStatemachine()
    {
        var state = new Dictionary<Type, BaseState>() {
           { typeof(WalkAround), new WalkAround(this) },
           { typeof(ShootState), new ShootState(this) },
            { typeof(FollowState), new FollowState(this) }
       };
       GetComponent<StateMachine>().SetStates(state);
    }

    internal void EliminateEnemy()
    {
        Target = null;
        TargetEnemy = null;
    }

    public void SetTarget(Transform target) {
        Target = target;
    }

    public void FireWeapon(Vector3 direction) {

       Debug.Log("Fire weapon method ");

       var projectile= Instantiate(_bullet, transform.position, Quaternion.identity);

       Vector3 directionNormalized = (direction - transform.position).normalized;

       projectile.GetComponent<BulletBehavour>().SetDirection(directionNormalized);

       projectile.GetComponent<BulletBehavour>().SetTeam(_team);

    }

}
