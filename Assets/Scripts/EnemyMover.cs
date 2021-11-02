using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> enemyPath = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] float enemySpeed = 1f;

    Enemy enemy;

    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowEnemyPath());
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void FindPath()
    {
        enemyPath.Clear();
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");

        foreach(GameObject waypoint in waypoints)
        {
            enemyPath.Add(waypoint.GetComponent<Waypoint>());
        }
    }

    void ReturnToStart()
    {
        transform.position = enemyPath[0].transform.position;
    }

    IEnumerator FollowEnemyPath()
    {
        foreach(Waypoint waypoint in enemyPath)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * enemySpeed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);

                yield return new WaitForEndOfFrame();
            }            
        }

        enemy.StealGold();
        gameObject.SetActive(false);        
    }
}
