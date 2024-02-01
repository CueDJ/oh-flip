using TMPro;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float speedMultiplier = 1f;
    private Camera cam;
    [SerializeField] private TextMeshProUGUI HeightText;
    private float height;
    [SerializeField] private TextMeshProUGUI velocityText;

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
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "trampoline")
        {
            speed += speedMultiplier;
            rb.AddForce(new Vector2(0, speed), ForceMode2D.Impulse);
        }
    }
}
