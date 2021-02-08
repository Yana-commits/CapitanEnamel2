using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float xMin, xMax, yMin, yMax;
    public Vector2 direction = new Vector2(0, 0);
   private Rigidbody2D rig;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Moove();
    }

    public void Moove()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            direction = new Vector2(-1,1);

        if (Input.GetKey(KeyCode.RightArrow))
            direction = new Vector2(1,-1);

        if (Input.GetKey(KeyCode.UpArrow))
            direction = new Vector2(1,1);

        if (Input.GetKey(KeyCode.DownArrow))
            direction = new Vector2(-1,-1);

        MoveAround(direction);
    }

    public void MoveAround(Vector2 vector)
    {
        rig.velocity = direction * speed;

        rig.position = new Vector2(

            Mathf.Clamp(rig.position.x, xMin, xMax),
            Mathf.Clamp(rig.position.y, yMin, yMax)

            );
    }
}
