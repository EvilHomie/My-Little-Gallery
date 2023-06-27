using System;
using UnityEngine;

public class SpawnPicture : MonoBehaviour
{
    [SerializeField] private DeviceAdaptation dAScript;
    [SerializeField] private GameObject pictPrefab; // выбор префаба для спавна (в инспекторе)
    [SerializeField] private GameObject content; // область спавна картинок

    private RectTransform contentRT;

    public static int ImageCurNum { get; private set; } = 0;// номер картинки
    private readonly int imageMaxNum = 66; // максимальное кол-во картинок (но лучше бы реализовать через hhtp), что бы автоматически менялось при запуске приложения.

    // получение стартовых ссылок на компоненты и стартовых значений
    private void OnEnable()
    {
        contentRT = content.GetComponent<RectTransform>();
        
        StarterPics();
    }

    // отслеживание изменений позиции зоны спавна картинок 
    private void Update()
    {
        GreatMorePics();

        if (ImageCurNum % dAScript.ColumnsAmount != 0)
        {
            GreatPic(1);
        }        
    }

    // загрузка начальных картинок ( столько сколько поместится на экране) + кол-во предзагруженных
    private void StarterPics()
    {
        GreatPic(dAScript.RowsAmount * dAScript.ColumnsAmount);
        StartCoroutine(dAScript.UpdateGLG());
    }

    // создание дополнительных картинок если зона спавна достаточно изменилась и не достигнуто максимальное число картинок
    private void GreatMorePics()
    {
        float contentSize = dAScript.BorderStep * dAScript.RowsAmount * (float)dAScript.UIScale;

        if ((contentSize - contentRT.position.y)  < dAScript.BorderStep * (float)dAScript.UIScale & ImageCurNum <= imageMaxNum)
        {            
            GreatPic(dAScript.ColumnsAmount);
        }
    }

    //метод спавна картинок и увеличение размера области спавна если была создана в последнем столбце ( в данном проекте кол-во столбцов = 2)
    private void GreatPic(int number)
    {
        for (int i = 0; i < number & ImageCurNum != imageMaxNum; i++)
        {
            ImageCurNum++;
            Instantiate(pictPrefab, content.transform);
            dAScript.ImageCount++;
        }
    }
}
