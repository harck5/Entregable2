using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise : MonoBehaviour
{
    public GameObject objetoPrefab;
    private int posX = 8;
    private int posZ = 8;
    Vector3 randomPosition;

    private float timer;
    public float timerMax = 1f;

    private List<Vector3> positionsNoRepeat = new List<Vector3>();

    private int index;

    private void Start()
    {
        for (int x = 0; x < posX; x++)
        {
            for (int z = 0; z < posZ; z++)
            {
                positionsNoRepeat.Add(new Vector3(x, 0f, z));
            }
        }
    }
    private void Update()
    {
        TimerGenerator();
    }
    void Generate()
    {
        if (positionsNoRepeat.Count > 0)
        {
            index = Random.Range(0, positionsNoRepeat.Count);//ejemplo el vector numero 4 de (.count) que esta ligado a (4, 0, 7) de positionsNoRepeat y luego es count se igual al index
            randomPosition = positionsNoRepeat[index];//basicamente asigna un numero a al vector con un count que luego se iguala el index
            positionsNoRepeat.RemoveAt(index);// y lo necesitamos para poder buscar la igualdades y posteriormente eliminarlas
            Instantiate(objetoPrefab, randomPosition, Quaternion.identity);
        }

    }
    private void TimerGenerator()
    {
        timer += Time.deltaTime;
        if (timer >= timerMax)
        {
            timer -= timerMax;

            Generate();
        }
    }
}
