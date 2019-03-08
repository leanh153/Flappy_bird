using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
// this class is scene fader while moving between 2 scene
public class SceneFader : MonoBehaviour {
    public static SceneFader instance;

    [SerializeField]
    private GameObject fadeCanvas;
    [SerializeField]
    private Animator fadeAnim;

    private void Awake()
    {
        MakeSingleton();
    }

    void MakeSingleton()
    {
    if(instance!=null)
        {
            Destroy(gameObject);
        }else
        {
            instance = this;
            // use this game object for all scene
            DontDestroyOnLoad(gameObject);
        }
    }

    public void FadeIn(int levelIndex)
    {
        StartCoroutine(FadeInAnimation(levelIndex));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutAnimation());
    }

    private IEnumerator FadeOutAnimation()
    {
        
        fadeAnim.Play("FadeOut");
        yield return StartCoroutine(new WaitForSecondsRealtime(.7f));
        fadeCanvas.SetActive(false);

    }

    private IEnumerator FadeInAnimation(int levelIndex)
    {
        // start fading set active true the canvas
        fadeCanvas.SetActive(true);
        // play the anim fadein
        fadeAnim.Play("FadeIn");
        // wait 0.7 second 
        yield return StartCoroutine(new WaitForSecondsRealtime(.7f));
        // load the new scene use SceneManager
        SceneManager.LoadScene(levelIndex);
        FadeOut();
    }
}
