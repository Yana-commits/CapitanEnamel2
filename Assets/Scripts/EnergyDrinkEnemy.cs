using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrinkEnemy : Enemy
{
    private float x = 0f;
    void FixedUpdate()
    {
        Avoid();

        rigidbody2D.position += ( new Vector2(x,-1) * speed) * Time.fixedDeltaTime;
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
            Debug.Log("BBB");
            EnemyReturn?.Invoke(gameObject);
        }
    }

    private void Avoid()
    {
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        if ((Mathf.Abs(transform.position.x - playerTransform.position.x) < 2) && ((transform.position.x - playerTransform.position.x) < 0))
        {
            x =-2f;
        }
        else if ((Mathf.Abs(transform.position.x - playerTransform.position.x) < 2) && ((transform.position.x - playerTransform.position.x) > 0))
        {
            x = 2f;
        }
    }
}
