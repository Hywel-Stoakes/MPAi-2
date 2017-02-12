using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MPAi.Cores
{
    /// <summary>
    /// Class that handles conversion of objects to and from bytestreams, and saving and loading said bytestreams into and out of files.
    /// </summary>
    /// <typeparam name="T">The type of object to serialize. Must extend ISerializable.</typeparam>
    public class Serializer<T>
    where T : class, ISerializable, new()
    {
        /// <summary>
        /// Calls the input formatter's Serialize method, and puts the object into a string format.
        /// </summary>
        /// <typeparam name="F">The formatter implementation to use when serializing the object.</typeparam>
        /// <param name="t">The object to serialize.</param>
        /// <returns>A string representing the serialized object.</returns>
        static public String Serialize<F>(T t) where F : IFormatter, new()
        {
            String result = "";
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    IFormatter ser = new F();
                    ser.Serialize(stream, t);
                    result = Encoding.Unicode.GetString(stream.GetBuffer());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return result;
        }
        /// <summary>
        /// Calls the input formatter's Deserialize method, and turns a serial string into an object.
        /// </summary>
        /// <typeparam name="F">The formatter implementation to use when deserializing the string.</typeparam>
        /// <param name="s">The string to deserialize.</param>
        /// <returns>The object that was serialised into the input string.</returns>
        static public T Deserialize<F>(String s) where F : IFormatter, new()
        {
            T t = new T();
            try
            {
                if(s != String.Empty)
                {
                    using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(s)))
                    {
                        IFormatter ser = new F();
                        t = ser.Deserialize(stream) as T;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return t;
        }
        /// <summary>
        /// Serializes, then saves an object into a file.
        /// </summary>
        /// <typeparam name="F">The formatter to use when serializing the object.</typeparam>
        /// <param name="path">The file path of the file to save the object into, as a string.</param>
        /// <param name="t">The object of type T, to save to the file.</param>
        static public void Save<F>(string path, T t) where F : IFormatter, new()
        {
            try
            {              
                using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    using (StreamWriter sw = new StreamWriter(stream))
                    {
                        string content = Serialize<F>(t);
                        sw.Write(content);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        /// <summary>
        /// Loads, then deserializes an object from a file.
        /// </summary>
        /// <typeparam name="F">The formatter to use when deserializing the file.</typeparam>
        /// <param name="path">The file path of the file to load the object from.</param>
        /// <returns>The object of type T, that was loaded from the file.</returns>
        static public T Load<F>(string path) where F : IFormatter, new()
        {
            T t = null;
            try
            {
                using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        string content = sr.ReadToEnd();
                        t = Deserialize<F>(content) as T;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return t;
        }
    }
}
