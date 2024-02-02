using System;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    // cached references
    private Rigidbody2D rb;
    private Camera cam;


    // serialized fields for jumping physics
    [Tooltip("This is the speed at which the player jumps")][SerializeField] private float jumpSpeed = 5f;
    [Tooltip("This is the amount of speed added to the jump speed after each jump")][SerializeField] private float jumpSpeedMultiplier = 1f;

    // serialized fields for rotation physics
    [Tooltip("This checks if there has been atleast 1 full rotation")][SerializeField] private bool Rotated = false;
    [Tooltip("This is the speed at which the player rotates")][SerializeField] private float rotationSpeed = 5f;
    [Tooltip("This is the maximum speed at which the player can rotate")][SerializeField] private float maxRotationSpeed = 120f;
    [Tooltip("This sets the max angle of attack when hitting the trampoline. Default: 20")][SerializeField] private float maxNotDeathAngle = 20;



    // serialized fields for UI
    [SerializeField] private TextMeshProUGUI HeightText;
    [SerializeField] private TextMeshProUGUI velocityText;

    // extra fields
    private float height;




    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;

    }


    private void Update()
    {
        cam.transform.position = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);
        height = transform.position.y + 2.1f;
        HeightText.text = "Height: " + height.ToString("0.0");
        velocityText.text = "Velocity: " + rb.velocity.y.ToString("0.0");
        /*        if (rb.angularVelocity > maxRotationSpeed)
                {
                    rb.angularVelocity = maxRotationSpeed;
                }*/
        /// Summary for above commented code: Could be used for front flips.
        if (rb.angularVelocity < -maxRotationSpeed)
        {
            rb.angularVelocity = -maxRotationSpeed;
        }
        if (rb.rotation < -360)
        {
            Rotated = true;
        }


    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddTorque(rotationSpeed);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "trampoline")
        {
            if (transform.localEulerAngles.z < 0 + maxNotDeathAngle || transform.localEulerAngles.z > 360 - maxNotDeathAngle)
            {
                throw new NotImplementedException();
            }
            else
            {
                Debug.Log("died");
                Destroy(gameObject);
            }
            if (Rotated)
            {
                rb.rotation = 0;
                Rotated = false;
                jumpSpeed += jumpSpeedMultiplier;
            }

            rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        }
    }


}
