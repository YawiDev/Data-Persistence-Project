using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenu : MonoBehaviour
{
    [SerializeField] Text highScoreText;
    [SerializeField] InputField playerNameEnterField;

    void Start () {
        DataManager.Instance.LoadHighScoreData();

        if (DataManager.Instance.highScore > 0)
            highScoreText.text = "Best Score : " + DataManager.Instance.highScorePlayerName + " : " + DataManager.Instance.highScore;
        else
            highScoreText.text = "Best Score : N/A";
    }

    public void StartGame () {
        if (playerNameEnterField.text == "")
            DataManager.Instance.playerName = "Player";
        else
            DataManager.Instance.playerName = playerNameEnterField.text;

        SceneManager.LoadScene(1);
    }

    public void Quit () {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
