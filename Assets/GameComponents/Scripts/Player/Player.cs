using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction<float> HealthChanged;

    public event UnityAction Died;

    [SerializeField]
    private float _maxHealthCount;

    private float _currentHealthCount;

    private void Start()
    {
        _currentHealthCount = _maxHealthCount;

        HealthChanged?.Invoke(ReturnNormalizedCountOfHealth());
    }

    private void Update()
    {
        CheckHealthStatus();
    }

    private void CheckHealthStatus()
    {
        if (_currentHealthCount <= 0)
        {
            _currentHealthCount = 0;

            Die();
        }
        else if (_currentHealthCount > _maxHealthCount)
        {
            _currentHealthCount = _maxHealthCount;
        }
    }

    private float ReturnNormalizedCountOfHealth()
    {
        float normalizedHealthCount = _currentHealthCount / _maxHealthCount;

        return normalizedHealthCount;
    }

    public void ApplyDamage(float damage)
    {
        _currentHealthCount -= damage;

        HealthChanged?.Invoke(ReturnNormalizedCountOfHealth());
    }

    public void Die()
    {
        Died?.Invoke();
    }
}