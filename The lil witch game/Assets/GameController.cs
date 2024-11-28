using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
 public void start(){
    SceneManager.LoadScene(1, LoadSceneMode.Single);
 }
 public void quit(){
    Application.Quit();
 }

 private void Update() {
    if (Input.GetKey("escape")){
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
 }
}
