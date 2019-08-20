using ProcessorSDK;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace View
{
    public class HostViewer: IManagerProcess
    {
        private Types.ArrayProcessorCollection mPlugInCollection = new Types.ArrayProcessorCollection();
        private Label mLabel;
        public HostViewer(Label control)
        {
            mLabel = control;
        }
        public Types.ArrayProcessorCollection PlugIns
        {
            get { return mPlugInCollection; }
        }

        public void FindPlugIns(string folderPath)
        {
            mPlugInCollection.Clear(); // reloads them all.

            // goes through all library-file(s) in the plug-in folder...
            DirectoryInfo container = new DirectoryInfo(folderPath);

            foreach (FileInfo file in container.GetFiles("*.dll"))
            { this.LoadPlugIns(file.FullName); }
        }

        private void LoadPlugIns(string filePath)
        {
            Assembly pluginAssembly = Assembly.LoadFrom(filePath);

            object[] pluginAttributes;

            // loops through all the Types found in the assembly...
            foreach (Type pluginType in pluginAssembly.GetTypes())
            {
                pluginAttributes = pluginType.GetCustomAttributes(typeof(ProcessorAttribute), true);

                // only looks for a public, non-abstract and having attribute type(s).
                if (pluginType.IsPublic && !pluginType.IsAbstract && pluginAttributes.Length != 0)
                {
                    Type interfaceType = pluginType.GetInterface("ProcessorSDK.IArrayProcessor", true);
                    if (null != interfaceType) // gets the right interface-type.
                    {
                        Types.AvailableArrayProcessor plugin = new Types.AvailableArrayProcessor();
                        plugin.AssemblyPath = filePath;
                        plugin.Instance =(IArrayProcessor)Activator.CreateInstance(pluginAssembly.GetType(pluginType.ToString()));
                        plugin.Instance.Attributes = pluginAttributes[0] as ProcessorAttribute;
                        plugin.Instance.Initialize(this);

                        mPlugInCollection.Add(plugin); // loaded done.

                        plugin = null; // clean up...
                    }

                    interfaceType = null; // clean up...
                }
            }

            pluginAssembly = null; // clean up...
        }
        public void Report(string message)
        {
            mLabel.Text = message;
        }

        public void Dispose()
        {
            foreach (Types.AvailableArrayProcessor plugin in mPlugInCollection)
            {
                plugin.Instance.Dispose();
                plugin.Instance = null;
            }

            mPlugInCollection.Clear();
        }

    }
    namespace Types
    {
        public class ArrayProcessorCollection : CollectionBase
        {
     
            // Adds new plug-in to the collection.
            public void Add(AvailableArrayProcessor plugin)
            {
                this.List.Add(plugin);
            }
            public void Remove(AvailableArrayProcessor plugin)
            {
                this.List.Remove(plugin);
            }
            public void Clear()
            {
                this.List.Clear();
            }

            public int PlugInCounter
            {
                get { return base.List.Count; }
            }

        }

        //Represents an available plug-in.
        public class AvailableArrayProcessor
        {

            /// Plug-in instance.
            private IArrayProcessor mInstance;

            /// Assembly-path of plug-in.
            private string mAssemblyPath;


            public AvailableArrayProcessor()
                : this(null, "")
            { }

           
            // Initialize a instance with given value.
            //<param name="plugin">instance of a plug-in.</param>
            // <param name="path">the path of plug-in assembly.</param>
            public AvailableArrayProcessor(IArrayProcessor plugin, string path)
            {
                mInstance = plugin;

                mAssemblyPath = path;
            }

            public IArrayProcessor Instance
            {
                get { return mInstance; }
                set { mInstance = value; }
            }
            public string AssemblyPath
            {
                get { return mAssemblyPath; }
                set { mAssemblyPath = value; }
            }
          
            public override int GetHashCode()
            {
                int hashcode = 0;

                unchecked
                {
                    hashcode += 1000034 * mInstance.GetHashCode();
                }

                return hashcode;
            }

            public override bool Equals(object other)
            {
                if (null == other) return false;

                AvailableArrayProcessor anotherOne = other as AvailableArrayProcessor;

                return this.mInstance.Equals(anotherOne.mInstance);
            }

            public override string ToString()
            {
                return mInstance.ToString();
            }
        }
    }
}
