using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]

public class Bumper : MonoBehaviour
{
    public float BumperStrength => bumperStrength;

    [SerializeField] float bumperStrength = 100f;
    [SerializeField] float muteTime = 2f;
    [SerializeField] bool pitchVariation = true;

    SpriteRenderer spriteRenderer;
    PokemonData currentPokemonData;
    AudioSource audioSource;

    bool isMute = false;
    float startTime = 0;

    Vector2 contact;

    public void InitBumper()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

    }

    private void Update()
    {
        if (isMute && Time.time >= startTime + muteTime)
        {
            isMute = false;
            SetData(PokedexData.Instance.GetRandomInTable(PokedexData.Instance.globalLootTable));
        }
    }

    public void PlaySound()
    {
        audioSource.pitch = pitchVariation ? Random.Range(.1f,3) : 1;
        audioSource.Play();
        isMute = true;
        startTime = Time.time;
    }

    public void SetData(PokemonData data)
    {
        currentPokemonData = data;
        spriteRenderer.sprite = data.icon;
        audioSource.clip = data.cry;
    }

    public Vector2 BumpDirection(Vector2 contactPos)
    {
        contact = contactPos;
        Vector2 center = transform.position;
        Vector2 initialDirection = (contactPos - center).normalized;
        Debug.Log("Initial direction : " + initialDirection);
        Vector2 bumpNormal = initialDirection.x < 0 ? -transform.right : transform.right;
        return Vector2.Reflect(initialDirection, bumpNormal);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isMute && collision.gameObject.GetComponent<Marble>()) 
        {
            PlaySound();
        }
    }
    private void OnDrawGizmos()
    {
        if (contact.x != 0 || contact.y != 0)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(contact, .05f);
            Gizmos.DrawLine(contact, transform.position);
            Gizmos.color = Color.green;
            Vector2 center = transform.position;
            Gizmos.DrawLine(transform.position, center + BumpDirection(contact));
        }
    }
}
