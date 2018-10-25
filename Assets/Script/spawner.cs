using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {
    public Transform spawnPos;
    public GameObject spawnee;

    private float height = 60;
    private float width = 60;

    // positions for the number
    private double[,] pos = new double[,] {{0, 0.6, 1.2, 1.6, 2 },
                                           {0, 0.2, 0.8, 1.52, 2},
                                           {0, 0.3, 1.2, 1.68, 2 },
                                           {0, 0.6, 0.1, 1.2, 2 } };

    // offset location from the eye position
    private Vector3 offset = new Vector3(-15.0f, -5.0f, 20.0f);

	// Use this for initialization
	void Start () {
        
        for( int i = 0; i < pos.GetLength(0); i++ )
        {
            for( int j = 0; j < pos.GetLength(1); j++ )
            {
                // new number cube location diff from offset
                Vector3 vec = new Vector3(width*(float)pos[i,j], height*i/pos.GetLength(0), 0.0f);
                // final position after add all adjustment.
                Vector3 newPos = spawnPos.position + vec + offset;

                GameObject projectile = Instantiate(spawnee, newPos, spawnPos.rotation);
                projectile.transform.rotation = Quaternion.Euler(0, 0, 180);

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
