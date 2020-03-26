using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Clock
{
    public struct BusinessDate : IFormattable, IEquatable<BusinessDate>, IComparable<BusinessDate>, IXmlSerializable
    {
        public int CompareTo([AllowNull] BusinessDate other)
        {
            throw new NotImplementedException();
        }

        public bool Equals([AllowNull] BusinessDate other)
        {
            throw new NotImplementedException();
        }

        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
