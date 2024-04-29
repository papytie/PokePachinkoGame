using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody))]

public class Marble : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer => spriteRenderer;
    public Rigidbody2D Rigidbody => rigidBody;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidBody;
    

    public void InitMarble()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
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
