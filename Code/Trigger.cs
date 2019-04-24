using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
	public GameObject can;
	Renderer rend;
	public Material[] material;
	public Animator anim;

	public AudioSource till;
	public GameObject pumpkin_baby;
	public GameObject pumpkin_plant;
	public GameObject pumpkin_fruit;
	public bool watered = false;
	public bool hoed = false;
	public int count = 1;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        till = GetComponent<AudioSource>();
        
        pumpkin_baby.SetActive(false);
        pumpkin_plant.SetActive(false);
        pumpkin_fruit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    	if(OVRInput.GetDown(OVRInput.Button.Three))
    	{
    		StartCoroutine(TimeSkip());
    	}
    }

    IEnumerator TimeSkip()
    {
		anim.Play("FadeOut");
		yield return new WaitForSeconds(1);


	        if((count == 1) && (watered == true) && (hoed == true))
			{
				pumpkin_baby.SetActive(true);
				count++;
				watered = false;
				rend.sharedMaterial = material[1];
			}
			else if((count == 2) && (watered == true))
			{
				pumpkin_plant.SetActive(true);
				pumpkin_baby.SetActive(false);
				count++;
				watered = false;
				rend.sharedMaterial = material[1];
			}
			else if((count == 3) && (watered == true)){
				pumpkin_fruit.SetActive(true);
				pumpkin_plant.SetActive(false);
				watered = false;
				rend.sharedMaterial = material[1];
			}
			
		yield return new WaitForSeconds(2);
		anim.Play("FadeIn");
    }

    void OnTriggerStay(Collider other){
    	if (other.GetType () == typeof(SphereCollider)) {
    		if((other.tag == "can") && (can.transform.rotation.eulerAngles.x > 50 && can.transform.rotation.eulerAngles.x < 180)){
    			if(hoed == false){
    				rend.sharedMaterial = material[3];
    			}
    			else{
    				rend.sharedMaterial = material[2];
    			}
    			//GameObject.FindGameObjectWithTag("can").GetComponent<WateringCan>().water.Play();
    			watered = true;
    			
    		}
    	}
	}

	void OnTriggerExit(Collider other){
		if (other.GetType () == typeof(SphereCollider)) {
			//water.Pause();
			GameObject.FindGameObjectWithTag("can").GetComponent<WateringCan>().water.Pause();
		}
	}

    void OnTriggerEnter(Collider other){
    	if (other.GetType () == typeof(BoxCollider)) {
    		if(other.tag == "hoe"){
    			if(watered == false){
    				rend.sharedMaterial = material[1];
    			}
    			else{
    				rend.sharedMaterial = material[2];
    			}
    			till.Play();
    			hoed = true;
    		}
    	}

    	if (other.GetType () == typeof(SphereCollider)) {
    		if((other.tag == "can") && (can.transform.rotation.eulerAngles.x > 50 && can.transform.rotation.eulerAngles.x < 180)){
    			GameObject.FindGameObjectWithTag("can").GetComponent<WateringCan>().water.Play();
    		}
    	}
	}
}
