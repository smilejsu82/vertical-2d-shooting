using System;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed;
    public int startIndex;
    public int endIndex;
    public Transform[] sprites;

    private float viewHeight;
    private void Start()
    {
        this.viewHeight = Camera.main.orthographicSize * 2;
    }

    private void Move()
    {
        Vector3 currentPos = this.transform.position;
        Vector3 nextPos = Vector3.down * this.speed * Time.deltaTime;
        this.transform.position = currentPos + nextPos;
    }

    private void Scrolling()
    { 
        if (sprites[endIndex].position.y < -viewHeight)
        {
            //Debug.LogError($"{startIndex}, {endIndex}");
            
            Vector3 backSpritePos = sprites[startIndex].localPosition;
            sprites[endIndex].localPosition = backSpritePos + Vector3.up * viewHeight;

            startIndex = endIndex;
            endIndex = (startIndex + 1) % sprites.Length;
        }
        
        // int startIndexSave = startIndex;
        // startIndex = endIndex;
        //
        // if (startIndexSave - 1 == -1)
        // {
        //     endIndex = sprites.Length - 1;
        // }
        // else
        // {
        //     endIndex = startIndexSave - 1;
        // }
        
        
    }
    
    
    void Update()
    {
        Move();
        Scrolling();
    }
}
