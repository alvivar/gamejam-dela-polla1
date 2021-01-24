
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SerializeIntValue
{

    public static void S(IntFile target, string name)
    {
        string path = Application.persistentDataPath + "/SaveData/Seed_Power_" + name +" .filedat";

        if (!Directory.Exists(Application.persistentDataPath + "/SaveData/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/SaveData/");
        }

        BinaryFormatter format = new BinaryFormatter();

        FileStream file = new FileStream(path, FileMode.Create);

        //w.ol(":: JUST SAVED - INT - IN :: " + path);

        format.Serialize(file, target);
        file.Close();

    }


    public static IntFile L(string name)
    {
        string path = Application.persistentDataPath + "/SaveData/Seed_Power_" + name + " .filedat";

        if (File.Exists(path))
        {
            BinaryFormatter format = new BinaryFormatter();
            FileStream file = new FileStream(path, FileMode.Open);

            //w.ol(":: LOADED - INT - IN :: " + path);

            IntFile loaded = format.Deserialize(file) as IntFile;
            file.Close();

            return loaded;

        }
        else
        {
            IntFile createNew = new IntFile();
            createNew.value = 1;
            //w.ol("TRYING TO LOAD - INT - DOESNT EXIST IN " + path);
            return createNew;
        }


    }


}
