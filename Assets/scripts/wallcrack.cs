using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//wallcrack in the hallway. Attached to the wallcrack game object. Made by Chris.

public class wallcrack : MonoBehaviour
{
    public GameObject wallCrack;
    public Sprite wallcrack1;
    public Sprite wallcrack2;
    public Sprite wallcrack3;
    public Sprite wallcrack4;
    public SpriteRenderer spriteRenderer;
    // kkey is the kitchen-key object
    public GameObject kkey;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = wallcrack1;
    }

    //Changes sprite when clicked
    private void OnMouseDown()
    {
        ChangeSprite();
    }

    void ChangeSprite()
    //changes sprite depending on what the previous sprite is, progressing between the cracks.
    {
        if (spriteRenderer.sprite == wallcrack1)
        {
            spriteRenderer.sprite = wallcrack2;
        }
        else if (spriteRenderer.sprite == wallcrack2)
        {
            spriteRenderer.sprite = wallcrack3;
        }
        else if (spriteRenderer.sprite == wallcrack3)
        {
            spriteRenderer.sprite = wallcrack4;
            //Activates kitchen-key object
            kkey.SetActive(true);
        }
    }
}