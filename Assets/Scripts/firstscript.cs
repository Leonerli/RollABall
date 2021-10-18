using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class firstscript : MonoBehaviour
{

    private Rigidbody rb;
    private int count;
    public int speed;
    public Text countText;
    public Text winText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }


    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        speed = 0b1110;

        rb.AddForce(movement*speed);
    }

    //destroy everything that enter the trigger
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
       
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if(count >= 3)
        {
            winText.text = "You Win!";
        }
    }
 
}
