using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Entity_Sheet2 : ScriptableObject
{	
	public List<Sheet> sheets = new List<Sheet> ();

	[System.SerializableAttribute]
	public class Sheet
	{
		public string name = string.Empty;
		public List<Param> list = new List<Param>();
	}

	[System.SerializableAttribute]
	public class Param
	{
		
		public string departure_Station;
		public double departure_Time;
		public string rail_direction;
		public string train_number;
		public string day_sp;
	}
}

