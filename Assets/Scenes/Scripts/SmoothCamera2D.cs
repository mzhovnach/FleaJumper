using UnityEngine;
using System.Collections;

public class SmoothCamera2D : MonoBehaviour
{
    public Camera cameraFollow;
    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 point = cameraFollow.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - cameraFollow.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            delta.y = 0.0f;
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }

    }
}