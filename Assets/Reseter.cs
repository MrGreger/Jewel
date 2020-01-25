using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reseter : MonoBehaviour
{
    public void ResetWorld()
    {
        print("lol");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
