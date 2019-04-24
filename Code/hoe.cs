using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y < 0.3){
        	this.transform.position = new Vector3( 5.89f , 1.3f , 14.059f );
        }
    }
}
