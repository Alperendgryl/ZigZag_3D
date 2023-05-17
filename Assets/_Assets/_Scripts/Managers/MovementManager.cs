using UnityEngine.SceneManagement;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    private IInput inputManager;
    private Rigidbody rb;
    private Vector3 direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputManager = GetComponent<IInput>();
        inputManager.OnDirectionChanged += UpdateDirection;
    }

    private void OnDestroy()
    {
        if (inputManager != null)
        {
            inputManager.OnDirectionChanged -= UpdateDirection;
        }
    }

    private void UpdateDirection(Vector3 newDirection)
    {
        direction = newDirection;
    }

    void FixedUpdate()
    {
        Vector3 horizontalVelocity = direction * movementSpeed;
        Vector3 verticalVelocity = new Vector3(0, rb.velocity.y, 0);
        rb.velocity = horizontalVelocity + verticalVelocity;

        PositionController();
    }

    private float minYPos = -50f;
    private void PositionController()
    {
        if (gameObject.transform.position.y < minYPos)
        {
            SceneManager.LoadScene(0);
        }
    }
}