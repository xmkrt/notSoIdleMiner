//Can´t change the sorting layer of the TextMesh in editor, so thats what is done here
using UnityEngine;

public class TextOrder : MonoBehaviour
{
    void Start()
    {
        GetComponent<Renderer>().sortingLayerName = "ForeGround";
        GetComponent<Renderer>().sortingOrder = 2;
    }
}
