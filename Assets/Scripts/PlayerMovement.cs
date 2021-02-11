using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float turboSpeed;
    Renderer color;
    public int bookTaken;
    GameObject newPosition;
    Rigidbody myBody;
    public Transform catchPlace;
    public int lifes;

    public void Start()
    {
       color = gameObject.GetComponent<Renderer>();
       bookTaken = 0;
       newPosition = GameObject.FindGameObjectWithTag("positionandtransformplayer");
       myBody = GetComponent<Rigidbody>();
       lifes = 3;
    }
    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

 
        if (Input.GetKey("w"))
        {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * speed;
        }
        else if (Input.GetKey("s"))
        {
            transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * speed;
        }
        if(Input.GetKey("a") && ! Input.GetKey("d"))
        {
            transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * speed;
        }
        else if (Input.GetKey("d") && !Input.GetKey("a"))
        {
            transform.position -= transform.TransformDirection(Vector3.left) * Time.deltaTime * speed;
        }

        if (bookTaken == 3 || lifes ==0)
        {
            Time.timeScale = 0.0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "book" || other.gameObject.tag == "evilBook")
        {
            ChangeColor(new Color(0.7735849f, 0.2607722f, 0.2371841f));

            if (lifes > 0)
            {
                lifes -= 1;
            }
        }
        if (other.gameObject.tag == "magicBook")
        {
            bookTaken += 1;
            Destroy(other.gameObject);

            if (bookTaken == 2)
            {
                gameObject.transform.position = newPosition.transform.position;
            }
        }

        if (other.gameObject.tag == "enemy")
        {
            if (lifes > 0)
            {
                lifes -= 1;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "book")
        {
            ChangeColor(Color.white);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "evilBook")
        {
            ChangeColor(Color.white); 
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "evilBook" || other.gameObject.tag == "catchBook")
        {
            ChangeColor(new Color(1f, 0.4980392f, 0.3137255f));

            if (Input.GetKey(KeyCode.Space))
            {
                other.transform.position = catchPlace.position;
                other.transform.parent = GameObject.Find("playerHands").transform;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                other.transform.parent = null;
                other.GetComponent<Rigidbody>().velocity = transform.up * 4;
            }
        }
    }

    void ChangeColor(Color col)
    {
        color.material.SetColor("_Color", col);
    }

}
