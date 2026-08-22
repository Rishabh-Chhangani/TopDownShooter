using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShootBehaviour : AIBehaviour
{
    public float fieldOfVisionForShooting = 60;
   
    public override void PerformAction(TankController tank, AIDetector aiDetector)
    {

        if (aiDetector == null)
        {
            return;
        }

        // If detector has no target yet, do nothing (avoid null reference). The target will be set when player enters detection range.
        if (aiDetector.Target == null)
            return;

        if (TargetInFOV(tank, aiDetector))
        {
            Debug.Log("This is runing");
            tank.HandleTankMovement(Vector2.zero);
            tank.HandleShoot();
        }

        if (tank != null && tank.aimTurret != null)
        {
            tank.HandleTurretRotation(aiDetector.Target.position);
        }
    }

    private bool TargetInFOV(TankController tank, AIDetector aiDetector)
    {
        if (aiDetector == null || aiDetector.Target == null || tank == null || tank.aimTurret == null)
            return false;

        var direction = aiDetector.Target.position - tank.aimTurret.transform.position;
        return Vector2.Angle(tank.aimTurret.transform.right, direction) < fieldOfVisionForShooting / 2;
    }


}
