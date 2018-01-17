using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class MainMenu : MonoBehaviour {

	public TMP_Dropdown resolutionDropDown;

	Resolution[] resolutions;

	void Start()
	{
		FindResolutions ();
	}

	public void PlayGame()
	{
		Debug.Log ("Play a game");
	}

	public void QuitGame()
	{
		Application.Quit ();
	}

	public void SetFullscreen(bool isFullScreen)
	{
		Screen.fullScreen = isFullScreen;
	}

	public void SetResolution(int index)
	{
		Resolution res = resolutions [index];
		Screen.SetResolution (res.width, res.height, Screen.fullScreen);
	}

	void FindResolutions()
	{
		resolutions = Screen.resolutions;
		resolutionDropDown.ClearOptions ();

		List<string> options = new List<string> ();


		int currentResolutionIndex = 0;
		for (int i = 0; i < resolutions.Length; i++)
		{
			string option = resolutions[i].width + " x " + resolutions[i].height + " (" + resolutions[i].refreshRate + ")";

			if (!options.Contains (option))
			{
				options.Add (option);
			}

			if (resolutions [i].width == Screen.currentResolution.width && 
				resolutions[i].height == Screen.currentResolution.height)
			{
				currentResolutionIndex = i;
			}
		}

		resolutionDropDown.AddOptions (options);
		resolutionDropDown.value = currentResolutionIndex;
		resolutionDropDown.RefreshShownValue ();

	}

}
