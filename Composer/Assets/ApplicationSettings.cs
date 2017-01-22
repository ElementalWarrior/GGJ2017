using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationSettings {

    private static ApplicationSettings _instance;
    public string Name;
    //private void Awake()
    //{
    //    if (_instance == null)
    //    {
    //        DontDestroyOnLoad(this);
    //        _instance = this;
    //    }
    //}
    public static ApplicationSettings Instance()
    {
        if (_instance == null)
        {
            _instance = new ApplicationSettings();
            _instance.Name = SceneManager.GetActiveScene().name;
        }
        Debug.Log(_instance.Name);
        return _instance;
    }
}
