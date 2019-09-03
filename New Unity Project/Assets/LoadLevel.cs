using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadLevel : MonoBehaviour
{
    [SerializeField] int level;
    [SerializeField] float delay;
    public Animator animator;
    public GameObject fader;

    private void Start()
    {
        StartCoroutine(ChangeLevel());
        animator = fader.GetComponent<Animator>();
    }
    IEnumerator ChangeLevel()
    {
        yield return new WaitForSeconds(delay);
        animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(level);
    }
}
