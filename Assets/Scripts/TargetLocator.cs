using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform turretWeapon;
    Transform enemyTarget;

    void Start()
    {
        enemyTarget = FindObjectOfType<EnemyMover>().transform;
    }

    void Update()
    {
        AimTurretWeapon();
    }

    void AimTurretWeapon()
    {
        turretWeapon.LookAt(enemyTarget);
    }
}