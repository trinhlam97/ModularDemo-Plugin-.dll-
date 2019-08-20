using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessorSDK
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ProcessorAttribute: Attribute
    {
        // Name of plug-in.
        string mName;

        // publisher of plug-in.
        string mPublisher;

        // Description of plug-in.
        string mDescription;

        // Version of plug-in.
        string mVersion;

        public string Name
        {
            get { return mName; }
        }
        public string Publisher
        {
            get { return mPublisher; }
        }

        public string Description
        {
            get { return mDescription; }
        }
        public string Version
        {
            get { return mVersion; }
        }

        public ProcessorAttribute(string name, string publisher, string description, string version)
        {
            mName = name;
            mPublisher = publisher;
            mDescription = description;
            mVersion = version;
        }

        public override string ToString()
        {
            return "Name: " + mName + "; Publisher: " + mPublisher + "; Description: " + mDescription + "; Version: " + mVersion + ".";
        }

    }
}
