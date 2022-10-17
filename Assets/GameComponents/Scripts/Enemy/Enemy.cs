using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _damageForce;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damageForce);
        }

        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}