using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 10;
    public static Player Instance;
    public VariableJoystick variableJoystick;
    private int count = 0;

    public Rigidbody rb;
    private bool checkStart;
    private List<Vector3> RemoveBrick = new List<Vector3>();
    GameObject brick;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        checkStart = true;
    }

    // Update is called once per frame

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        transform.forward = direction;
    }
    void Update()
    {
        if(checkStart) 
        {
            StateStart.Instance.OnStart();
        }
        checkStart = false;
        Move();
    }

    void Move()
    {
        OnMoveButton();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Brick")
        {
            // add brick
            if (collision.gameObject.GetComponent<Renderer>().material.color == Color.red)
            {
                // destroy & create after 3s
                Destroy(collision.gameObject);
                count++;
                RemoveBrick.Add(collision.transform.position);
                foreach (Vector3 item in RemoveBrick)
                {
                    StartCoroutine(CreateCubeAfterDelay(1f, item));
                }
                RemoveBrick.Clear();
                // add brick
                brick = GameObject.CreatePrimitive(PrimitiveType.Cube);
                var cubeRenderer = brick.GetComponent<Renderer>();
                cubeRenderer.material.SetColor("_Color", Color.red);

                brick.transform.localScale = new Vector3(1, 0.3f, 1);
                brick.transform.rotation = transform.rotation;
                brick.transform.position = transform.GetChild(0).position + new Vector3(0, 0.3f, 0) * count;
                brick.transform.SetParent(transform.GetChild(0));
            }
        }
        if (collision.gameObject.name == "Stair")
        {
            Debug.Log("Stair");
            Onbridge();
        }
        else
        {
            speed = 20;
        }
    }

    IEnumerator CreateCubeAfterDelay(float delayTime, Vector3 item)
    {
        yield return new WaitForSeconds(delayTime);
        brick = GameObject.CreatePrimitive(PrimitiveType.Cube);
        brick.transform.position = item;
        brick.transform.localScale = new Vector3(1f, 0.3f, 1f);
        var cubeRenderer = brick.GetComponent<Renderer>();
        brick.transform.name = "Brick";
        cubeRenderer.material.SetColor("_Color", Color.red);
    }
    public void OnMoveButton()
    {
        if (Input.GetKey(KeyCode.DownArrow)) { transform.Translate(Vector3.back * speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.LeftArrow)) { transform.Translate(Vector3.left * speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.RightArrow)) { transform.Translate(Vector3.right * speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.UpArrow)) { transform.Translate(Vector3.forward * speed * Time.deltaTime); }
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            Debug.Log("----Moving----");
    }
    public void Onbridge()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + transform.forward * 1f, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            if (hit.transform.name == "Stair")
            {
                speed = 45;
                if (hit.transform.GetComponent<Renderer>().material.color == Color.red)
                {
                    OnMoveButton();
                }
                else
                {
                    if (count > 0)
                    {
                        OnMoveButton();
                        hit.transform.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                        Destroy(transform.GetChild(0).transform.GetChild(count - 1).gameObject);
                        count--;
                    }
                    else
                    {
                        speed = 0;
                    }
                }
            }
        }
    }
}
