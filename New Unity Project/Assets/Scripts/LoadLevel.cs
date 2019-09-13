using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadLevel : MonoBehaviour
{
    [SerializeField] int level;
    [SerializeField] float delay;
    [SerializeField] SweepTransition transition;
    [SerializeField] bool onStart;
    private void Start()
    {
        if(onStart)
            StartCoroutine(ChangeLevel());
    }
    public void Run()
    {
        StartCoroutine(ChangeLevel());
    }
    IEnumerator ChangeLevel()
    { 
        yield return new WaitForSeconds(delay-0.5f);
        transition.TransitionOut();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(level);
    }
}
