using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fox_Save : MonoBehaviour
{
    [SerializeField] TMP_Text saveWarning;
    //Получаем позицию игрока(добавим в следующем этапе)
    public void SavePosition(Vector3 playerPos)
    {
        //сохраняем позиции персонажа по всем осям в различные ячейки
        PlayerPrefs.SetFloat("posX", playerPos.x);
        PlayerPrefs.SetFloat("posY", playerPos.y);
        PlayerPrefs.SetFloat("posZ", playerPos.z);
        //сохраняем полученные данные
        PlayerPrefs.Save();
        saveWarning.text = "The save was successful!";
        Invoke("DeleteText", 2f);
    }

    void DeleteText()
    {
        saveWarning.text = "";
    }
    private void OnTriggerEnter(Collider other)
    {
        //если триггер портала пересек объект с тегом Player, то...
        if(other.CompareTag("Player"))
        {
            //Запоминаем позицию объекта и передаем её в метод SavePosition
            Vector3 pos = other.transform.position;
            SavePosition(pos);            
        }
    }
}
