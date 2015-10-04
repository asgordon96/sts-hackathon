using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour {
	public void startGame(string buttonID) {
		Application.LoadLevel (1);
	}
}
