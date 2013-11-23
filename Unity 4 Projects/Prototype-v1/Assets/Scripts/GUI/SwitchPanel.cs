using UnityEngine;
using System.Collections;

public class SwitchPanel : MonoBehaviour {
	
    public GameObject currentPanelObject;
    public GameObject nextPanelObject;

	private BackendManager backendManager;

    void OnClick() {

        NGUITools.SetActive(nextPanelObject, true);
        NGUITools.SetActive(currentPanelObject, false);
    }

	void Start()
	{
		backendManager = FindObjectOfType(typeof(BackendManager)) as BackendManager; //get reference to Server-Communication GameObject
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
