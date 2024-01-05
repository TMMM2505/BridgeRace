using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateMoving : MonoBehaviour
{
    [SerializeField] float speed;
    public static StateMoving Instance;

    private bool checkMoveForward;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    public void OnMove()
    {
        if (Input.GetKey(KeyCode.DownArrow)) { transform.Translate(Vector3.back * speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.LeftArrow)) { transform.Translate(Vector3.left * speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.RightArrow)) { transform.Translate(Vector3.right * speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.UpArrow)) { transform.Translate(Vector3.forward * speed * Time.deltaTime); }
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            Debug.Log("----Moving----");
        Debug.Log(checkMoveForward);
    }

    /*public void Onbridge()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + transform.forward * 1f, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            if(hit.transform.name == "Stair")
            {
                if (hit.transform.GetComponent<Renderer>().material.color == Color.red)
                {
                    speed = 10;
                    OnMove();
                }
                else
                {
                    if (Player.Instance.count > 0)
                    {
                        OnMove();
                        Debug.Log("SetRed");
                        hit.transform.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                        Destroy(transform.GetChild(0).transform.GetChild(Player.Instance.count - 1).gameObject);
                        Player.Instance.count--;
                    }
                    else
                    {
                        speed = 0;
                    }
                }
            }
        }
    }*/
}