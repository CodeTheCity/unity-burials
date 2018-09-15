using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;
using System;

public class PointsImporterEditor : Editor {

    [MenuItem("GameObject/Create Other/Burials")]
	static void Create()
    {
        GameObject gameObject = new GameObject("SK");

        string path = EditorUtility.OpenFilePanel("Burials data", "", "csv");
        LoadASCFile(path, gameObject);
    }

    static void CreateBurial(Vector3 position, GameObject gameObject, String name)
    {

        GameObject instance = Instantiate(Resources.Load("SK", typeof(GameObject))) as GameObject;
        instance.transform.parent = gameObject.transform;
        instance.transform.position += new Vector3(position.x, position.y, position.z);
        instance.name = name;
    }

    static bool LoadASCFile(string fileName, GameObject gameObject)
    {
        try
        {
            string line;

            StreamReader theReader = new StreamReader(fileName, Encoding.Default);
            using (theReader)
            {
                bool firstLine = false;
                do
                {
                    line = theReader.ReadLine();
                    if (line != null)
                    {
                        if (firstLine)
                        {
                            firstLine = false;
                        }
                        else {
                                string[] values = line.Split(',');

                                Vector3 rawPosition = new Vector3(float.Parse(values[0]), float.Parse(values[1]), float.Parse(values[2]));
                            // Vector2 convertedPosition = ConvertToMeters(rawPosition);
                            String name = values[3];
                            CreateBurial(rawPosition, gameObject, name);

                            
                        }
                    }
                }
                while (line != null);

                theReader.Close();
                return true;
            }
        }
        catch (Exception e)
        {
            GameObject sphereRoot = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphereRoot.transform.parent = gameObject.transform;
            sphereRoot.name = e.Message;
            Console.WriteLine("{0}\n", e.Message);
            return false;
        }
    }

    static Vector2 ConvertToMeters(Vector2 latLong)
    {
        Vector2 relativeNullPoint = new Vector2(-2.1011677f, 57.1461714f);
        Vector2 meters = new Vector2(0.0f, 0.0f);
        float deltaLatitude = latLong.x - relativeNullPoint.x;
        float deltaLongutude = latLong.y - relativeNullPoint.y;
        float latitudeCircumference = 40075160 * Mathf.Cos(relativeNullPoint.x * Mathf.PI / 180.0f);
        meters.x = deltaLongutude * latitudeCircumference / 360.0f;
        meters.y = deltaLatitude * 4000800.0f / 360.0f * 2;
        return meters;
    }
}
