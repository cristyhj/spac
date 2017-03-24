using UnityEngine;
using System.Collections;

public class BoundariesSetUp : MonoBehaviour {

    // Use this for initialization
    void Start() {
        EdgeCollider2D testEdge = GetComponent<EdgeCollider2D>();
        Vector2[] tempArray = testEdge.points;
        Vector2 pos;
        pos.x = Camera.main.pixelWidth;
        pos.y = Camera.main.pixelHeight;
        pos = Camera.main.ScreenToWorldPoint(pos);
        // still in debugging

        pos.x *= 8f / 12.8f;
        pos.y *= 5f / 8f;

        tempArray[0] = new Vector2(pos.x, pos.y);
        tempArray[1] = new Vector2(-pos.x, pos.y);
        tempArray[2] = new Vector2(-pos.x, -pos.y);
        tempArray[3] = new Vector2(pos.x, -pos.y);
        tempArray[4] = new Vector2(pos.x, pos.y);

        testEdge.points = tempArray;

    }
}
