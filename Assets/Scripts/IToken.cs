using UnityEngine;

public interface IToken
{
    public SpriteRenderer SpriteRenderer { get; set; }
    public void InitToken() { }
    public void SetSprite(Sprite newSprite) { }
}
