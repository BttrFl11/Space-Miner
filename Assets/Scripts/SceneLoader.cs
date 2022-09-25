using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private float transitionTime;
    [SerializeField] private Animator transition;

    public void LoadScene(int index) => StartCoroutine(Load(index));
    //public void LoadScene(string name) => StartCoroutine(Load(SceneManager.GetSceneByName(name).buildIndex));

    private IEnumerator Load(int index)
    {
        if (transition != null)
            transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(index);
    }
}
