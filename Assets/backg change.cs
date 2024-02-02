using UnityEngine;

public class backgchange : MonoBehaviour
{
    [SerializeField]
    private Camera main;
    [SerializeField]
    private GameObject playerpos;
    private float timeleft;

    private float height = 1065f;

    void Start()
    {
        main = GetComponent<Camera>();
        playerpos = GameObject.Find("Player");
    }

    void Update()
    {
        timeleft -= Time.deltaTime;
        backgroundcolor();
    }

    private void backgroundcolor()
    {
        if (playerpos.transform.position.y >= height)
        {

            main.backgroundColor = new Color(0f, 0.1185984f, 0.3113208f);
        }
        if (playerpos.transform.position.y <= height)
        {

            main.backgroundColor = new Color(0.6367924f, 0.7780398f, 1f);
        }


    }
}
