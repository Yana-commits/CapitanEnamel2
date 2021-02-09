using Game.Level;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected float speed;
   public Rigidbody2D rigidbody2D;
    public static Action<GameObject> EnemyReturn;
    public Animator anim;

    public void Init(LevelRepository levelRepository, int index)
    {
        FallinEnemy fallin = levelRepository.LevelList[index].fallinEnemy;
        speed = fallin.speed;
        //var anim = GetComponent<Animator>();
    }

    
}
