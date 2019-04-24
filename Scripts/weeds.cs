using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weeds : MonoBehaviour
{
	public GameObject weed;

    // Start is called before the first frame update
    void Start()
    {
        weed.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    	GetComponent<CharacterController>().enabled = true;

    	if( Input.GetKeyDown("t"))
    	{
    		//int ten = Random.Range(1, 11);

			if((GameObject.Find("FPSController").GetComponent<player>().ten == 4) || (GameObject.Find("FPSController").GetComponent<player>().ten == 5) || (GameObject.Find("FPSController").GetComponent<player>().ten == 6)){
				weed.transform.position = new Vector3( 10.43418f , 0.6027374f , -6.926197f );
				weed.SetActive(true);
			}

			GetComponent<CharacterController>().enabled = false;

    		// anim.Play("FadeInOut");
    		// if(toggle) {
	    		// StartCoroutine(TimeSkip());
	    		// yield return new WaitForSeconds(1);
    			// toggle = false;
    		// } else {
	    		// anim.Play("FadeOut");
    			// toggle = true;
    		// }
    	}

        if(this.transform.position.y < 0.3){
        	weed.SetActive(false);
        }
    }
}
