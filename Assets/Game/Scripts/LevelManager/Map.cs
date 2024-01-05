using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Map : MonoBehaviour
{
    public static Map Instance;
    [SerializeField] TextAsset textMap;
    GameObject brick;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    /*int[,] Convert()
    {
        string data = textMap.text;
        string[] data2 = data.Split("\r\n");

        int row = data2.Length;
        int col = data2[0].Split(",").Length;

        int[,] map = new int[row, col];

        for (int i = 0; i < row - 1; i++)
        {
            if (data2.Length > 0)
            {
                string[] data3 = data2[i].Split(",");
                col = data3.Length;

                for (int j = 0; j < data3.Length - 1; j++)
                {
                    map[i, j] = int.Parse(data3[j]);
                }
            }
        }
        return map;
    }
*/
    /*public void BuildMap()
    {
        int[,] map;
        map = Convert();
        System.Random r = new System.Random();
        for(int i = 0; i < 13; i+=2)
        {
            for(int j = 0; j < 13; j+=2) 
            {
                if (i != 0 || j != 0)
                {
                    map[i, j] = r.Next(0, 2);
                    CreateBrick(map[i, j], i ,j);
                }
            }
        }
    }

    // Update is called once per frame

    public void CreateBrick(float x, float i, float k)
    {

        brick = GameObject.CreatePrimitive(PrimitiveType.Cube);
        var cubeRenderer = brick.GetComponent<Renderer>();
        brick.transform.position = new Vector3(i, 0.1f, k);
        brick.transform.localScale = new Vector3(1, 0.3f, 1);
        if (x == 1)
        {
            brick.gameObject.name = "Green";
            cubeRenderer.material.SetColor("_Color", Color.green);
        }
        else if(x == 0) 
        {
            brick.gameObject.name = "Blue";
            cubeRenderer.material.SetColor("_Color", Color.blue);
        }
    }*/

/*    public void makeBride()
    {
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(Player.Instance.transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            RaycastHit _hit = new RaycastHit();
            
        }
        if ((hit.transform.name != null) && Physics.Raycast(Player.Instance.transform.position + new Vector3(1f, 0, 0), transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            brick = GameObject.CreatePrimitive(PrimitiveType.Cube);
            brick.transform.position = hit.transform.position + new Vector3(0, 0, 1f);
            brick.transform.SetParent(hit.transform);
        }
    }
*/
    public void CreateMap()
    {
        System.Random r = new System.Random();
        int red = 0, blue = 0, yellow = 0, grey = 0;
        for (int i = 0; i < 20; i+=2)
            for (int j = 0; j < 20; j+=2)
            {
                brick = GameObject.CreatePrimitive(PrimitiveType.Cube);
                var cubeRenderer = brick.GetComponent<Renderer>();
                brick.transform.name = "Brick";
                brick.transform.localScale = new Vector3(1f, 0.3f, 1f);
                brick.transform.position = new Vector3(i, 0, j);
                int t = r.Next(0, 4);
                if (t == 0)
                {
                    if (red <= 20)
                    {
                        cubeRenderer.material.SetColor("_Color", Color.red);
                        red++;
                    }
                }
                else if (t == 1)
                {
                    if (blue <= 20)
                    {
                        blue++;
                        cubeRenderer.material.SetColor("_Color", Color.blue);
                    }
                }
                else if (t == 2)
                {
                    if (yellow <= 20)
                    {
                        yellow++;
                        cubeRenderer.material.SetColor("_Color", Color.yellow);
                    }
                }
                else if (t == 3)
                {
                    if (grey <= 20)
                    {
                        grey++;
                        cubeRenderer.material.SetColor("_Color", Color.gray);
                    }
                }
            }
    }
}



/*
 * [SerializeField] protected GameObject brick;
    [SerializeField] TextAsset[] TextMap = new TextAsset[100];
    public static MakeMap Instance;
    public Vector3 SPoint, EPoint;

    private int indexMap;
    int[,] map;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    int[,] Convert(TextAsset mapText)
    {
        string data = mapText.text;
        string[] data2 = data.Split("\r\n");

        int row = data2.Length;
        int col = data2[0].Split(",").Length;

        int[,] map = new int[row, col];

        for (int i = 0; i < row - 1; i++)
        {
            if (data2.Length > 0)
            {
                string[] data3 = data2[i].Split(",");
                col = data3.Length;

                for (int j = 0; j < data3.Length - 1; j++)
                {
                    map[i, j] = int.Parse(data3[j]);
                }
            }
        }
        return map;
    }
    public void GenMap()
    {
        indexMap = Player.Instance.getIndexMap();
        map = Convert(TextMap[indexMap]);
        SPoint = new Vector3(0, 0, 0);
        for (int z = 0; z < 8; z++)
        {
            for (int i = 0; i < 8; i++)
            {
                brick = GameObject.CreatePrimitive(PrimitiveType.Cube);
                var cubeRenderer = brick.GetComponent<Renderer>();
                if (map[z, i] == 1)
                {
                    brick.gameObject.name = "Brick";
                    cubeRenderer.material.SetColor("_Color", Color.green);
                    brick.transform.position = new Vector3(i, 0, z);
                }
                else if (map[z, i] == -1)
                {
                    brick.gameObject.name = "UnBrick";
                    cubeRenderer.material.SetColor("_Color", Color.red);
                    brick.transform.position = new Vector3(i , 0, z);
                }
                else if (map[z, i] == 3)
                {
                    brick.gameObject.name = "Start";
                    cubeRenderer.material.SetColor("_Color", Color.blue);
                    brick.transform.position = new Vector3(i, 0, z);
                    SPoint = new Vector3(i, 1.55f, z);
                }
                else if (map[z, i] == 2)
                {
                    brick.gameObject.name = "End";
                    cubeRenderer.material.SetColor("_Color", Color.yellow);
                    brick.transform.position = new Vector3(i, 0, z);
                    EPoint = new Vector3(i, 1.55f, z);
                }
            }
        }
    }
 */