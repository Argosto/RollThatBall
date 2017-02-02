using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    private int count;

    public Text countText;
    public float speed;
    public Text winText;
    public Particles trail;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVeritcal = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVeritcal);

        rb.AddForce(movement * speed);
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            trail.Upgrade();
        }
    }

    void SetCountText()
    {
        countText.text = "Count; " + count.ToString();
        if (count >= 16)
        {
            winText.text = "WINNER IS YOU!";
        }
    }
}
