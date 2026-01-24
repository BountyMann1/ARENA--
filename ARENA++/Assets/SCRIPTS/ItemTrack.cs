using UnityEngine;

public class ItemCircularMovement : MonoBehaviour
{
    public float radius = 2f;
    public float speed = 1f;
    public Vector3 centerPoint;

    private float angle;

    void Update()
    {
        angle += speed * Time.deltaTime;

        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;

        transform.position = centerPoint + new Vector3(x, 0f, z);
    }
}
