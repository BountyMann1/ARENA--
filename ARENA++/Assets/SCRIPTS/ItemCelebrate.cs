using System.Collections;
using UnityEngine;

public class ItemCelebrate : MonoBehaviour
{
    public float flipDuration = 0.5f;
    public float jumpHeight = 1f;
    public float jumpDuration = 0.5f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            StartCoroutine(JumpFlipAndDisappear());
            Debug.Log("Item collected!");
        }
    }

    IEnumerator JumpFlipAndDisappear()
    {
        // Disable collider so it doesn't trigger again
        Collider col = GetComponent<Collider>();
        if (col != null)
            col.enabled = false;

        Vector3 startPos = transform.position;
        float elapsed = 0f;

        // JUMP + FLIP at the same time
        while (elapsed < jumpDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / jumpDuration;

            // Jump arc (parabolic)
            float height = Mathf.Sin(t * Mathf.PI) * jumpHeight;
            transform.position = startPos + new Vector3(0f, height, 0f);

            // Backflip rotation
            float rotation = Mathf.Lerp(0f, 360f, t);
            transform.localEulerAngles = new Vector3(rotation, transform.localEulerAngles.y, transform.localEulerAngles.z);

            yield return null;
        }

        Destroy(gameObject);
    }
}
