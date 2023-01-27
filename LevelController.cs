using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public void lvl1()

    {
        SceneManager.LoadScene("lvl1");
    }

    public void lvl2()

    {
        SceneManager.LoadScene("lvl2");
    }
}
