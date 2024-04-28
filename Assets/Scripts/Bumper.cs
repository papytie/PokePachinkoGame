using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Bumper : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer { get; set; }
    PokemonData currentPokemonData; 


    public void InitBumper()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();

    }
    public void SetData(PokemonData data)
    {
        currentPokemonData = data;
        SpriteRenderer.sprite = data.icon;
    }

}
