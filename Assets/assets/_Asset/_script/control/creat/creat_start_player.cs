using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creat_start_player : MonoBehaviour
{
    public GameObject players;
    public Transform location;
    public Transform playerContainer;
    public GameObject Square;


    private List<GameObject> activeSquares = new List<GameObject>(); // Danh sách các square đang hoạt động
    private int totalSquares = 0;     // Tổng số square được tạo
   // private bool spawningDone = false;

    private GameObject player;
    private void Awake()
    {
        //GameObject player = Instantiate(players, location.position, Quaternion.identity);
         player = Instantiate(players, location.position, Quaternion.identity, playerContainer);
        player.transform.SetSiblingIndex(0); // Đưa nó lên đầu trong Hierarchy
        player.SetActive(false);

    }
    void Start()
    {
        StartCoroutine(SpawnAndMoveSquares());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnAndMoveSquares()
    {
        // Sinh ra số lượng square ngẫu nhiên từ 3 đến 8
        totalSquares = Random.Range(7, 20);

        for (int i = 0; i < totalSquares; i++)
        {
            // Tạo vị trí ngẫu nhiên trong bán kính 2f quanh location
            Vector2 randomPos = (Vector2)location.position + Random.insideUnitCircle * 2f;

            // Tạo square tại vị trí random với góc quay ngẫu nhiên
            GameObject square = Instantiate(Square, randomPos,Quaternion.Euler(0, 0, Random.Range(0f, 360f))  );
               
                
          

            // Gán kích thước ngẫu nhiên
            float randomScale = Random.Range(0.01f, 0.1f);
            square.transform.localScale = new Vector3(randomScale, randomScale, 1f);

            // Thêm square vào danh sách để theo dõi
            activeSquares.Add(square);

            // Bắt đầu di chuyển square đó về location
            StartCoroutine(MoveAndDestroy(square));
        }

        //spawningDone = true;

        // Chờ đến khi tất cả square đã bị xóa
        yield return new WaitUntil(() => activeSquares.Count == 0);

        // Bật player sau khi hoàn tất
        player.SetActive(true);
    }

    IEnumerator MoveAndDestroy(GameObject square)
    {
        float speed = 3f;

        // Di chuyển square dần về vị trí location
        while (Vector3.Distance(square.transform.position, location.position) > 0.05f)
        {
            square.transform.position = Vector3.MoveTowards(  square.transform.position, location.position,speed * Time.deltaTime );        
            yield return null;
        }

        // Khi đến nơi, xóa khỏi danh sách và huỷ đối tượng
        activeSquares.Remove(square);
        Destroy(square);
    }

}
