/****************************************************
    文件：ResService.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：2019/1/24 14:50:1
	功能：资源模块的加载
*****************************************************/

using System;
using System.Collections.Generic;
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
        GameRoot.instance.loadingWind.SetWindowState();

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
                GameRoot.instance.loadingWind.SetWindowState(false);
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

	private Dictionary<string,AudioClip> audioDic = new Dictionary<string,AudioClip>();
	public AudioClip LoadClip(string path,bool isCache = false)
	{
		AudioClip au = null;

		if(!audioDic.TryGetValue(path,out au))
		{	
			au = Resources.Load<AudioClip>(path);
			if(isCache)
			{
				audioDic.Add(path,au);
			}	
		}
		return au;
	}





}