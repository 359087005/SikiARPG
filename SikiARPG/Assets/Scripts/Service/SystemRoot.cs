/****************************************************
    文件：ResService.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：2019/1/24 14:50:1
	功能：业务系统基类
*****************************************************/

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemRoot: MonoBehaviour 
{
   protected ResService resService;
	protected AudioService audioService;

	public virtual void Init()
	{
		resService = ResService.instance;
		audioService = AudioService.instance;
	}
}