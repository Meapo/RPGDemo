using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour
{
    #region Singleton
    static public PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion
    // Start is called before the first frame update
    public GameObject player;

    public void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
