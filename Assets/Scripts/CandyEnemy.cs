using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyEnemy : Enemy
{
    void FixedUpdate()
    {
        rigidbody2D.position += (Vector2.down * speed) * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Tooth")
        {
            EnemyReturn?.Invoke(gameObject);
        }
        else if (collider.tag == "Player")
        {
            Debug.Log("BBB");
            EnemyReturn?.Invoke(gameObject);
        }
    }
}
