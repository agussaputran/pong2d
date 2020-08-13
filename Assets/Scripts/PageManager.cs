using UnityEngine;
using UnityEngine.SceneManagement;

public class PageManager : MonoBehaviour
{

	public void ButtonMulai()
	{
		SceneManager.LoadScene(1);
	}

	public void ButtonMenu()
	{
		SceneManager.LoadScene(0);
	}

	public void ButtonCredit()
	{
		SceneManager.LoadScene(2);
	}

	public void ExitGame()
	{
		Application.Quit();
		Debug.Log("kelaur");
	}
}
