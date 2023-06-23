using UnityEngine;

public class SpawnPicture : MonoBehaviour
{
    public GameObject pictPrefab; // выбор префаба для спавна (в инспекторе)
    public GameObject content; // область спавна картинок
    private RectTransform contentAreaRT; // ссылка на размеры и позицию области спавна картинок

    public static int imageCurNum; // номер картинки
    private int imageMaxNum = 66; // максимальное кол-во картинок (но лучше бы реализовать через hhtp), что бы автоматически менялось при запуске приложения.
    private int preloadPicNumber = 2; // кол-во предзагруженных картинок (т.е. за пределами экрана устройства)    
    private float borderForSpawnPic; // позиция верхней рамки зоны спавна
    

    // получение стартовых ссылок на компоненты и стартовых значений
    private void Awake()
    {
        contentAreaRT = content.GetComponent<RectTransform>();

        borderForSpawnPic = contentAreaRT.position.y;

        imageCurNum = 1;

        StarterPics();
    }

    // отслеживание изменений позиции зоны спавна картинок 
    private void Update()
    {
        GreatMorePics();        
    }

    

    // загрузка начальных картинок ( столько сколько поместится на экране) + кол-во предзагруженных
    private void StarterPics()
    {
        for (int i = 0; i < (DeviceAdaptation.picNumberOnScreen * 2 + preloadPicNumber); i++)
        {
            GreatPic();
        }
    }

    // создание дополнительных картинок если зона спавна достаточно изменилась и не достигнуто максимальное число картинок
    private void GreatMorePics()
    {
        if (contentAreaRT.position.y > borderForSpawnPic & imageCurNum <= imageMaxNum)
        {
            GreatPic();
            GreatPic();
            borderForSpawnPic += DeviceAdaptation.picSize;
            
        }
    }

    //метод спавна картинок и увеличение размера области спавна если была создана в последнем столбце ( в данном проекте кол-во столбцов = 2)
    private void GreatPic()
    {
        Instantiate(pictPrefab, content.transform);
        imageCurNum++;

        if (imageCurNum % 2 == 0)
        {
            ResizeContentArea();
        }
    }

    // метод увеличения области спавна
    private void ResizeContentArea()
    {
        contentAreaRT.sizeDelta = new Vector2(contentAreaRT.sizeDelta.x, contentAreaRT.sizeDelta.y + DeviceAdaptation.picSize);
    }
}
