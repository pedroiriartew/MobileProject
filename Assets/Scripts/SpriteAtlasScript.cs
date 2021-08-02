using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SpriteAtlasScript : MonoBehaviour
{
    [SerializeField] private SpriteAtlas _atlas;
    [SerializeField] private string _spriteName;

    private void Awake()
    {
        this.GetComponent<Image>().sprite = _atlas.GetSprite(_spriteName);
    }
}
