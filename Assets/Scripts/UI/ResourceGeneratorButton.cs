using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ResourceGeneratorButton : MonoBehaviour
{
    [Serializable]
    public class ButtonSpriteSet
    {
        public ResourceOwner owner;
        public Sprite normal;
        public Sprite highlighted;
        public Sprite pressed;
        public Sprite selected;
        public Sprite disabled;
    }

    [SerializeField] private Button button;
    [SerializeField] private Image targetGraphic;
    [SerializeField] private ResourceOwner currentTarget;
    [SerializeField] private List<ButtonSpriteSet> spriteSets = new List<ButtonSpriteSet>();

    private void Reset()
    {
        button = GetComponent<Button>();
        targetGraphic = GetComponent<Image>();
    }

    private void OnEnable()
    {
        ApplyStyle(currentTarget);
    }

    public void ApplyStyle(ResourceOwner owner)
    {
        currentTarget = owner;

        ButtonSpriteSet set = FindSet(owner);
        if (set == null)
        {
            return;
        }

        if (button == null)
        {
            button = GetComponent<Button>();
        }

        if (targetGraphic == null)
        {
            if (button != null)
            {
                targetGraphic = button.image;
            }
            else
            {
                targetGraphic = GetComponent<Image>();
            }
        }

        // État "normal" = sprite de l'Image
        if (targetGraphic != null)
        {
            targetGraphic.sprite = set.normal;
        }

        // Les 4 autres états passent par le SpriteState du Button
        SpriteState spriteState = new SpriteState
        {
            highlightedSprite = set.highlighted,
            pressedSprite = set.pressed,
            selectedSprite = set.selected,
            disabledSprite = set.disabled
        };

        if (button != null)
        {
            button.spriteState = spriteState;
        }
    }

    private ButtonSpriteSet FindSet(ResourceOwner owner)
    {
        foreach (ButtonSpriteSet set in spriteSets)
        {
            if (set.owner == owner)
            {
                return set;
            }
        }

        return null;
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (button == null)
        {
            button = GetComponent<Button>();
        }

        if (targetGraphic == null)
        {
            targetGraphic = GetComponent<Image>();
        }

        ApplyStyle(currentTarget);
    }
#endif
}