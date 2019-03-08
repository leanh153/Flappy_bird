using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// this class contain almost UI for the level 1 scene
/// using Time.timeScale to pause and play game
/// </summary>
public class GamePlayerController : MonoBehaviour
{
    public static GamePlayerController instance;    
    public Text scoreText, endScoreText, bestScoreText, gameOverText;    
    public Button instructionButton;    
    public GameObject pausePanel;    
    public GameObject[] birds;    
    public Sprite[] medalsSprite;   
    public Image medalImage;
    public int score;
    private int lastBesScore;
   

    // Use this for initialization
    private void Awake()
    {
        MakeIntance();
        Time.timeScale = 0;
        score = 0;
        lastBesScore = GameController.instance.GetHighScore();
    }

    private void MakeIntance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }
   
    public void PauseGame()
    {
        if (BirdScripts.instance != null)
        {
            if (BirdScripts.instance.isAlive)
            {
                // Handle game's pause
                Time.timeScale = 0;
                // set active the pause panal and set all its value
                pausePanel.SetActive(true);
                endScoreText.text = score.ToString();
                bestScoreText.text = lastBesScore.ToString();
                if (lastBesScore <= 20)
                {
                    // white medal
                    medalImage.sprite = medalsSprite[0];
                }
                else if (lastBesScore > 20 && lastBesScore < 40)
                {
                    // brozen medal
                    medalImage.sprite = medalsSprite[1];

                }
                else
                {
                    // gold medal
                    medalImage.sprite = medalsSprite[2];

                }
            }
        }
    }

    public void GotoMainMenu()
    {
        // loading scene MainMene
        SceneFader.instance.FadeIn(0);
    }

    public void ResumeGame()
    {
        // Handle game's resume
        if (BirdScripts.instance.isAlive)
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            
        }
    }

    public void RestartGame()
    {
        // Handle Game's restart
        if (!BirdScripts.instance.isAlive)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(1);

        }

    }

    public   void PlayGame()
    {
        // Handle game's play
        Time.timeScale = 1;
        scoreText.gameObject.SetActive(true);        
        instructionButton.gameObject.SetActive(false);
        // enable the bird object based on Selected bird 
        birds[GameController.instance.GetSelectedBird()].SetActive(true);
    }

    public void SetScrore()
    {    
        // display score
            score++;
            scoreText.text = score.ToString();
    }

    // this show score if player dead, and set new score to player preference
    public void PlayerDeadShowScore()
    {
        Time.timeScale = 0;
        // display Game over text
        gameOverText.gameObject.SetActive(true);
        // display pause panel and set its detail for current time
        pausePanel.SetActive(true);
        endScoreText.text = score.ToString();
        
        if (lastBesScore < score)
        {
            // change new best Score if player get new height score
            GameController.instance.SetHighScore(score);
            bestScoreText.text = score.ToString();

        }
        else
        {
            bestScoreText.text = lastBesScore.ToString();
        }
        
       

        // set medal based on current score
        if (score <= 20)
        {
            medalImage.sprite = medalsSprite[0];
        }
        else if (score > 20 && score < 40)
        {
            medalImage.sprite = medalsSprite[1];

        }
        else
        {
            medalImage.sprite = medalsSprite[2];

        }
    }

   
}
