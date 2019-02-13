/****************************************************
    文件：GameUIRoot.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：2019/1/25 14:54:58
	功能：UI界面基类
*****************************************************/

using UnityEngine;
using UnityEngine.UI;

public class GameUIRoot : MonoBehaviour
{
    protected ResService res = null;
    protected AudioService audioService = null;

    public void SetWindowState(bool isActive = true)
    {
        if (this.gameObject.activeSelf != isActive)
        {
            SetActive(this.gameObject, isActive);
        }
        if (isActive)
        { InitWindow(); }
        else
        { ClearWindow(); }
    }
    protected virtual void InitWindow()
    {
        res = ResService.instance;
        audioService = AudioService.instance;
    }

    protected virtual void ClearWindow()
    {
        res = null;
        audioService = null;
    }

    #region Tool

    protected void SetActive(GameObject go, bool active = true)
    { go.SetActive(active); }

    protected void SetActive(Transform trans, bool active = true)
    { trans.gameObject.SetActive(active); }

    protected void SetActive(RectTransform rectTrans, bool active = true)
    { rectTrans.gameObject.SetActive(active); }

    protected void SetActive(Image image, bool active = true)
    { image.transform.gameObject.SetActive(active); }

    protected void SetActive(Text txt, bool active = true)
    { txt.transform.gameObject.SetActive(active); }


    protected void SetText(Text txt, string content = "")
    {
        txt.text = content;
    }
    protected void SetText(Text txt, int num = 0)
    {
        SetText(txt, num.ToString());
    }

    protected void SetText(Transform trans, string content = "")
    {
        SetText(trans.GetComponent<Text>(), content);
    }
    protected void SetText(Transform trans, int num = 0)
    {

        SetText(trans.GetComponent<Text>(), num);
    }

    #endregion
}