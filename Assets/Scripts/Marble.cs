using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Marble : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer => spriteRenderer;
    public Rigidbody2D Rigidbody => rigidBody;
    public CircleCollider2D CircleCollider => circleCollider;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidBody;
    CircleCollider2D circleCollider;

    public void InitMarble()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    public void SetSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
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
