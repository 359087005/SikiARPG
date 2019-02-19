/****************************************************
    文件：ResService.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：2019/1/24 14:50:1
	功能：声音播放服务
*****************************************************/

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioService: MonoBehaviour 
{
    public static AudioService instance = null;

	public AudioSource bgAudio;
	public AudioSource uiAudio;

    public void InitService()
    { 
        instance = this;
        PECommon.Log("AudioService Init...");
    }
   
	public void PlayBGAudio(string name,bool isloop = true)
	{
		AudioClip clip = ResService.instance.LoadClip("ResAudio/" + name,true);
		if(bgAudio.clip == null || bgAudio.clip.name != clip.name)
		{
			bgAudio.clip = clip;
			bgAudio.loop = isloop;
			bgAudio.Play();
		}
	}

	public void PlayUIAudio(string name)
	{
		AudioClip clip = ResService.instance.LoadClip("ResAudio/" + name,true);
		uiAudio.clip = clip;
		uiAudio.Play();
	}

}