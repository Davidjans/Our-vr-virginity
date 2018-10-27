using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateBehaviour : MonoBehaviour {
	[SerializeField] private int m_MinItems;
	[SerializeField] private int m_MaxItems;
	[SerializeField] private List<Transform> m_ItemSpawnLocations;

	
	private PossibleItems m_PossibleItems;
	public int m_ItemAmmount;
	public List<GameObject> m_ItemsInCrate = new List<GameObject>();
	private List<BoxedItem> m_ItemsInBoxScript = new List<BoxedItem>();
	// Use this for initialization
	void Start () { 
		m_PossibleItems = GameObject.Find("PossibleItems").GetComponent<PossibleItems>();
		m_ItemAmmount = Random.Range(m_MinItems, m_MaxItems);
		for (int i = 0; i < m_ItemAmmount; i++)
		{
			GameObject item = Instantiate(m_PossibleItems.m_PossibleItems[Random.Range(0, m_PossibleItems.m_PossibleItems.Count)]);
			item.transform.position = m_ItemSpawnLocations[i].position;
			m_ItemsInCrate.Add(item);
			m_ItemsInBoxScript.Add(m_ItemsInCrate[i].GetComponent<BoxedItem>());
			m_ItemsInBoxScript[i].m_AllowedThrough = CheckIfAllowedThrough(i);
			Debug.Log(i);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("BoxItem"))
		{
			other.GetComponent<BoxedItem>().m_InBox = false;
			Debug.Log(other.name + " is now out of the box");
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("BoxItem"))
		{
			other.GetComponent<BoxedItem>().m_InBox = true;
			Debug.Log(other.name + " is now back in the box");
		}
	}

	private bool CheckIfAllowedThrough(int i)
	{
		for (int p = 0; p < m_PossibleItems.m_NotAllowedThrough.Count; p++)
		{
			if (m_ItemsInBoxScript[i].m_ItemID == m_PossibleItems.m_NotAllowedThrough[p])
			{
				return false;
			}
		}
		for (int p = 0; p < m_PossibleItems.m_AllowedThrough.Count; p++)
		{
			if (m_ItemsInBoxScript[i].m_ItemID == m_PossibleItems.m_AllowedThrough[p])
			{
				return true;
			}
		}
		return true;
	}
}
