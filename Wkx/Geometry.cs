﻿using System.IO;

namespace Wkx
{
    public abstract class Geometry
    {
        public abstract GeometryType GeometryType { get; }
        public abstract bool IsEmpty { get; }

        public static Geometry Parse(string value)
        {
            return new WktReader(value).Read();
        }

        public static Geometry Parse(byte[] buffer)
        {
            using (MemoryStream memoryStream = new MemoryStream(buffer))
                return new WkbReader(memoryStream).Read();
        }

        public static Geometry Parse(Stream stream)
        {
            return new WkbReader(stream).Read();
        }

        public string ToWkt()
        {
            return new WktWriter().Write(this);
        }

        public byte[] ToWkb()
        {
            return new WkbWriter().Write(this);
        }
    }
}