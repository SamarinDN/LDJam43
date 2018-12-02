using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverWindow : MonoBehaviour {
	[SerializeField] private Button _restartButton;
	[SerializeField] private Text _messageField;

	private void Start() {
		_restartButton.onClick.AddListener(Restart);
		EventManager.OnLose += ShowWindow;
		gameObject.SetActive(false);
	}

	private void ShowWindow() {
		gameObject.SetActive(true);
		_messageField.text = "Game over\n" +
			"You score : " + GameParameters.Instance.GameScore;
	}

	private void Restart() {
		EventManager.RestartGame();
		gameObject.SetActive(false);
	}
}
