using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> enemyPath = new List<Waypoint>();
    [SerializeField] float enemyWaitTime = 1f;

    void Start()
    {
        StartCoroutine(FollowEnemyPath());
    }

    IEnumerator FollowEnemyPath()
    {
        foreach(Waypoint waypoint in enemyPath)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(enemyWaitTime);
        }
    }
}
