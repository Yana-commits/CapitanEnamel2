using Game.Level;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    [SerializeField] Rigidbody2D rigidbody2D;
    public static Action<GameObject> EnemyReturn;

    public void Init(LevelRepository levelRepository, int index)
    {
        FallinEnemy fallin = levelRepository.LevelList[index].fallinEnemy;
        speed = fallin.speed;
        GetComponent<SpriteRenderer>().sprite = fallin.sprite;
        var anim = GetComponent<Animator>();
        anim.runtimeAnimatorController = fallin.animator.runtimeAnimatorController;
    }

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
