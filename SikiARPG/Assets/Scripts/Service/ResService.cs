/****************************************************
    文件：ResService.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：2019/1/24 14:50:1
	功能：资源模块的加载
*****************************************************/

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResService : MonoBehaviour 
{
    public static ResService instance = null;

    public void InitRes()
    { 
        instance = this;
        Debug.Log("ResLoading...");
    }
    private Action sceneAsyncAction = null;
    public void AsyncLoadScene(string name,Action at)
    {
        //显示进度
        GameRoot.instance.loadingWind.Init();
        GameRoot.instance.loadingWind.gameObject.SetActive(true);

        AsyncOperation ao =  SceneManager.LoadSceneAsync(name);
        sceneAsyncAction = () =>
        {
            float value = ao.progress;
            GameRoot.instance.loadingWind.SetValue(value);
            if (value >= 1)
            {
                if (at != null)
                {
                    at();
                }
                sceneAsyncAction = null;
                ao = null;
                GameRoot.instance.loadingWind.gameObject.SetActive(false);
            }
        };
    }
    private void Update()
    {
        if (sceneAsyncAction != null)
        {
            sceneAsyncAction();
        }
    }
}