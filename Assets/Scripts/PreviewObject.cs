using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]

public class PreviewObject : MonoBehaviour
{
    public Rigidbody2D Rigidbody => rigidBody;
    public CircleCollider2D CircleCollider => circleCollider;

    Rigidbody2D rigidBody;
    CircleCollider2D circleCollider;

    public void InitPreview()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    public void DestroyPreview()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bumper>())
        {
            Vector2 forceVector = (transform.position - collision.transform.position).normalized * 100;
            rigidBody.AddForce(forceVector);
        }
    }
}
