using UnityEngine;
/// <summary>
/// this class change the bird color, and change the player preference too
/// </summary>
public class Menucontroller : MonoBehaviour {
    public static Menucontroller instance;
    [SerializeField]
    private GameObject[] birds;
    

    // Use this for initialization
    private void Awake()
    {
        MakeInstance();
    }

    void Start () {
        // time scale ==1 play state
        // this use time scale to stop and play game
        Time.timeScale = 1;
        birds[GameController.instance.GetSelectedBird()].SetActive(true);
       
	}

   public void PlayGame()
    {
        SceneFader.instance.FadeIn(1);
    }

    private void MakeInstance()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

  

    public void ChangeBird()
    {
        if (GameController.instance.GetSelectedBird() == 0)
        {
            // Handle logic when the bird (case index equal 0)
            birds[GameController.instance.GetSelectedBird()+1].SetActive(true);
            birds[2].SetActive(false);
            birds[0].SetActive(false);
            GameController.instance.SetSelectedBird(1);


        } else if (GameController.instance.GetSelectedBird() == 1)
        {
            // Handle logic when the bird (case index equal 1)
            birds[GameController.instance.GetSelectedBird() + 1].SetActive(true);
            birds[0].SetActive(false);
            birds[1].SetActive(false);
            GameController.instance.SetSelectedBird(2);

        } else if (GameController.instance.GetSelectedBird() == 2)
        {
            // Handle logic when the bird (case index equal 2)
            birds[GameController.instance.GetSelectedBird()-2].SetActive(true);
            birds[1].SetActive(false);
            birds[2].SetActive(false);
            GameController.instance.SetSelectedBird(0);

        }
    }


}
