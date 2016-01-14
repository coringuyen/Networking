using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Exit : MonoBehaviour {

    public Button exit;
	void Start ()
    {
        exit.GetComponent<RectTransform>().position = new Vector3(Screen.width * 0.8f, Screen.height * 0.9f, 0);

        exit.gameObject.SetActive(true);	
	}
	
	public void ExitApplication()
    {
        Application.Quit();
    }
}
