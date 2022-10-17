using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _maxHealthCount;

    private float _currentHealthCount;

    private void Start()
    {
        _currentHealthCount = _maxHealthCount;
    }

    private void Update()
    {
        CheckHealthStatus();
    }

    private void CheckHealthStatus()
    {
        if (_currentHealthCount < 0)
        {
            _currentHealthCount = 0;

            Die();
        }
        else if (_currentHealthCount > _maxHealthCount)
        {
            _currentHealthCount = _maxHealthCount;
        }
    }

    public void ApplyDamage(float damage)
    {
        _currentHealthCount -= damage;
    }

    public void Die()
    {
        Debug.Log("Сдох");
    }
}