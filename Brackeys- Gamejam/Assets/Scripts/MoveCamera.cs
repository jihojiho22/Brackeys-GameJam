using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public string playerTag = "Player";
    public Vector3 offset = new Vector3(0, 3, -8);
    public float smoothSpeed = 0.125f;
    public Vector3 indoorOffset = new Vector3(0, 1, -1);
    private Player playerScript;

    private Transform target;

    void Start()
    {
        // Find the player by tag
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        playerScript = player.GetComponent<Player>();   
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

        Vector3 currentOffset = playerScript.isIndoors ? indoorOffset : offset;
        Vector3 desiredPosition = target.position + currentOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(target);
    }
}