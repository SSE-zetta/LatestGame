using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private bool jumpKeywaspressed = false;
    private int space_press_count = 0;
    private float horizontal_Input;
    private Rigidbody rigidbody_component;
    [SerializeField] private Transform ground_check;
    [SerializeField] private Transform SpawnPoint;
    public GameObject level1;
    public int platformcounter = 0;
    public int life = 2;
    private bool flag = true;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody_component = GetComponent<Rigidbody>();
        level1 = GameObject.Find("Level1");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeywaspressed = true;

        }
        horizontal_Input = Input.GetAxis("Horizontal");
        //Debug.Log(GetComponent<Transform>().position.y);
        //Debug.Log(level1.GetComponent<Transform>().position.y);
        if (GetComponent<Transform>().position.y <  (level1.GetComponent<Transform>().position.y-1.0f)) {
            GetComponent<Transform>().position = SpawnPoint.transform.position;
            if (life > 1)
            {
                life = life - 1;
            }
            else
            {
                SceneManager.LoadScene(2);
            }
        }
        Debug.Log(GetComponent<Rigidbody>().velocity.y);
        if(((GetComponent<Rigidbody>().velocity.y==-0.0003206879f)||(GetComponent<Rigidbody>().velocity.y == -0.0003112555f)|| (GetComponent<Rigidbody>().velocity.y == 0.00066109f) ||(GetComponent<Rigidbody>().velocity.y == 0.0006479472f)) && (GetComponent<Rigidbody>().velocity.x < 0))
        {
            if (life > 1)
            {
                life = life - 1;
            }
            else {
                SceneManager.LoadScene(2);
            }
            GetComponent<Transform>().position = SpawnPoint.transform.position;
        }
    }

    private void FixedUpdate()
    {
        rigidbody_component.velocity = new Vector3(3 * horizontal_Input, rigidbody_component.velocity.y, 0);
        //Debug.Log(Physics.OverlapSphere(ground_check.position, 0.1f).Length);
        //Debug.Log(space_press_count);
        if (Physics.OverlapSphere(ground_check.position, 0.1f).Length == 1)
        {
            if (flag == true)
            {
                if (jumpKeywaspressed && space_press_count < 3 && rigidbody_component.velocity.y < 0)
                {
                    rigidbody_component.AddForce(Vector3.up * 10, ForceMode.VelocityChange);
                    jumpKeywaspressed = false;
                    space_press_count = space_press_count + 1;
                }
                else
                {
                    jumpKeywaspressed = false;
                }



                if (jumpKeywaspressed && space_press_count < 3 && rigidbody_component.velocity.y > 0)
                {
                    rigidbody_component.AddForce(Vector3.up * 7, ForceMode.VelocityChange);
                    jumpKeywaspressed = false;
                    space_press_count = space_press_count + 1;
                }
                else
                {
                    jumpKeywaspressed = false;
                }
            }
            else
            {
                if (jumpKeywaspressed && space_press_count < 2 && rigidbody_component.velocity.y < 0)
                {
                    rigidbody_component.AddForce(Vector3.up * 10, ForceMode.VelocityChange);
                    jumpKeywaspressed = false;
                    space_press_count = space_press_count + 1;
                }
                else
                {
                    jumpKeywaspressed = false;
                }


                if (jumpKeywaspressed && space_press_count < 2 && rigidbody_component.velocity.y > 0)
                {
                    rigidbody_component.AddForce(Vector3.up * 7, ForceMode.VelocityChange);
                    jumpKeywaspressed = false;
                    space_press_count = space_press_count + 1;
                }
                else
                {
                    jumpKeywaspressed = false;
                }
            }
        }
        else
        {
            space_press_count = 0;
            if (jumpKeywaspressed)
            {
                flag = false;
                rigidbody_component.AddForce(Vector3.up * 7, ForceMode.VelocityChange);
                jumpKeywaspressed = false;
                space_press_count = space_press_count + 1;
            }
        }



    }
}
