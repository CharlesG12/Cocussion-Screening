using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner_scene2 : MonoBehaviour {
    public Transform eyePosition;
    public GameObject spawnee;
    public GameObject canvas;
    public Texture[] textures;

    public GameObject lineGerneratorPrefab;

    private static float height = 30.0f;
    private static float width = 70.0f;
    private static float distanceFromEye = 20.0f;

    // positions for the number
    private double[,] pos = new double[,] {{0, 0.3,  0.56, 0.73,  1 },
                                           {0, 0.15,  0.4, 0.73, 1},
                                           {0, 0.24, 0.57, 0.79, 1},
                                           {0, 0.3,  0.53, 0.69,  1 },
                                           {0, 0.17, 0.45, 0.73, 1 },
                                           {0, 0.3, 0.52, 0.77, 1 },
                                           {0, 0.15, 0.42, 0.68, 1 },
                                           {0, 0.33, 0.61, 0.75, 1 },};

    // offset location from the eye position
    private Vector3 offset = new Vector3(width/2.0f, -height/2.0f, distanceFromEye);

	// Use this for initialization
	void Start () {
        for ( int i = 0; i < pos.GetLength(0); i++ )
        {
            GameObject newLineGen = Instantiate(lineGerneratorPrefab);
            LineRenderer lRend = newLineGen.GetComponent<LineRenderer>();
            lRend.positionCount = pos.GetLength(1);
            int index = 0;

            for ( int j = 0; j < pos.GetLength(1); j++ )
            {
                // new number cube location diff from offset
                Vector3 vec = new Vector3(-width*(float)pos[i,j], height*i/pos.GetLength(0), 0.0f);
                // final position after add all adjustment.
                Vector3 newPos = eyePosition.position + vec + offset;

                GameObject projectile = Instantiate(spawnee, newPos, eyePosition.rotation);
                projectile.transform.rotation = Quaternion.Euler(0, 0, 180);

                projectile.name = index.ToString();
                projectile.transform.parent = canvas.transform;

                // randomly select texture
                int currentTexture_index = Random.Range(0, 10);
                projectile.GetComponent<Renderer>().material.mainTexture = textures[currentTexture_index];

                lRend.SetPosition(index, newPos);
                index++;
            }
        }

    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetMouseButtonDown(0))
        {

        }
		
	}
}
