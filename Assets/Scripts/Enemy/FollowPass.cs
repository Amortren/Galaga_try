using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPass : MonoBehaviour
{
    public enum MovementType { Moveing}
    public MovementType type = MovementType.Moveing;
    private MovingEnemyPass Path;
    [SerializeField]
    private MovingEnemyPass Path1;
    [SerializeField]
    private MovingEnemyPass Path2;
    [SerializeField]
    private MovingEnemyPass Path3;
    public float speed = 1f;
    public float maxDistance = .1f;

    private IEnumerator<Transform> pointInPath;

    private void Awake()
    {
        int r = Random.Range(1, 3);
        switch (r)
        {
            case 1:
                Path = Path1;
                break;
            case 2:
                Path = Path2;
                break;
            case 3:
                Path = Path3;
                break;
        }

    }
    void Start()
    {

        if (Path==null)
        {
            return;
        }

        pointInPath = Path.GetNextPathPoint();

        pointInPath.MoveNext();

        if (pointInPath.Current==null)
        {
            return;
        }

        transform.position = pointInPath.Current.position;
    }

    private void Update()
    {
        if (pointInPath==null || pointInPath.Current==null)
        {
            return;
        }
        if (type == MovementType.Moveing)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
        }
        
        var distanceSquare = (transform.position - pointInPath.Current.position).sqrMagnitude;
        if (distanceSquare<maxDistance*maxDistance)
        {
            
            pointInPath.MoveNext();
            
        }
        if (transform.position.z < -2.8f)
        {
            
            gameObject.SetActive(false);
        }
    }

    
}
