using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _velocityModifier;

    [SerializeField]
    private float _stepSizeVertical;

    [SerializeField]
    private float _minVerticalHeight;

    [SerializeField]
    private float _maxVerticalHeight;

    private Vector2 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if ((Vector2)transform.position != _targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, _targetPosition, Time.fixedDeltaTime * _velocityModifier);
        }
    }

    private void SetTargetVerticalPosition(float stepSizeVertical)
    {
        float targetPointY = _targetPosition.y + stepSizeVertical;

        if (targetPointY > _maxVerticalHeight)
        {
            targetPointY = _maxVerticalHeight;
        }
        else if(targetPointY < _minVerticalHeight)
        {
            targetPointY = _minVerticalHeight;
        }

        _targetPosition = new Vector2(_targetPosition.x, targetPointY);
    }

    public void MoveUp()
    {
        SetTargetVerticalPosition(_stepSizeVertical);
    }

    public void MoveDown()
    {
        SetTargetVerticalPosition(-1f * _stepSizeVertical);
    }
}