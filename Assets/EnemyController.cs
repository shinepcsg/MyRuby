using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3.0f;
    public bool vertical;
    public float changeTime = 3.0f;
    new Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }


        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.y += Time.deltaTime * speed * direction;
        }
        else
        {
            position.x += Time.deltaTime * speed * direction;
        }

        rigidbody2D.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D other) // isTrigger ��� �����Ǿ��ִ� �͵鳢�� �浹
    {
        Debug.Log($"OnCollisionEnter2D :: {name}�� {other.gameObject.name}�� �浹 �߽��ϴ�");

        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"OnTriggerEnter2D :: {name}�� {other}�� �浹 �߽��ϴ�");
    }

}