using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//wallcrack in the hallway. Made by Chris.

public class wallcrack : MonoBehaviour
{
    public Sprite wallcrack1; // Drag your first sprite here
    public Sprite wallcrack2; // Drag your second sprite here
    public Sprite wallcrack3; // Drag your first sprite here
    public Sprite wallcrack4; // Drag your second sprite here
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = wallcrack1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ChangeSprite(); //changes Sprite
        }

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
        }
    }
}