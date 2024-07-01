using UnityEngine;

// 베지어 곡선을 기반으로 움직인다.
public class Move : MonoBehaviour
{   
    [SerializeField] Transform _middlePoint;    
    [SerializeField] Transform _endPoint;
    [SerializeField] float speed = 0.15f;

    Vector2[] _movePositions = new Vector2[4];
    Vector2 _startPosition;
    Vector2 _targetPosition;

    float _movingTime = 0;

    void Awake()
    {
        _startPosition = transform.position;
        _movePositions[0] = _startPosition;
        _movePositions[3] = _endPoint.position;        
    }

    void OnEnable()
    {
        SetTarget();
        _movingTime = 0;
    }

    void Update()
    {
        if(_movingTime > 1)
        {
            return;
        }

        _movingTime += Time.deltaTime * speed;
        MoveTransform();
    }

    void SetTarget()
    {
        //_targetPosition = 
        //_movePositoin[] = 
    }

    void MoveTransform()
    {
        transform.position = new Vector2(
            GetBezierPoint(_movePositions[0].x, _movePositions[1].x, _movePositions[2].x, _movePositions[3].x),
            GetBezierPoint(_movePositions[0].y, _movePositions[1].y, _movePositions[2].y, _movePositions[3].y)
            );
    }

    float GetBezierPoint(float a, float b, float c, float d) 
    {
        return Mathf.Pow((1 - _movingTime), 3) * a
            + Mathf.Pow((1 - _movingTime), 2) * 3 * _movingTime * b
            + Mathf.Pow(_movingTime, 2) * 3 * (1 - _movingTime) * c
            + Mathf.Pow(_movingTime, 3) * d;
    }
}
