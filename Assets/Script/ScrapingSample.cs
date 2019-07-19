using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Async;
using AngleSharp.Html.Parser;
using AngleSharp.Html.Dom;
using System.Net.Http;

//AngleSharp.dll必須
//AngleSharp.Js.dll Jint.dll必須
public class ScrapingSample : MonoBehaviour
{
    public string uri;

    void Start()
    {
        CheckURL();
    }

    async void CheckURL()
    {
        var doc = await Parce();

        //参考　http://angelpinpoint.seesaa.net/article/462279383.html
        var elem = doc.QuerySelectorAll(".ProfileNav-value")[2];
        Debug.Log("フォロワー数"+elem.InnerHtml.Replace(",", ""));
    }

    async UniTask<IHtmlDocument> Parce()
    {
        var parser = new HtmlParser();
        using (var client = new HttpClient())
        using (var stream = await client.GetStreamAsync(new Uri(uri)))
        {
            return await parser.ParseDocumentAsync(stream);
        }
    }
}
