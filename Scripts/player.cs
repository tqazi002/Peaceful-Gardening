using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
	//public bool pest_control = true;
	public GameObject weeds;
	public GameObject flies;
	public Animator anim;
	private bool toggle;
	public int ten;

    // Start is called before the first frame update
    void Start()
    {
    	anim.Play("FadeIn");
        weeds.SetActive(false);
        flies.SetActive(true);
        toggle = true;
        // StartCoroutine(TimeSkip());
    }

    // Update is called once per frame
    void Update()
    {

    	GetComponent<CharacterController>().enabled = true;

   //  	if( Input.GetKeyDown("t"))
   //  	{
   //  		ten = Random.Range(1, 11);

			// // if((ten == 4) || (ten == 5) || (ten == 6)){
			// // 	  weeds.SetActive(true);
			// // }

			// GetComponent<CharacterController>().enabled = false;
   //  	}
    	
        if ( Input .GetKeyDown ( KeyCode .Escape)) {
		#if UNITY_EDITOR
		UnityEditor. EditorApplication .isPlaying = false ;
		#else
		Application.Quit();
		#endif
		}

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Grab" || collision.gameObject.tag == "hoe"|| collision.gameObject.tag == "can")
		{
			Physics.IgnoreCollision(collision.transform.GetComponent<Collider>(),GetComponent<Collider>());
		}
	}
    }
}
