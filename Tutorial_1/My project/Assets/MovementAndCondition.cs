using UnityEngine;

public class MovementAndCondition : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool IsJumping = false;
    int jumpvelo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); 
        float verticalInput = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && IsJumping == false)
        {
            jumpvelo = 100;
            IsJumping = true;
        }

        Vector3 moveDirection = new Vector3(horizontalInput,jumpvelo, verticalInput);

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        jumpvelo = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsJumping = false;
        }

        if (collision.gameObject.CompareTag("Win"))
        {
            print("Win");
        }

        if (collision.gameObject.CompareTag("Lose"))
        {
            print("Lose");
            Destroy(gameObject);

        }
    }
}
