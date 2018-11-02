using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner_scene1 : MonoBehaviour
{
    public Transform eyePosition;
    public GameObject spawnee;
    public GameObject canvas;

    public GameObject lineGerneratorPrefab;

    private static float height = 30.0f;
    private static float width = 70.0f;
    private static float distanceFromEye = 20.0f;

    // positions for the number
    private double[,] pos = new double[,] {{0, 0.3,  0.6, 0.8,  1 },
                                           {0, 0.1,  0.4, 0.76, 1},
                                           {0, 0.15, 0.6, 0.84, 1},
                                           {0, 0.3,  0.5, 0.6,  1 },
                                           {0, 0.15, 0.6, 0.84, 1 },
                                           {0, 0.15, 0.6, 0.84, 1 },
                                           {0, 0.15, 0.6, 0.84, 1 },
                                           {0, 0.15, 0.6, 0.84, 1 },};

    // offset location from the eye position
    private Vector3 offset = new Vector3(width / 2.0f, -height / 2.0f, distanceFromEye);

    // Use this for initialization
    void Start()
    {

        GameObject newLineGen = Instantiate(lineGerneratorPrefab);
        LineRenderer lRend = newLineGen.GetComponent<LineRenderer>();

        lRend.positionCount = pos.Length;
        int index = 0;

        for (int i = 0; i < pos.GetLength(0); i++)
        {
            for (int j = 0; j < pos.GetLength(1); j++)
            {
                // new number cube location diff from offset
                Vector3 vec = new Vector3(-width * (float)pos[i, j], height * i / pos.GetLength(0), 0.0f);
                // final position after add all adjustment.
                Vector3 newPos = eyePosition.position + vec + offset;

                GameObject projectile = Instantiate(spawnee, newPos, eyePosition.rotation);
                projectile.transform.rotation = Quaternion.Euler(0, 0, 180);

                projectile.name = index.ToString();
                projectile.transform.parent = canvas.transform;

                lRend.SetPosition(index, newPos);
                index++;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

        }

    }
}
