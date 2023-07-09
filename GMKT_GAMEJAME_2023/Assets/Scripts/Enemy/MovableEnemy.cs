using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MovableEnemy : BaseEnemy
{
    public GameObject patrolPoints;
    private List<Transform> pointsList = new List<Transform>();
    private int _numberOfFillowingPoint = 0;

    protected override void Start()
    {
        base.Start();
        pointsList.AddRange(patrolPoints.GetComponentsInChildren<PatrolPoint>().Select(point => point.transform).ToList());
    }
    protected override void Move()
    {
        if (pointsList.Count <= 1)
            return;

        float step = _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, pointsList[_numberOfFillowingPoint].position, step);

        if ((pointsList[_numberOfFillowingPoint].position - transform.position).magnitude < 2)
        {
            _numberOfFillowingPoint++;
            if (_numberOfFillowingPoint >= pointsList.Count)
                _numberOfFillowingPoint = 0;
        }
    }
}
