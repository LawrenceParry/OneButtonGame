using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadLevel : MonoBehaviour
{
    [SerializeField] int level;
    [SerializeField] float delay;
    private void Start()
    {
        StartCoroutine(ChangeLevel());
    }
    IEnumerator ChangeLevel()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(level);
    }
}
