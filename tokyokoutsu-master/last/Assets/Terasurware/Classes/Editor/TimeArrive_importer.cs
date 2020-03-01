using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;
using System.Xml.Serialization;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

public class TimeArrive_importer : AssetPostprocessor {
	private static readonly string filePath = "Assets/TimeArrive.xls";
	private static readonly string exportPath = "Assets/Resources/TimeArrive.asset";
	private static readonly string[] sheetNames = { "Sheet2", };
	
	static void OnPostprocessAllAssets (string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
	{
		foreach (string asset in importedAssets) {
			if (!filePath.Equals (asset))
				continue;
				
			Entity_Sheet3 data = (Entity_Sheet3)AssetDatabase.LoadAssetAtPath (exportPath, typeof(Entity_Sheet3));
			if (data == null) {
				data = ScriptableObject.CreateInstance<Entity_Sheet3> ();
				AssetDatabase.CreateAsset ((ScriptableObject)data, exportPath);
				data.hideFlags = HideFlags.NotEditable;
			}
			
			data.sheets.Clear ();
			using (FileStream stream = File.Open (filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
				IWorkbook book = null;
				if (Path.GetExtension (filePath) == ".xls") {
					book = new HSSFWorkbook(stream);
				} else {
					book = new XSSFWorkbook(stream);
				}
				
				foreach(string sheetName in sheetNames) {
					ISheet sheet = book.GetSheet(sheetName);
					if( sheet == null ) {
						Debug.LogError("[QuestData] sheet not found:" + sheetName);
						continue;
					}

					Entity_Sheet3.Sheet s = new Entity_Sheet3.Sheet ();
					s.name = sheetName;
				
					for (int i=1; i<= sheet.LastRowNum; i++) {
						IRow row = sheet.GetRow (i);
						ICell cell = null;
						
						Entity_Sheet3.Param p = new Entity_Sheet3.Param ();
						
					cell = row.GetCell(0); p.arrival_Station = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(1); p.arrival_Time = (cell == null ? 0.0 : cell.NumericCellValue);
					cell = row.GetCell(2); p.rail_direction = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(3); p.train_number = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(4); p.day_sp = (cell == null ? "" : cell.StringCellValue);
						s.list.Add (p);
					}
					data.sheets.Add(s);
				}
			}

			ScriptableObject obj = AssetDatabase.LoadAssetAtPath (exportPath, typeof(ScriptableObject)) as ScriptableObject;
			EditorUtility.SetDirty (obj);
		}
	}
}
