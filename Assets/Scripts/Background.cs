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
        
        //(startIndex + 1) % sprites.Length;

        //단순 순환 하고싶을때 
        // for (int i = 0; i < 10; i++)
        // {
        //     int idx = i % 3;
        //     Debug.Log(idx);
        // }

        //이전 인덱스로 순환 하고싶을때 
        // int length = 3;
        // for (int i = 0; i < 10; i++)
        // {
        //     int idx = (i - 1  + length) % length;
        //     Debug.Log(idx);
        // }
        
        // int length = 3;
        // for (int i = 0; i < 10; i++)
        // {
        //     int idx = (i + 1) % length;
        //     Debug.Log(idx);
        // }
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
