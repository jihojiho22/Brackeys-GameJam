using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public string playerTag = "Player";
    public Vector3 offset = new Vector3(0, 3, -8);
    public float smoothSpeed = 0.125f;

    private Transform target;

    void Start()
    {
        // Find the player by tag
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            Debug.LogError("No GameObject with tag '" + playerTag + "' found!");
        }
    }

    void LateUpdate()
    {
        if (target == null)
            return;

   
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(target);
    }
}