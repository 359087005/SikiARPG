/****************************************************
    文件：ResService.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：2019/1/24 14:50:1
	功能：资源模块的加载
*****************************************************/

using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResService : MonoBehaviour 
{
    public static ResService instance = null;

    public void InitRes()
    { 
        instance = this;

        InitRdmName();
        PECommon.Log("ResLoading...");
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

    #region 配置表初始化

    private List<string> surNameList = new List<string>();
    private List<string> manList = new List<string>();
    private List<string> womanList = new List<string>();

    private void InitRdmName()
    {
        TextAsset xml = Resources.Load<TextAsset>(PathDefine.rdmName);
        if (xml == null)
        {
            Debug.LogError("Init RdmName Config is Error.It is Not exist");
        }
        else
        {
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(xml.text);

            XmlNodeList xn = xd.SelectSingleNode("root").ChildNodes;

            for (int i = 0; i < xn.Count; i++)
            {
                XmlElement xe = xn[i] as XmlElement;
                if (xe.GetAttributeNode("ID") == null)
                {
                    continue;
                }
               int id =  Convert.ToInt32(xe.GetAttributeNode("ID").InnerText);
                foreach (XmlElement e in xn[i].ChildNodes)
                {
                    switch (e.Name)
                    {
                        case "surname":
                            surNameList.Add(e.InnerText);
                            break;
                        case "man":
                            manList.Add(e.InnerText);
                            break;
                        case "woman":
                            womanList.Add(e.InnerText);
                            break;
                    }
                }
            }

        }

    }
    #endregion

    public string GetRdmName(bool man = true)
    {
        System.Random rd = new System.Random();
        string surName = surNameList[MyTools.RdmNum(0,surNameList.Count-1,rd)];
        if (man)
        {
            surName += manList[MyTools.RdmNum(0,manList.Count-1,rd)];
        }
        else
        {
            surName += womanList[MyTools.RdmNum(0, womanList.Count - 1, rd)];
        }
        return surName;
    }
}