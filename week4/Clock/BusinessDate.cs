using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Clock
{
    public struct BusinessDate : IFormattable, IEquatable<BusinessDate>, IComparable<BusinessDate>, IXmlSerializable
    {
		private DateTime _dt;

		public static readonly BusinessDate MaxValue = new BusinessDate(DateTime.MaxValue);
		public static readonly BusinessDate MinValue = new BusinessDate(DateTime.MinValue);

		public BusinessDate(int year, int month, int day)
		{
			this._dt = new DateTime(year, month, day);
		}

		public BusinessDate(DateTime dateTime)
		{
			this._dt = dateTime.AddTicks(-dateTime.Ticks % TimeSpan.TicksPerDay);
		}

		
		private BusinessDate(SerializationInfo info, StreamingContext context)
		{
			this._dt = DateTime.FromFileTime(info.GetInt64("clock"));
		}

		public static bool operator !=(BusinessDate d1, BusinessDate d2)
		{
			return d1._dt != d2._dt;
		}

		public static bool operator ==(BusinessDate d1, BusinessDate d2)
		{
			return d1._dt == d2._dt;
		}

		public static explicit operator BusinessDate(DateTime d)
		{
			return new BusinessDate(d);
		}

		public int Day
		{
			get
			{
				return this._dt.Day;
			}
		}

		public DayOfWeek DayOfWeek
		{
			get
			{
				return this._dt.DayOfWeek;
			}
		}

		public int DayOfYear
		{
			get
			{
				return this._dt.DayOfYear;
			}
		}

		public int Month
		{
			get
			{
				return this._dt.Month;
			}
		}

		public static BusinessDate Today
		{
			get
			{
				return new BusinessDate(DateTime.Today);
			}
		}

		public int Year
		{
			get
			{
				return this._dt.Year;
			}
		}

		public static BusinessDate Parse(string s)
		{
			return new BusinessDate(DateTime.Parse(s));
		}


		public int CompareTo(BusinessDate value)
		{
			return this._dt.CompareTo(value._dt);
		}

		public int CompareTo(object value)
		{
			return this._dt.CompareTo(value);
		}

		public bool Equals(BusinessDate value)
		{
			return this._dt.Equals(value._dt);
		}

		public override bool Equals(object value)
		{
			return value is BusinessDate && this._dt.Equals(((BusinessDate)value)._dt);
		}

		public override int GetHashCode()
		{
			return this._dt.GetHashCode();
		}

		public static bool Equals(BusinessDate d1, BusinessDate d2)
		{
			return d1._dt.Equals(d2._dt);
		}

		public override string ToString()
		{
			return this._dt.ToShortDateString();
		}

		public string ToString(IFormatProvider provider)
		{
			return this._dt.ToString(provider);
		}

		public string ToString(string format, IFormatProvider formatProvider)
		{
			if (format == "O" || format == "o" || format == "s")
			{
				return this.ToString("yyyy-MM-dd", formatProvider);
			}

			return this._dt.ToString(format);
		}

		public static object ParseFromIso8601String(string v)
		{
			return  DateTime.Parse(v, null, System.Globalization.DateTimeStyles.RoundtripKind);
		}

		public XmlSchema GetSchema()
		{
			throw new NotImplementedException();
		}

		public void ReadXml(XmlReader reader)
		{
			throw new NotImplementedException();
		}

		public void WriteXml(XmlWriter writer)
		{
			throw new NotImplementedException();
		}
	}
}
