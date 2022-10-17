using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _velocityModifier;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.left * Time.deltaTime * _velocityModifier);
    }
}