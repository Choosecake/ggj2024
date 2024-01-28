using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayReaction : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    public SpriteRenderer spriteRenderer;

    public void SetSprite(int index)
    {
        spriteRenderer.sprite = _sprites[index];
    }
}
