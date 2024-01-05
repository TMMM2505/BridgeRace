using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateStart : MonoBehaviour
{
    public static StateStart Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    public void OnStart()
    {
        Player.Instance.transform.position = new Vector3(7.92999983f, 1.00000012f, 7.39603996f);
        Map.Instance.CreateMap();
    }
}
