using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swapTextures : MonoBehaviour {
    public Texture[] textures;
    public int currentTexture;
    private int updated = 0;

	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
		if( updated ==0  )
        {
            currentTexture = Random.Range(0, 10);
            Renderer m_renderer = GetComponent<Renderer>();
            m_renderer.material.mainTexture = textures[currentTexture];
            updated = 1;
        }
    }
}
