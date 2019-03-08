using UnityEngine;
/// <summary>
/// this class save player preference by using PlayerPrefs class
/// saving player's best score and the selected bird
/// </summary>
public class GameController : MonoBehaviour {
    public static GameController instance;
    public GameObject SceneFader;
   

    private const string HIGH_SCORE = "High Score";
    private const string SELECTED_BIRD = "Selected Bird";


    // Use this for initialization
    private void Awake()
    {
        MakeSingleton();
        IsTheGameStartForTheFirstTime();
    }

    private void MakeSingleton()
    {
        if(instance!= null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // set the default value for the first time
    private void IsTheGameStartForTheFirstTime()
    {
        if(!PlayerPrefs.HasKey("IsTheGameStartForTheFirstTime"))
        {
            PlayerPrefs.SetInt(HIGH_SCORE, 0);
            PlayerPrefs.SetInt(SELECTED_BIRD, 0);
            PlayerPrefs.SetInt("IsTheGameStartForTheFirstTime", 0);

        }
    }

    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt(HIGH_SCORE, score);
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE);
    }

    public void SetSelectedBird(int selectedBird)
    {
        PlayerPrefs.SetInt(SELECTED_BIRD, selectedBird);
    }

    public int GetSelectedBird()
    {
        return PlayerPrefs.GetInt(SELECTED_BIRD);
    }
  
}
