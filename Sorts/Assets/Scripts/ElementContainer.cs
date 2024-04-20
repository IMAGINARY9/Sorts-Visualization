using System.Collections;
using TMPro;
using UnityEngine;

public class ElementContainer : MonoBehaviour
{
    [SerializeField]
    private AudioSource audio;

    [SerializeField]
    private TextMeshPro tmp;

    [SerializeField]
    private GameObject sprite;

    private int value;
    public int Value { get => value; set => this.value = value; }

    private Color baseColor;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = sprite.GetComponent<SpriteRenderer>();
        baseColor = spriteRenderer.color;
    }

    public void Init(int value)
    {
        Value = value;
        tmp.text = value.ToString();
        sprite.transform.localScale = new Vector3(transform.localScale.x, value, 0);
    }

    public void Select(Color color)
    {
        audio.Play();
        spriteRenderer.color = color;
    }

    public void Deselect()
    {
        audio.Stop();
        spriteRenderer.color = baseColor;
    }
}
