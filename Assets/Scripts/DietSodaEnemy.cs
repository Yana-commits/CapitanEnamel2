using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DietSodaEnemy : Enemy
{
    public Vector2 direction;
    public float accelerastion;
    private int touch = 1;

    void FixedUpdate()
    {
        rigidbody2D.position += (Vector2.down * speed) * Time.fixedDeltaTime;
    }
    void OnBecameInvisible()
    {
        Debug.Log("return");
        EnemyReturn?.Invoke(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Tooth")
        {
            EnemyReturn?.Invoke(gameObject);
        }
        else if (collider.tag == "Player")
        {
            Count(ref touch);
            ForceMoover();
        }
    }
    private void ForceMoover()
    {
        rigidbody2D.AddForce(direction.normalized * accelerastion, ForceMode2D.Impulse);
    }
    private void Count( ref int touch)
    {
        if (touch == 0)
        {
            EnemyReturn?.Invoke(gameObject);
            touch = 2;
        }
        touch--;
        Debug.Log($"{touch}");
    }
}
