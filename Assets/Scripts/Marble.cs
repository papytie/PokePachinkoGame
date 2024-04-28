using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Marble : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer { get; set; }

    public void InitScore()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();

    }

    public void SetSprite(Sprite newSprite)
    {
        SpriteRenderer.sprite = newSprite;
    }

    void Update()
    {
        
    }
}
