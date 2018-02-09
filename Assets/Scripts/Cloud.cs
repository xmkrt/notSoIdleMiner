// clouds just move from right to left
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private float speed;
    private float screenHalfWidth;
    void Start()
    {
        screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
        speed = Random.Range(0.4f, 0.6f);
    }
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.left);
        if (transform.position.x < -screenHalfWidth - 2f)
        {
            Destroy(gameObject);
        }
    }
}
