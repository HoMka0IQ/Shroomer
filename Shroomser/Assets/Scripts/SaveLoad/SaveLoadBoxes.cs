using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadBoxes : MonoBehaviour
{
    public static SaveLoadBoxes instance;
    public List<BoxManager> boxes;
    List<BoxManager> _oldBoxe;
    public BoxesData boxesDara;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        LoadMushroom();
        StartCoroutine(SaveData());
    }
    public void AddBoxes(BoxManager box)
    {
        boxes.Add(box);
        SaveMushroom();
    }

    public void SaveMushroom()
    {
        List<BoxManager> CleareMushroom = new List<BoxManager>();
        for (int i = 0; i < boxes.Count; i++)
        {
            if (boxes[i] != null)
            {
                CleareMushroom.Add(boxes[i]);
            }
        }
        boxes = CleareMushroom;

        for (int i = 0; i < boxes.Count; i++)
        {
            PlayerPrefs.SetInt("boxCost" + i, boxes[i].cost);
        }
        for (int i = 0; i < boxes.Count; i++)
        {
            PlayerPrefs.SetFloat("boxPosX" + i, boxes[i].gameObject.transform.position.x);
            PlayerPrefs.SetFloat("boxPosY" + i, boxes[i].gameObject.transform.position.y);
            PlayerPrefs.SetFloat("boxPosZ" + i, boxes[i].gameObject.transform.position.z);

            PlayerPrefs.SetFloat("boxRotX" + i, boxes[i].gameObject.transform.rotation.x);
            PlayerPrefs.SetFloat("boxRotY" + i, boxes[i].gameObject.transform.rotation.y);
            PlayerPrefs.SetFloat("boxRotZ" + i, boxes[i].gameObject.transform.rotation.z);
            PlayerPrefs.SetFloat("boxRotW" + i, boxes[i].gameObject.transform.rotation.w);
        }
        PlayerPrefs.SetInt("boxesNumber", boxes.Count);
    }

    public void LoadMushroom()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("boxesNumber"); i++)
        {
            Vector3 pos = new Vector3(PlayerPrefs.GetFloat("boxPosX" + i), PlayerPrefs.GetFloat("boxPosY" + i), PlayerPrefs.GetFloat("boxPosZ" + i));
            Quaternion Rot = new Quaternion(PlayerPrefs.GetFloat("boxRotX" + i), PlayerPrefs.GetFloat("boxRotY" + i), PlayerPrefs.GetFloat("boxRotZ" + i), PlayerPrefs.GetFloat("boxRotW" + i));
            GameObject box = Instantiate(boxesDara.allBoxes[0].prefab, pos, Quaternion.identity);
            box.transform.rotation = Rot;
            BoxManager BM = box.GetComponent<BoxManager>();
            BM.cost = PlayerPrefs.GetInt("boxCost" + i);
            boxes.Add(BM);
        }
    }
    IEnumerator SaveData()
    {
        while (true)
        {
            SaveMushroom();
            yield return new WaitForSeconds(2f);
        }
    }
    private void OnApplicationQuit()
    {
        SaveMushroom();
    }
}
