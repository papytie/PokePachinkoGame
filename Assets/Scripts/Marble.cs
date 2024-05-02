using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Marble : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer => spriteRenderer;
    public Rigidbody2D Rigidbody => rigidbody;
    public CircleCollider2D CircleCollider => circleCollider;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidbody;
    CircleCollider2D circleCollider;

    public void InitMarble()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    public void InitPreview()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sprite = null;
        rigidbody = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    public void SetSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }

    void Bounce(Collision2D collision, float bumpStrength)
    {
        Vector2 forceVector = (transform.position - collision.transform.position).normalized * bumpStrength;
        rigidbody.AddForce(forceVector);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bumper>())
        {
            float currentVelocity = rigidbody.velocity.magnitude;
            Debug.Log("Current velocity : " + currentVelocity);
            Bumper bumper = collision.gameObject.GetComponent<Bumper>();
            //Bounce(collision, bumper.BumperStrength);
            Vector2 bumpDirection = bumper.BumpDirection(collision.GetContact(0).point);
            rigidbody.velocity = bumpDirection;
            rigidbody.AddForce(bumpDirection.normalized * bumper.BumperStrength, ForceMode2D.Impulse);
        }
    }

    
}
