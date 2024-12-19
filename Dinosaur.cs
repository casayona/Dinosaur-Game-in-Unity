using UnityEngine;

public class Dinosaur : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 direction;
    public float jumpForce = 10f;
    public float gravity = 35f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        direction = Vector3.zero;
    }
    private void Update()
    {
        direction += gravity * Time.deltaTime * Vector3.down;
        if (characterController.isGrounded)
        {
            direction = Vector3.down;
            if (Input.GetButton("Jump"))
            {
                direction = Vector3.up * jumpForce;
            }
        }
        characterController.Move(direction * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacles"))
        {
            GameManager.instance.GameOver();
        }
    }
}
