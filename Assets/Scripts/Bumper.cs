using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Bumper : MonoBehaviour, IToken
{
    public SpriteRenderer SpriteRenderer { get; set; }

    public void InitToken()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();

    }

    public void SetSprite(Sprite newSprite)
    {
        SpriteRenderer.sprite = newSprite;
    }
}
