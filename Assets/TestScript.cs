using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// amggap scene loader
public class TestScript : MonoBehaviour
{
    [SerializeField]
    private List<string> _sceneToLoad;

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(_sceneToLoad[sceneIndex]);
    }
}

