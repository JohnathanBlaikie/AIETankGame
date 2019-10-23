using System;
using System.Collections.Generic;
using System.Text;

namespace MathHelpers
{
    public class Vector2
    {
        public float x, y;
        public Vector2(float X, float Y)
        {
            x = X;
            y = Y;
        }
        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x + rhs.x, lhs.y + rhs.y);
        }

        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x - rhs.x, lhs.y - rhs.y);
        }
        public static Vector2 operator *(Vector2 lhs, float rhs)
        {
            return new Vector2((float)(lhs.x * rhs), (float)(lhs.y * rhs));
        }
        public static Vector2 operator *(float rhs, Vector2 lhs)
        {
            return new Vector2((float)(lhs.x * rhs), (float)(lhs.y * rhs));
        }

        public static Vector2 operator /(Vector2 lhs, float rhs)
        {
            return new Vector2((float)(lhs.x / rhs), (float)(lhs.y / rhs));
        }
        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y);
        }
        public float MagnitudeSqr()
        {
            return (x * x + y * y);
        }
        public float Distance(Vector2 other)
        {
            float dX = x - other.x;
            float dY = y - other.y;
            return (float)Math.Sqrt(dX * dX + dY * dY);
        }
        public void Normalize()
        {
            float m = Magnitude();
            x /= m;
            y /= m;
        }
        public Vector2 GetNormalized()
        {
            return (this / Magnitude());
        }
        public float Dot(Vector2 rhs)
        {
            return x * rhs.x + y * rhs.y;
        }

        float AngleBetween(Vector2 other)
        {
            Vector2 a = GetNormalized();
            Vector2 b = other.GetNormalized();

            float d = a.x * b.x + a.y * b.y;
            return (float)Math.Acos(d);
        }
        public string toString()
        {
            return $"{x} {y}";
        }
    }

    public class Vector3
    {
        public float x, y, z;

        public Vector3()
        {
            x = 0;
            y = 0;
            z = 0;
        }
        public Vector3(float _x, float _y, float _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }

        public Vector3(Vector3 v)
        {
            x = v.x;
            y = v.y;
            z = v.z;
        }

        #region Operators
        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }
        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }
        
        public static Vector3 operator *(Vector3 lhs, float rhs)
        {
            return new Vector3(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);
        }
     
        public static Vector3 operator /(Vector3 lhs, float rhs)
        {
            return new Vector3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
        }

        public static Vector3 operator *(float lhs, Vector3 rhs)
        {
            return rhs * lhs;
        }
        
        public static Vector3 operator /(float lhs, Vector3 rhs)
        {
            return rhs * lhs;
        }
        #endregion Operators
        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }
        public float MagnitudeSqr()
        {
            return x * x + y * y + z * z;
        }

        public float Distance(Vector3 other)
        {
            float dx = x - other.x;
            float dy = y - other.y;
            float dz = z - other.z;
            return (float)Math.Sqrt(dx * dx + dy * dy + dz * dz);
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
            return x * rhs.x + y * rhs.y + z * rhs.z;
        }
        public Vector3 Cross(Vector3 rhs)
        {
            return new Vector3(
           y * rhs.z - z * rhs.y,
           z * rhs.x - x * rhs.z,
           x * rhs.y - y * rhs.x);
        }
        float AngleBetween(Vector3 other)
        {
            Vector3 a = GetNormalized();
            Vector3 b = other.GetNormalized();
            float d = a.x * b.x + a.y * b.y + a.z * b.z;
            return (float)Math.Acos(d);
        }

        public static Vector3 Min (Vector3 a, Vector3 b)
        {
            return new Vector3(Math.Min(a.x, b.x), Math.Min(a.y, b.y), Math.Min(a.z, b.z));

        }
        public static Vector3 Max(Vector3 a, Vector3 b)
        {
            return new Vector3(Math.Max(a.x, b.x), Math.Max(a.y, b.y), Math.Max(a.z, b.z));

        }
        public static Vector3 Clamp(Vector3 t, Vector3 a, Vector3 b)
        {
            return Max(a, Min(b, t));

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

    #region Matrix3
    #region Teacher Code
    public class Matrix3
    {
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9;
        public Matrix3()
        {
            m1 = 1; m2 = 0; m3 = 0;
            m4 = 0; m5 = 1; m6 = 0;
            m7 = 0; m8 = 0; m9 = 1;
        }
        public Matrix3(Matrix3 _m)
        {
            m1 = _m.m1;
            m2 = _m.m2;
            m3 = _m.m3;
            m4 = _m.m4;
            m5 = _m.m5;
            m6 = _m.m6;
            m7 = _m.m7;
            m8 = _m.m8;
            m9 = _m.m9;
        }
        public Matrix3(float _m1, float _m2, float _m3, float _m4, float _m5, float _m6, float _m7, float _m8, float _m9)
        {
            m1 = _m1;
            m2 = _m2;
            m3 = _m3;
            m4 = _m4;
            m5 = _m5;
            m6 = _m6;
            m7 = _m7;
            m8 = _m8;
            m9 = _m9;
        }
        public static Matrix3 identity = new Matrix3(1, 0, 0, 0, 1, 0, 0, 0, 1);
        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {
            //147
            //258
            //369

            return new Matrix3(
            #region Broken Code
                //Top Row (m1 m2 m3) ??
                //lhs.m1 * rhs.m1 + lhs.m4 * rhs.m2 + lhs.m7 * rhs.m3,
                //lhs.m1 * rhs.m4 + lhs.m4 * rhs.m5 + lhs.m7 * rhs.m5,
                //lhs.m1 * rhs.m7 + lhs.m4 * rhs.m8 + lhs.m7 * rhs.m9,

                ////Middle Row (m4 m5 m6) ??
                //lhs.m2 * rhs.m1 + lhs.m5 * rhs.m2 + lhs.m8 * rhs.m3,
                //lhs.m2 * rhs.m4 + lhs.m5 * rhs.m5 + lhs.m8 * rhs.m5,
                //lhs.m2 * rhs.m7 + lhs.m5 * rhs.m8 + lhs.m8 * rhs.m9,

                ////Bottom Row (m7 m8 m9) ??
                //lhs.m3 * rhs.m1 + lhs.m6 * rhs.m2 + lhs.m9 * rhs.m3,
                //lhs.m3 * rhs.m4 + lhs.m6 * rhs.m5 + lhs.m9 * rhs.m5,
                //lhs.m3 * rhs.m7 + lhs.m6 * rhs.m8 + lhs.m9 * rhs.m9
            #endregion
            #region Working Code
                //Top Row (m1 m2 m3) ??
                lhs.m1 * rhs.m1 + lhs.m4 * rhs.m2 + lhs.m7 * rhs.m3,
                lhs.m2 * rhs.m1 + lhs.m5 * rhs.m2 + lhs.m8 * rhs.m3,
                lhs.m3 * rhs.m1 + lhs.m6 * rhs.m2 + lhs.m9 * rhs.m3,

                //Middle Row (m4 m5 m6) ??
                lhs.m1 * rhs.m4 + lhs.m4 * rhs.m5 + lhs.m7 * rhs.m6,
                lhs.m2 * rhs.m4 + lhs.m5 * rhs.m5 + lhs.m8 * rhs.m6,
                lhs.m3 * rhs.m4 + lhs.m6 * rhs.m5 + lhs.m9 * rhs.m6,

                //Bottom Row (m7 m8 m9) ??
                lhs.m1 * rhs.m7 + lhs.m4 * rhs.m8 + lhs.m7 * rhs.m9,
                lhs.m2 * rhs.m7 + lhs.m5 * rhs.m8 + lhs.m8 * rhs.m9,
                lhs.m3 * rhs.m7 + lhs.m6 * rhs.m8 + lhs.m9 * rhs.m9
            #endregion
                );
        }

        internal void SetTranslation(float x, float y)
        {
            m7 = x;
            m8 = y;
        }
        internal void Translate(float x, float y)
        {
            m7 += x;
            m8 += y;
        }

        public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
        {
            return new Vector3(
                lhs.m1 * rhs.x + lhs.m4 * rhs.y + lhs.m7 * rhs.z,
                lhs.m2 * rhs.x + lhs.m5 * rhs.y + lhs.m8 * rhs.z,
                lhs.m3 * rhs.x + lhs.m6 * rhs.y + lhs.m9 * rhs.z);
        }
        public Matrix3 GetTransposed()
        {
            return new Matrix3(
                m1, m4, m7,
                m2, m5, m8,
                m3, m6, m9
                );
        }
        public void SetScaled(float x, float y, float z)
        {
            m1 = x; m2 = 0; m3 = 0;
            m4 = 0; m5 = y; m6 = 0;
            m7 = 0; m8 = 0; m9 = z;
        }
        public void SetScaled(Vector3 _v)
        {
            m1 = _v.x; m2 = 0; m3 = 0;
            m4 = 0; m5 = _v.y; m6 = 0;
            m7 = 0; m8 = 0; m9 = _v.z;

        }
        public void Scale(float x, float y, float z)
        {
            Matrix3 m = new Matrix3();
            m.SetScaled(x, y, z);
            Set(this * m);
        }
        void Scale(Vector3 _v)
        {
            Matrix3 m = new Matrix3();
            m.SetScaled(_v.x, _v.y, _v.z);
            Set(this * m);
        }
        void Set(Matrix3 _m)
        {
            m1 = _m.m1;
            m2 = _m.m2;
            m3 = _m.m3;
            m4 = _m.m4;
            m5 = _m.m5;
            m6 = _m.m6;
            m7 = _m.m7;
            m8 = _m.m8;
            m9 = _m.m9;
        }
        void Set(float _m1, float _m2, float _m3, float _m4, float _m5, float _m6, float _m7, float _m8, float _m9)
        {
            m1 = _m1;
            m2 = _m2;
            m3 = _m3;
            m4 = _m4;
            m5 = _m5;
            m6 = _m6;
            m7 = _m7;
            m8 = _m8;
            m9 = _m9;
        }
        public void SetRotateX(double radians)
        {
            Set(
                1, 0, 0,
                0, (float)Math.Cos(radians), (float)Math.Sin(radians),
                0, (float)-Math.Sin(radians), (float)Math.Cos(radians)
                );
        }
        public void RotateX(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateX(radians);
            Set(this * m);
        }
        public void SetRotateY(double radians)
        {
            Set(
               (float)Math.Cos(radians), 0, (float)-Math.Sin(radians),
               0, 1, 0,
               (float)Math.Sin(radians), 0, (float)Math.Cos(radians)
                );
        }
        public void RotateY(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateY(radians);
            Set(this * m);
        }
        public void SetRotateZ(double radians)
        {
            Set(
                (float)Math.Cos(radians), (float)Math.Sin(radians), 0,
                (float)-Math.Sin(radians), (float)Math.Cos(radians), 0,
                0, 0, 1
                );
        }
        public void RotateZ(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateZ(radians);
            Set(this * m);
        }
        void SetEuler(float pitch, float yaw, float roll)
        {
            Matrix3 x = new Matrix3();
            Matrix3 y = new Matrix3();
            Matrix3 z = new Matrix3();
            x.SetRotateX(pitch);
            y.SetRotateY(yaw);
            z.SetRotateZ(roll);
            // combine rotations in a specific order
            Set(z * y * x);
        }
    }
    #endregion Techer Code

    #region Original Code
    //ORIGINAL MATRIX3 CODE
    //public class Matrix3
    //{
    //    public float m1
    //    {
    //        //get => m[0];
    //        get
    //        {
    //            return m[0];
    //        }
    //        set
    //        {
    //            m[0] = value;
    //        }
    //    }
    //    public float m2
    //    {
    //        //get => m[0];
    //        get
    //        {
    //            return m[1];
    //        }
    //        set
    //        {
    //            m[1] = value;
    //        }
    //    }
    //    public float m3
    //    {
    //        //get => m[0];
    //        get
    //        {
    //            return m[2];
    //        }
    //        set
    //        {
    //            m[2] = value;
    //        }
    //    }
    //    public float m4
    //    {
    //        //get => m[0];
    //        get
    //        {
    //            return m[3];
    //        }
    //        set
    //        {
    //            m[3] = value;
    //        }
    //    }
    //    public float m5
    //    {
    //        //get => m[0];
    //        get
    //        {
    //            return m[4];
    //        }
    //        set
    //        {
    //            m[4] = value;
    //        }
    //    }
    //    public float m6
    //    {
    //        //get => m[0];
    //        get
    //        {
    //            return m[5];
    //        }
    //        set
    //        {
    //            m[5] = value;
    //        }
    //    }
    //    public float m7
    //    {
    //        //get => m[0];
    //        get
    //        {
    //            return m[6];
    //        }
    //        set
    //        {
    //            m[6] = value;
    //        }
    //    }
    //    public float m8
    //    {
    //        //get => m[0];
    //        get
    //        {
    //            return m[7];
    //        }
    //        set
    //        {
    //            m[7] = value;
    //        }
    //    }
    //    public float m9
    //    {
    //        //get => m[0];
    //        get
    //        {
    //            return m[8];
    //        }
    //        set
    //        {
    //            m[8] = value;
    //        }
    //    }
    //    //public float m1, m2, m3, m4, m5, m6, m7, m8, m9;

    //    //public float m1, m2, m3, m4, m5, m6, m7, m8, m9;
    //    public float[] m = new float[9];

    //    public Matrix3()
    //    {
    //        m[0] = 1; m[1] = 0; m[2] = 0;
    //        m[3] = 0; m[4] = 1; m[5] = 0;
    //        m[6] = 0; m[7] = 0; m[8] = 1;
    //    }

    //    public void SetScaled(float x, float y, float z)
    //    {
    //        m[0] = x; m[1] = 0; m[2] = 0;
    //        m[3] = 0; m[4] = y; m[5] = 0;
    //        m[6] = 0; m[7] = 0; m[8] = z;
    //    }
    //    public void SetScaled(Vector3 v)
    //    {
    //        m[0] = v.x; m[1] = 0; m[2] = 0;
    //        m[3] = 0; m[4] = v.y; m[5] = 0;
    //        m[6] = 0; m[7] = 0; m[8] = v.z;
    //    }
    //    public void Set(Matrix3 _m)
    //    {

    //        m[0] = _m.m[0]; m[1] = _m.m[1]; m[2] = _m.m[2];
    //        m[3] = _m.m[3]; m[4] = _m.m[4]; m[5] = _m.m[5];
    //        m[6] = _m.m[6]; m[7] = _m.m[7]; m[8] = _m.m[8];

    //    }
    //    public void Set(float _m1, float _m2, float _m3, float _m4, float _m5, float _m6, float _m7, float _m8, float _m9)
    //    {
    //        m[0] = _m1; m[1] = _m2; m[2] = _m3;
    //        m[3] = _m4; m[4] = _m5; m[5] = _m6;
    //        m[6] = _m7; m[7] = _m8; m[8] = _m9;
    //    }

    //    public void Scale(float x, float y, float z)
    //    {
    //        Matrix3 _m = new Matrix3();
    //        _m.SetScaled(x, y, z);
    //        Set(this * _m);
    //    }
    //    void Scale(Vector3 v)
    //    {
    //        Matrix3 _m = new Matrix3();
    //        _m.SetScaled(v.x, v.y, v.z);
    //        Set(this * _m);
    //    }
    //    public Matrix3(float[] tma)
    //    {
    //        m = tma;
    //    }
    //    public Matrix3(float _m1, float _m2, float _m3, float _m4, float _m5, float _m6, float _m7, float _m8, float _m9)
    //    {
    //        m[0] = _m1; m[1] = _m2; m[2] = _m3;
    //        m[3] = _m4; m[4] = _m5; m[5] = _m6;
    //        m[6] = _m7; m[7] = _m8; m[8] = _m9;
    //        //_m1 = m1; _m2 = m2; _m3 = m3;
    //        //_m4 = m4; _m5 = m5; _m6 = m6;
    //        //_m7 = m7; _m8 = m8; _m9 = m9;
    //    }
    //    public string toString()
    //    {
    //        return $"{m[0]} {m[1]} {m[2]}\n{m[3]} {m[4]} {m[5]}\n{m[6]} {m[7]} {m[8]}";
    //    }
    //    public void SetRotateX(double radians)
    //    {
    //        Set(1, 0, 0,
    //            0, (float)Math.Cos(radians), (float)Math.Sin(radians), 0,
    //            (float)-Math.Sin(radians), (float)Math.Cos(radians));
    //    }
    //    public void SetRotateY(double radians)
    //    {
    //        Set((float)Math.Cos(radians), 0, -(float)Math.Sin(radians),
    //            0, 1, 0,
    //            (float)Math.Sin(radians), 0, (float)Math.Cos(radians));
    //    }
    //    public void SetRotateZ(double radians)
    //    {
    //        Set((float)Math.Cos(radians), (float)Math.Sin(radians), 0,
    //            (float)-Math.Sin(radians), (float)Math.Cos(radians), 0,
    //            0, 0, 1);
    //    }
    //    public void RotateX(double radians)
    //    {
    //        Matrix3 m = new Matrix3();
    //        m.SetRotateX(radians);
    //        Set(this * m);
    //    }
    //    public void RotateY(double radians)
    //    {
    //        Matrix3 m = new Matrix3();
    //        m.SetRotateY(radians);
    //        Set(this * m);
    //    }
    //    public void RotateZ(double radians)
    //    {
    //        Matrix3 m = new Matrix3();
    //        m.SetRotateZ(radians);
    //        Set(this * m);
    //    }
    //    public void SetTranslation(float x, float y)
    //    {
    //        m[6] = x; m[7] = y;
    //    }
    //    public void Translate(float x, float y)
    //    {
    //        m[6] += x; m[7] += y;
    //    }
    //    public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
    //    {
    //        return new Matrix3(
    //          lhs.m[0] * rhs.m[0] + lhs.m[3] * rhs.m[1] + lhs.m[2] * rhs.m[2],
    //          lhs.m[1] * rhs.m[0] + lhs.m[4] * rhs.m[1] + lhs.m[5] * rhs.m[2],
    //          lhs.m[2] * rhs.m[0] + lhs.m[5] * rhs.m[1] + lhs.m[8] * rhs.m[2],

    //          lhs.m[0] * rhs.m[3] + lhs.m[3] * rhs.m[4] + lhs.m[2] * rhs.m[5],
    //          lhs.m[1] * rhs.m[3] + lhs.m[4] * rhs.m[4] + lhs.m[5] * rhs.m[5],
    //          lhs.m[2] * rhs.m[3] + lhs.m[5] * rhs.m[4] + lhs.m[8] * rhs.m[5],

    //          lhs.m[0] * rhs.m[6] + lhs.m[1] * rhs.m[7] + lhs.m[2] * rhs.m[8],
    //          lhs.m[1] * rhs.m[6] + lhs.m[4] * rhs.m[7] + lhs.m[5] * rhs.m[8],
    //          lhs.m[2] * rhs.m[6] + lhs.m[5] * rhs.m[7] + lhs.m[8] * rhs.m[8]);
    //    }
    //}

    //public class Vector3
    //{
    //    public float x, y, z;
    //    public float[] v = new float[3];

    //    public Raylib.Vector3 rV3()
    //    {
    //        Raylib.Vector3 tRV3 = new Raylib.Vector3();
    //        tRV3.x = v[0];
    //        tRV3.y = v[1];
    //        tRV3.z = v[2];

    //        return tRV3;
    //    }
    //    public Vector3(float X, float Y, float Z)
    //    {
    //        v[0] = X;
    //        v[1] = Y;
    //        v[2] = Z;

    //    }
    //    public Vector3(float[] tVA)
    //    {
    //        v = tVA;
    //    }

    //    public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
    //    {
    //        return new Vector3((float)(lhs.x + rhs.x), (float)(lhs.y + rhs.y), (float)(lhs.z + rhs.z));
    //    }

    //    public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
    //    {
    //        return new Vector3((float)(lhs.x - rhs.x), (float)(lhs.y - rhs.y), (float)(lhs.z - rhs.z));
    //    }
    //    public static Vector3 operator *(Vector3 lhs, float rhs)
    //    {
    //        return new Vector3((float)(lhs.x * rhs), (float)(lhs.y * rhs), (float)(lhs.z * rhs));
    //    }
    //    public static Vector3 operator *(float rhs, Vector3 lhs)
    //    {
    //        return new Vector3((float)(lhs.x * rhs), (float)(lhs.y * rhs), (float)(lhs.z * rhs));
    //    }
    //    public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
    //    {
    //        return new Vector3(
    //            (lhs.m[0] * rhs.v[0]) + (lhs.m[3] * rhs.v[1]) + (lhs.m[6] * rhs.v[2]),
    //            (lhs.m[1] * rhs.v[0]) + (lhs.m[4] * rhs.v[1]) + (lhs.m[7] * rhs.v[2]),
    //            (lhs.m[2] * rhs.v[0]) + (lhs.m[5] * rhs.v[1]) + (lhs.m[8] * rhs.v[2]));
    //    }
    //    public static Vector3 operator /(Vector3 lhs, float rhs)
    //    {
    //        return new Vector3((float)(lhs.x / rhs), (float)(lhs.y / rhs), (float)(lhs.z / rhs));
    //    }
    //    public float Magnitude()
    //    {
    //        return (float)Math.Sqrt(v[0] * v[0] + v[1] * v[1] + v[2] * v[2]);
    //    }
    //    public float MagnitudeSqr()
    //    {
    //        return (x * x + y * y + z * z);
    //    }
    //    public float Distance(Vector3 other)
    //    {
    //        float dX = x - other.x;
    //        float dY = y - other.y;
    //        float dZ = z - other.z;
    //        return (float)Math.Sqrt(dX * dX + dY * dY + dZ * dZ);
    //    }
    //    public void Normalize()
    //    {
    //        float m = Magnitude();
    //        x /= m;
    //        y /= m;
    //        z /= m;
    //    }
    //    public Vector3 GetNormalized()
    //    {
    //        return (this / Magnitude());
    //    }
    //    public float Dot(Vector3 rhs)
    //    {
    //        return v[0] * rhs.v[0] + v[1] * rhs.v[1] + v[2] * rhs.v[2];
    //    }
    //    public Vector3 Cross(Vector3 rhs)
    //    {
    //        return new Vector3(
    //        (float)(this.y * rhs.z - this.z * rhs.y),
    //        (float)(this.z * rhs.x - this.x * rhs.z),
    //        (float)(this.x * rhs.y - this.y * rhs.x));
    //    }
    //    float AngleBetween(Vector3 other)
    //    {
    //        Vector3 a = GetNormalized();
    //        Vector3 b = other.GetNormalized();

    //        float d = a.x * b.x + a.y * b.y + a.z * b.z;
    //        return (float)Math.Acos(d);
    //    }
    //    public string toString()
    //    {
    //        return $"{v[0]} {v[1]} {v[2]}";
    //    }
    //}
    #endregion Original Code
    #endregion Matrix3

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
    
    public class AABB
    {
        Vector3 min = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
        Vector3 max = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);

        public AABB()
        {

        }
        public AABB(Vector3 min, Vector3 max)
        {
            this.min = min;
            this.max = max;
        }
        public void Resize(Vector3 min, Vector3 max)
        {
            this.min = min;
            this.max = max;
        }
        public Vector3 Center()
        {
            return (min + max) * 0.5f;

        }
        public Vector3 Extents()
        {
            return new Vector3(Math.Abs(max.x - min.x) * 0.5f, Math.Abs(max.y - min.y) * 0.5f, Math.Abs(max.z - min.z) * 0.5f);

        }

        public List<Vector3> Corners()
        {
            List<Vector3> corners = new List<Vector3>(4);
            corners[0] = min;
            corners[1] = new Vector3(min.x, max.y, min.z);
            corners[2] = max;
            corners[3] = new Vector3(max.x, min.y, max.z);
            return corners;

        }

        public void Fit(List<Vector3> points)
        {
            min = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
            max = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);

            foreach(Vector3 p in points)
            {
                min = Vector3.Min(min, p);
                max = Vector3.Max(max, p);
            }
        }

        public bool Overlaps(Vector3 p)
        {
            return !(p.x < min.x || p.y < min.y || p.x > max.x || p.y > max.y);

        }

        public bool Overlaps(AABB other)
        {
            return !(max.x < other.min.x || max.y < other.min.y || min.x > other.max.x || min.y > other.max.y);

        }
        public Vector3 ClosestPoint(Vector3 p)
        {
            return Vector3.Clamp(p, min, max);

        }
    }

    public class Sphere
    {
        public Vector3 center;
        public float radius;
        public Sphere()
        {

        }
        public Sphere(Vector3 p, float r)
        {
            this.center = p;
            this.radius = r;
        }

        public bool Overlaps(Vector3 p)
        {
            Vector3 toPoint = p - center;
            return toPoint.MagnitudeSqr() <= (radius * radius);

        }
        public bool Overlaps(Sphere other)
        {
            Vector3 diff = other.center - center;
            float f = radius + other.radius;
            return diff.MagnitudeSqr() <= (radius * radius);

        }
        public bool Overlaps(AABB aabb)
        {
            Vector3 diff = aabb.ClosestPoint(center) - center;
            return diff.Dot(diff) <= (radius * radius);

        }
        public Vector3 ClosestPoint(Vector3 p)
        {
            Vector3 toPoint = p - center;

            if(toPoint.MagnitudeSqr()> radius*radius)
            {
                toPoint = toPoint.GetNormalized() * radius;
            }
            return center + toPoint;

        }
    }
    public class Ray
    {

        Vector3 origin;
        Vector3 direction;
        float length;
        public Ray()
        {

        }
        public Ray(Vector3 start, Vector3 dir, float len = float.MaxValue)
        {
            origin = start;
            direction = dir;
            length = len;
        }
        public float Clamp(float t, float a, float b)
        {
            return Math.Max(a, Math.Min(a, t));

        }
        public Vector3 ClosestPoint(Vector3 point)
        {
            Vector3 p = point - origin;
            float t = Clamp(p.Dot(direction), 0, length);
            return origin + direction * t;

        }
        public bool Intersects(Sphere sp, Vector3 I = null)
        {
            Vector3 L = sp.center - origin;

            float t = L.Dot(direction);

            float dd = L.Dot(L) - t * t;

            t -= (float)Math.Sqrt(sp.radius * sp.radius - dd);

            if(t >= 0 && t <= length)
            {
                if(I != null )
                {
                    I = origin + direction * t;
                }
                return true;
            }

            return false;

        }
    }
}



