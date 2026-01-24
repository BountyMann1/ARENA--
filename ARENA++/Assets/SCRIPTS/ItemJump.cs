using UnityEngine;

public class ItemJump : MonoBehaviour
{
    public float jumpHeight = 0.5f;     // How high it moves
    public float jumpSpeed = 2f;        // How fast it moves

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * jumpSpeed) * jumpHeight;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
