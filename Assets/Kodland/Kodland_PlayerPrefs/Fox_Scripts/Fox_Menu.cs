using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fox_Menu : MonoBehaviour
{
    //Ссылка на кнопку загрузки игры
    [SerializeField] Button loadButton;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        //Проверяем есть ли у нас сохранение и если да, то делаем кнопку загрузки активной
        if (PlayerPrefs.HasKey("posX"))
        {
            loadButton.interactable = true;
        }
    }
    //Функция для новой игры
    public void StartNewGame()
    {
        //Проверяем есть ли сохранение, и если да, то удаляем все ячейки сохранений и запускаем игру
        if(PlayerPrefs.HasKey("posX"))
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("Game");
        }
        //Иначе просто запускаем игру
        else
        {
            SceneManager.LoadScene("Game");
        }
    }
    //Функция для загрузки игры с сохранениями
    public void LoadGame()
    {
        //Если есть сохранения, то запускаем игру
        if (PlayerPrefs.HasKey("posX"))
        {
            SceneManager.LoadScene("Game");     
        }
    }    
}
