using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    public Animator anim;
    public void StartGame(int sceneIndex) 
    {
        anim.SetTrigger("FadeOut");
        StartCoroutine(Transition(sceneIndex));
            
    }

    private IEnumerator Transition(int scene)
    {
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene(scene);
    }
}