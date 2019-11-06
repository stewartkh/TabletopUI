using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using UnityEngine;

namespace Orpheus.Generate {
	public class Catalog : MonoBehaviour {
		public XmlDocument catalogXml;
		public List<CatalogEntry> catalog;

		// Use this for initialization
		void Start () {
			catalogXml = new XmlDocument();
			catalogXml.Load("Assets/RandomGenerators/Resources/Catalog.xml");

			XmlNodeList entries = catalogXml.SelectNodes("Catalog/Entry");
			
			int numEntries = 0;
			foreach(XmlNode entry in entries) 
			{
				if(entry.NodeType == XmlNodeType.Element && entry.HasChildNodes) 
				{
					string name = "";
					List<string> tags = new List<string>();
					foreach(XmlNode child in entry.ChildNodes) 
						switch(child.Name) 
						{
							case "name":
								name = child.InnerText;
								break;
							case "tag":
								tags.Add(child.InnerText);
								break;
						}
					catalog.Add(new CatalogEntry(name, tags));
				}
				numEntries++;
			}
			Debug.LogFormat("Loaded {0} entries from the catalog.", numEntries);
		}
		

		// Encapsulates a single catalog entry
		public class CatalogEntry 
		{
			public string name;
			public List<string> tags;

			public CatalogEntry(string pName, IEnumerable<string> pTags) 
			{
				name = pName;
				tags = new List<string>(pTags);
			}

			public override string ToString() {
				string rtnval = "[" + name + "]: ";
				foreach(string tag in tags) 
				{
					rtnval += tag;
					if(tag != tags[tags.Count-1])
						rtnval += ", ";
				}

				return rtnval;
			}
		}
	}
}