﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MathHelpers
{
    
        public class Vector3
        {
            public float x, y, z;
            public float[] vArray = new float[3];
            public Vector3(float X, float Y, float Z)
            {
                vArray[0] = X;
                vArray[1] = Y;
                vArray[2] = Z;

            }
            public Vector3(float[] tVA)
            {
                vArray = tVA;
            }

            public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
            {
                return new Vector3((float)(lhs.x + rhs.x), (float)(lhs.y + rhs.y), (float)(lhs.z + rhs.z));
            }

            public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
            {
                return new Vector3((float)(lhs.x - rhs.x), (float)(lhs.y - rhs.y), (float)(lhs.z - rhs.z));
            }
            public static Vector3 operator *(Vector3 lhs, float rhs)
            {
                return new Vector3((float)(lhs.x * rhs), (float)(lhs.y * rhs), (float)(lhs.z * rhs));
            }
            public static Vector3 operator *(float rhs, Vector3 lhs)
            {
                return new Vector3((float)(lhs.x * rhs), (float)(lhs.y * rhs), (float)(lhs.z * rhs));
            }
            public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
            {
                return new Vector3(
                    (lhs.m[0] * rhs.vArray[0]) + (lhs.m[3] * rhs.vArray[1]) + (lhs.m[6] * rhs.vArray[2]),
                    (lhs.m[1] * rhs.vArray[0]) + (lhs.m[4] * rhs.vArray[1]) + (lhs.m[7] * rhs.vArray[2]),
                    (lhs.m[2] * rhs.vArray[0]) + (lhs.m[5] * rhs.vArray[1]) + (lhs.m[8] * rhs.vArray[2]));
            }
            public static Vector3 operator /(Vector3 lhs, float rhs)
            {
                return new Vector3((float)(lhs.x / rhs), (float)(lhs.y / rhs), (float)(lhs.z / rhs));
            }
            public float Magnitude()
            {
                return (float)Math.Sqrt(vArray[0] * vArray[0] + vArray[1] * vArray[1] + vArray[2] * vArray[2]);
            }
            public float MagnitudeSqr()
            {
                return (x * x + y * y + z * z);
            }
            public float Distance(Vector3 other)
            {
                float dX = x - other.x;
                float dY = y - other.y;
                float dZ = z - other.z;
                return (float)Math.Sqrt(dX * dX + dY * dY + dZ * dZ);
            }
            public void Normalize()
            {
                float m = Magnitude();
                x /= m;
                y /= m;
                z /= m;
            }
            public Vector3 GetNormalized()
            {
                return (this / Magnitude());
            }
            public float Dot(Vector3 rhs)
            {
                return vArray[0] * rhs.vArray[0] + vArray[1] * rhs.vArray[1] + vArray[2] * rhs.vArray[2];
            }
            public Vector3 Cross(Vector3 rhs)
            {
                return new Vector3(
                (float)(this.y * rhs.z - this.z * rhs.y),
                (float)(this.z * rhs.x - this.x * rhs.z),
                (float)(this.x * rhs.y - this.y * rhs.x));
            }
            float AngleBetween(Vector3 other)
            {
                Vector3 a = GetNormalized();
                Vector3 b = other.GetNormalized();

                float d = a.x * b.x + a.y * b.y + a.z * b.z;
                return (float)Math.Acos(d);
            }
            public string toString()
            {
                return $"{vArray[0]} {vArray[1]} {vArray[2]}";
            }
        }
        public class Vector4
        {
            public float[] v = new float[4];

            public Vector4(float[] vec4)
            {
                v = vec4;
            }
            public Vector4(float x, float y, float z, float w)
            {
                v[0] = x;
                v[1] = y;
                v[2] = z;
                v[3] = w;
            }
            public Vector4()
            {
                v[0] = 0;
                v[1] = 0;
                v[2] = 0;
                v[3] = 0;
            }
            public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
            {
                return new Vector4
                    (
                    lhs.v[0] + rhs.v[0],
                    lhs.v[1] + rhs.v[1],
                    lhs.v[2] + rhs.v[2],
                    lhs.v[3] + rhs.v[3]
                    );
            }
            public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
            {
                return new Vector4
                    (
                    lhs.v[0] - rhs.v[0],
                    lhs.v[1] - rhs.v[1],
                    lhs.v[2] - rhs.v[2],
                    lhs.v[3] - rhs.v[3]
                    );
            }
            public static Vector4 operator *(Vector4 lhs, float rhs)
            {
                return new Vector4
                    (
                    lhs.v[0] * rhs,
                    lhs.v[1] * rhs,
                    lhs.v[2] * rhs,
                    lhs.v[3] * rhs
                    );
            }
            public static Vector4 operator *(float rhs, Vector4 lhs)
            {
                return new Vector4
                    (
                    lhs.v[0] * rhs,
                    lhs.v[1] * rhs,
                    lhs.v[2] * rhs,
                    lhs.v[3] * rhs
                    );
            }
            public static Vector4 operator *(Matrix4 lhs, Vector4 rhs)
            {
                return new Vector4(
                (lhs.m[0] * rhs.v[0]) + (lhs.m[4] * rhs.v[1]) + (lhs.m[8] * rhs.v[2]) + (lhs.m[12] * rhs.v[3]),
                (lhs.m[1] * rhs.v[0]) + (lhs.m[5] * rhs.v[1]) + (lhs.m[9] * rhs.v[2]) + (lhs.m[13] * rhs.v[3]),
                (lhs.m[2] * rhs.v[0]) + (lhs.m[6] * rhs.v[1]) + (lhs.m[10] * rhs.v[2]) + (lhs.m[14] * rhs.v[3]),
                (lhs.m[3] * rhs.v[0]) + (lhs.m[7] * rhs.v[1]) + (lhs.m[11] * rhs.v[2]) + (lhs.m[15] * rhs.v[3])
                );
            }
            public float Magnitude()
            {
                return (float)Math.Sqrt((double)(v[0] * v[0] + v[1] * v[1] + v[2] * v[2] + v[3] * v[3]));
            }
            public void Normalize()
            {
                float m = Magnitude();
                v[0] /= m;
                v[1] /= m;
                v[2] /= m;
                v[3] /= m;

            }
            public float Dot(Vector4 rhs)
            {
                return v[0] * rhs.v[0] + v[1] * rhs.v[1] + v[2] * rhs.v[2] + v[3] * rhs.v[3];
            }
            public Vector4 Cross(Vector4 rhs)
            {
                return new Vector4(
                    v[1] * rhs.v[2] - v[2] * rhs.v[1],
                    v[2] * rhs.v[0] - v[0] * rhs.v[2],
                    v[0] * rhs.v[1] - v[1] * rhs.v[0],
                    0);
            }
        }
        public class Matrix3
        {

            public float m1, m2, m3, m4, m5, m6, m7, m8, m9;

            //public float m1, m2, m3, m4, m5, m6, m7, m8, m9;
            public float[] m = new float[9];

            public Matrix3()
            {
                m[0] = 1; m[1] = 0; m[2] = 0;
                m[3] = 0; m[4] = 1; m[5] = 0;
                m[6] = 0; m[7] = 0; m[8] = 1;
            }

            public void SetScaled(float x, float y, float z)
            {
                m[0] = x; m[1] = 0; m[2] = 0;
                m[3] = 0; m[4] = y; m[5] = 0;
                m[6] = 0; m[7] = 0; m[8] = z;
            }
            public void SetScaled(Vector3 v)
            {
                m[0] = v.x; m[1] = 0; m[2] = 0;
                m[3] = 0; m[4] = v.y; m[5] = 0;
                m[6] = 0; m[7] = 0; m[8] = v.z;
            }
            public void Set(Matrix3 _m)
            {

                m[0] = _m.m[0]; m[1] = _m.m[1]; m[2] = _m.m[2];
                m[3] = _m.m[3]; m[4] = _m.m[4]; m[5] = _m.m[5];
                m[6] = _m.m[6]; m[7] = _m.m[7]; m[8] = _m.m[8];

            }
            public void Set(float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8, float m9)
            {
                m[0] = m1; m[1] = m2; m[2] = m3;
                m[3] = m4; m[4] = m5; m[5] = m6;
                m[6] = m7; m[7] = m6; m[8] = m9;
            }

            public void Scale(float x, float y, float z)
            {
                Matrix3 m = new Matrix3();
                m.SetScaled(x, y, z);
                Set(this * m);
            }
            void Scale(Vector3 v)
            {
                Matrix3 m = new Matrix3();
                m.SetScaled(v.x, v.y, v.z);
                Set(this * m);
            }
            public Matrix3(float[] tma)
            {
                m = tma;
            }
            public Matrix3(float mm1, float mm2, float mm3, float mm4, float mm5, float mm6, float mm7, float mm8, float mm9)
            {
                m[0] = mm1; m[1] = mm2; m[2] = mm3;
                m[3] = mm4; m[4] = mm5; m[5] = mm6;
                m[6] = mm7; m[7] = mm8; m[8] = mm9;
                //mm1 = m1; mm2 = m2; mm3 = m3;
                //mm4 = m4; mm5 = m5; mm6 = m6;
                //mm7 = m7; mm8 = m8; mm9 = m9;
            }
            public string toString()
            {
                return $"{m[0]} {m[1]} {m[2]}\n{m[3]} {m[4]} {m[5]}\n{m[6]} {m[7]} {m[8]}";
            }
            public void SetRotateX(double radians)
            {
                Set(1, 0, 0,
                    0, (float)Math.Cos(radians), (float)Math.Sin(radians), 0,
                    (float)-Math.Sin(radians), (float)Math.Cos(radians));
            }
            public void SetRotateY(double radians)
            {
                Set((float)Math.Cos(radians), 0, -(float)Math.Sin(radians),
                    0, 1, 0,
                    (float)Math.Sin(radians), 0, (float)Math.Cos(radians));
            }
            public void SetRotateZ(double radians)
            {
                Set((float)Math.Cos(radians), (float)Math.Sin(radians), 0,
                    (float)-Math.Sin(radians), (float)Math.Cos(radians), 0,
                    0, 0, 1);
            }
            public void SetTranslation(float x, float y)
            {
                m[6] = x; m[7] = y; m[8] = 1;
            }
            public void Translate(float x, float y)
            {
                m[6] += x; m[7] += y;
            }
        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
            {
                return new Matrix3(
                    lhs.m[0] * rhs.m[0] + lhs.m[3] * rhs.m[1] + lhs.m[6] * rhs.m[2],

                    lhs.m[1] * rhs.m[0] + lhs.m[4] * rhs.m[1] + lhs.m[7] * rhs.m[2],

                    lhs.m[2] * rhs.m[0] + lhs.m[5] * rhs.m[1] + lhs.m[8] * rhs.m[2],

                    lhs.m[0] * rhs.m[3] + lhs.m[3] * rhs.m[4] + lhs.m[6] * rhs.m[5],

                    lhs.m[1] * rhs.m[3] + lhs.m[4] * rhs.m[4] + lhs.m[7] * rhs.m[5],

                    lhs.m[2] * rhs.m[3] + lhs.m[5] * rhs.m[4] + lhs.m[8] * rhs.m[5],

                    lhs.m[0] * rhs.m[6] + lhs.m[3] * rhs.m[7] + lhs.m[6] * rhs.m[8],

                    lhs.m[1] * rhs.m[6] + lhs.m[4] * rhs.m[7] + lhs.m[7] * rhs.m[8],

                    lhs.m[2] * rhs.m[6] + lhs.m[5] * rhs.m[7] + lhs.m[8] * rhs.m[8]
                    );
            }
        }
        public class Matrix4
        {
            //public float m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16;

            public float m1
            {
                //get => m[0];
                get
                {
                    return m[0];
                }
                set
                {
                    m[0] = value;
                }
            }
            public float m2
            {
                //get => m[0];
                get
                {
                    return m[1];
                }
                set
                {
                    m[1] = value;
                }
            }
            public float m3
            {
                //get => m[0];
                get
                {
                    return m[2];
                }
                set
                {
                    m[2] = value;
                }
            }
            public float m4
            {
                //get => m[0];
                get
                {
                    return m[3];
                }
                set
                {
                    m[3] = value;
                }
            }
            public float m5
            {
                //get => m[0];
                get
                {
                    return m[4];
                }
                set
                {
                    m[4] = value;
                }
            }
            public float m6
            {
                //get => m[0];
                get
                {
                    return m[5];
                }
                set
                {
                    m[5] = value;
                }
            }
            public float m7
            {
                //get => m[0];
                get
                {
                    return m[6];
                }
                set
                {
                    m[6] = value;
                }
            }
            public float m8
            {
                //get => m[0];
                get
                {
                    return m[7];
                }
                set
                {
                    m[7] = value;
                }
            }
            public float m9
            {
                //get => m[0];
                get
                {
                    return m[8];
                }
                set
                {
                    m[8] = value;
                }
            }
            public float m10
            {
                //get => m[0];
                get
                {
                    return m[9];
                }
                set
                {
                    m[9] = value;
                }
            }
            public float m11
            {
                //get => m[0];
                get
                {
                    return m[10];
                }
                set
                {
                    m[10] = value;
                }
            }
            public float m12
            {
                //get => m[0];
                get
                {
                    return m[11];
                }
                set
                {
                    m[11] = value;
                }
            }
            public float m13
            {
                //get => m[0];
                get
                {
                    return m[12];
                }
                set
                {
                    m[12] = value;
                }
            }
            public float m14
            {
                //get => m[0];
                get
                {
                    return m[13];
                }
                set
                {
                    m[13] = value;
                }
            }
            public float m15
            {
                //get => m[0];
                get
                {
                    return m[14];
                }
                set
                {
                    m[14] = value;
                }
            }
            public float m16
            {
                //get => m[0];
                get
                {
                    return m[15];
                }
                set
                {
                    m[15] = value;
                }
            }

            public float[] m = new float[16];
            public Matrix4()
            {
                m[0] = 1; m[1] = 0; m[2] = 0; m[3] = 0;
                m[4] = 0; m[5] = 1; m[6] = 0; m[7] = 0;
                m[8] = 0; m[9] = 0; m[10] = 1; m[11] = 0;
                m[12] = 0; m[13] = 0; m[14] = 0; m[15] = 1;
            }
            public Matrix4(float[] _m)
            {
                m = _m;
            }
            //public Matrix4(float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8, float m9, float m10, float m11, float m12, float m13, float m14, float m15, float m16)
            //{
            //    m[0] = m1; m[1] = m2; m[2] = m3; m[3] = m4;
            //    m[4] = m5; m[5] = m6; m[6] = m7; m[7] = m8;
            //    m[8] = m9; m[9] = m10; m[10] = m11; m[11] = m12;
            //    m[12] = m13; m[13] = m14; m[14] = m15; m[15] = m16;
            //}
            public Matrix4(float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8, float m9, float m10, float m11, float m12, float m13, float m14, float m15, float m16)
            {
                m[0] = m1; m[1] = m2; m[2] = m3; m[3] = m4;
                m[4] = m5; m[5] = m6; m[6] = m7; m[7] = m8;
                m[8] = m9; m[9] = m10; m[10] = m11; m[11] = m12;
                m[12] = m13; m[13] = m14; m[14] = m15; m[15] = m16;
            }
            public void Set(Matrix4 _m)
            {
                m[0] = _m.m[0]; m[1] = _m.m[1]; m[2] = _m.m[2]; m[3] = _m.m[3];
                m[4] = _m.m[4]; m[5] = _m.m[5]; m[6] = _m.m[6]; m[7] = _m.m[7];
                m[8] = _m.m[8]; m[9] = _m.m[9]; m[10] = _m.m[10]; m[11] = _m.m[11];
                m[12] = _m.m[12]; m[13] = _m.m[13]; m[14] = _m.m[14]; m[15] = _m.m[15];
            }
            public void SetScaled(float x, float y, float z)
            {
                m[0] = x; m[1] = 0; m[1] = 0; m[2] = 0;
                m[4] = 0; m[5] = y; m[6] = 0; m[7] = 0;
                m[8] = 0; m[9] = 0; m[10] = z; m[11] = 0;
                m[12] = 0; m[13] = 0; m[14] = 0; m[15] = 1;
            }
            public void SetRotateX(double radians)
            {
                Matrix4 n = new Matrix4();
                n.m[0] = 1;
                n.m[5] = (float)Math.Cos(radians);
                n.m[6] = (float)Math.Sin(radians);
                n.m[9] = (float)-Math.Sin(radians);
                n.m[10] = (float)Math.Cos(radians);
                n.m[15] = 1;
                Set(n);
            }
            public void SetRotateY(double radians)
            {
                Matrix4 n = new Matrix4();

                n.m[0] = (float)Math.Cos(radians);
                n.m[2] = (float)-Math.Sin(radians);
                n.m[5] = 1;
                n.m[8] = (float)Math.Sin(radians);
                n.m[10] = (float)Math.Cos(radians);
                n.m[15] = 1;

                Set(n);
            }
            public void SetRotateZ(double radians)
            {
                Matrix4 n = new Matrix4();
                n.m[0] = (float)Math.Cos(radians);      // | Cos, Sin, 0, 0
                n.m[1] = (float)Math.Sin(radians);      // |-Sin, Cos, 0, 0
                n.m[4] = (float)-Math.Sin(radians);     // | 0,   0,   1, 0
                n.m[5] = (float)Math.Cos(radians);      // | 0,   0,   0, 1
                n.m[10] = 1;
                n.m[15] = 1;
                Set(n);
            }
            public void SetTranslation(float x, float y, float z)
            {
                m[12] = x; m[13] = y; m[14] = z; m[15] = 1;
            }
            public void Translate(float x, float y, float z)
            {
                m[12] += x; m[13] += y; m[14] += z;
            }
            public static Matrix4 operator *(Matrix4 lhs, Matrix4 rhs)
            {
                Matrix4 Matty = new Matrix4();

                Matty.m[0] = rhs.m[0] * lhs.m[0] + rhs.m[1] * lhs.m[4] + rhs.m[2] * lhs.m[8] + rhs.m[3] * lhs.m[12];
                Matty.m[1] = rhs.m[0] * lhs.m[1] + rhs.m[1] * lhs.m[5] + rhs.m[2] * lhs.m[9] + rhs.m[3] * lhs.m[13];
                Matty.m[2] = rhs.m[0] * lhs.m[2] + rhs.m[1] * lhs.m[6] + rhs.m[2] * lhs.m[10] + rhs.m[3] * lhs.m[14];
                Matty.m[3] = rhs.m[0] * lhs.m[3] + rhs.m[1] * lhs.m[7] + rhs.m[2] * lhs.m[11] + rhs.m[3] * lhs.m[15];

                Matty.m[4] = rhs.m[4] * lhs.m[0] + rhs.m[5] * lhs.m[4] + rhs.m[6] * lhs.m[8] + rhs.m[7] * lhs.m[12];
                Matty.m[5] = rhs.m[4] * lhs.m[1] + rhs.m[5] * lhs.m[5] + rhs.m[6] * lhs.m[9] + rhs.m[7] * lhs.m[13];
                Matty.m[6] = rhs.m[4] * lhs.m[2] + rhs.m[5] * lhs.m[6] + rhs.m[6] * lhs.m[10] + rhs.m[7] * lhs.m[14];
                Matty.m[7] = rhs.m[4] * lhs.m[3] + rhs.m[5] * lhs.m[7] + rhs.m[6] * lhs.m[11] + rhs.m[7] * lhs.m[15];

                Matty.m[8] = rhs.m[8] * lhs.m[0] + rhs.m[9] * lhs.m[4] + rhs.m[10] * lhs.m[8] + rhs.m[11] * lhs.m[12];
                Matty.m[9] = rhs.m[8] * lhs.m[1] + rhs.m[9] * lhs.m[5] + rhs.m[10] * lhs.m[9] + rhs.m[11] * lhs.m[13];
                Matty.m[10] = rhs.m[8] * lhs.m[2] + rhs.m[9] * lhs.m[6] + rhs.m[10] * lhs.m[10] + rhs.m[11] * lhs.m[14];
                Matty.m[11] = rhs.m[8] * lhs.m[3] + rhs.m[9] * lhs.m[7] + rhs.m[10] * lhs.m[11] + rhs.m[11] * lhs.m[15];

                Matty.m[12] = rhs.m[12] * lhs.m[0] + rhs.m[13] * lhs.m[4] + rhs.m[14] * lhs.m[8] + rhs.m[15] * lhs.m[12];
                Matty.m[13] = rhs.m[12] * lhs.m[1] + rhs.m[13] * lhs.m[5] + rhs.m[14] * lhs.m[9] + rhs.m[15] * lhs.m[13];
                Matty.m[14] = rhs.m[12] * lhs.m[2] + rhs.m[13] * lhs.m[6] + rhs.m[14] * lhs.m[10] + rhs.m[15] * lhs.m[14];
                Matty.m[15] = rhs.m[12] * lhs.m[3] + rhs.m[13] * lhs.m[7] + rhs.m[14] * lhs.m[11] + rhs.m[15] * lhs.m[15];


                return Matty;
            }

        }
    
}