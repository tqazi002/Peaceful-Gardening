using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour
{
	public AudioSource water;
	//GameObject.Find("FPSController").GetComponent<player>().flies.SetActive(false);

    // Start is called before the first frame update
    void Start()
    {
        water = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y < 0.3){
        	this.transform.position = new Vector3( 5.6f , 1.13f , 13.3f );
        }
    }
}
