using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class ScrollingImage : MonoBehaviour
{
    public BoxCollider2D imageCollider;

    [SerializeField]private float scrollSpeed;
    private Rigidbody2D imageRB;
    private float imageLength;

    private void Start()
    {
        //Set background velocity
        imageRB = GetComponent<Rigidbody2D>();
        imageRB.velocity = new Vector2(-scrollSpeed, 0);

        //Get the background length
        //imageCollider = GetComponent<BoxCollider2D>();
        imageLength = imageCollider.size.x; 
    }

    private void Update()
    {
        //This will create the infinite scrolling background
        if (transform.position.x < -imageLength)
            RepostionBackground();
    }

    private void RepostionBackground()
    {
        Vector2 Offset = new Vector2(imageLength * 2f, 0);
        transform.position = (Vector2)transform.position + Offset;
    }
}
