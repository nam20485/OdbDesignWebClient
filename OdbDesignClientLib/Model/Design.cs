using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odb.Client.Lib.Model
{
    public class Design
    {
        public string productModel { get; set; }
        public string name { get; set; }
        public Net[] nets { get; set; }
        public Net.StringDictionary netsByName { get; set; }
        public Package[] packages { get; set; }
        public Package.StringDictionary packagesByName { get; set; }
        public Component[] components { get; set; }
        public Component.StringDictionary componentsByName { get; set; }
        public Part[] parts { get; set; }
        public Part.StringDictionary partsByName { get; set; }
    }

    public class Net
    {
        public string name { get; set; }
        public PinConnection[] pinConnections { get; set; }
        public int index { get; set; }

        public class StringDictionary : Dictionary<string, Net> { }
    }

    public class PinConnection
    {
        public string name { get; set; }
        public Component component { get; set; }
        public Pin pin { get; set; }
    }

    public class Component
    {
        public string refDes { get; set; }
        public string partName { get; set; }
        public Package package { get; set; }
        public int index { get; set; }
        public string side { get; set; }
        public Part part { get; set; }

        public class StringDictionary : Dictionary<string, Component> { }
    }

    public class Package
    {
        public string name { get; set; }
        public Pin[] pins { get; set; }
        public Pin.StringDictionary pinsByName { get; set; }
        public int index { get; set; }

        public class StringDictionary : Dictionary<string, Package> { }
    }


    public class Pin
    {
        public string name { get; set; }
        public int index { get; set; }

        public class StringDictionary : Dictionary<string, Pin> { }
    }

    public class Part
    {
        public string name { get; set; }

        public class StringDictionary : Dictionary<string, Part> { }
    }
}
