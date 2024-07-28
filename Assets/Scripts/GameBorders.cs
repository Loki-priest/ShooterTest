using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBorders : MonoBehaviour
{

    public BoxCollider2D up;
    public BoxCollider2D down;
    public BoxCollider2D right;
    public BoxCollider2D left;

    public float orthoHeight = 5f;

    private void Awake()
    {
        float screenWH = (float)Screen.width / Screen.height;

        up.transform.position = orthoHeight * Vector3.up;
        down.transform.position = orthoHeight * -Vector3.up;
        right.transform.position = orthoHeight * screenWH * Vector3.right;
        left.transform.position = orthoHeight * screenWH * -Vector3.right;

        up.size = Vector2.right * 2f * orthoHeight * screenWH + Vector2.up;
        down.size = Vector2.right * 2f * orthoHeight * screenWH + Vector2.up;
        right.size = Vector2.up * 2f * orthoHeight + Vector2.right;
        left.size = Vector2.up * 2f * orthoHeight + Vector2.right;
    }
}
