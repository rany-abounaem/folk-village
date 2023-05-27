using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private int _mainSceneIndex;

    [SerializeField]
    private Animator _coverAnimator;

    public IEnumerator LoadMainScene()
    {
        _coverAnimator.SetTrigger("LoadScene");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(_mainSceneIndex);
    }
}
