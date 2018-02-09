// spawning some background clouds
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject cloudGameObject;
    private float nextCloud;

    void Update()
    {
        if (Time.time >= nextCloud)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        Vector2 pos = new Vector2(4, Random.Range(2f, 5f));
        Instantiate(cloudGameObject,pos, Quaternion.identity, transform);
        nextCloud = Time.time + Random.Range(5f, 10f);
    }
}
