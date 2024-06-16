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
        // 使用Addressables系统异步加载一个预设（Prefab）资源 Completed是处理异步加载操作完成时的回调 
        Addressables.LoadAssetAsync<GameObject>("Assets/Res/Prefab/Player.prefab").Completed += (player) =>
        {
            // 预设物体加载完成后，获取加载的结果（即预设物体） Result属性用于获取异步操作的结果，即加载的预设资源。
            GameObject prefabObj = player.Result;

            // 实例化加载的预设物体，创建一个新的游戏对象
            GameObject cubeObj = Instantiate(prefabObj);
        };

        // 使用Addressables系统异步实例化一个预设（Prefab）资源 InstantiateAsync方法会在加载资源的同时直接实例化它
        Addressables.InstantiateAsync("Assets/Res/Prefab/Sphere.prefab").Completed += (handle) =>
        {
            // 已实例化的物体
            GameObject cubeObj = handle.Result;
        };

        //cubePrefabRef.LoadAssetAsync<GameObject>().Completed += (obj) =>
        //{
        //    // 预设
        //    GameObject cube = obj.Result;
        //    // 实例化
        //    GameObject cubeobj = Instantiate(cube);
        //};

        //cubePrefabRef.InstantiateAsync().Completed += (obj) =>
        //{
        //    GameObject cube= obj.Result;
        //};

        Addressables.LoadAssetAsync<Texture2D>("Assets/Res/Sprites/2.png").Completed += (obj) =>
        {
            // 图片
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
