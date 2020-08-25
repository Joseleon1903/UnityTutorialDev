using System;

public class ShootState : BaseState
{
    private Drone _drone;

    public ShootState(Drone drone) : base(drone.gameObject)
    {
        _drone = drone;
    }

    public override Type Tick()
    {
        ShootInEnemyDirection();
        return typeof(FollowState);
    }

    private void ShootInEnemyDirection() {
        if (_drone.TargetEnemy != null) {
            _drone.FireWeapon(_drone.TargetEnemy.position);
        }
    }

}
