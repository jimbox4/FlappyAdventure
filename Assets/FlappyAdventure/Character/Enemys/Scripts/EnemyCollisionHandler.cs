using System;
using UnityEngine;

[Serializable]
public class EnemyCollisionHandler
{
    public bool TryHandleCollision(Collision2D collision, int contactDamage)
    {
        if (collision.transform.TryGetComponent(out Player player))
        {
            player.TakeDamage(contactDamage);
            return true;
        }

        return false;
    }
}
