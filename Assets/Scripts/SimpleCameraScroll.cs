using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraScroll : MonoBehaviour
{
    private Vector2 startingPos;
    [SerializeField]
    private float scrollSpeed = 5f;
    void Start()
    {
        startingPos = transform.position;
    }
    void Update()
    {
        if (Input.mousePosition.y >= Screen.height * 0.95f && transform.position.y < startingPos.y)
        {
            transform.Translate(scrollSpeed * Time.deltaTime * Vector2.up);
        }
        else if (Input.mousePosition.y <= Screen.height * 0.05f)
        {
            transform.Translate(scrollSpeed * Time.deltaTime * Vector2.down);
        }
    }
}
