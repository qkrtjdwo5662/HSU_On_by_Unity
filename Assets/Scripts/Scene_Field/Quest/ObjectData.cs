using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectData : MonoBehaviour
{
    // Start is called before the first frame update
    public int id;
    public bool isNpc;
    public Image image;
    public Text text;
	public Camera MainCamera;
	
	/*void Start()
	{

		MainCamera = Camera.main;
	}

    void Update()
    {
		Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit))
		{
			Debug.Log(hit.transform.gameObject);

			/*if (hit.transform.gameObject.id = "100")
			{
				

			}
		}
	}
	*/
   
       
}
