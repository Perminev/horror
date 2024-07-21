using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox_Coins : MonoBehaviour
{
    Fox_Logic foxLogic;
    
    //имя объекта
    public string objectName;
    //взят ли объект?
    public bool isTaken;

    private void Start()
    {
        foxLogic = FindObjectOfType<Fox_Logic>();    
        
        //Если у нас есть ячейка с таким именем, то..
        if (PlayerPrefs.HasKey(objectName))
        {
            //сравниваем значение в этой ячейке с единицей и результат кладём в переменную isTaken
            //Если у нас есть запись , то мы сравниваем 1 с 1, а это True
            isTaken = PlayerPrefs.GetInt(objectName) == 1;
            //включаем или отключаем объект в зависимости от значения переменной isTaken
            gameObject.SetActive(!isTaken);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //Если объект имеет тег Player, то...
        if (other.CompareTag("Player"))
        { 
            //Установим переменную  
            isTaken = true;
            //Создаем ячейку сохранения с именем объекта и кладём в неё единицу
            PlayerPrefs.SetInt(objectName, 1);
            //Отключаем монету
            gameObject.SetActive(false);
            
            //Получаем количество монет из ячейки сохранения и записываем во временную переменную,
            //Если такой ячейки сохранения нет, то выставляем значение 0
            var value = PlayerPrefs.GetInt("Coins", 0);
            //Записываем в ячейку Coins новое значение монет
            //К текущему прибавляем единицу
            PlayerPrefs.SetInt("Coins", value + 1);
            //Вызываем метод обновления UI(сейчас выйдет ошибка так как этот метод мы еще не создали)
            foxLogic.GetCoin();
        }
        
    }
}
