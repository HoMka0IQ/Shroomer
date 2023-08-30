using UnityEngine;

public class InsectSpawner : MonoBehaviour
{
    public InsectData insectData;
    public void SpawnInsectOnMushroom(GameObject mushroomObject, int numbers)
    {
        
        for (int i = 0; i < numbers; i++)
        {
            
            int t = Random.Range(0, insectData.InsectPrefab.Length);
            if (Item3DViewer.instance.MushroomData.currentQuality - insectData.IncreaseQuality[t] < 0)
            {
                return;
            }
            // Отримуємо меш гриба (меш сітку)
            MeshFilter mushroomMeshFilter = mushroomObject.GetComponent<MeshFilter>();
            if (mushroomMeshFilter == null)
            {
                Debug.LogError("Mushroom object does not have a MeshFilter component!");
                return;
            }

            // Перевіряємо, чи меш має включений доступ до вершин
            if (!mushroomMeshFilter.mesh.isReadable)
            {
                Debug.LogError("Mesh of the mushroom object is not readable! Enable Read/Write in import settings.");
                return;
            }

            // Отримуємо масив вершин мешу гриба
            Vector3[] vertices = mushroomMeshFilter.mesh.vertices;

            // Перевіряємо, чи є вершини у мешу
            if (vertices.Length == 0)
            {
                Debug.LogError("Mesh of the mushroom object does not have any vertices!");
                return;
            }

            // Вибираємо випадкову вершину мешу гриба
            Vector3 randomVertex = vertices[Random.Range(0, vertices.Length)];

            // Отримуємо глобальну позицію комахи на основі випадкової вершини
            Vector3 spawnPosition = mushroomObject.transform.TransformPoint(randomVertex);

            // Створюємо нову комаху на визначеній позиції
            Debug.Log(numbers);
            GameObject newInsect = Instantiate(insectData.InsectPrefab[t], spawnPosition, Quaternion.identity);
            newInsect.transform.SetParent(mushroomObject.transform);
            Insect insect = newInsect.AddComponent<Insect>();
            insect.IncreaseQuality = insectData.IncreaseQuality[t];

            Item3DViewer.instance.MushroomData.currentQuality -= insectData.IncreaseQuality[t];

            // Напрямлюємо комаху на місце свого створення
            Vector3 lookDirection = spawnPosition - mushroomObject.transform.position;
            newInsect.transform.rotation = Quaternion.LookRotation(lookDirection, -Vector3.up);
        }
    }
}
