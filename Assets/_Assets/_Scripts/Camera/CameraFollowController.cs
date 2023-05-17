using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    [SerializeField] private float lerpValue;
    [SerializeField] private Transform player;
    private Vector3 offset, newPos;
    private float minYPos = -2f;
    void Start()
    {
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        if (player.position.y < minYPos) return;
        
        newPos = Vector3.Lerp(transform.position, player.position + offset, lerpValue * Time.deltaTime);
        transform.position = newPos;
    }
}
