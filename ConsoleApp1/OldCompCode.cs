using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class OldCompCode
    {
        #region original code
        #region original matrix3 code
        //ORIGINAL MATRIX3 CODE
        //public class Matrix3
        //{

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
        //        //012
        //        //345
        //        //678

        //        return new Matrix3(


        //            lhs.m[0] * rhs.m[0] + lhs.m[1] * rhs.m[3] + lhs.m[2] * rhs.m[6],
        //            lhs.m[3] * rhs.m[0] + lhs.m[4] * rhs.m[3] + lhs.m[5] * rhs.m[6],
        //            lhs.m[6] * rhs.m[0] + lhs.m[7] * rhs.m[3] + lhs.m[8] * rhs.m[6],

        //            lhs.m[0] * rhs.m[1] + lhs.m[1] * rhs.m[4] + lhs.m[2] * rhs.m[7],
        //            lhs.m[3] * rhs.m[1] + lhs.m[4] * rhs.m[4] + lhs.m[5] * rhs.m[7],
        //            lhs.m[6] * rhs.m[1] + lhs.m[7] * rhs.m[4] + lhs.m[8] * rhs.m[7],

        //            lhs.m[0] * rhs.m[2] + lhs.m[1] * rhs.m[5] + lhs.m[2] * rhs.m[8],
        //            lhs.m[3] * rhs.m[2] + lhs.m[4] * rhs.m[5] + lhs.m[5] * rhs.m[8],
        //            lhs.m[6] * rhs.m[2] + lhs.m[7] * rhs.m[5] + lhs.m[8] * rhs.m[8]


        ///<summary
        ///The math in my matrix is wrong, it should be lhs [0],[1],[2] x rhs [0]; [3], [4], [5] x [1]; and [6], [7], [8] x [2].
        ///Currently, the code above will multiply the first of each lhs row by rhs [0], the second of each lhs row by [3], etc.
        ///The code below has been corrected to multiply the first row by the [0], the second row by [1], and so forth.
        ///</summary>
        //            lhs.m[0] * rhs.m[0] + lhs.m[3] * rhs.m[1] + lhs.m[2] * rhs.m[2],
        //            lhs.m[1] * rhs.m[0] + lhs.m[4] * rhs.m[1] + lhs.m[5] * rhs.m[2],
        //            lhs.m[2] * rhs.m[0] + lhs.m[5] * rhs.m[1] + lhs.m[8] * rhs.m[2],

        //            lhs.m[0] * rhs.m[3] + lhs.m[3] * rhs.m[4] + lhs.m[2] * rhs.m[5],
        //            lhs.m[1] * rhs.m[3] + lhs.m[4] * rhs.m[4] + lhs.m[5] * rhs.m[5],
        //            lhs.m[2] * rhs.m[3] + lhs.m[5] * rhs.m[4] + lhs.m[8] * rhs.m[5],

        //            lhs.m[0] * rhs.m[6] + lhs.m[1] * rhs.m[7] + lhs.m[2] * rhs.m[8],
        //            lhs.m[1] * rhs.m[6] + lhs.m[4] * rhs.m[7] + lhs.m[5] * rhs.m[8],
        //            lhs.m[2] * rhs.m[6] + lhs.m[5] * rhs.m[7] + lhs.m[8] * rhs.m[8]






        //            );
        //    }
        //}
        #endregion origional matrix3 code

        #region everything but matrix3
        //public v2 GetPerpRH()
        //{
        //    return { -y, x};
        //}
        //public v2 GetPerpLH()
        //{
        //    return { y, -x};
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
        #endregion everything but matrix3
        #endregion original code
        //END OLD CODE


        #region Teacher code
        ///<summary>
        ///Working code from teacher
        /// </summary>
        //public class Matrix3
        //{
        //    public float m1, m2, m3, m4, m5, m6, m7, m8, m9;
        //    public Matrix3()
        //    {
        //        m1 = 1; m2 = 0; m3 = 0;
        //        m4 = 0; m5 = 1; m6 = 0;
        //        m7 = 0; m8 = 0; m9 = 1;
        //    }
        //    public Matrix3(Matrix3 _m)
        //    {
        //        m1 = _m.m1;
        //        m2 = _m.m2;
        //        m3 = _m.m3;
        //        m4 = _m.m4;
        //        m5 = _m.m5;
        //        m6 = _m.m6;
        //        m7 = _m.m7;
        //        m8 = _m.m8;
        //        m9 = _m.m9;
        //    }
        //    public Matrix3(float _m1, float _m2, float _m3, float _m4, float _m5, float _m6, float _m7, float _m8, float _m9)
        //    {
        //        m1 = _m1;
        //        m2 = _m2;
        //        m3 = _m3;
        //        m4 = _m4;
        //        m5 = _m5;
        //        m6 = _m6;
        //        m7 = _m7;
        //        m8 = _m8;
        //        m9 = _m9;
        //    }
        //    public static Matrix3 identity = new Matrix3(1, 0, 0, 0, 1, 0, 0, 0, 1);
        //    public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        //    {
        //        //147
        //        //258
        //        //369

        //        return new Matrix3(
        //        #region Broken Code
        //            //Top Row (m1 m2 m3) ??
        //            //lhs.m1 * rhs.m1 + lhs.m4 * rhs.m2 + lhs.m7 * rhs.m3,
        //            //lhs.m1 * rhs.m4 + lhs.m4 * rhs.m5 + lhs.m7 * rhs.m5,
        //            //lhs.m1 * rhs.m7 + lhs.m4 * rhs.m8 + lhs.m7 * rhs.m9,

        //            ////Middle Row (m4 m5 m6) ??
        //            //lhs.m2 * rhs.m1 + lhs.m5 * rhs.m2 + lhs.m8 * rhs.m3,
        //            //lhs.m2 * rhs.m4 + lhs.m5 * rhs.m5 + lhs.m8 * rhs.m5,
        //            //lhs.m2 * rhs.m7 + lhs.m5 * rhs.m8 + lhs.m8 * rhs.m9,

        //            ////Bottom Row (m7 m8 m9) ??
        //            //lhs.m3 * rhs.m1 + lhs.m6 * rhs.m2 + lhs.m9 * rhs.m3,
        //            //lhs.m3 * rhs.m4 + lhs.m6 * rhs.m5 + lhs.m9 * rhs.m5,
        //            //lhs.m3 * rhs.m7 + lhs.m6 * rhs.m8 + lhs.m9 * rhs.m9
        //        #endregion
        //        #region Working Code
        //            //Top Row (m1 m2 m3) ??
        //            lhs.m1 * rhs.m1 + lhs.m4 * rhs.m2 + lhs.m7 * rhs.m3,
        //            lhs.m2 * rhs.m1 + lhs.m5 * rhs.m2 + lhs.m8 * rhs.m3,
        //            lhs.m3 * rhs.m1 + lhs.m6 * rhs.m2 + lhs.m9 * rhs.m3,

        //            //Middle Row (m4 m5 m6) ??
        //            lhs.m1 * rhs.m4 + lhs.m4 * rhs.m5 + lhs.m7 * rhs.m6,
        //            lhs.m2 * rhs.m4 + lhs.m5 * rhs.m5 + lhs.m8 * rhs.m6,
        //            lhs.m3 * rhs.m4 + lhs.m6 * rhs.m5 + lhs.m9 * rhs.m6,

        //            //Bottom Row (m7 m8 m9) ??
        //            lhs.m1 * rhs.m7 + lhs.m4 * rhs.m8 + lhs.m7 * rhs.m9,
        //            lhs.m2 * rhs.m7 + lhs.m5 * rhs.m8 + lhs.m8 * rhs.m9,
        //            lhs.m3 * rhs.m7 + lhs.m6 * rhs.m8 + lhs.m9 * rhs.m9
        //        #endregion
        //        );
        //    }

        //    internal void SetTranslation(float x, float y)
        //    {
        //        m7 = x;
        //        m8 = y;
        //    }
        //    internal void Translate(float x, float y)
        //    {
        //        m7 += x;
        //        m8 += y;
        //    }

        //    public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
        //    {
        //        return new Vector3(
        //            lhs.m1 * rhs.x + lhs.m4 * rhs.y + lhs.m7 * rhs.z,
        //            lhs.m2 * rhs.x + lhs.m5 * rhs.y + lhs.m8 * rhs.z,
        //            lhs.m3 * rhs.x + lhs.m6 * rhs.y + lhs.m9 * rhs.z);
        //    }
        //    public Matrix3 GetTransposed()
        //    {
        //        return new Matrix3(
        //            m1, m4, m7,
        //            m2, m5, m8,
        //            m3, m6, m9
        //            );
        //    }
        //    public void SetScaled(float x, float y, float z)
        //    {
        //        m1 = x; m2 = 0; m3 = 0;
        //        m4 = 0; m5 = y; m6 = 0;
        //        m7 = 0; m8 = 0; m9 = z;
        //    }
        //    public void SetScaled(Vector3 _v)
        //    {
        //        m1 = _v.x; m2 = 0; m3 = 0;
        //        m4 = 0; m5 = _v.y; m6 = 0;
        //        m7 = 0; m8 = 0; m9 = _v.z;

        //    }
        //    public void Scale(float x, float y, float z)
        //    {
        //        Matrix3 m = new Matrix3();
        //        m.SetScaled(x, y, z);
        //        Set(this * m);
        //    }
        //    void Scale(Vector3 _v)
        //    {
        //        Matrix3 m = new Matrix3();
        //        m.SetScaled(_v.x, _v.y, _v.z);
        //        Set(this * m);
        //    }
        //    void Set(Matrix3 _m)
        //    {
        //        m1 = _m.m1;
        //        m2 = _m.m2;
        //        m3 = _m.m3;
        //        m4 = _m.m4;
        //        m5 = _m.m5;
        //        m6 = _m.m6;
        //        m7 = _m.m7;
        //        m8 = _m.m8;
        //        m9 = _m.m9;
        //    }
        //    void Set(float _m1, float _m2, float _m3, float _m4, float _m5, float _m6, float _m7, float _m8, float _m9)
        //    {
        //        m1 = _m1;
        //        m2 = _m2;
        //        m3 = _m3;
        //        m4 = _m4;
        //        m5 = _m5;
        //        m6 = _m6;
        //        m7 = _m7;
        //        m8 = _m8;
        //        m9 = _m9;
        //    }
        //    public void SetRotateX(double radians)
        //    {
        //        Set(
        //            1, 0, 0,
        //            0, (float)Math.Cos(radians), (float)Math.Sin(radians),
        //            0, (float)-Math.Sin(radians), (float)Math.Cos(radians)
        //            );
        //    }
        //    public void RotateX(double radians)
        //    {
        //        Matrix3 m = new Matrix3();
        //        m.SetRotateX(radians);
        //        Set(this * m);
        //    }
        //    public void SetRotateY(double radians)
        //    {
        //        Set(
        //           (float)Math.Cos(radians), 0, (float)-Math.Sin(radians),
        //           0, 1, 0,
        //           (float)Math.Sin(radians), 0, (float)Math.Cos(radians)
        //            );
        //    }
        //    public void RotateY(double radians)
        //    {
        //        Matrix3 m = new Matrix3();
        //        m.SetRotateY(radians);
        //        Set(this * m);
        //    }
        //    public void SetRotateZ(double radians)
        //    {
        //        Set(
        //            (float)Math.Cos(radians), (float)Math.Sin(radians), 0,
        //            (float)-Math.Sin(radians), (float)Math.Cos(radians), 0,
        //            0, 0, 1
        //            );
        //    }
        //    public void RotateZ(double radians)
        //    {
        //        Matrix3 m = new Matrix3();
        //        m.SetRotateZ(radians);
        //        Set(this * m);
        //    }
        //    void SetEuler(float pitch, float yaw, float roll)
        //    {
        //        Matrix3 x = new Matrix3();
        //        Matrix3 y = new Matrix3();
        //        Matrix3 z = new Matrix3();
        //        x.SetRotateX(pitch);
        //        y.SetRotateY(yaw);
        //        z.SetRotateZ(roll);
        //        // combine rotations in a specific order
        //        Set(z * y * x);
        //    }
        //}
        #endregion Teacher code
    }

}