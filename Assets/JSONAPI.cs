using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONAPI : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		// 正常なJSON
		try
		{
            var t = JsonUtility.FromJson<Tenants>("{\"tenants\":[{\"id\":1,\"name\":\"development\",\"display_name\":\"テナント1\"}]}");
            Debug.Log(JsonUtility.ToJson(t));
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}

		// 不正なJSON
		try
		{
            var t = JsonUtility.FromJson<Tenants>("tenants\":[{\"id\":1,\"name\":\"development\",\"display_name\":\"テナント1\"}]}");
            Debug.Log(JsonUtility.ToJson(t));
		}
		catch (Exception e)
		{
			Console.WriteLine(e); // ArgumentException
		}
		
		// 正常なJSONだが、必要な情報が足りない
		try
		{
            var t = JsonUtility.FromJson<Tenants>("{\"tenants\":[{\"display_name\":\"テナント1\"}]}");
            Debug.Log(JsonUtility.ToJson(t));
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
		
		// 正常なJSONだが、情報が多い
		try
		{
            var t = JsonUtility.FromJson<Tenants>("{\"tenants\":[{\"id\":1,\"key\":\"hoge\",\"name\":\"development\",\"display_name\":\"テナント1\"}]}");
            Debug.Log(JsonUtility.ToJson(t));
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw;
		}
	}
}

[Serializable]
internal struct Tenants
{
	public List<Tenant> tenants;
}

[Serializable]
internal struct Tenant
{
	[SerializeField]
	public int id;
	public string name;
	public string display_name;
}