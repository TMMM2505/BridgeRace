using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    //[SerializeField] GameObject brick;
    //[SerializeField] GameObject barrier;
    GameObject brick;
    GameObject barrier;
    public static Bridge Instance;

    public List<GameObject> Wall = new List<GameObject>();
    public List<GameObject> Stair = new List<GameObject>();
    private Vector3 origin = new Vector3(7.49f, 0.13f, 22.55f);
    void Start()
    {
        Instance = this;
        BuildBrigde();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BuildBrigde()
    {
        Vector3 x = new Vector3(0, 1f, 1f);
        int i = 0;
        for(i = 0; i < 20; i++)
        {
            brick = GameObject.CreatePrimitive(PrimitiveType.Cube);
            brick.name = "Stair";
            brick.transform.position = origin + x * i;
            brick.transform.rotation = Quaternion.Euler(314.630005f, 0, 0);
            brick.transform.SetParent(transform);
            brick.transform.localScale = new Vector3(6.05000019f, 0.300000012f, 1.63999999f);
            Stair.Add(brick);

/*            barrier = GameObject.CreatePrimitive(PrimitiveType.Cube);
            barrier.transform.position = origin + x * i;
            barrier.name = "Barrier";
            barrier.transform.localScale = new Vector3(6.19999981f, 5.30000019f, 1f);
            barrier.transform.SetParent(transform);
            Destroy(barrier.transform.GetComponent<MeshRenderer>());
            Wall.Add(barrier);*/
        }
        i = 0;
        /*foreach(GameObject t in Wall)
        {
            Instantiate(t, origin + x * i, Quaternion.identity);
            i++;
        }
        i = 0;  
        foreach(GameObject t in Stair)
        {
            Instantiate(t, origin + x * i, Quaternion.Euler(314.630005f, 0, 0));
            i++;
        }*/
    }

    public int getLengthWall()
    {
        return Wall.Count;
    }
}
