using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class ResLoadMgr : MonoBehaviour
{
    public AssetReference cubePrefabRef;
    public RawImage rawImage;

    // Start is called before the first frame update
    void Start()
    {
        // ʹ��Addressablesϵͳ�첽����һ��Ԥ�裨Prefab����Դ Completed�Ǵ����첽���ز������ʱ�Ļص� 
        Addressables.LoadAssetAsync<GameObject>("Assets/Res/Prefab/Player.prefab").Completed += (player) =>
        {
            // Ԥ�����������ɺ󣬻�ȡ���صĽ������Ԥ�����壩 Result�������ڻ�ȡ�첽�����Ľ���������ص�Ԥ����Դ��
            GameObject prefabObj = player.Result;

            // ʵ�������ص�Ԥ�����壬����һ���µ���Ϸ����
            GameObject cubeObj = Instantiate(prefabObj);
        };

        // ʹ��Addressablesϵͳ�첽ʵ����һ��Ԥ�裨Prefab����Դ InstantiateAsync�������ڼ�����Դ��ͬʱֱ��ʵ������
        Addressables.InstantiateAsync("Assets/Res/Prefab/Sphere.prefab").Completed += (handle) =>
        {
            // ��ʵ����������
            GameObject cubeObj = handle.Result;
        };

        //cubePrefabRef.LoadAssetAsync<GameObject>().Completed += (obj) =>
        //{
        //    // Ԥ��
        //    GameObject cube = obj.Result;
        //    // ʵ����
        //    GameObject cubeobj = Instantiate(cube);
        //};

        //cubePrefabRef.InstantiateAsync().Completed += (obj) =>
        //{
        //    GameObject cube= obj.Result;
        //};

        Addressables.LoadAssetAsync<Texture2D>("Assets/Res/Sprites/2.png").Completed += (obj) =>
        {
            // ͼƬ
            Texture2D tex2D = obj.Result;
            rawImage.texture = tex2D;
            rawImage.GetComponent<RectTransform>().sizeDelta = new Vector2(tex2D.width, tex2D.height);
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
