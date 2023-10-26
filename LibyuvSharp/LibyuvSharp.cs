
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
namespace LibyuvSharp
{
   public unsafe class Libyuv
    {
        const string DLL_NAME = "libyuv_internal.dll";
        static Libyuv()
        {
            var dll_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"runtimes/{(Environment.Is64BitProcess ? "win-x64" : "win-x86")}/native/{DLL_NAME}");
            _ = NativeLibrary.TryLoad(dll_path, out IntPtr _);
        }
        #region Rotate
        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420Rotate", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420Rotate(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height, RotationMode mode);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422Rotate", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I422Rotate(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height, RotationMode mode);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444Rotate", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I444Rotate(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height, RotationMode mode);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I010Rotate", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I010Rotate(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, ushort* dst_y, int dst_stride_y, ushort* dst_u, int dst_stride_u, ushort* dst_v, int dst_stride_v, int width, int height, RotationMode mode);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I210Rotate", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I210Rotate(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, ushort* dst_y, int dst_stride_y, ushort* dst_u, int dst_stride_u, ushort* dst_v, int dst_stride_v, int width, int height, RotationMode mode);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I410Rotate", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I410Rotate(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, ushort* dst_y, int dst_stride_y, ushort* dst_u, int dst_stride_u, ushort* dst_v, int dst_stride_v, int width, int height, RotationMode mode);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToI420Rotate", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NV12ToI420Rotate(byte* src_y, int src_stride_y, byte* src_uv, int src_stride_uv, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height, RotationMode mode);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "Android420ToI420Rotate", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Android420ToI420Rotate(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, int src_pixel_stride_uv, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height, RotationMode rotation);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RotatePlane", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int RotatePlane(byte* src, int src_stride, byte* dst, int dst_stride, int width, int height, RotationMode mode);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RotatePlane90", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void RotatePlane90(byte* src, int src_stride, byte* dst, int dst_stride, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RotatePlane180", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void RotatePlane180(byte* src, int src_stride, byte* dst, int dst_stride, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RotatePlane270", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void RotatePlane270(byte* src, int src_stride, byte* dst, int dst_stride, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RotatePlane_16", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int RotatePlane16(ushort* src, int src_stride, ushort* dst, int dst_stride, int width, int height, RotationMode mode);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitRotateUV", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SplitRotateUV(byte* src_uv, int src_stride_uv, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height, RotationMode mode);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitRotateUV90", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void SplitRotateUV90(byte* src, int src_stride, byte* dst_a, int dst_stride_a, byte* dst_b, int dst_stride_b, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitRotateUV180", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void SplitRotateUV180(byte* src, int src_stride, byte* dst_a, int dst_stride_a, byte* dst_b, int dst_stride_b, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitRotateUV270", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void SplitRotateUV270(byte* src, int src_stride, byte* dst_a, int dst_stride_a, byte* dst_b, int dst_stride_b, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "TransposePlane", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void TransposePlane(byte* src, int src_stride, byte* dst, int dst_stride, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitTransposeUV", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void SplitTransposeUV(byte* src, int src_stride, byte* dst_a, int dst_stride_a, byte* dst_b, int dst_stride_b, int width, int height);
        #endregion

        #region Scale
        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScalePlane", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScalePlane(byte* src, int src_stride, int src_width, int src_height, byte* dst, int dst_stride, int dst_width, int dst_height, FilterMode filtering);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScalePlane_16", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScalePlane16(ushort* src, int src_stride, int src_width, int src_height, ushort* dst, int dst_stride, int dst_width, int dst_height, FilterMode filtering);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScalePlane_12", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScalePlane12(ushort* src, int src_stride, int src_width, int src_height, ushort* dst, int dst_stride, int dst_width, int dst_height, FilterMode filtering);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420Scale", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420Scale(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, int src_width, int src_height, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int dst_width, int dst_height, FilterMode filtering);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420Scale_16", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420Scale16(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, int src_width, int src_height, ushort* dst_y, int dst_stride_y, ushort* dst_u, int dst_stride_u, ushort* dst_v, int dst_stride_v, int dst_width, int dst_height, FilterMode filtering);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420Scale_12", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420Scale12(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, int src_width, int src_height, ushort* dst_y, int dst_stride_y, ushort* dst_u, int dst_stride_u, ushort* dst_v, int dst_stride_v, int dst_width, int dst_height, FilterMode filtering);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444Scale", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I444Scale(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, int src_width, int src_height, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int dst_width, int dst_height, FilterMode filtering);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444Scale_16", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I444Scale16(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, int src_width, int src_height, ushort* dst_y, int dst_stride_y, ushort* dst_u, int dst_stride_u, ushort* dst_v, int dst_stride_v, int dst_width, int dst_height, FilterMode filtering);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444Scale_12", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I444Scale12(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, int src_width, int src_height, ushort* dst_y, int dst_stride_y, ushort* dst_u, int dst_stride_u, ushort* dst_v, int dst_stride_v, int dst_width, int dst_height, FilterMode filtering);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422Scale", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I422Scale(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, int src_width, int src_height, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int dst_width, int dst_height, FilterMode filtering);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422Scale_16", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I422Scale16(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, int src_width, int src_height, ushort* dst_y, int dst_stride_y, ushort* dst_u, int dst_stride_u, ushort* dst_v, int dst_stride_v, int dst_width, int dst_height, FilterMode filtering);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422Scale_12", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I422Scale12(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, int src_width, int src_height, ushort* dst_y, int dst_stride_y, ushort* dst_u, int dst_stride_u, ushort* dst_v, int dst_stride_v, int dst_width, int dst_height, FilterMode filtering);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12Scale", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NV12Scale(byte* src_y, int src_stride_y, byte* src_uv, int src_stride_uv, int src_width, int src_height, byte* dst_y, int dst_stride_y, byte* dst_uv, int dst_stride_uv, int dst_width, int dst_height, FilterMode filtering);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "Scale", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Scale(byte* src_y, byte* src_u, byte* src_v, int src_stride_y, int src_stride_u, int src_stride_v, int src_width, int src_height, byte* dst_y, byte* dst_u, byte* dst_v, int dst_stride_y, int dst_stride_u, int dst_stride_v, int dst_width, int dst_height, int interpolate);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SetUseReferenceImpl", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void SetUseReferenceImpl(int use);
        #endregion

        #region convert_argb
        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBCopy", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBCopy(byte* src_argb, int src_stride_argb, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420ToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420ToARGB(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420ToABGR", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420ToABGR(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_abgr, int dst_stride_abgr, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "J420ToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int J420ToARGB(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "J420ToABGR", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int J420ToABGR(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_abgr, int dst_stride_abgr, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "H420ToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int H420ToARGB(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "H420ToABGR", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int H420ToABGR(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_abgr, int dst_stride_abgr, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "U420ToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int U420ToARGB(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "U420ToABGR", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int U420ToABGR(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_abgr, int dst_stride_abgr, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I422ToARGB(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToABGR", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I422ToABGR(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_abgr, int dst_stride_abgr, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "J422ToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int J422ToARGB(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "J422ToABGR", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int J422ToABGR(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_abgr, int dst_stride_abgr, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "H422ToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int H422ToARGB(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "H422ToABGR", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int H422ToABGR(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_abgr, int dst_stride_abgr, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "U422ToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int U422ToARGB(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "U422ToABGR", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int U422ToABGR(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_abgr, int dst_stride_abgr, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444ToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I444ToARGB(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444ToABGR", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I444ToABGR(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_abgr, int dst_stride_abgr, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "J444ToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int J444ToARGB(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "J444ToABGR", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int J444ToABGR(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_abgr, int dst_stride_abgr, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "H444ToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int H444ToARGB(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "H444ToABGR", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int H444ToABGR(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_abgr, int dst_stride_abgr, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "U444ToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int U444ToARGB(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "U444ToABGR", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int U444ToABGR(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_abgr, int dst_stride_abgr, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444ToRGB24", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I444ToRGB24(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_rgb24, int dst_stride_rgb24, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444ToRAW", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I444ToRAW(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_raw, int dst_stride_raw, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I010ToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I010ToARGB(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I010ToABGR", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I010ToABGR(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_abgr, int dst_stride_abgr, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "H010ToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int H010ToARGB(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "H010ToABGR", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int H010ToABGR(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_abgr, int dst_stride_abgr, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "U010ToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int U010ToARGB(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "U010ToABGR", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int U010ToABGR(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_abgr, int dst_stride_abgr, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I210ToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I210ToARGB(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I210ToABGR", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I210ToABGR(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_abgr, int dst_stride_abgr, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "H210ToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int H210ToARGB(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "H210ToABGR", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int H210ToABGR(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_abgr, int dst_stride_abgr, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "U210ToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int U210ToARGB(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "U210ToABGR", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int U210ToABGR(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_abgr, int dst_stride_abgr, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420AlphaToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420AlphaToARGB(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* src_a, int src_stride_a, byte* dst_argb, int dst_stride_argb, int width, int height, int attenuate);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420AlphaToABGR", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420AlphaToABGR(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* src_a, int src_stride_a, byte* dst_abgr, int dst_stride_abgr, int width, int height, int attenuate);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422AlphaToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I422AlphaToARGB(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* src_a, int src_stride_a, byte* dst_argb, int dst_stride_argb, int width, int height, int attenuate);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422AlphaToABGR", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I422AlphaToABGR(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* src_a, int src_stride_a, byte* dst_abgr, int dst_stride_abgr, int width, int height, int attenuate);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444AlphaToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I444AlphaToARGB(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* src_a, int src_stride_a, byte* dst_argb, int dst_stride_argb, int width, int height, int attenuate);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444AlphaToABGR", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I444AlphaToABGR(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* src_a, int src_stride_a, byte* dst_abgr, int dst_stride_abgr, int width, int height, int attenuate);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I400ToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I400ToARGB(byte* src_y, int src_stride_y, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "J400ToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int J400ToARGB(byte* src_y, int src_stride_y, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NV12ToARGB(byte* src_y, int src_stride_y, byte* src_uv, int src_stride_uv, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NV21ToARGB(byte* src_y, int src_stride_y, byte* src_vu, int src_stride_vu, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToABGR", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NV12ToABGR(byte* src_y, int src_stride_y, byte* src_uv, int src_stride_uv, byte* dst_abgr, int dst_stride_abgr, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToABGR", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NV21ToABGR(byte* src_y, int src_stride_y, byte* src_vu, int src_stride_vu, byte* dst_abgr, int dst_stride_abgr, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToRGB24", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NV12ToRGB24(byte* src_y, int src_stride_y, byte* src_uv, int src_stride_uv, byte* dst_rgb24, int dst_stride_rgb24, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToRGB24", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NV21ToRGB24(byte* src_y, int src_stride_y, byte* src_vu, int src_stride_vu, byte* dst_rgb24, int dst_stride_rgb24, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToYUV24", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NV21ToYUV24(byte* src_y, int src_stride_y, byte* src_vu, int src_stride_vu, byte* dst_yuv24, int dst_stride_yuv24, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToRAW", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NV12ToRAW(byte* src_y, int src_stride_y, byte* src_uv, int src_stride_uv, byte* dst_raw, int dst_stride_raw, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToRAW", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NV21ToRAW(byte* src_y, int src_stride_y, byte* src_vu, int src_stride_vu, byte* dst_raw, int dst_stride_raw, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int YUY2ToARGB(byte* src_yuy2, int src_stride_yuy2, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int UYVYToARGB(byte* src_uyvy, int src_stride_uyvy, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I010ToAR30", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I010ToAR30(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_ar30, int dst_stride_ar30, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "H010ToAR30", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int H010ToAR30(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_ar30, int dst_stride_ar30, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I010ToAB30", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I010ToAB30(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_ab30, int dst_stride_ab30, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "H010ToAB30", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int H010ToAB30(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_ab30, int dst_stride_ab30, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "U010ToAR30", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int U010ToAR30(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_ar30, int dst_stride_ar30, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "U010ToAB30", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int U010ToAB30(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_ab30, int dst_stride_ab30, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I210ToAR30", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I210ToAR30(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_ar30, int dst_stride_ar30, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I210ToAB30", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I210ToAB30(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_ab30, int dst_stride_ab30, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "H210ToAR30", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int H210ToAR30(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_ar30, int dst_stride_ar30, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "H210ToAB30", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int H210ToAB30(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_ab30, int dst_stride_ab30, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "U210ToAR30", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int U210ToAR30(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_ar30, int dst_stride_ar30, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "U210ToAB30", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int U210ToAB30(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_ab30, int dst_stride_ab30, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "BGRAToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int BGRAToARGB(byte* src_bgra, int src_stride_bgra, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ABGRToARGB(byte* src_abgr, int src_stride_abgr, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int RGBAToARGB(byte* src_rgba, int src_stride_rgba, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int RGB24ToARGB(byte* src_rgb24, int src_stride_rgb24, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int RAWToARGB(byte* src_raw, int src_stride_raw, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToRGBA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int RAWToRGBA(byte* src_raw, int src_stride_raw, byte* dst_rgba, int dst_stride_rgba, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB565ToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int RGB565ToARGB(byte* src_rgb565, int src_stride_rgb565, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB1555ToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGB1555ToARGB(byte* src_argb1555, int src_stride_argb1555, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB4444ToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGB4444ToARGB(byte* src_argb4444, int src_stride_argb4444, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AR30ToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int AR30ToARGB(byte* src_ar30, int src_stride_ar30, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AR30ToABGR", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int AR30ToABGR(byte* src_ar30, int src_stride_ar30, byte* dst_abgr, int dst_stride_abgr, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AR30ToAB30", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int AR30ToAB30(byte* src_ar30, int src_stride_ar30, byte* dst_ab30, int dst_stride_ab30, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AR64ToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int AR64ToARGB(ushort* src_ar64, int src_stride_ar64, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AB64ToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int AB64ToARGB(ushort* src_ab64, int src_stride_ab64, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AR64ToAB64", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int AR64ToAB64(ushort* src_ar64, int src_stride_ar64, ushort* dst_ab64, int dst_stride_ab64, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MJPGToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int MJPGToARGB(byte* sample, ulong sample_size, byte* dst_argb, int dst_stride_argb, int src_width, int src_height, int dst_width, int dst_height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "Android420ToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Android420ToARGB(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, int src_pixel_stride_uv, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "Android420ToABGR", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Android420ToABGR(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, int src_pixel_stride_uv, byte* dst_abgr, int dst_stride_abgr, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToRGB565", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NV12ToRGB565(byte* src_y, int src_stride_y, byte* src_uv, int src_stride_uv, byte* dst_rgb565, int dst_stride_rgb565, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToBGRA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I422ToBGRA(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_bgra, int dst_stride_bgra, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGBA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I422ToRGBA(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_rgba, int dst_stride_rgba, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420ToBGRA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420ToBGRA(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_bgra, int dst_stride_bgra, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420ToRGBA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420ToRGBA(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_rgba, int dst_stride_rgba, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420ToRGB24", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420ToRGB24(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_rgb24, int dst_stride_rgb24, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420ToRAW", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420ToRAW(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_raw, int dst_stride_raw, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "H420ToRGB24", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int H420ToRGB24(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_rgb24, int dst_stride_rgb24, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "H420ToRAW", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int H420ToRAW(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_raw, int dst_stride_raw, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "J420ToRGB24", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int J420ToRGB24(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_rgb24, int dst_stride_rgb24, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "J420ToRAW", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int J420ToRAW(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_raw, int dst_stride_raw, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGB24", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I422ToRGB24(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_rgb24, int dst_stride_rgb24, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRAW", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I422ToRAW(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_raw, int dst_stride_raw, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420ToRGB565", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420ToRGB565(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_rgb565, int dst_stride_rgb565, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "J420ToRGB565", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int J420ToRGB565(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_rgb565, int dst_stride_rgb565, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "H420ToRGB565", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int H420ToRGB565(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_rgb565, int dst_stride_rgb565, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGB565", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I422ToRGB565(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_rgb565, int dst_stride_rgb565, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420ToRGB565Dither", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420ToRGB565Dither(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_rgb565, int dst_stride_rgb565, byte* dither4x4, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420ToARGB1555", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420ToARGB1555(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_argb1555, int dst_stride_argb1555, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420ToARGB4444", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420ToARGB4444(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_argb4444, int dst_stride_argb4444, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420ToAR30", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420ToAR30(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_ar30, int dst_stride_ar30, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420ToAB30", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420ToAB30(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_ab30, int dst_stride_ab30, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "H420ToAR30", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int H420ToAR30(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_ar30, int dst_stride_ar30, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "H420ToAB30", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int H420ToAB30(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_ab30, int dst_stride_ab30, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420ToARGBMatrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420ToARGBMatrix(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_argb, int dst_stride_argb, IntPtr yuvconstants, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGBMatrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I422ToARGBMatrix(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_argb, int dst_stride_argb, IntPtr yuvconstants, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444ToARGBMatrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I444ToARGBMatrix(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_argb, int dst_stride_argb, IntPtr yuvconstants, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444ToRGB24Matrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I444ToRGB24Matrix(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_rgb24, int dst_stride_rgb24, IntPtr yuvconstants, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I010ToAR30Matrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I010ToAR30Matrix(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_ar30, int dst_stride_ar30, IntPtr yuvconstants, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I210ToAR30Matrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I210ToAR30Matrix(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_ar30, int dst_stride_ar30, IntPtr yuvconstants, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I410ToAR30Matrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I410ToAR30Matrix(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_ar30, int dst_stride_ar30, IntPtr yuvconstants, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I010ToARGBMatrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I010ToARGBMatrix(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_argb, int dst_stride_argb, IntPtr yuvconstants, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I012ToAR30Matrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I012ToAR30Matrix(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_ar30, int dst_stride_ar30, IntPtr yuvconstants, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I012ToARGBMatrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I012ToARGBMatrix(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_argb, int dst_stride_argb, IntPtr yuvconstants, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I210ToARGBMatrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I210ToARGBMatrix(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_argb, int dst_stride_argb, IntPtr yuvconstants, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I410ToARGBMatrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I410ToARGBMatrix(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_argb, int dst_stride_argb, IntPtr yuvconstants, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P010ToARGBMatrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int P010ToARGBMatrix(ushort* src_y, int src_stride_y, ushort* src_uv, int src_stride_uv, byte* dst_argb, int dst_stride_argb, IntPtr yuvconstants, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P210ToARGBMatrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int P210ToARGBMatrix(ushort* src_y, int src_stride_y, ushort* src_uv, int src_stride_uv, byte* dst_argb, int dst_stride_argb, IntPtr yuvconstants, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P010ToAR30Matrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int P010ToAR30Matrix(ushort* src_y, int src_stride_y, ushort* src_uv, int src_stride_uv, byte* dst_ar30, int dst_stride_ar30, IntPtr yuvconstants, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P210ToAR30Matrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int P210ToAR30Matrix(ushort* src_y, int src_stride_y, ushort* src_uv, int src_stride_uv, byte* dst_ar30, int dst_stride_ar30, IntPtr yuvconstants, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420AlphaToARGBMatrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420AlphaToARGBMatrix(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* src_a, int src_stride_a, byte* dst_argb, int dst_stride_argb, IntPtr yuvconstants, int width, int height, int attenuate);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422AlphaToARGBMatrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I422AlphaToARGBMatrix(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* src_a, int src_stride_a, byte* dst_argb, int dst_stride_argb, IntPtr yuvconstants, int width, int height, int attenuate);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444AlphaToARGBMatrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I444AlphaToARGBMatrix(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* src_a, int src_stride_a, byte* dst_argb, int dst_stride_argb, IntPtr yuvconstants, int width, int height, int attenuate);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I010AlphaToARGBMatrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I010AlphaToARGBMatrix(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, ushort* src_a, int src_stride_a, byte* dst_argb, int dst_stride_argb, IntPtr yuvconstants, int width, int height, int attenuate);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I210AlphaToARGBMatrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I210AlphaToARGBMatrix(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, ushort* src_a, int src_stride_a, byte* dst_argb, int dst_stride_argb, IntPtr yuvconstants, int width, int height, int attenuate);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I410AlphaToARGBMatrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I410AlphaToARGBMatrix(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, ushort* src_a, int src_stride_a, byte* dst_argb, int dst_stride_argb, IntPtr yuvconstants, int width, int height, int attenuate);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToARGBMatrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NV12ToARGBMatrix(byte* src_y, int src_stride_y, byte* src_uv, int src_stride_uv, byte* dst_argb, int dst_stride_argb, IntPtr yuvconstants, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToARGBMatrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NV21ToARGBMatrix(byte* src_y, int src_stride_y, byte* src_vu, int src_stride_vu, byte* dst_argb, int dst_stride_argb, IntPtr yuvconstants, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToRGB565Matrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NV12ToRGB565Matrix(byte* src_y, int src_stride_y, byte* src_uv, int src_stride_uv, byte* dst_rgb565, int dst_stride_rgb565, IntPtr yuvconstants, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToRGB24Matrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NV12ToRGB24Matrix(byte* src_y, int src_stride_y, byte* src_uv, int src_stride_uv, byte* dst_rgb24, int dst_stride_rgb24, IntPtr yuvconstants, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToRGB24Matrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NV21ToRGB24Matrix(byte* src_y, int src_stride_y, byte* src_vu, int src_stride_vu, byte* dst_rgb24, int dst_stride_rgb24, IntPtr yuvconstants, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "Android420ToARGBMatrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Android420ToARGBMatrix(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, int src_pixel_stride_uv, byte* dst_argb, int dst_stride_argb, IntPtr yuvconstants, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGBAMatrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I422ToRGBAMatrix(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_rgba, int dst_stride_rgba, IntPtr yuvconstants, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420ToRGBAMatrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420ToRGBAMatrix(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_rgba, int dst_stride_rgba, IntPtr yuvconstants, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420ToRGB24Matrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420ToRGB24Matrix(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_rgb24, int dst_stride_rgb24, IntPtr yuvconstants, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGB24Matrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I422ToRGB24Matrix(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_rgb24, int dst_stride_rgb24, IntPtr yuvconstants, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420ToRGB565Matrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420ToRGB565Matrix(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_rgb565, int dst_stride_rgb565, IntPtr yuvconstants, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGB565Matrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I422ToRGB565Matrix(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_rgb565, int dst_stride_rgb565, IntPtr yuvconstants, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420ToAR30Matrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420ToAR30Matrix(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_ar30, int dst_stride_ar30, IntPtr yuvconstants, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I400ToARGBMatrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I400ToARGBMatrix(byte* src_y, int src_stride_y, byte* dst_argb, int dst_stride_argb, IntPtr yuvconstants, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420ToARGBMatrixFilter", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420ToARGBMatrixFilter(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_argb, int dst_stride_argb, IntPtr yuvconstants, int width, int height, FilterMode filter);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGBMatrixFilter", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I422ToARGBMatrixFilter(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_argb, int dst_stride_argb, IntPtr yuvconstants, int width, int height, FilterMode filter);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGB24MatrixFilter", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I422ToRGB24MatrixFilter(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_rgb24, int dst_stride_rgb24, IntPtr yuvconstants, int width, int height, FilterMode filter);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420ToRGB24MatrixFilter", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420ToRGB24MatrixFilter(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_rgb24, int dst_stride_rgb24, IntPtr yuvconstants, int width, int height, FilterMode filter);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I010ToAR30MatrixFilter", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I010ToAR30MatrixFilter(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_ar30, int dst_stride_ar30, IntPtr yuvconstants, int width, int height, FilterMode filter);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I210ToAR30MatrixFilter", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I210ToAR30MatrixFilter(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_ar30, int dst_stride_ar30, IntPtr yuvconstants, int width, int height, FilterMode filter);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I010ToARGBMatrixFilter", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I010ToARGBMatrixFilter(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_argb, int dst_stride_argb, IntPtr yuvconstants, int width, int height, FilterMode filter);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I210ToARGBMatrixFilter", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I210ToARGBMatrixFilter(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_argb, int dst_stride_argb, IntPtr yuvconstants, int width, int height, FilterMode filter);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420AlphaToARGBMatrixFilter", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420AlphaToARGBMatrixFilter(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* src_a, int src_stride_a, byte* dst_argb, int dst_stride_argb, IntPtr yuvconstants, int width, int height, int attenuate, FilterMode filter);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422AlphaToARGBMatrixFilter", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I422AlphaToARGBMatrixFilter(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* src_a, int src_stride_a, byte* dst_argb, int dst_stride_argb, IntPtr yuvconstants, int width, int height, int attenuate, FilterMode filter);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I010AlphaToARGBMatrixFilter", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I010AlphaToARGBMatrixFilter(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, ushort* src_a, int src_stride_a, byte* dst_argb, int dst_stride_argb, IntPtr yuvconstants, int width, int height, int attenuate, FilterMode filter);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I210AlphaToARGBMatrixFilter", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I210AlphaToARGBMatrixFilter(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, ushort* src_a, int src_stride_a, byte* dst_argb, int dst_stride_argb, IntPtr yuvconstants, int width, int height, int attenuate, FilterMode filter);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P010ToARGBMatrixFilter", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int P010ToARGBMatrixFilter(ushort* src_y, int src_stride_y, ushort* src_uv, int src_stride_uv, byte* dst_argb, int dst_stride_argb, IntPtr yuvconstants, int width, int height, FilterMode filter);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P210ToARGBMatrixFilter", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int P210ToARGBMatrixFilter(ushort* src_y, int src_stride_y, ushort* src_uv, int src_stride_uv, byte* dst_argb, int dst_stride_argb, IntPtr yuvconstants, int width, int height, FilterMode filter);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P010ToAR30MatrixFilter", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int P010ToAR30MatrixFilter(ushort* src_y, int src_stride_y, ushort* src_uv, int src_stride_uv, byte* dst_ar30, int dst_stride_ar30, IntPtr yuvconstants, int width, int height, FilterMode filter);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P210ToAR30MatrixFilter", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int P210ToAR30MatrixFilter(ushort* src_y, int src_stride_y, ushort* src_uv, int src_stride_uv, byte* dst_ar30, int dst_stride_ar30, IntPtr yuvconstants, int width, int height, FilterMode filter);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ConvertToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ConvertToARGB(byte* sample, ulong sample_size, byte* dst_argb, int dst_stride_argb, int crop_x, int crop_y, int src_width, int src_height, int crop_width, int crop_height, RotationMode rotation, uint fourcc);
        #endregion

        #region convert_from
        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420ToI010", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420ToI010(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, ushort* dst_y, int dst_stride_y, ushort* dst_u, int dst_stride_u, ushort* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420ToI012", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420ToI012(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, ushort* dst_y, int dst_stride_y, ushort* dst_u, int dst_stride_u, ushort* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420ToI422", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420ToI422(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420ToI444", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420ToI444(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I400Copy", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I400Copy(byte* src_y, int src_stride_y, byte* dst_y, int dst_stride_y, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420ToNV12", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420ToNV12(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_y, int dst_stride_y, byte* dst_uv, int dst_stride_uv, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420ToNV21", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420ToNV21(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_y, int dst_stride_y, byte* dst_vu, int dst_stride_vu, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420ToYUY2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420ToYUY2(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_yuy2, int dst_stride_yuy2, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420ToUYVY", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420ToUYVY(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_uyvy, int dst_stride_uyvy, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420ToARGB", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420ToARGB1(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420ToABGR", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420ToABGR1(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_abgr, int dst_stride_abgr, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ConvertFromI420", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ConvertFromI420(byte* y, int y_stride, byte* u, int u_stride, byte* v, int v_stride, byte* dst_sample, int dst_sample_stride, int width, int height, uint fourcc);
        #endregion

        #region convert
        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444ToI420", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I444ToI420(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444ToNV12", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I444ToNV12(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_y, int dst_stride_y, byte* dst_uv, int dst_stride_uv, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444ToNV21", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I444ToNV21(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_y, int dst_stride_y, byte* dst_vu, int dst_stride_vu, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToI420", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I422ToI420(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToI444", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I422ToI444(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToI210", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I422ToI210(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, ushort* dst_y, int dst_stride_y, ushort* dst_u, int dst_stride_u, ushort* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MM21ToNV12", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int MM21ToNV12(byte* src_y, int src_stride_y, byte* src_uv, int src_stride_uv, byte* dst_y, int dst_stride_y, byte* dst_uv, int dst_stride_uv, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MM21ToI420", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int MM21ToI420(byte* src_y, int src_stride_y, byte* src_uv, int src_stride_uv, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MM21ToYUY2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int MM21ToYUY2(byte* src_y, int src_stride_y, byte* src_uv, int src_stride_uv, byte* dst_yuy2, int dst_stride_yuy2, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MT2TToP010", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int MT2TToP010(byte* src_y, int src_stride_y, byte* src_uv, int src_stride_uv, ushort* dst_y, int dst_stride_y, ushort* dst_uv, int dst_stride_uv, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToNV21", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I422ToNV21(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_y, int dst_stride_y, byte* dst_vu, int dst_stride_vu, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420Copy", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420Copy(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420ToI444", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420ToI4441(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I010Copy", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I010Copy(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, ushort* dst_y, int dst_stride_y, ushort* dst_u, int dst_stride_u, ushort* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I010ToI420", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I010ToI420(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I210ToI420", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I210ToI420(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I210ToI422", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I210ToI422(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I410ToI420", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I410ToI420(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I410ToI444", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I410ToI444(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I012ToI420", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I012ToI420(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I212ToI422", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I212ToI422(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I212ToI420", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I212ToI420(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I412ToI444", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I412ToI444(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I412ToI420", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I412ToI420(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I410ToI010", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I410ToI010(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, ushort* dst_y, int dst_stride_y, ushort* dst_u, int dst_stride_u, ushort* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I210ToI010", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I210ToI010(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, ushort* dst_y, int dst_stride_y, ushort* dst_u, int dst_stride_u, ushort* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I010ToI410", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I010ToI410(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, ushort* dst_y, int dst_stride_y, ushort* dst_u, int dst_stride_u, ushort* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I210ToI410", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I210ToI410(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, ushort* dst_y, int dst_stride_y, ushort* dst_u, int dst_stride_u, ushort* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I010ToP010", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I010ToP010(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, ushort* dst_y, int dst_stride_y, ushort* dst_uv, int dst_stride_uv, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I210ToP210", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I210ToP210(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, ushort* dst_y, int dst_stride_y, ushort* dst_uv, int dst_stride_uv, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I012ToP012", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I012ToP012(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, ushort* dst_y, int dst_stride_y, ushort* dst_uv, int dst_stride_uv, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I212ToP212", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I212ToP212(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, ushort* dst_y, int dst_stride_y, ushort* dst_uv, int dst_stride_uv, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I400ToI420", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I400ToI420(byte* src_y, int src_stride_y, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I400ToNV21", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I400ToNV21(byte* src_y, int src_stride_y, byte* dst_y, int dst_stride_y, byte* dst_vu, int dst_stride_vu, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToI420", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NV12ToI420(byte* src_y, int src_stride_y, byte* src_uv, int src_stride_uv, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToI420", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NV21ToI420(byte* src_y, int src_stride_y, byte* src_vu, int src_stride_vu, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToNV24", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NV12ToNV24(byte* src_y, int src_stride_y, byte* src_uv, int src_stride_uv, byte* dst_y, int dst_stride_y, byte* dst_uv, int dst_stride_uv, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV16ToNV24", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NV16ToNV24(byte* src_y, int src_stride_y, byte* src_uv, int src_stride_uv, byte* dst_y, int dst_stride_y, byte* dst_uv, int dst_stride_uv, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P010ToI010", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int P010ToI010(ushort* src_y, int src_stride_y, ushort* src_uv, int src_stride_uv, ushort* dst_y, int dst_stride_y, ushort* dst_u, int dst_stride_u, ushort* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P012ToI012", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int P012ToI012(ushort* src_y, int src_stride_y, ushort* src_uv, int src_stride_uv, ushort* dst_y, int dst_stride_y, ushort* dst_u, int dst_stride_u, ushort* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P010ToP410", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int P010ToP410(ushort* src_y, int src_stride_y, ushort* src_uv, int src_stride_uv, ushort* dst_y, int dst_stride_y, ushort* dst_uv, int dst_stride_uv, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P210ToP410", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int P210ToP410(ushort* src_y, int src_stride_y, ushort* src_uv, int src_stride_uv, ushort* dst_y, int dst_stride_y, ushort* dst_uv, int dst_stride_uv, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToI420", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int YUY2ToI420(byte* src_yuy2, int src_stride_yuy2, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToI420", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int UYVYToI420(byte* src_uyvy, int src_stride_uyvy, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AYUVToNV12", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int AYUVToNV12(byte* src_ayuv, int src_stride_ayuv, byte* dst_y, int dst_stride_y, byte* dst_uv, int dst_stride_uv, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AYUVToNV21", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int AYUVToNV21(byte* src_ayuv, int src_stride_ayuv, byte* dst_y, int dst_stride_y, byte* dst_vu, int dst_stride_vu, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "Android420ToI420", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Android420ToI420(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, int src_pixel_stride_uv, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToI420", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBToI420(byte* src_argb, int src_stride_argb, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToI420Alpha", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBToI420Alpha(byte* src_argb, int src_stride_argb, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, byte* dst_a, int dst_stride_a, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "BGRAToI420", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int BGRAToI420(byte* src_bgra, int src_stride_bgra, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToI420", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ABGRToI420(byte* src_abgr, int src_stride_abgr, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToI420", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int RGBAToI420(byte* src_rgba, int src_stride_rgba, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToI420", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int RGB24ToI420(byte* src_rgb24, int src_stride_rgb24, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToJ420", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int RGB24ToJ420(byte* src_rgb24, int src_stride_rgb24, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToI420", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int RAWToI420(byte* src_raw, int src_stride_raw, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToJ420", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int RAWToJ420(byte* src_raw, int src_stride_raw, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB565ToI420", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int RGB565ToI420(byte* src_rgb565, int src_stride_rgb565, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB1555ToI420", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGB1555ToI420(byte* src_argb1555, int src_stride_argb1555, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB4444ToI420", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGB4444ToI420(byte* src_argb4444, int src_stride_argb4444, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToJ400", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int RGB24ToJ400(byte* src_rgb24, int src_stride_rgb24, byte* dst_yj, int dst_stride_yj, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToJ400", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int RAWToJ400(byte* src_raw, int src_stride_raw, byte* dst_yj, int dst_stride_yj, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MJPGToI420", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int MJPGToI420(byte* sample, ulong sample_size, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int src_width, int src_height, int dst_width, int dst_height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MJPGToNV21", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int MJPGToNV21(byte* sample, ulong sample_size, byte* dst_y, int dst_stride_y, byte* dst_vu, int dst_stride_vu, int src_width, int src_height, int dst_width, int dst_height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MJPGToNV12", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int MJPGToNV12(byte* sample, ulong sample_size, byte* dst_y, int dst_stride_y, byte* dst_uv, int dst_stride_uv, int src_width, int src_height, int dst_width, int dst_height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MJPGSize", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int MJPGSize(byte* sample, ulong sample_size, int* width, int* height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ConvertToI420", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ConvertToI420(byte* sample, ulong sample_size, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int crop_x, int crop_y, int src_width, int src_height, int crop_width, int crop_height, RotationMode rotation, uint fourcc);
        #endregion

        #region planar_functions
        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "CopyPlane", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void CopyPlane(byte* src_y, int src_stride_y, byte* dst_y, int dst_stride_y, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "CopyPlane_16", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void CopyPlane16(ushort* src_y, int src_stride_y, ushort* dst_y, int dst_stride_y, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "Convert16To8Plane", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Convert16To8Plane(ushort* src_y, int src_stride_y, byte* dst_y, int dst_stride_y, int scale, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "Convert8To16Plane", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Convert8To16Plane(byte* src_y, int src_stride_y, ushort* dst_y, int dst_stride_y, int scale, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SetPlane", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void SetPlane(byte* dst_y, int dst_stride_y, int width, int height, uint value);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "DetilePlane", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DetilePlane(byte* src_y, int src_stride_y, byte* dst_y, int dst_stride_y, int width, int height, int tile_height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "DetilePlane_16", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DetilePlane16(ushort* src_y, int src_stride_y, ushort* dst_y, int dst_stride_y, int width, int height, int tile_height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "DetileSplitUVPlane", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DetileSplitUVPlane(byte* src_uv, int src_stride_uv, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height, int tile_height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "DetileToYUY2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DetileToYUY2(byte* src_y, int src_stride_y, byte* src_uv, int src_stride_uv, byte* dst_yuy2, int dst_stride_yuy2, int width, int height, int tile_height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitUVPlane", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void SplitUVPlane(byte* src_uv, int src_stride_uv, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeUVPlane", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void MergeUVPlane(byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_uv, int dst_stride_uv, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitUVPlane_16", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void SplitUVPlane16(ushort* src_uv, int src_stride_uv, ushort* dst_u, int dst_stride_u, ushort* dst_v, int dst_stride_v, int width, int height, int depth);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeUVPlane_16", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void MergeUVPlane16(ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, ushort* dst_uv, int dst_stride_uv, int width, int height, int depth);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ConvertToMSBPlane_16", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ConvertToMSBPlane16(ushort* src_y, int src_stride_y, ushort* dst_y, int dst_stride_y, int width, int height, int depth);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ConvertToLSBPlane_16", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ConvertToLSBPlane16(ushort* src_y, int src_stride_y, ushort* dst_y, int dst_stride_y, int width, int height, int depth);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "HalfMergeUVPlane", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void HalfMergeUVPlane(byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_uv, int dst_stride_uv, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SwapUVPlane", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void SwapUVPlane(byte* src_uv, int src_stride_uv, byte* dst_vu, int dst_stride_vu, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitRGBPlane", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void SplitRGBPlane(byte* src_rgb, int src_stride_rgb, byte* dst_r, int dst_stride_r, byte* dst_g, int dst_stride_g, byte* dst_b, int dst_stride_b, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeRGBPlane", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void MergeRGBPlane(byte* src_r, int src_stride_r, byte* src_g, int src_stride_g, byte* src_b, int src_stride_b, byte* dst_rgb, int dst_stride_rgb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitARGBPlane", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void SplitARGBPlane(byte* src_argb, int src_stride_argb, byte* dst_r, int dst_stride_r, byte* dst_g, int dst_stride_g, byte* dst_b, int dst_stride_b, byte* dst_a, int dst_stride_a, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeARGBPlane", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void MergeARGBPlane(byte* src_r, int src_stride_r, byte* src_g, int src_stride_g, byte* src_b, int src_stride_b, byte* src_a, int src_stride_a, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeXR30Plane", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void MergeXR30Plane(ushort* src_r, int src_stride_r, ushort* src_g, int src_stride_g, ushort* src_b, int src_stride_b, byte* dst_ar30, int dst_stride_ar30, int width, int height, int depth);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeAR64Plane", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void MergeAR64Plane(ushort* src_r, int src_stride_r, ushort* src_g, int src_stride_g, ushort* src_b, int src_stride_b, ushort* src_a, int src_stride_a, ushort* dst_ar64, int dst_stride_ar64, int width, int height, int depth);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeARGB16To8Plane", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void MergeARGB16To8Plane(ushort* src_r, int src_stride_r, ushort* src_g, int src_stride_g, ushort* src_b, int src_stride_b, ushort* src_a, int src_stride_a, byte* dst_argb, int dst_stride_argb, int width, int height, int depth);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I400ToI400", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I400ToI400(byte* src_y, int src_stride_y, byte* dst_y, int dst_stride_y, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422Copy", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I422Copy(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444Copy", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I444Copy(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I210Copy", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I210Copy(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, ushort* dst_y, int dst_stride_y, ushort* dst_u, int dst_stride_u, ushort* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I410Copy", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I410Copy(ushort* src_y, int src_stride_y, ushort* src_u, int src_stride_u, ushort* src_v, int src_stride_v, ushort* dst_y, int dst_stride_y, ushort* dst_u, int dst_stride_u, ushort* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12Copy", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NV12Copy(byte* src_y, int src_stride_y, byte* src_uv, int src_stride_uv, byte* dst_y, int dst_stride_y, byte* dst_uv, int dst_stride_uv, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21Copy", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NV21Copy(byte* src_y, int src_stride_y, byte* src_vu, int src_stride_vu, byte* dst_y, int dst_stride_y, byte* dst_vu, int dst_stride_vu, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToI422", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int YUY2ToI422(byte* src_yuy2, int src_stride_yuy2, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToI422", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int UYVYToI422(byte* src_uyvy, int src_stride_uyvy, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToNV12", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int YUY2ToNV12(byte* src_yuy2, int src_stride_yuy2, byte* dst_y, int dst_stride_y, byte* dst_uv, int dst_stride_uv, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToNV12", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int UYVYToNV12(byte* src_uyvy, int src_stride_uyvy, byte* dst_y, int dst_stride_y, byte* dst_uv, int dst_stride_uv, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToNV12", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NV21ToNV12(byte* src_y, int src_stride_y, byte* src_vu, int src_stride_vu, byte* dst_y, int dst_stride_y, byte* dst_uv, int dst_stride_uv, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToY", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int YUY2ToY(byte* src_yuy2, int src_stride_yuy2, byte* dst_y, int dst_stride_y, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToY", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int UYVYToY(byte* src_uyvy, int src_stride_uyvy, byte* dst_y, int dst_stride_y, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420ToI400", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420ToI400(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_y, int dst_stride_y, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420Mirror", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420Mirror(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I400Mirror", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I400Mirror(byte* src_y, int src_stride_y, byte* dst_y, int dst_stride_y, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12Mirror", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NV12Mirror(byte* src_y, int src_stride_y, byte* src_uv, int src_stride_uv, byte* dst_y, int dst_stride_y, byte* dst_uv, int dst_stride_uv, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBMirror", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBMirror(byte* src_argb, int src_stride_argb, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24Mirror", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int RGB24Mirror(byte* src_rgb24, int src_stride_rgb24, byte* dst_rgb24, int dst_stride_rgb24, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorPlane", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void MirrorPlane(byte* src_y, int src_stride_y, byte* dst_y, int dst_stride_y, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorUVPlane", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void MirrorUVPlane(byte* src_uv, int src_stride_uv, byte* dst_uv, int dst_stride_uv, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToRGB24", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int RAWToRGB24(byte* src_raw, int src_stride_raw, byte* dst_rgb24, int dst_stride_rgb24, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420Rect", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420Rect(byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int x, int y, int width, int height, int value_y, int value_u, int value_v);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBRect", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBRect(byte* dst_argb, int dst_stride_argb, int dst_x, int dst_y, int width, int height, uint value);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBGrayTo", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBGrayTo(byte* src_argb, int src_stride_argb, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBGray", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBGray(byte* dst_argb, int dst_stride_argb, int dst_x, int dst_y, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBSepia", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBSepia(byte* dst_argb, int dst_stride_argb, int dst_x, int dst_y, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBColorMatrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBColorMatrix(byte* src_argb, int src_stride_argb, byte* dst_argb, int dst_stride_argb, sbyte* matrix_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBColorMatrix", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int RGBColorMatrix(byte* dst_argb, int dst_stride_argb, sbyte* matrix_rgb, int dst_x, int dst_y, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBColorTable", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBColorTable(byte* dst_argb, int dst_stride_argb, byte* table_argb, int dst_x, int dst_y, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBColorTable", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int RGBColorTable(byte* dst_argb, int dst_stride_argb, byte* table_argb, int dst_x, int dst_y, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBLumaColorTable", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBLumaColorTable(byte* src_argb, int src_stride_argb, byte* dst_argb, int dst_stride_argb, byte* luma, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBPolynomial", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBPolynomial(byte* src_argb, int src_stride_argb, byte* dst_argb, int dst_stride_argb, float* poly, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "HalfFloatPlane", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int HalfFloatPlane(ushort* src_y, int src_stride_y, ushort* dst_y, int dst_stride_y, float scale, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ByteToFloat", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ByteToFloat(byte* src_y, float* dst_y, float scale, int width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBQuantize", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBQuantize(byte* dst_argb, int dst_stride_argb, int scale, int interval_size, int interval_offset, int dst_x, int dst_y, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBCopy", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBCopy1(byte* src_argb, int src_stride_argb, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBCopyAlpha", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBCopyAlpha(byte* src_argb, int src_stride_argb, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBExtractAlpha", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBExtractAlpha(byte* src_argb, int src_stride_argb, byte* dst_a, int dst_stride_a, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBCopyYToAlpha", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBCopyYToAlpha(byte* src_y, int src_stride_y, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBBlend", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBBlend(byte* src_argb0, int src_stride_argb0, byte* src_argb1, int src_stride_argb1, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "BlendPlane", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int BlendPlane(byte* src_y0, int src_stride_y0, byte* src_y1, int src_stride_y1, byte* alpha, int alpha_stride, byte* dst_y, int dst_stride_y, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420Blend", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420Blend(byte* src_y0, int src_stride_y0, byte* src_u0, int src_stride_u0, byte* src_v0, int src_stride_v0, byte* src_y1, int src_stride_y1, byte* src_u1, int src_stride_u1, byte* src_v1, int src_stride_v1, byte* alpha, int alpha_stride, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBMultiply", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBMultiply(byte* src_argb0, int src_stride_argb0, byte* src_argb1, int src_stride_argb1, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBAdd", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBAdd(byte* src_argb0, int src_stride_argb0, byte* src_argb1, int src_stride_argb1, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBSubtract", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBSubtract(byte* src_argb0, int src_stride_argb0, byte* src_argb1, int src_stride_argb1, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToYUY2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I422ToYUY2(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_yuy2, int dst_stride_yuy2, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToUYVY", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I422ToUYVY(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_uyvy, int dst_stride_uyvy, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBAttenuate", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBAttenuate(byte* src_argb, int src_stride_argb, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBUnattenuate", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBUnattenuate(byte* src_argb, int src_stride_argb, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBComputeCumulativeSum", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBComputeCumulativeSum(byte* src_argb, int src_stride_argb, int* dst_cumsum, int dst_stride32_cumsum, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBBlur", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBBlur(byte* src_argb, int src_stride_argb, byte* dst_argb, int dst_stride_argb, int* dst_cumsum, int dst_stride32_cumsum, int width, int height, int radius);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "GaussPlane_F32", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GaussPlaneF32(float* src, int src_stride, float* dst, int dst_stride, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBShade", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBShade(byte* src_argb, int src_stride_argb, byte* dst_argb, int dst_stride_argb, int width, int height, uint value);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "InterpolatePlane", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int InterpolatePlane(byte* src0, int src_stride0, byte* src1, int src_stride1, byte* dst, int dst_stride, int width, int height, int interpolation);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "InterpolatePlane_16", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int InterpolatePlane16(ushort* src0, int src_stride0, ushort* src1, int src_stride1, ushort* dst, int dst_stride, int width, int height, int interpolation);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBInterpolate", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBInterpolate(byte* src_argb0, int src_stride_argb0, byte* src_argb1, int src_stride_argb1, byte* dst_argb, int dst_stride_argb, int width, int height, int interpolation);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I420Interpolate", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int I420Interpolate(byte* src0_y, int src0_stride_y, byte* src0_u, int src0_stride_u, byte* src0_v, int src0_stride_v, byte* src1_y, int src1_stride_y, byte* src1_u, int src1_stride_u, byte* src1_v, int src1_stride_v, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height, int interpolation);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBAffineRow_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ARGBAffineRowC(byte* src_argb, int src_argb_stride, byte* dst_argb, float* uv_dudv, int width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBAffineRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ARGBAffineRowSSE2(byte* src_argb, int src_argb_stride, byte* dst_argb, float* uv_dudv, int width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBShuffle", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBShuffle(byte* src_bgra, int src_stride_bgra, byte* dst_argb, int dst_stride_argb, byte* shuffler, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AR64Shuffle", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int AR64Shuffle(ushort* src_ar64, int src_stride_ar64, ushort* dst_ar64, int dst_stride_ar64, byte* shuffler, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBSobelToPlane", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBSobelToPlane(byte* src_argb, int src_stride_argb, byte* dst_y, int dst_stride_y, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBSobel", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBSobel(byte* src_argb, int src_stride_argb, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBSobelXY", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBSobelXY(byte* src_argb, int src_stride_argb, byte* dst_argb, int dst_stride_argb, int width, int height);
        #endregion

        #region convert_from_argb
        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBCopy", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBCopy2(byte* src_argb, int src_stride_argb, byte* dst_argb, int dst_stride_argb, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToBGRA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBToBGRA(byte* src_argb, int src_stride_argb, byte* dst_bgra, int dst_stride_bgra, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToABGR", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBToABGR(byte* src_argb, int src_stride_argb, byte* dst_abgr, int dst_stride_abgr, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGBA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBToRGBA(byte* src_argb, int src_stride_argb, byte* dst_rgba, int dst_stride_rgba, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToAR30", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ABGRToAR30(byte* src_abgr, int src_stride_abgr, byte* dst_ar30, int dst_stride_ar30, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToAR30", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBToAR30(byte* src_argb, int src_stride_argb, byte* dst_ar30, int dst_stride_ar30, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB24", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBToRGB24(byte* src_argb, int src_stride_argb, byte* dst_rgb24, int dst_stride_rgb24, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRAW", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBToRAW(byte* src_argb, int src_stride_argb, byte* dst_raw, int dst_stride_raw, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB565", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBToRGB565(byte* src_argb, int src_stride_argb, byte* dst_rgb565, int dst_stride_rgb565, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB565Dither", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBToRGB565Dither(byte* src_argb, int src_stride_argb, byte* dst_rgb565, int dst_stride_rgb565, byte* dither4x4, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToARGB1555", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBToARGB1555(byte* src_argb, int src_stride_argb, byte* dst_argb1555, int dst_stride_argb1555, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToARGB4444", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBToARGB4444(byte* src_argb, int src_stride_argb, byte* dst_argb4444, int dst_stride_argb4444, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToI444", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBToI444(byte* src_argb, int src_stride_argb, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToAR64", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBToAR64(byte* src_argb, int src_stride_argb, ushort* dst_ar64, int dst_stride_ar64, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToAB64", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBToAB64(byte* src_argb, int src_stride_argb, ushort* dst_ab64, int dst_stride_ab64, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToI422", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBToI422(byte* src_argb, int src_stride_argb, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToI420", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBToI4201(byte* src_argb, int src_stride_argb, byte* dst_y, int dst_stride_y, byte* dst_u, int dst_stride_u, byte* dst_v, int dst_stride_v, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToJ420", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBToJ420(byte* src_argb, int src_stride_argb, byte* dst_yj, int dst_stride_yj, byte* dst_uj, int dst_stride_uj, byte* dst_vj, int dst_stride_vj, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToJ422", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBToJ422(byte* src_argb, int src_stride_argb, byte* dst_yj, int dst_stride_yj, byte* dst_uj, int dst_stride_uj, byte* dst_vj, int dst_stride_vj, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToJ400", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBToJ400(byte* src_argb, int src_stride_argb, byte* dst_yj, int dst_stride_yj, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToJ420", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ABGRToJ420(byte* src_abgr, int src_stride_abgr, byte* dst_yj, int dst_stride_yj, byte* dst_uj, int dst_stride_uj, byte* dst_vj, int dst_stride_vj, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToJ422", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ABGRToJ422(byte* src_abgr, int src_stride_abgr, byte* dst_yj, int dst_stride_yj, byte* dst_uj, int dst_stride_uj, byte* dst_vj, int dst_stride_vj, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToJ400", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ABGRToJ400(byte* src_abgr, int src_stride_abgr, byte* dst_yj, int dst_stride_yj, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToJ400", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int RGBAToJ400(byte* src_rgba, int src_stride_rgba, byte* dst_yj, int dst_stride_yj, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToI400", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBToI400(byte* src_argb, int src_stride_argb, byte* dst_y, int dst_stride_y, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToG", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBToG(byte* src_argb, int src_stride_argb, byte* dst_g, int dst_stride_g, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToNV12", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBToNV12(byte* src_argb, int src_stride_argb, byte* dst_y, int dst_stride_y, byte* dst_uv, int dst_stride_uv, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToNV21", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBToNV21(byte* src_argb, int src_stride_argb, byte* dst_y, int dst_stride_y, byte* dst_vu, int dst_stride_vu, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToNV12", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ABGRToNV12(byte* src_abgr, int src_stride_abgr, byte* dst_y, int dst_stride_y, byte* dst_uv, int dst_stride_uv, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToNV21", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ABGRToNV21(byte* src_abgr, int src_stride_abgr, byte* dst_y, int dst_stride_y, byte* dst_vu, int dst_stride_vu, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToYUY2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBToYUY2(byte* src_argb, int src_stride_argb, byte* dst_yuy2, int dst_stride_yuy2, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUYVY", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBToUYVY(byte* src_argb, int src_stride_argb, byte* dst_uyvy, int dst_stride_uyvy, int width, int height);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToJNV21", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int RAWToJNV21(byte* src_raw, int src_stride_raw, byte* dst_y, int dst_stride_y, byte* dst_vu, int dst_stride_vu, int width, int height);
        #endregion

        #region scale_argb
        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBScale", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBScale(byte* src_argb, int src_stride_argb, int src_width, int src_height, byte* dst_argb, int dst_stride_argb, int dst_width, int dst_height, FilterMode filtering);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBScaleClip", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ARGBScaleClip(byte* src_argb, int src_stride_argb, int src_width, int src_height, byte* dst_argb, int dst_stride_argb, int dst_width, int dst_height, int clip_x, int clip_y, int clip_width, int clip_height, FilterMode filtering);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUVToARGBScaleClip", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int YUVToARGBScaleClip(byte* src_y, int src_stride_y, byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, uint src_fourcc, int src_width, int src_height, byte* dst_argb, int dst_stride_argb, uint dst_fourcc, int dst_width, int dst_height, int clip_x, int clip_y, int clip_width, int clip_height, FilterMode filtering);
        #endregion

        #region  scale_uv
        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UVScale", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int UVScale(byte* src_uv, int src_stride_uv, int src_width, int src_height, byte* dst_uv, int dst_stride_uv, int dst_width, int dst_height, FilterMode filtering);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UVScale_16", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int UVScale16(ushort* src_uv, int src_stride_uv, int src_width, int src_height, ushort* dst_uv, int dst_stride_uv, int dst_width, int dst_height, FilterMode filtering);
        #endregion

        #region scale_row

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScalePlaneVertical", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScalePlaneVertical(int src_height, int dst_width, int dst_height, int src_stride, int dst_stride, byte* src_argb, byte* dst_argb, int x, int y, int dy, int bpp, FilterMode filtering);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScalePlaneVertical_16", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScalePlaneVertical16(int src_height, int dst_width, int dst_height, int src_stride, int dst_stride, ushort* src_argb, ushort* dst_argb, int x, int y, int dy, int wpp, FilterMode filtering);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScalePlaneVertical_16To8", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScalePlaneVertical16To8(int src_height, int dst_width, int dst_height, int src_stride, int dst_stride, ushort* src_argb, byte* dst_argb, int x, int y, int dy, int wpp, int scale, FilterMode filtering);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScalePlaneDown2_16To8", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScalePlaneDown2_16To8(int src_width, int src_height, int dst_width, int dst_height, int src_stride, int dst_stride, ushort* src_ptr, byte* dst_ptr, int scale, FilterMode filtering);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleFilterReduce", CallingConvention = CallingConvention.Cdecl)]
        internal static extern FilterMode ScaleFilterReduce(int src_width, int src_height, int dst_width, int dst_height, FilterMode filtering);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "FixedDiv_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int FixedDivC(int num, int div);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "FixedDiv_X86", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int FixedDivX86(int num, int div);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "FixedDiv_MIPS", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int FixedDivMIPS(int num, int div);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "FixedDiv1_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int FixedDiv1C(int num, int div);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "FixedDiv1_X86", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int FixedDiv1X86(int num, int div);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "FixedDiv1_MIPS", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int FixedDiv1MIPS(int num, int div);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleSlope", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleSlope(int src_width, int src_height, int dst_width, int dst_height, FilterMode filtering, int* x, int* y, int* dx, int* dy);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2C(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2_16_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2_16C(ushort* src_ptr, long src_stride, ushort* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2_16To8_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2_16To8C(ushort* src_ptr, long src_stride, byte* dst, int dst_width, int scale);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2_16To8_Odd_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2_16To8OddC(ushort* src_ptr, long src_stride, byte* dst, int dst_width, int scale);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Linear_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2LinearC(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Linear_16_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2Linear16C(ushort* src_ptr, long src_stride, ushort* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Linear_16To8_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2Linear16To8C(ushort* src_ptr, long src_stride, byte* dst, int dst_width, int scale);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Linear_16To8_Odd_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2Linear16To8OddC(ushort* src_ptr, long src_stride, byte* dst, int dst_width, int scale);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Box_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2BoxC(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Box_Odd_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2BoxOddC(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Box_16_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2Box16C(ushort* src_ptr, long src_stride, ushort* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Box_16To8_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2Box16To8C(ushort* src_ptr, long src_stride, byte* dst, int dst_width, int scale);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Box_16To8_Odd_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2Box16To8OddC(ushort* src_ptr, long src_stride, byte* dst, int dst_width, int scale);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown4_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown4C(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown4_16_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown4_16C(ushort* src_ptr, long src_stride, ushort* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown4Box_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown4BoxC(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown4Box_16_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown4Box16C(ushort* src_ptr, long src_stride, ushort* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown34_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown34C(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown34_16_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown34_16C(ushort* src_ptr, long src_stride, ushort* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown34_0_Box_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown34_0BoxC(byte* src_ptr, long src_stride, byte* d, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown34_0_Box_16_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown34_0Box16C(ushort* src_ptr, long src_stride, ushort* d, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown34_1_Box_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown34_1BoxC(byte* src_ptr, long src_stride, byte* d, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown34_1_Box_16_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown34_1Box16C(ushort* src_ptr, long src_stride, ushort* d, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Linear_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2LinearC(byte* src_ptr, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Bilinear_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2BilinearC(byte* src_ptr, long src_stride, byte* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Linear_16_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2Linear16C(ushort* src_ptr, ushort* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Bilinear_16_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2Bilinear16C(ushort* src_ptr, long src_stride, ushort* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Linear_Any_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2LinearAnyC(byte* src_ptr, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Bilinear_Any_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2BilinearAnyC(byte* src_ptr, long src_stride, byte* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Linear_16_Any_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2Linear16AnyC(ushort* src_ptr, ushort* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Bilinear_16_Any_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2Bilinear16AnyC(ushort* src_ptr, long src_stride, ushort* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleCols_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleColsC(byte* dst_ptr, byte* src_ptr, int dst_width, int x, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleCols_16_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleCols16C(ushort* dst_ptr, ushort* src_ptr, int dst_width, int x, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleColsUp2_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleColsUp2C(byte* dst_ptr, byte* src_ptr, int dst_width, int _0, int _1);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleColsUp2_16_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleColsUp2_16C(ushort* dst_ptr, ushort* src_ptr, int dst_width, int _0, int _1);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleFilterCols_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleFilterColsC(byte* dst_ptr, byte* src_ptr, int dst_width, int x, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleFilterCols_16_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleFilterCols16C(ushort* dst_ptr, ushort* src_ptr, int dst_width, int x, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleFilterCols64_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleFilterCols64C(byte* dst_ptr, byte* src_ptr, int dst_width, int x32, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleFilterCols64_16_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleFilterCols64_16C(ushort* dst_ptr, ushort* src_ptr, int dst_width, int x32, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown38_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown38C(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown38_16_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown38_16C(ushort* src_ptr, long src_stride, ushort* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown38_3_Box_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown38_3BoxC(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown38_3_Box_16_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown38_3Box16C(ushort* src_ptr, long src_stride, ushort* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown38_2_Box_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown38_2BoxC(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown38_2_Box_16_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown38_2Box16C(ushort* src_ptr, long src_stride, ushort* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleAddRow_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleAddRowC(byte* src_ptr, ushort* dst_ptr, int src_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleAddRow_16_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleAddRow16C(ushort* src_ptr, uint* dst_ptr, int src_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDown2_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDown2C(byte* src_argb, long src_stride, byte* dst_argb, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDown2Linear_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDown2LinearC(byte* src_argb, long src_stride, byte* dst_argb, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDown2Box_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDown2BoxC(byte* src_argb, long src_stride, byte* dst_argb, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDownEven_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDownEvenC(byte* src_argb, long src_stride, int src_stepx, byte* dst_argb, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDownEvenBox_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDownEvenBoxC(byte* src_argb, long src_stride, int src_stepx, byte* dst_argb, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBCols_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBColsC(byte* dst_argb, byte* src_argb, int dst_width, int x, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBCols64_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBCols64C(byte* dst_argb, byte* src_argb, int dst_width, int x32, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBColsUp2_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBColsUp2C(byte* dst_argb, byte* src_argb, int dst_width, int _0, int _1);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBFilterCols_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBFilterColsC(byte* dst_argb, byte* src_argb, int dst_width, int x, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBFilterCols64_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBFilterCols64C(byte* dst_argb, byte* src_argb, int dst_width, int x32, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDown2_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDown2C(byte* src_uv, long src_stride, byte* dst_uv, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDown2Linear_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDown2LinearC(byte* src_uv, long src_stride, byte* dst_uv, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDown2Box_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDown2BoxC(byte* src_uv, long src_stride, byte* dst_uv, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDownEven_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDownEvenC(byte* src_uv, long src_stride, int src_stepx, byte* dst_uv, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDownEvenBox_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDownEvenBoxC(byte* src_uv, long src_stride, int src_stepx, byte* dst_uv, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Linear_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2LinearC(byte* src_ptr, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Bilinear_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2BilinearC(byte* src_ptr, long src_stride, byte* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Linear_Any_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2LinearAnyC(byte* src_ptr, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Bilinear_Any_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2BilinearAnyC(byte* src_ptr, long src_stride, byte* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Linear_16_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2Linear16C(ushort* src_ptr, ushort* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Bilinear_16_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2Bilinear16C(ushort* src_ptr, long src_stride, ushort* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Linear_16_Any_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2Linear16AnyC(ushort* src_ptr, ushort* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Bilinear_16_Any_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2Bilinear16AnyC(ushort* src_ptr, long src_stride, ushort* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVCols_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVColsC(byte* dst_uv, byte* src_uv, int dst_width, int x, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVCols64_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVCols64C(byte* dst_uv, byte* src_uv, int dst_width, int x32, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVColsUp2_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVColsUp2C(byte* dst_uv, byte* src_uv, int dst_width, int _0, int _1);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVFilterCols_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVFilterColsC(byte* dst_uv, byte* src_uv, int dst_width, int x, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVFilterCols64_C", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVFilterCols64C(byte* dst_uv, byte* src_uv, int dst_width, int x32, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2SSSE3(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Linear_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2LinearSSSE3(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Box_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2BoxSSSE3(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2AVX2(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Linear_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2LinearAVX2(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Box_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2BoxAVX2(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown4_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown4SSSE3(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown4Box_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown4BoxSSSE3(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown4_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown4AVX2(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown4Box_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown4BoxAVX2(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown34_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown34SSSE3(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown34_1_Box_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown34_1BoxSSSE3(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown34_0_Box_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown34_0BoxSSSE3(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown38_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown38SSSE3(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown38_3_Box_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown38_3BoxSSSE3(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown38_2_Box_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown38_2BoxSSSE3(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Linear_SSE2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2LinearSSE2(byte* src_ptr, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Bilinear_SSE2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2BilinearSSE2(byte* src_ptr, long src_stride, byte* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Linear_12_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2Linear12SSSE3(ushort* src_ptr, ushort* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Bilinear_12_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2Bilinear12SSSE3(ushort* src_ptr, long src_stride, ushort* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Linear_16_SSE2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2Linear16SSE2(ushort* src_ptr, ushort* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Bilinear_16_SSE2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2Bilinear16SSE2(ushort* src_ptr, long src_stride, ushort* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Linear_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2LinearSSSE3(byte* src_ptr, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Bilinear_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2BilinearSSSE3(byte* src_ptr, long src_stride, byte* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Linear_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2LinearAVX2(byte* src_ptr, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Bilinear_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2BilinearAVX2(byte* src_ptr, long src_stride, byte* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Linear_12_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2Linear12AVX2(ushort* src_ptr, ushort* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Bilinear_12_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2Bilinear12AVX2(ushort* src_ptr, long src_stride, ushort* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Linear_16_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2Linear16AVX2(ushort* src_ptr, ushort* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Bilinear_16_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2Bilinear16AVX2(ushort* src_ptr, long src_stride, ushort* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Linear_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2LinearAnySSE2(byte* src_ptr, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Bilinear_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2BilinearAnySSE2(byte* src_ptr, long src_stride, byte* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Linear_12_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2Linear12AnySSSE3(ushort* src_ptr, ushort* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Bilinear_12_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2Bilinear12AnySSSE3(ushort* src_ptr, long src_stride, ushort* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Linear_16_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2Linear16AnySSE2(ushort* src_ptr, ushort* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Bilinear_16_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2Bilinear16AnySSE2(ushort* src_ptr, long src_stride, ushort* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Linear_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2LinearAnySSSE3(byte* src_ptr, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Bilinear_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2BilinearAnySSSE3(byte* src_ptr, long src_stride, byte* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Linear_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2LinearAnyAVX2(byte* src_ptr, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Bilinear_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2BilinearAnyAVX2(byte* src_ptr, long src_stride, byte* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Linear_12_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2Linear12AnyAVX2(ushort* src_ptr, ushort* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Bilinear_12_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2Bilinear12AnyAVX2(ushort* src_ptr, long src_stride, ushort* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Linear_16_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2Linear16AnyAVX2(ushort* src_ptr, ushort* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Bilinear_16_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2Bilinear16AnyAVX2(ushort* src_ptr, long src_stride, ushort* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2AnySSSE3(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Linear_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2LinearAnySSSE3(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Box_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2BoxAnySSSE3(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Box_Odd_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2BoxOddSSSE3(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2AnyAVX2(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Linear_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2LinearAnyAVX2(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Box_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2BoxAnyAVX2(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Box_Odd_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2BoxOddAVX2(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown4_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown4AnySSSE3(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown4Box_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown4BoxAnySSSE3(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown4_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown4AnyAVX2(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown4Box_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown4BoxAnyAVX2(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown34_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown34AnySSSE3(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown34_1_Box_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown34_1BoxAnySSSE3(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown34_0_Box_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown34_0BoxAnySSSE3(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown38_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown38AnySSSE3(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown38_3_Box_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown38_3BoxAnySSSE3(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown38_2_Box_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown38_2BoxAnySSSE3(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleAddRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleAddRowSSE2(byte* src_ptr, ushort* dst_ptr, int src_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleAddRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleAddRowAVX2(byte* src_ptr, ushort* dst_ptr, int src_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleAddRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleAddRowAnySSE2(byte* src_ptr, ushort* dst_ptr, int src_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleAddRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleAddRowAnyAVX2(byte* src_ptr, ushort* dst_ptr, int src_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleFilterCols_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleFilterColsSSSE3(byte* dst_ptr, byte* src_ptr, int dst_width, int x, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleColsUp2_SSE2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleColsUp2SSE2(byte* dst_ptr, byte* src_ptr, int dst_width, int x, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBCols_SSE2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBColsSSE2(byte* dst_argb, byte* src_argb, int dst_width, int x, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBFilterCols_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBFilterColsSSSE3(byte* dst_argb, byte* src_argb, int dst_width, int x, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBColsUp2_SSE2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBColsUp2SSE2(byte* dst_argb, byte* src_argb, int dst_width, int x, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBFilterCols_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBFilterColsNEON(byte* dst_argb, byte* src_argb, int dst_width, int x, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBCols_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBColsNEON(byte* dst_argb, byte* src_argb, int dst_width, int x, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBFilterCols_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBFilterColsAnyNEON(byte* dst_ptr, byte* src_ptr, int dst_width, int x, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBCols_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBColsAnyNEON(byte* dst_ptr, byte* src_ptr, int dst_width, int x, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBFilterCols_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBFilterColsMSA(byte* dst_argb, byte* src_argb, int dst_width, int x, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBCols_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBColsMSA(byte* dst_argb, byte* src_argb, int dst_width, int x, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBFilterCols_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBFilterColsAnyMSA(byte* dst_ptr, byte* src_ptr, int dst_width, int x, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBCols_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBColsAnyMSA(byte* dst_ptr, byte* src_ptr, int dst_width, int x, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDown2_SSE2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDown2SSE2(byte* src_argb, long src_stride, byte* dst_argb, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDown2Linear_SSE2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDown2LinearSSE2(byte* src_argb, long src_stride, byte* dst_argb, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDown2Box_SSE2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDown2BoxSSE2(byte* src_argb, long src_stride, byte* dst_argb, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDown2_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDown2NEON(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDown2Linear_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDown2LinearNEON(byte* src_argb, long src_stride, byte* dst_argb, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDown2Box_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDown2BoxNEON(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDown2_RVV", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDown2RVV(byte* src_argb, long src_stride, byte* dst_argb, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDown2Linear_RVV", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDown2LinearRVV(byte* src_argb, long src_stride, byte* dst_argb, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDown2Box_RVV", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDown2BoxRVV(byte* src_argb, long src_stride, byte* dst_argb, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDown2_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDown2MSA(byte* src_argb, long src_stride, byte* dst_argb, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDown2Linear_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDown2LinearMSA(byte* src_argb, long src_stride, byte* dst_argb, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDown2Box_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDown2BoxMSA(byte* src_argb, long src_stride, byte* dst_argb, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDown2_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDown2LSX(byte* src_argb, long src_stride, byte* dst_argb, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDown2Linear_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDown2LinearLSX(byte* src_argb, long src_stride, byte* dst_argb, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDown2Box_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDown2BoxLSX(byte* src_argb, long src_stride, byte* dst_argb, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDown2_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDown2AnySSE2(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDown2Linear_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDown2LinearAnySSE2(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDown2Box_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDown2BoxAnySSE2(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDown2_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDown2AnyNEON(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDown2Linear_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDown2LinearAnyNEON(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDown2Box_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDown2BoxAnyNEON(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDown2_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDown2AnyMSA(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDown2Linear_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDown2LinearAnyMSA(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDown2Box_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDown2BoxAnyMSA(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDown2_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDown2AnyLSX(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDown2Linear_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDown2LinearAnyLSX(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDown2Box_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDown2BoxAnyLSX(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDownEven_SSE2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDownEvenSSE2(byte* src_argb, long src_stride, int src_stepx, byte* dst_argb, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDownEvenBox_SSE2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDownEvenBoxSSE2(byte* src_argb, long src_stride, int src_stepx, byte* dst_argb, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDownEven_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDownEvenNEON(byte* src_argb, long src_stride, int src_stepx, byte* dst_argb, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDownEvenBox_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDownEvenBoxNEON(byte* src_argb, long src_stride, int src_stepx, byte* dst_argb, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDownEven_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDownEvenMSA(byte* src_argb, long src_stride, int src_stepx, byte* dst_argb, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDownEvenBox_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDownEvenBoxMSA(byte* src_argb, long src_stride, int src_stepx, byte* dst_argb, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDownEven_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDownEvenLSX(byte* src_argb, long src_stride, int src_stepx, byte* dst_argb, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDownEvenBox_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDownEvenBoxLSX(byte* src_argb, long src_stride, int src_stepx, byte* dst_argb, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDownEven_RVV", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDownEvenRVV(byte* src_argb, long src_stride, int src_stepx, byte* dst_argb, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDownEvenBox_RVV", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDownEvenBoxRVV(byte* src_argb, long src_stride, int src_stepx, byte* dst_argb, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDownEven_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDownEvenAnySSE2(byte* src_ptr, long src_stride, int src_stepx, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDownEvenBox_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDownEvenBoxAnySSE2(byte* src_ptr, long src_stride, int src_stepx, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDownEven_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDownEvenAnyNEON(byte* src_ptr, long src_stride, int src_stepx, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDownEvenBox_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDownEvenBoxAnyNEON(byte* src_ptr, long src_stride, int src_stepx, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDownEven_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDownEvenAnyMSA(byte* src_ptr, long src_stride, int src_stepx, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDownEvenBox_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDownEvenBoxAnyMSA(byte* src_ptr, long src_stride, int src_stepx, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDownEven_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDownEvenAnyLSX(byte* src_ptr, long src_stride, int src_stepx, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBRowDownEvenBox_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBRowDownEvenBoxAnyLSX(byte* src_ptr, long src_stride, int src_stepx, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDown2_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDown2SSSE3(byte* src_ptr, long src_stride, byte* dst_uv, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDown2Linear_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDown2LinearSSSE3(byte* src_ptr, long src_stride, byte* dst_uv, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDown2Box_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDown2BoxSSSE3(byte* src_ptr, long src_stride, byte* dst_uv, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDown2Box_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDown2BoxAVX2(byte* src_ptr, long src_stride, byte* dst_uv, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDown2_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDown2NEON(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDown2Linear_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDown2LinearNEON(byte* src_ptr, long src_stride, byte* dst_uv, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDown2Box_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDown2BoxNEON(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDown2_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDown2MSA(byte* src_ptr, long src_stride, byte* dst_uv, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDown2Linear_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDown2LinearMSA(byte* src_ptr, long src_stride, byte* dst_uv, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDown2Box_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDown2BoxMSA(byte* src_ptr, long src_stride, byte* dst_uv, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDown2_RVV", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDown2RVV(byte* src_ptr, long src_stride, byte* dst_uv, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDown2Linear_RVV", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDown2LinearRVV(byte* src_ptr, long src_stride, byte* dst_uv, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDown2Box_RVV", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDown2BoxRVV(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDown2_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDown2AnySSSE3(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDown2Linear_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDown2LinearAnySSSE3(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDown2Box_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDown2BoxAnySSSE3(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDown2Box_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDown2BoxAnyAVX2(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDown2_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDown2AnyNEON(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDown2Linear_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDown2LinearAnyNEON(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDown2Box_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDown2BoxAnyNEON(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDown2_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDown2AnyMSA(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDown2Linear_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDown2LinearAnyMSA(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDown2Box_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDown2BoxAnyMSA(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDownEven_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDownEvenSSSE3(byte* src_ptr, long src_stride, int src_stepx, byte* dst_uv, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDownEvenBox_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDownEvenBoxSSSE3(byte* src_ptr, long src_stride, int src_stepx, byte* dst_uv, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDownEven_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDownEvenNEON(byte* src_ptr, long src_stride, int src_stepx, byte* dst_uv, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDownEvenBox_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDownEvenBoxNEON(byte* src_ptr, long src_stride, int src_stepx, byte* dst_uv, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDown4_RVV", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDown4RVV(byte* src_ptr, long src_stride, int src_stepx, byte* dst_uv, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDownEven_RVV", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDownEvenRVV(byte* src_ptr, long src_stride, int src_stepx, byte* dst_uv, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDownEven_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDownEvenMSA(byte* src_ptr, long src_stride, int src_stepx, byte* dst_uv, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDownEvenBox_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDownEvenBoxMSA(byte* src_ptr, long src_stride, int src_stepx, byte* dst_uv, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDownEven_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDownEvenAnySSSE3(byte* src_ptr, long src_stride, int src_stepx, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDownEvenBox_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDownEvenBoxAnySSSE3(byte* src_ptr, long src_stride, int src_stepx, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDownEven_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDownEvenAnyNEON(byte* src_ptr, long src_stride, int src_stepx, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDownEvenBox_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDownEvenBoxAnyNEON(byte* src_ptr, long src_stride, int src_stepx, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDownEven_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDownEvenAnyMSA(byte* src_ptr, long src_stride, int src_stepx, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowDownEvenBox_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowDownEvenBoxAnyMSA(byte* src_ptr, long src_stride, int src_stepx, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Linear_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2LinearSSSE3(byte* src_ptr, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Bilinear_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2BilinearSSSE3(byte* src_ptr, long src_stride, byte* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Linear_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2LinearAnySSSE3(byte* src_ptr, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Bilinear_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2BilinearAnySSSE3(byte* src_ptr, long src_stride, byte* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Linear_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2LinearAVX2(byte* src_ptr, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Bilinear_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2BilinearAVX2(byte* src_ptr, long src_stride, byte* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Linear_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2LinearAnyAVX2(byte* src_ptr, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Bilinear_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2BilinearAnyAVX2(byte* src_ptr, long src_stride, byte* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Linear_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2LinearNEON(byte* src_ptr, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Bilinear_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2BilinearNEON(byte* src_ptr, long src_stride, byte* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Linear_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2LinearAnyNEON(byte* src_ptr, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Bilinear_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2BilinearAnyNEON(byte* src_ptr, long src_stride, byte* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Linear_RVV", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2LinearRVV(byte* src_ptr, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Bilinear_RVV", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2BilinearRVV(byte* src_ptr, long src_stride, byte* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Linear_16_SSE41", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2Linear16SSE41(ushort* src_ptr, ushort* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Bilinear_16_SSE41", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2Bilinear16SSE41(ushort* src_ptr, long src_stride, ushort* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Linear_16_Any_SSE41", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2Linear16AnySSE41(ushort* src_ptr, ushort* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Bilinear_16_Any_SSE41", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2Bilinear16AnySSE41(ushort* src_ptr, long src_stride, ushort* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Linear_16_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2Linear16AVX2(ushort* src_ptr, ushort* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Bilinear_16_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2Bilinear16AVX2(ushort* src_ptr, long src_stride, ushort* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Linear_16_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2Linear16AnyAVX2(ushort* src_ptr, ushort* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Bilinear_16_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2Bilinear16AnyAVX2(ushort* src_ptr, long src_stride, ushort* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Linear_16_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2Linear16NEON(ushort* src_ptr, ushort* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Bilinear_16_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2Bilinear16NEON(ushort* src_ptr, long src_stride, ushort* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Linear_16_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2Linear16AnyNEON(ushort* src_ptr, ushort* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleUVRowUp2_Bilinear_16_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleUVRowUp2Bilinear16AnyNEON(ushort* src_ptr, long src_stride, ushort* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2NEON(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Linear_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2LinearNEON(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Box_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2BoxNEON(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown4_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown4NEON(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown4Box_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown4BoxNEON(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown34_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown34NEON(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown34_0_Box_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown34_0BoxNEON(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown34_1_Box_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown34_1BoxNEON(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown38_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown38NEON(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown38_3_Box_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown38_3BoxNEON(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown38_2_Box_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown38_2BoxNEON(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2AnyNEON(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Linear_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2LinearAnyNEON(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Box_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2BoxAnyNEON(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Box_Odd_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2BoxOddNEON(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown4_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown4AnyNEON(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown4Box_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown4BoxAnyNEON(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown34_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown34AnyNEON(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown34_0_Box_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown34_0BoxAnyNEON(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown34_1_Box_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown34_1BoxAnyNEON(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown38_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown38AnyNEON(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown38_3_Box_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown38_3BoxAnyNEON(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown38_2_Box_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown38_2BoxAnyNEON(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Linear_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2LinearNEON(byte* src_ptr, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Bilinear_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2BilinearNEON(byte* src_ptr, long src_stride, byte* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Linear_12_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2Linear12NEON(ushort* src_ptr, ushort* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Bilinear_12_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2Bilinear12NEON(ushort* src_ptr, long src_stride, ushort* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Linear_16_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2Linear16NEON(ushort* src_ptr, ushort* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Bilinear_16_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2Bilinear16NEON(ushort* src_ptr, long src_stride, ushort* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Linear_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2LinearAnyNEON(byte* src_ptr, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Bilinear_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2BilinearAnyNEON(byte* src_ptr, long src_stride, byte* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Linear_12_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2Linear12AnyNEON(ushort* src_ptr, ushort* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Bilinear_12_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2Bilinear12AnyNEON(ushort* src_ptr, long src_stride, ushort* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Linear_16_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2Linear16AnyNEON(ushort* src_ptr, ushort* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Bilinear_16_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2Bilinear16AnyNEON(ushort* src_ptr, long src_stride, ushort* dst_ptr, long dst_stride, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleAddRow_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleAddRowNEON(byte* src_ptr, ushort* dst_ptr, int src_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleAddRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleAddRowAnyNEON(byte* src_ptr, ushort* dst_ptr, int src_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleFilterCols_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleFilterColsNEON(byte* dst_ptr, byte* src_ptr, int dst_width, int x, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleFilterCols_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleFilterColsAnyNEON(byte* dst_ptr, byte* src_ptr, int dst_width, int x, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2MSA(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Linear_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2LinearMSA(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Box_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2BoxMSA(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown4_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown4MSA(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown4Box_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown4BoxMSA(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown38_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown38MSA(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown38_2_Box_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown38_2BoxMSA(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown38_3_Box_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown38_3BoxMSA(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleAddRow_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleAddRowMSA(byte* src_ptr, ushort* dst_ptr, int src_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleFilterCols_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleFilterColsMSA(byte* dst_ptr, byte* src_ptr, int dst_width, int x, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown34_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown34MSA(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown34_0_Box_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown34_0BoxMSA(byte* src_ptr, long src_stride, byte* d, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown34_1_Box_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown34_1BoxMSA(byte* src_ptr, long src_stride, byte* d, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2AnyMSA(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Linear_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2LinearAnyMSA(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Box_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2BoxAnyMSA(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown4_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown4AnyMSA(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown4Box_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown4BoxAnyMSA(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown38_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown38AnyMSA(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown38_2_Box_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown38_2BoxAnyMSA(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown38_3_Box_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown38_3BoxAnyMSA(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleAddRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleAddRowAnyMSA(byte* src_ptr, ushort* dst_ptr, int src_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleFilterCols_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleFilterColsAnyMSA(byte* dst_ptr, byte* src_ptr, int dst_width, int x, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown34_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown34AnyMSA(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown34_0_Box_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown34_0BoxAnyMSA(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown34_1_Box_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown34_1BoxAnyMSA(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2LSX(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Linear_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2LinearLSX(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Box_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2BoxLSX(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown4_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown4LSX(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown4Box_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown4BoxLSX(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown38_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown38LSX(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown38_2_Box_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown38_2BoxLSX(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown38_3_Box_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown38_3BoxLSX(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleAddRow_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleAddRowLSX(byte* src_ptr, ushort* dst_ptr, int src_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleFilterCols_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleFilterColsLSX(byte* dst_ptr, byte* src_ptr, int dst_width, int x, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBFilterCols_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBFilterColsLSX(byte* dst_argb, byte* src_argb, int dst_width, int x, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBCols_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBColsLSX(byte* dst_argb, byte* src_argb, int dst_width, int x, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown34_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown34LSX(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown34_0_Box_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown34_0BoxLSX(byte* src_ptr, long src_stride, byte* d, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown34_1_Box_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown34_1BoxLSX(byte* src_ptr, long src_stride, byte* d, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2AnyLSX(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Linear_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2LinearAnyLSX(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Box_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2BoxAnyLSX(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown4_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown4AnyLSX(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown4Box_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown4BoxAnyLSX(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown38_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown38AnyLSX(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown38_2_Box_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown38_2BoxAnyLSX(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown38_3_Box_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown38_3BoxAnyLSX(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleAddRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleAddRowAnyLSX(byte* src_ptr, ushort* dst_ptr, int src_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleFilterCols_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleFilterColsAnyLSX(byte* dst_ptr, byte* src_ptr, int dst_width, int x, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBCols_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBColsAnyLSX(byte* dst_ptr, byte* src_ptr, int dst_width, int x, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleARGBFilterCols_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleARGBFilterColsAnyLSX(byte* dst_ptr, byte* src_ptr, int dst_width, int x, int dx);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown34_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown34AnyLSX(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown34_0_Box_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown34_0BoxAnyLSX(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown34_1_Box_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown34_1BoxAnyLSX(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleAddRow_RVV", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleAddRowRVV(byte* src_ptr, ushort* dst_ptr, int src_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2_RVV", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2RVV(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Linear_RVV", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2LinearRVV(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown2Box_RVV", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown2BoxRVV(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown4_RVV", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown4RVV(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown4Box_RVV", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown4BoxRVV(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown34_RVV", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown34RVV(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown34_0_Box_RVV", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown34_0BoxRVV(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown34_1_Box_RVV", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown34_1BoxRVV(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown38_RVV", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown38RVV(byte* src_ptr, long src_stride, byte* dst, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown38_3_Box_RVV", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown38_3BoxRVV(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowDown38_2_Box_RVV", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowDown38_2BoxRVV(byte* src_ptr, long src_stride, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Linear_RVV", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2LinearRVV(byte* src_ptr, byte* dst_ptr, int dst_width);

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleRowUp2_Bilinear_RVV", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ScaleRowUp2BilinearRVV(byte* src_ptr, long src_stride, byte* dst_ptr, long dst_stride, int dst_width);
        #endregion

        #region row
       
            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444ToARGBRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I444ToARGBRowNEON(byte* src_y, byte* src_u, byte* src_v, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444ToRGB24Row_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I444ToRGB24RowNEON(byte* src_y, byte* src_u, byte* src_v, byte* dst_rgb24, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGBRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGBRowNEON(byte* src_y, byte* src_u, byte* src_v, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444AlphaToARGBRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I444AlphaToARGBRowNEON(byte* src_y, byte* src_u, byte* src_v, byte* src_a, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422AlphaToARGBRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422AlphaToARGBRowNEON(byte* src_y, byte* src_u, byte* src_v, byte* src_a, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGBARow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGBARowNEON(byte* src_y, byte* src_u, byte* src_v, byte* dst_rgba, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGB24Row_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGB24RowNEON(byte* src_y, byte* src_u, byte* src_v, byte* dst_rgb24, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGB565Row_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGB565RowNEON(byte* src_y, byte* src_u, byte* src_v, byte* dst_rgb565, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGB1555Row_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGB1555RowNEON(byte* src_y, byte* src_u, byte* src_v, byte* dst_argb1555, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGB4444Row_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGB4444RowNEON(byte* src_y, byte* src_u, byte* src_v, byte* dst_argb4444, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToARGBRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToARGBRowNEON(byte* src_y, byte* src_uv, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToRGB565Row_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToRGB565RowNEON(byte* src_y, byte* src_uv, byte* dst_rgb565, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToARGBRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV21ToARGBRowNEON(byte* src_y, byte* src_vu, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToRGB24Row_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToRGB24RowNEON(byte* src_y, byte* src_uv, byte* dst_rgb24, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToRGB24Row_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV21ToRGB24RowNEON(byte* src_y, byte* src_vu, byte* dst_rgb24, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToYUV24Row_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV21ToYUV24RowNEON(byte* src_y, byte* src_vu, byte* dst_yuv24, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToARGBRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToARGBRowNEON(byte* src_yuy2, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToARGBRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToARGBRowNEON(byte* src_uyvy, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444ToARGBRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I444ToARGBRowRVV(byte* src_y, byte* src_u, byte* src_v, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444AlphaToARGBRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I444AlphaToARGBRowRVV(byte* src_y, byte* src_u, byte* src_v, byte* src_a, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444ToRGB24Row_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I444ToRGB24RowRVV(byte* src_y, byte* src_u, byte* src_v, byte* dst_rgb24, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGBRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGBRowRVV(byte* src_y, byte* src_u, byte* src_v, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422AlphaToARGBRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422AlphaToARGBRowRVV(byte* src_y, byte* src_u, byte* src_v, byte* src_a, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGBARow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGBARowRVV(byte* src_y, byte* src_u, byte* src_v, byte* dst_rgba, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGB24Row_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGB24RowRVV(byte* src_y, byte* src_u, byte* src_v, byte* dst_rgb24, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444ToARGBRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I444ToARGBRowMSA(byte* src_y, byte* src_u, byte* src_v, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444ToARGBRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I444ToARGBRowLSX(byte* src_y, byte* src_u, byte* src_v, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGBRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGBRowMSA(byte* src_y, byte* src_u, byte* src_v, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGBRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGBRowLSX(byte* src_y, byte* src_u, byte* src_v, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGBRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGBRowLASX(byte* src_y, byte* src_u, byte* src_v, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGBARow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGBARowMSA(byte* src_y, byte* src_u, byte* src_v, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGBARow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGBARowLSX(byte* src_y, byte* src_u, byte* src_v, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGBARow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGBARowLASX(byte* src_y, byte* src_u, byte* src_v, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422AlphaToARGBRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422AlphaToARGBRowMSA(byte* src_y, byte* src_u, byte* src_v, byte* src_a, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422AlphaToARGBRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422AlphaToARGBRowLSX(byte* src_y, byte* src_u, byte* src_v, byte* src_a, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422AlphaToARGBRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422AlphaToARGBRowLASX(byte* src_y, byte* src_u, byte* src_v, byte* src_a, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGB24Row_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGB24RowMSA(byte* src_y, byte* src_u, byte* src_v, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGB24Row_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGB24RowLSX(byte* src_y, byte* src_u, byte* src_v, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGB24Row_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGB24RowLASX(byte* src_y, byte* src_u, byte* src_v, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGB565Row_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGB565RowMSA(byte* src_y, byte* src_u, byte* src_v, byte* dst_rgb565, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGB565Row_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGB565RowLSX(byte* src_y, byte* src_u, byte* src_v, byte* dst_rgb565, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGB565Row_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGB565RowLASX(byte* src_y, byte* src_u, byte* src_v, byte* dst_rgb565, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGB4444Row_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGB4444RowMSA(byte* src_y, byte* src_u, byte* src_v, byte* dst_argb4444, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGB4444Row_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGB4444RowLSX(byte* src_y, byte* src_u, byte* src_v, byte* dst_argb4444, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGB4444Row_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGB4444RowLASX(byte* src_y, byte* src_u, byte* src_v, byte* dst_argb4444, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGB1555Row_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGB1555RowMSA(byte* src_y, byte* src_u, byte* src_v, byte* dst_argb1555, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGB1555Row_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGB1555RowLSX(byte* src_y, byte* src_u, byte* src_v, byte* dst_argb1555, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGB1555Row_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGB1555RowLASX(byte* src_y, byte* src_u, byte* src_v, byte* dst_argb1555, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToARGBRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToARGBRowMSA(byte* src_y, byte* src_uv, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToRGB565Row_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToRGB565RowMSA(byte* src_y, byte* src_uv, byte* dst_rgb565, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToARGBRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV21ToARGBRowMSA(byte* src_y, byte* src_vu, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToARGBRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToARGBRowMSA(byte* src_yuy2, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToARGBRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToARGBRowMSA(byte* src_uyvy, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToARGBRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToARGBRowLSX(byte* src_y, byte* src_uv, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToARGBRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToARGBRowLASX(byte* src_y, byte* src_uv, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToRGB565Row_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToRGB565RowLSX(byte* src_y, byte* src_uv, byte* dst_rgb565, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToRGB565Row_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToRGB565RowLASX(byte* src_y, byte* src_uv, byte* dst_rgb565, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToARGBRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV21ToARGBRowLSX(byte* src_y, byte* src_vu, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToARGBRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV21ToARGBRowLASX(byte* src_y, byte* src_vu, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToARGBRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToARGBRowLSX(byte* src_yuy2, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToARGBRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToARGBRowLSX(byte* src_uyvy, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToARGBRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToARGBRowRVV(byte* src_y, byte* src_uv, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToARGBRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV21ToARGBRowRVV(byte* src_y, byte* src_vu, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToRGB24Row_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToRGB24RowRVV(byte* src_y, byte* src_uv, byte* dst_rgb24, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToRGB24Row_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV21ToRGB24RowRVV(byte* src_y, byte* src_vu, byte* dst_rgb24, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToYRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToYRowAVX2(byte* src_argb, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToYRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToYRowAnyAVX2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToYRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToYRowAVX2(byte* src_abgr, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToYRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToYRowAnyAVX2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToYRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToYRowSSSE3(byte* src_argb, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToYJRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToYJRowSSSE3(byte* src_argb, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToYJRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToYJRowAVX2(byte* src_argb, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToYJRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToYJRowAnyAVX2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToYRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToYRowSSSE3(byte* src_abgr, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToYJRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToYJRowSSSE3(byte* src_abgr, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToYJRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToYJRowAVX2(byte* src_abgr, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToYJRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToYJRowAnyAVX2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToYJRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToYJRowAVX2(byte* src_rgba, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToYJRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToYJRowAnyAVX2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToYJRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToYJRowSSSE3(byte* src_rgba, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "BGRAToYRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void BGRAToYRowSSSE3(byte* src_bgra, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToYRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToYRowSSSE3(byte* src_rgba, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToYRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToYRowSSSE3(byte* src_rgb24, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToYJRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToYJRowSSSE3(byte* src_rgb24, byte* dst_yj, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToYRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToYRowSSSE3(byte* src_raw, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToYJRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToYJRowSSSE3(byte* src_raw, byte* dst_yj, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToYJRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToYJRowAVX2(byte* src_rgb24, byte* dst_yj, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToYJRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToYJRowAVX2(byte* src_raw, byte* dst_yj, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToYRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToYRowNEON(byte* src_argb, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToYJRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToYJRowNEON(byte* src_argb, byte* dst_yj, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToYJRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToYJRowNEON(byte* src_abgr, byte* dst_yj, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToYJRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToYJRowNEON(byte* src_rgba, byte* dst_yj, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToYRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToYRowRVV(byte* src_argb, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToYJRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToYJRowRVV(byte* src_argb, byte* dst_yj, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToYJRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToYJRowRVV(byte* src_rgba, byte* dst_yj, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToYJRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToYJRowRVV(byte* src_rgba, byte* dst_yj, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToYRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToYRowMSA(byte* src_argb0, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToYJRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToYJRowMSA(byte* src_argb0, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToYRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToYRowLSX(byte* src_argb0, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToYRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToYRowLASX(byte* src_argb0, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToYJRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToYJRowLSX(byte* src_argb0, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToYJRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToYJRowLSX(byte* src_abgr, byte* dst_yj, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToYJRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToYJRowLSX(byte* src_rgba, byte* dst_yj, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToYJRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToYJRowLASX(byte* src_argb0, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToYJRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToYJRowLASX(byte* src_abgr, byte* dst_yj, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToYJRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToYJRowLASX(byte* src_rgba, byte* dst_yj, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUV444Row_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUV444RowNEON(byte* src_argb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUVRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUVRowNEON(byte* src_argb, int src_stride_argb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUV444Row_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUV444RowMSA(byte* src_argb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUVRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUVRowMSA(byte* src_argb, int src_stride_argb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUVRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUVRowLSX(byte* src_argb, int src_stride_argb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUVRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUVRowLASX(byte* src_argb, int src_stride_argb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUV444Row_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUV444RowLSX(byte* src_argb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUV444Row_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUV444RowLASX(byte* src_argb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUVJRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUVJRowNEON(byte* src_argb, int src_stride_argb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToUVJRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToUVJRowNEON(byte* src_abgr, int src_stride_abgr, byte* dst_uj, byte* dst_vj, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "BGRAToUVRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void BGRAToUVRowNEON(byte* src_bgra, int src_stride_bgra, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToUVRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToUVRowNEON(byte* src_abgr, int src_stride_abgr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToUVRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToUVRowNEON(byte* src_rgba, int src_stride_rgba, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToUVRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToUVRowNEON(byte* src_rgb24, int src_stride_rgb24, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToUVRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToUVRowNEON(byte* src_raw, int src_stride_raw, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToUVJRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToUVJRowNEON(byte* src_rgb24, int src_stride_rgb24, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToUVJRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToUVJRowNEON(byte* src_raw, int src_stride_raw, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB565ToUVRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB565ToUVRowNEON(byte* src_rgb565, int src_stride_rgb565, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB1555ToUVRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB1555ToUVRowNEON(byte* src_argb1555, int src_stride_argb1555, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB4444ToUVRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB4444ToUVRowNEON(byte* src_argb4444, int src_stride_argb4444, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUVJRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUVJRowMSA(byte* src_rgb, int src_stride_rgb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToUVJRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToUVJRowMSA(byte* src_rgb, int src_stride_rgb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "BGRAToUVRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void BGRAToUVRowMSA(byte* src_rgb, int src_stride_rgb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToUVRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToUVRowMSA(byte* src_rgb, int src_stride_rgb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToUVRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToUVRowMSA(byte* src_rgb, int src_stride_rgb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToUVRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToUVRowMSA(byte* src_rgb, int src_stride_rgb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToUVRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToUVRowMSA(byte* src_rgb, int src_stride_rgb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB565ToUVRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB565ToUVRowMSA(byte* src_rgb565, int src_stride_rgb565, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB1555ToUVRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB1555ToUVRowMSA(byte* src_argb1555, int src_stride_argb1555, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "BGRAToUVRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void BGRAToUVRowLSX(byte* src_bgra, int src_stride_bgra, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToUVRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToUVRowLSX(byte* src_abgr, int src_stride_abgr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToUVRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToUVRowLSX(byte* src_rgba, int src_stride_rgba, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUVJRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUVJRowLSX(byte* src_argb, int src_stride_argb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUVJRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUVJRowLASX(byte* src_argb, int src_stride_argb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB1555ToUVRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB1555ToUVRowLSX(byte* src_argb1555, int src_stride_argb1555, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB1555ToUVRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB1555ToUVRowLASX(byte* src_argb1555, int src_stride_argb1555, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB565ToUVRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB565ToUVRowLSX(byte* src_rgb565, int src_stride_rgb565, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB565ToUVRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB565ToUVRowLASX(byte* src_rgb565, int src_stride_rgb565, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToUVRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToUVRowLSX(byte* src_rgb24, int src_stride_rgb24, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToUVRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToUVRowLASX(byte* src_rgb24, int src_stride_rgb24, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToUVRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToUVRowLSX(byte* src_raw, int src_stride_raw, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToUVRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToUVRowLASX(byte* src_raw, int src_stride_raw, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "BGRAToYRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void BGRAToYRowNEON(byte* src_bgra, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToYRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToYRowNEON(byte* src_abgr, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToYRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToYRowNEON(byte* src_rgba, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToYRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToYRowNEON(byte* src_rgb24, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToYJRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToYJRowNEON(byte* src_rgb24, byte* dst_yj, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToYRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToYRowNEON(byte* src_raw, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToYJRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToYJRowNEON(byte* src_raw, byte* dst_yj, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB565ToYRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB565ToYRowNEON(byte* src_rgb565, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB1555ToYRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB1555ToYRowNEON(byte* src_argb1555, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB4444ToYRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB4444ToYRowNEON(byte* src_argb4444, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "BGRAToYRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void BGRAToYRowRVV(byte* src_bgra, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToYRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToYRowRVV(byte* src_abgr, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToYRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToYRowRVV(byte* src_rgba, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToYRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToYRowRVV(byte* src_rgb24, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToYJRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToYJRowRVV(byte* src_rgb24, byte* dst_yj, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToYRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToYRowRVV(byte* src_raw, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToYJRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToYJRowRVV(byte* src_raw, byte* dst_yj, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "BGRAToYRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void BGRAToYRowMSA(byte* src_argb, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToYRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToYRowMSA(byte* src_argb, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToYRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToYRowMSA(byte* src_argb, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToYRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToYRowMSA(byte* src_argb, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToYRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToYRowMSA(byte* src_argb, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB565ToYRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB565ToYRowMSA(byte* src_rgb565, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB1555ToYRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB1555ToYRowMSA(byte* src_argb1555, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "BGRAToYRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void BGRAToYRowLSX(byte* src_bgra, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToYRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToYRowLSX(byte* src_abgr, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToYRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToYRowLSX(byte* src_rgba, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB1555ToYRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB1555ToYRowLSX(byte* src_argb1555, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToYJRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToYJRowLSX(byte* src_rgb24, byte* dst_yj, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToYRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToYRowLASX(byte* src_abgr, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB1555ToYRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB1555ToYRowLASX(byte* src_argb1555, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB565ToYRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB565ToYRowLSX(byte* src_rgb565, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB565ToYRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB565ToYRowLASX(byte* src_rgb565, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToYRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToYRowLSX(byte* src_rgb24, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToYRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToYRowLASX(byte* src_rgb24, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToYRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToYRowLSX(byte* src_raw, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToYRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToYRowLASX(byte* src_raw, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToYRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToYRowLASX(byte* src_rgba, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "BGRAToYRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void BGRAToYRowLASX(byte* src_bgra, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToYJRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToYJRowLASX(byte* src_rgb24, byte* dst_yj, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToYJRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToYJRowLSX(byte* src_raw, byte* dst_yj, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToYJRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToYJRowLASX(byte* src_raw, byte* dst_yj, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToYRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToYRowC(byte* src_rgb, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToYJRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToYJRowC(byte* src_rgb, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToYJRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToYJRowC(byte* src_rgb, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToYJRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToYJRowC(byte* src_rgb, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "BGRAToYRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void BGRAToYRowC(byte* src_rgb, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToYRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToYRowC(byte* src_rgb, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToYRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToYRowC(byte* src_rgb, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToYRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToYRowC(byte* src_rgb, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToYJRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToYJRowC(byte* src_rgb, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToYRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToYRowC(byte* src_rgb, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToYJRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToYJRowC(byte* src_rgb, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB565ToYRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB565ToYRowC(byte* src_rgb565, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB1555ToYRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB1555ToYRowC(byte* src_argb1555, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB4444ToYRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB4444ToYRowC(byte* src_argb4444, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToYRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToYRowAnySSSE3(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToYJRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToYJRowAnySSSE3(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToYJRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToYJRowAnySSSE3(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToYJRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToYJRowAnySSSE3(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "BGRAToYRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void BGRAToYRowAnySSSE3(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToYRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToYRowAnySSSE3(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToYRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToYRowAnySSSE3(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToYRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToYRowAnySSSE3(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToYJRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToYJRowAnySSSE3(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToYRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToYRowAnySSSE3(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToYJRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToYJRowAnySSSE3(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToYJRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToYJRowAnyAVX2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToYJRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToYJRowAnyAVX2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToYRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToYRowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToYJRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToYJRowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToYJRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToYJRowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToYJRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToYJRowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "BGRAToYRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void BGRAToYRowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToYRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToYRowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToYRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToYRowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToYRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToYRowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToYJRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToYJRowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToYRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToYRowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToYJRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToYJRowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB565ToYRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB565ToYRowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB1555ToYRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB1555ToYRowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB4444ToYRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB4444ToYRowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "BGRAToYRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void BGRAToYRowAnyMSA(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToYRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToYRowAnyMSA(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToYRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToYRowAnyMSA(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToYJRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToYJRowAnyMSA(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToYRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToYRowAnyMSA(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToYRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToYRowAnyMSA(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToYRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToYRowAnyMSA(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB565ToYRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB565ToYRowAnyMSA(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB1555ToYRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB1555ToYRowAnyMSA(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "BGRAToYRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void BGRAToYRowAnyLSX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToYRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToYRowAnyLSX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToYRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToYRowAnyLSX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToYRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToYRowAnyLSX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToYJRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToYJRowAnyLSX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToYRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToYRowAnyLSX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB565ToYRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB565ToYRowAnyLSX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToYJRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToYJRowAnyLSX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToYRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToYRowAnyLSX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToYJRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToYJRowAnyLSX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToYJRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToYJRowAnyLSX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToYJRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToYJRowAnyLSX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB1555ToYRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB1555ToYRowAnyLSX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB565ToYRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB565ToYRowAnyLASX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToYRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToYRowAnyLASX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToYJRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToYJRowAnyLASX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToYRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToYRowAnyLASX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToYRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToYRowAnyLASX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToYJRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToYJRowAnyLASX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToYRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToYRowAnyLASX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToYRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToYRowAnyLASX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToYJRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToYJRowAnyLASX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "BGRAToYRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void BGRAToYRowAnyLASX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToYJRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToYJRowAnyLASX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToYJRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToYJRowAnyLASX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB1555ToYRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB1555ToYRowAnyLASX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUVRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUVRowAVX2(byte* src_argb, int src_stride_argb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToUVRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToUVRowAVX2(byte* src_abgr, int src_stride_abgr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUVJRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUVJRowAVX2(byte* src_argb, int src_stride_argb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToUVJRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToUVJRowAVX2(byte* src_abgr, int src_stride_abgr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUVRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUVRowSSSE3(byte* src_argb, int src_stride_argb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUVJRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUVJRowSSSE3(byte* src_argb, int src_stride_argb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToUVJRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToUVJRowSSSE3(byte* src_abgr, int src_stride_abgr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "BGRAToUVRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void BGRAToUVRowSSSE3(byte* src_bgra, int src_stride_bgra, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToUVRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToUVRowSSSE3(byte* src_abgr, int src_stride_abgr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToUVRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToUVRowSSSE3(byte* src_rgba, int src_stride_rgba, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUVRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUVRowAnyAVX2(byte* src_ptr, int src_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToUVRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToUVRowAnyAVX2(byte* src_ptr, int src_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUVJRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUVJRowAnyAVX2(byte* src_ptr, int src_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToUVJRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToUVJRowAnyAVX2(byte* src_ptr, int src_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUVRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUVRowAnySSSE3(byte* src_ptr, int src_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUVJRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUVJRowAnySSSE3(byte* src_ptr, int src_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToUVJRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToUVJRowAnySSSE3(byte* src_ptr, int src_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "BGRAToUVRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void BGRAToUVRowAnySSSE3(byte* src_ptr, int src_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToUVRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToUVRowAnySSSE3(byte* src_ptr, int src_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToUVRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToUVRowAnySSSE3(byte* src_ptr, int src_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUV444Row_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUV444RowAnyNEON(byte* src_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUVRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUVRowAnyNEON(byte* src_ptr, int src_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUV444Row_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUV444RowAnyMSA(byte* src_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUVRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUVRowAnyMSA(byte* src_ptr, int src_stride_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUVRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUVRowAnyLSX(byte* src_ptr, int src_stride_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUVRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUVRowAnyLASX(byte* src_ptr, int src_stride_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUV444Row_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUV444RowAnyLSX(byte* src_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUV444Row_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUV444RowAnyLASX(byte* src_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUVJRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUVJRowAnyNEON(byte* src_ptr, int src_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToUVJRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToUVJRowAnyNEON(byte* src_ptr, int src_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "BGRAToUVRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void BGRAToUVRowAnyNEON(byte* src_ptr, int src_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToUVRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToUVRowAnyNEON(byte* src_ptr, int src_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToUVRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToUVRowAnyNEON(byte* src_ptr, int src_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToUVRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToUVRowAnyNEON(byte* src_ptr, int src_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToUVRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToUVRowAnyNEON(byte* src_ptr, int src_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToUVJRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToUVJRowAnyNEON(byte* src_ptr, int src_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToUVJRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToUVJRowAnyNEON(byte* src_ptr, int src_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB565ToUVRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB565ToUVRowAnyNEON(byte* src_ptr, int src_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB1555ToUVRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB1555ToUVRowAnyNEON(byte* src_ptr, int src_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB4444ToUVRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB4444ToUVRowAnyNEON(byte* src_ptr, int src_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUVJRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUVJRowAnyMSA(byte* src_ptr, int src_stride_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "BGRAToUVRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void BGRAToUVRowAnyMSA(byte* src_ptr, int src_stride_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToUVRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToUVRowAnyMSA(byte* src_ptr, int src_stride_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToUVRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToUVRowAnyMSA(byte* src_ptr, int src_stride_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToUVRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToUVRowAnyMSA(byte* src_ptr, int src_stride_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToUVRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToUVRowAnyMSA(byte* src_ptr, int src_stride_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB565ToUVRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB565ToUVRowAnyMSA(byte* src_ptr, int src_stride_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB1555ToUVRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB1555ToUVRowAnyMSA(byte* src_ptr, int src_stride_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToUVRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToUVRowAnyLSX(byte* src_ptr, int src_stride_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "BGRAToUVRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void BGRAToUVRowAnyLSX(byte* src_ptr, int src_stride_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToUVRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToUVRowAnyLSX(byte* src_ptr, int src_stride_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUVJRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUVJRowAnyLSX(byte* src_ptr, int src_stride_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUVJRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUVJRowAnyLASX(byte* src_ptr, int src_stride_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB1555ToUVRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB1555ToUVRowAnyLSX(byte* src_ptr, int src_stride_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB1555ToUVRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB1555ToUVRowAnyLASX(byte* src_ptr, int src_stride_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB565ToUVRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB565ToUVRowAnyLSX(byte* src_ptr, int src_stride_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB565ToUVRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB565ToUVRowAnyLASX(byte* src_ptr, int src_stride_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToUVRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToUVRowAnyLSX(byte* src_ptr, int src_stride_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToUVRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToUVRowAnyLASX(byte* src_ptr, int src_stride_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToUVRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToUVRowAnyLSX(byte* src_ptr, int src_stride_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToUVRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToUVRowAnyLASX(byte* src_ptr, int src_stride_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUVRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUVRowC(byte* src_rgb, int src_stride_rgb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUVJRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUVJRowC(byte* src_rgb, int src_stride_rgb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToUVJRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToUVJRowC(byte* src_rgb, int src_stride_rgb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "BGRAToUVRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void BGRAToUVRowC(byte* src_rgb, int src_stride_rgb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToUVRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToUVRowC(byte* src_rgb, int src_stride_rgb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToUVRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToUVRowC(byte* src_rgb, int src_stride_rgb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToUVJRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToUVJRowC(byte* src_rgb, int src_stride_rgb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToUVRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToUVRowC(byte* src_rgb, int src_stride_rgb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToUVRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToUVRowC(byte* src_rgb, int src_stride_rgb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToUVJRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToUVJRowC(byte* src_rgb, int src_stride_rgb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToUVJRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToUVJRowC(byte* src_rgb, int src_stride_rgb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB565ToUVRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB565ToUVRowC(byte* src_rgb565, int src_stride_rgb565, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB1555ToUVRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB1555ToUVRowC(byte* src_argb1555, int src_stride_argb1555, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB4444ToUVRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB4444ToUVRowC(byte* src_argb4444, int src_stride_argb4444, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUV444Row_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUV444RowSSSE3(byte* src_argb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUV444Row_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUV444RowAnySSSE3(byte* src_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToUV444Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToUV444RowC(byte* src_argb, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MirrorRowAVX2(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MirrorRowSSSE3(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MirrorRowNEON(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MirrorRowMSA(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MirrorRowLSX(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MirrorRowLASX(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MirrorRowC(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MirrorRowAnyAVX2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MirrorRowAnySSSE3(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MirrorRowAnySSE2(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MirrorRowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MirrorRowAnyMSA(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MirrorRowAnyLSX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MirrorRowAnyLASX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorUVRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MirrorUVRowAVX2(byte* src_uv, byte* dst_uv, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorUVRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MirrorUVRowSSSE3(byte* src_uv, byte* dst_uv, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorUVRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MirrorUVRowNEON(byte* src_uv, byte* dst_uv, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorUVRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MirrorUVRowMSA(byte* src_uv, byte* dst_uv, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorUVRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MirrorUVRowLSX(byte* src_uv, byte* dst_uv, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorUVRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MirrorUVRowLASX(byte* src_uv, byte* dst_uv, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorUVRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MirrorUVRowC(byte* src_uv, byte* dst_uv, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorUVRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MirrorUVRowAnyAVX2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorUVRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MirrorUVRowAnySSSE3(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorUVRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MirrorUVRowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorUVRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MirrorUVRowAnyMSA(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorUVRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MirrorUVRowAnyLSX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorUVRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MirrorUVRowAnyLASX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorSplitUVRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MirrorSplitUVRowSSSE3(byte* src, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorSplitUVRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MirrorSplitUVRowNEON(byte* src_uv, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorSplitUVRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MirrorSplitUVRowMSA(byte* src_uv, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorSplitUVRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MirrorSplitUVRowLSX(byte* src_uv, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorSplitUVRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MirrorSplitUVRowC(byte* src_uv, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MirrorRow_16_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MirrorRow16C(ushort* src, ushort* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBMirrorRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBMirrorRowAVX2(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBMirrorRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBMirrorRowSSE2(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBMirrorRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBMirrorRowNEON(byte* src_argb, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBMirrorRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBMirrorRowMSA(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBMirrorRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBMirrorRowLSX(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBMirrorRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBMirrorRowLASX(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBMirrorRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBMirrorRowC(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBMirrorRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBMirrorRowAnyAVX2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBMirrorRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBMirrorRowAnySSE2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBMirrorRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBMirrorRowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBMirrorRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBMirrorRowAnyMSA(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBMirrorRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBMirrorRowAnyLSX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBMirrorRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBMirrorRowAnyLASX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24MirrorRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24MirrorRowSSSE3(byte* src_rgb24, byte* dst_rgb24, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24MirrorRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24MirrorRowNEON(byte* src_rgb24, byte* dst_rgb24, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24MirrorRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24MirrorRowC(byte* src_rgb24, byte* dst_rgb24, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24MirrorRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24MirrorRowAnySSSE3(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24MirrorRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24MirrorRowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitUVRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitUVRowC(byte* src_uv, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitUVRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitUVRowSSE2(byte* src_uv, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitUVRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitUVRowAVX2(byte* src_uv, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitUVRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitUVRowNEON(byte* src_uv, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitUVRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitUVRowMSA(byte* src_uv, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitUVRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitUVRowLSX(byte* src_uv, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitUVRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitUVRowRVV(byte* src_uv, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitUVRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitUVRowAnySSE2(byte* src_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitUVRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitUVRowAnyAVX2(byte* src_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitUVRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitUVRowAnyNEON(byte* src_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitUVRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitUVRowAnyMSA(byte* src_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitUVRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitUVRowAnyLSX(byte* src_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "DetileRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void DetileRowC(byte* src, long src_tile_stride, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "DetileRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void DetileRowNEON(byte* src, long src_tile_stride, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "DetileRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void DetileRowAnyNEON(byte* src, long src_tile_stride, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "DetileRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void DetileRowSSE2(byte* src, long src_tile_stride, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "DetileRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void DetileRowAnySSE2(byte* src, long src_tile_stride, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "DetileRow_AVX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void DetileRowAVX(byte* src, long src_tile_stride, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "DetileRow_Any_AVX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void DetileRowAnyAVX(byte* src, long src_tile_stride, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "DetileRow_16_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void DetileRow16C(ushort* src, long src_tile_stride, ushort* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "DetileRow_16_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void DetileRow16NEON(ushort* src, long src_tile_stride, ushort* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "DetileRow_16_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void DetileRow16AnyNEON(ushort* src, long src_tile_stride, ushort* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "DetileRow_16_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void DetileRow16SSE2(ushort* src, long src_tile_stride, ushort* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "DetileRow_16_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void DetileRow16AnySSE2(ushort* src, long src_tile_stride, ushort* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "DetileRow_16_AVX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void DetileRow16AVX(ushort* src, long src_tile_stride, ushort* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "DetileRow_16_Any_AVX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void DetileRow16AnyAVX(ushort* src, long src_tile_stride, ushort* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "DetileSplitUVRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void DetileSplitUVRowC(byte* src_uv, long src_tile_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "DetileSplitUVRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void DetileSplitUVRowSSSE3(byte* src_uv, long src_tile_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "DetileSplitUVRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void DetileSplitUVRowAnySSSE3(byte* src_uv, long src_tile_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "DetileSplitUVRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void DetileSplitUVRowNEON(byte* src_uv, long src_tile_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "DetileSplitUVRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void DetileSplitUVRowAnyNEON(byte* src_uv, long src_tile_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "DetileToYUY2_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void DetileToYUY2C(byte* src_y, long src_y_tile_stride, byte* src_uv, long src_uv_tile_stride, byte* dst_yuy2, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "DetileToYUY2_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void DetileToYUY2SSE2(byte* src_y, long src_y_tile_stride, byte* src_uv, long src_uv_tile_stride, byte* dst_yuy2, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "DetileToYUY2_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void DetileToYUY2AnySSE2(byte* src_y, long src_y_tile_stride, byte* src_uv, long src_uv_tile_stride, byte* dst_yuy2, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "DetileToYUY2_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void DetileToYUY2NEON(byte* src_y, long src_y_tile_stride, byte* src_uv, long src_uv_tile_stride, byte* dst_yuy2, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "DetileToYUY2_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void DetileToYUY2AnyNEON(byte* src_y, long src_y_tile_stride, byte* src_uv, long src_uv_tile_stride, byte* dst_yuy2, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UnpackMT2T_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UnpackMT2T_C(byte* src, ushort* dst, ulong size);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UnpackMT2T_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UnpackMT2T_NEON(byte* src, ushort* dst, ulong size);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeUVRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeUVRowC(byte* src_u, byte* src_v, byte* dst_uv, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeUVRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeUVRowSSE2(byte* src_u, byte* src_v, byte* dst_uv, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeUVRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeUVRowAVX2(byte* src_u, byte* src_v, byte* dst_uv, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeUVRow_AVX512BW", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeUVRowAVX512BW(byte* src_u, byte* src_v, byte* dst_uv, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeUVRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeUVRowNEON(byte* src_u, byte* src_v, byte* dst_uv, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeUVRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeUVRowMSA(byte* src_u, byte* src_v, byte* dst_uv, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeUVRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeUVRowLSX(byte* src_u, byte* src_v, byte* dst_uv, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeUVRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeUVRowRVV(byte* src_u, byte* src_v, byte* dst_uv, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeUVRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeUVRowAnySSE2(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeUVRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeUVRowAnyAVX2(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeUVRow_Any_AVX512BW", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeUVRowAnyAVX512BW(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeUVRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeUVRowAnyNEON(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeUVRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeUVRowAnyMSA(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeUVRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeUVRowAnyLSX(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "HalfMergeUVRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void HalfMergeUVRowC(byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_uv, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "HalfMergeUVRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void HalfMergeUVRowNEON(byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_uv, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "HalfMergeUVRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void HalfMergeUVRowSSSE3(byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_uv, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "HalfMergeUVRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void HalfMergeUVRowAVX2(byte* src_u, int src_stride_u, byte* src_v, int src_stride_v, byte* dst_uv, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitRGBRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitRGBRowC(byte* src_rgb, byte* dst_r, byte* dst_g, byte* dst_b, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitRGBRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitRGBRowSSSE3(byte* src_rgb, byte* dst_r, byte* dst_g, byte* dst_b, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitRGBRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitRGBRowNEON(byte* src_rgb, byte* dst_r, byte* dst_g, byte* dst_b, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitRGBRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitRGBRowRVV(byte* src_rgb, byte* dst_r, byte* dst_g, byte* dst_b, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitRGBRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitRGBRowAnySSSE3(byte* src_ptr, byte* dst_r, byte* dst_g, byte* dst_b, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitRGBRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitRGBRowAnyNEON(byte* src_ptr, byte* dst_r, byte* dst_g, byte* dst_b, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeRGBRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeRGBRowC(byte* src_r, byte* src_g, byte* src_b, byte* dst_rgb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeRGBRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeRGBRowSSSE3(byte* src_r, byte* src_g, byte* src_b, byte* dst_rgb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeRGBRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeRGBRowNEON(byte* src_r, byte* src_g, byte* src_b, byte* dst_rgb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeRGBRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeRGBRowRVV(byte* src_r, byte* src_g, byte* src_b, byte* dst_rgb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeRGBRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeRGBRowAnySSSE3(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeRGBRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeRGBRowAnyNEON(byte* src_r, byte* src_g, byte* src_b, byte* dst_rgb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeARGBRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeARGBRowC(byte* src_r, byte* src_g, byte* src_b, byte* src_a, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeARGBRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeARGBRowSSE2(byte* src_r, byte* src_g, byte* src_b, byte* src_a, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeARGBRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeARGBRowAVX2(byte* src_r, byte* src_g, byte* src_b, byte* src_a, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeARGBRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeARGBRowNEON(byte* src_r, byte* src_g, byte* src_b, byte* src_a, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeARGBRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeARGBRowRVV(byte* src_r, byte* src_g, byte* src_b, byte* src_a, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeARGBRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeARGBRowAnySSE2(byte* y_buf, byte* u_buf, byte* v_buf, byte* a_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeARGBRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeARGBRowAnyAVX2(byte* y_buf, byte* u_buf, byte* v_buf, byte* a_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeARGBRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeARGBRowAnyNEON(byte* y_buf, byte* u_buf, byte* v_buf, byte* a_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitARGBRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitARGBRowC(byte* src_argb, byte* dst_r, byte* dst_g, byte* dst_b, byte* dst_a, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitARGBRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitARGBRowSSE2(byte* src_argb, byte* dst_r, byte* dst_g, byte* dst_b, byte* dst_a, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitARGBRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitARGBRowSSSE3(byte* src_argb, byte* dst_r, byte* dst_g, byte* dst_b, byte* dst_a, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitARGBRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitARGBRowAVX2(byte* src_argb, byte* dst_r, byte* dst_g, byte* dst_b, byte* dst_a, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitARGBRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitARGBRowNEON(byte* src_rgba, byte* dst_r, byte* dst_g, byte* dst_b, byte* dst_a, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitARGBRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitARGBRowRVV(byte* src_rgba, byte* dst_r, byte* dst_g, byte* dst_b, byte* dst_a, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitARGBRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitARGBRowAnySSE2(byte* src_ptr, byte* dst_r, byte* dst_g, byte* dst_b, byte* dst_a, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitARGBRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitARGBRowAnySSSE3(byte* src_ptr, byte* dst_r, byte* dst_g, byte* dst_b, byte* dst_a, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitARGBRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitARGBRowAnyAVX2(byte* src_ptr, byte* dst_r, byte* dst_g, byte* dst_b, byte* dst_a, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitARGBRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitARGBRowAnyNEON(byte* src_ptr, byte* dst_r, byte* dst_g, byte* dst_b, byte* dst_a, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeXRGBRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeXRGBRowC(byte* src_r, byte* src_g, byte* src_b, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeXRGBRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeXRGBRowSSE2(byte* src_r, byte* src_g, byte* src_b, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeXRGBRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeXRGBRowAVX2(byte* src_r, byte* src_g, byte* src_b, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeXRGBRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeXRGBRowNEON(byte* src_r, byte* src_g, byte* src_b, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeXRGBRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeXRGBRowRVV(byte* src_r, byte* src_g, byte* src_b, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeXRGBRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeXRGBRowAnySSE2(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeXRGBRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeXRGBRowAnyAVX2(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeXRGBRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeXRGBRowAnyNEON(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitXRGBRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitXRGBRowC(byte* src_argb, byte* dst_r, byte* dst_g, byte* dst_b, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitXRGBRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitXRGBRowSSE2(byte* src_argb, byte* dst_r, byte* dst_g, byte* dst_b, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitXRGBRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitXRGBRowSSSE3(byte* src_argb, byte* dst_r, byte* dst_g, byte* dst_b, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitXRGBRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitXRGBRowAVX2(byte* src_argb, byte* dst_r, byte* dst_g, byte* dst_b, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitXRGBRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitXRGBRowNEON(byte* src_rgba, byte* dst_r, byte* dst_g, byte* dst_b, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitXRGBRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitXRGBRowRVV(byte* src_rgba, byte* dst_r, byte* dst_g, byte* dst_b, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitXRGBRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitXRGBRowAnySSE2(byte* src_ptr, byte* dst_r, byte* dst_g, byte* dst_b, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitXRGBRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitXRGBRowAnySSSE3(byte* src_ptr, byte* dst_r, byte* dst_g, byte* dst_b, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitXRGBRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitXRGBRowAnyAVX2(byte* src_ptr, byte* dst_r, byte* dst_g, byte* dst_b, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitXRGBRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitXRGBRowAnyNEON(byte* src_ptr, byte* dst_r, byte* dst_g, byte* dst_b, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeXR30Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeXR30RowC(ushort* src_r, ushort* src_g, ushort* src_b, byte* dst_ar30, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeAR64Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeAR64RowC(ushort* src_r, ushort* src_g, ushort* src_b, ushort* src_a, ushort* dst_ar64, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeARGB16To8Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeARGB16To8RowC(ushort* src_r, ushort* src_g, ushort* src_b, ushort* src_a, byte* dst_argb, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeXR64Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeXR64RowC(ushort* src_r, ushort* src_g, ushort* src_b, ushort* dst_ar64, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeXRGB16To8Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeXRGB16To8RowC(ushort* src_r, ushort* src_g, ushort* src_b, byte* dst_argb, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeXR30Row_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeXR30RowAVX2(ushort* src_r, ushort* src_g, ushort* src_b, byte* dst_ar30, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeAR64Row_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeAR64RowAVX2(ushort* src_r, ushort* src_g, ushort* src_b, ushort* src_a, ushort* dst_ar64, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeARGB16To8Row_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeARGB16To8RowAVX2(ushort* src_r, ushort* src_g, ushort* src_b, ushort* src_a, byte* dst_argb, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeXR64Row_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeXR64RowAVX2(ushort* src_r, ushort* src_g, ushort* src_b, ushort* dst_ar64, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeXRGB16To8Row_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeXRGB16To8RowAVX2(ushort* src_r, ushort* src_g, ushort* src_b, byte* dst_argb, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeXR30Row_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeXR30RowNEON(ushort* src_r, ushort* src_g, ushort* src_b, byte* dst_ar30, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeXR30Row_10_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeXR30Row10NEON(ushort* src_r, ushort* src_g, ushort* src_b, byte* dst_ar30, int _0, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeAR64Row_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeAR64RowNEON(ushort* src_r, ushort* src_g, ushort* src_b, ushort* src_a, ushort* dst_ar64, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeARGB16To8Row_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeARGB16To8RowNEON(ushort* src_r, ushort* src_g, ushort* src_b, ushort* src_a, byte* dst_argb, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeXR64Row_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeXR64RowNEON(ushort* src_r, ushort* src_g, ushort* src_b, ushort* dst_ar64, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeXRGB16To8Row_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeXRGB16To8RowNEON(ushort* src_r, ushort* src_g, ushort* src_b, byte* dst_argb, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeXR30Row_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeXR30RowAnyAVX2(ushort* r_buf, ushort* g_buf, ushort* b_buf, byte* dst_ptr, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeAR64Row_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeAR64RowAnyAVX2(ushort* r_buf, ushort* g_buf, ushort* b_buf, ushort* a_buf, ushort* dst_ptr, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeXR64Row_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeXR64RowAnyAVX2(ushort* r_buf, ushort* g_buf, ushort* b_buf, ushort* dst_ptr, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeARGB16To8Row_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeARGB16To8RowAnyAVX2(ushort* r_buf, ushort* g_buf, ushort* b_buf, ushort* a_buf, byte* dst_ptr, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeXRGB16To8Row_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeXRGB16To8RowAnyAVX2(ushort* r_buf, ushort* g_buf, ushort* b_buf, byte* dst_ptr, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeXR30Row_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeXR30RowAnyNEON(ushort* r_buf, ushort* g_buf, ushort* b_buf, byte* dst_ptr, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeXR30Row_10_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeXR30Row10AnyNEON(ushort* r_buf, ushort* g_buf, ushort* b_buf, byte* dst_ptr, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeAR64Row_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeAR64RowAnyNEON(ushort* r_buf, ushort* g_buf, ushort* b_buf, ushort* a_buf, ushort* dst_ptr, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeARGB16To8Row_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeARGB16To8RowAnyNEON(ushort* r_buf, ushort* g_buf, ushort* b_buf, ushort* a_buf, byte* dst_ptr, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeXR64Row_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeXR64RowAnyNEON(ushort* r_buf, ushort* g_buf, ushort* b_buf, ushort* dst_ptr, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeXRGB16To8Row_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeXRGB16To8RowAnyNEON(ushort* r_buf, ushort* g_buf, ushort* b_buf, byte* dst_ptr, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeUVRow_16_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeUVRow16C(ushort* src_u, ushort* src_v, ushort* dst_uv, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeUVRow_16_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeUVRow16AVX2(ushort* src_u, ushort* src_v, ushort* dst_uv, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeUVRow_16_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeUVRow16AnyAVX2(ushort* src_u, ushort* src_v, ushort* dst_uv, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeUVRow_16_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeUVRow16NEON(ushort* src_u, ushort* src_v, ushort* dst_uv, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MergeUVRow_16_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MergeUVRow16AnyNEON(ushort* src_u, ushort* src_v, ushort* dst_uv, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitUVRow_16_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitUVRow16C(ushort* src_uv, ushort* dst_u, ushort* dst_v, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitUVRow_16_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitUVRow16AVX2(ushort* src_uv, ushort* dst_u, ushort* dst_v, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitUVRow_16_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitUVRow16AnyAVX2(ushort* src_uv, ushort* dst_u, ushort* dst_v, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitUVRow_16_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitUVRow16NEON(ushort* src_uv, ushort* dst_u, ushort* dst_v, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SplitUVRow_16_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SplitUVRow16AnyNEON(ushort* src_uv, ushort* dst_u, ushort* dst_v, int depth, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MultiplyRow_16_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MultiplyRow16C(ushort* src_y, ushort* dst_y, int scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MultiplyRow_16_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MultiplyRow16AVX2(ushort* src_y, ushort* dst_y, int scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MultiplyRow_16_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MultiplyRow16AnyAVX2(ushort* src_ptr, ushort* dst_ptr, int scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MultiplyRow_16_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MultiplyRow16NEON(ushort* src_y, ushort* dst_y, int scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "MultiplyRow_16_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void MultiplyRow16AnyNEON(ushort* src_ptr, ushort* dst_ptr, int scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "DivideRow_16_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void DivideRow16C(ushort* src_y, ushort* dst_y, int scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "DivideRow_16_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void DivideRow16AVX2(ushort* src_y, ushort* dst_y, int scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "DivideRow_16_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void DivideRow16AnyAVX2(ushort* src_ptr, ushort* dst_ptr, int scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "DivideRow_16_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void DivideRow16NEON(ushort* src_y, ushort* dst_y, int scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "DivideRow_16_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void DivideRow16AnyNEON(ushort* src_ptr, ushort* dst_ptr, int scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "Convert8To16Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Convert8To16RowC(byte* src_y, ushort* dst_y, int scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "Convert8To16Row_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Convert8To16RowSSE2(byte* src_y, ushort* dst_y, int scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "Convert8To16Row_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Convert8To16RowAVX2(byte* src_y, ushort* dst_y, int scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "Convert8To16Row_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Convert8To16RowAnySSE2(byte* src_ptr, ushort* dst_ptr, int scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "Convert8To16Row_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Convert8To16RowAnyAVX2(byte* src_ptr, ushort* dst_ptr, int scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "Convert16To8Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Convert16To8RowC(ushort* src_y, byte* dst_y, int scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "Convert16To8Row_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Convert16To8RowSSSE3(ushort* src_y, byte* dst_y, int scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "Convert16To8Row_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Convert16To8RowAVX2(ushort* src_y, byte* dst_y, int scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "Convert16To8Row_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Convert16To8RowAnySSSE3(ushort* src_ptr, byte* dst_ptr, int scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "Convert16To8Row_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Convert16To8RowAnyAVX2(ushort* src_ptr, byte* dst_ptr, int scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "Convert16To8Row_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Convert16To8RowNEON(ushort* src_y, byte* dst_y, int scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "Convert16To8Row_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Convert16To8RowAnyNEON(ushort* src_ptr, byte* dst_ptr, int scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "CopyRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void CopyRowSSE2(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "CopyRow_AVX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void CopyRowAVX(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "CopyRow_ERMS", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void CopyRowERMS(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "CopyRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void CopyRowNEON(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "CopyRow_MIPS", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void CopyRowMIPS(byte* src, byte* dst, int count);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "CopyRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void CopyRowRVV(byte* src, byte* dst, int count);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "CopyRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void CopyRowC(byte* src, byte* dst, int count);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "CopyRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void CopyRowAnySSE2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "CopyRow_Any_AVX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void CopyRowAnyAVX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "CopyRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void CopyRowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "CopyRow_16_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void CopyRow16C(ushort* src, ushort* dst, int count);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBCopyAlphaRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBCopyAlphaRowC(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBCopyAlphaRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBCopyAlphaRowSSE2(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBCopyAlphaRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBCopyAlphaRowAVX2(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBCopyAlphaRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBCopyAlphaRowAnySSE2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBCopyAlphaRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBCopyAlphaRowAnyAVX2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBExtractAlphaRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBExtractAlphaRowC(byte* src_argb, byte* dst_a, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBExtractAlphaRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBExtractAlphaRowSSE2(byte* src_argb, byte* dst_a, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBExtractAlphaRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBExtractAlphaRowAVX2(byte* src_argb, byte* dst_a, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBExtractAlphaRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBExtractAlphaRowNEON(byte* src_argb, byte* dst_a, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBExtractAlphaRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBExtractAlphaRowMSA(byte* src_argb, byte* dst_a, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBExtractAlphaRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBExtractAlphaRowLSX(byte* src_argb, byte* dst_a, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBExtractAlphaRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBExtractAlphaRowRVV(byte* src_argb, byte* dst_a, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBExtractAlphaRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBExtractAlphaRowAnySSE2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBExtractAlphaRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBExtractAlphaRowAnyAVX2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBExtractAlphaRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBExtractAlphaRowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBExtractAlphaRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBExtractAlphaRowAnyMSA(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBExtractAlphaRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBExtractAlphaRowAnyLSX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBCopyYToAlphaRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBCopyYToAlphaRowC(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBCopyYToAlphaRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBCopyYToAlphaRowSSE2(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBCopyYToAlphaRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBCopyYToAlphaRowAVX2(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBCopyYToAlphaRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBCopyYToAlphaRowRVV(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBCopyYToAlphaRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBCopyYToAlphaRowAnySSE2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBCopyYToAlphaRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBCopyYToAlphaRowAnyAVX2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SetRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SetRowC(byte* dst, byte v8, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SetRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SetRowMSA(byte* dst, byte v8, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SetRow_X86", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SetRowX86(byte* dst, byte v8, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SetRow_ERMS", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SetRowERMS(byte* dst, byte v8, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SetRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SetRowNEON(byte* dst, byte v8, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SetRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SetRowLSX(byte* dst, byte v8, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SetRow_Any_X86", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SetRowAnyX86(byte* dst_ptr, byte v32, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SetRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SetRowAnyNEON(byte* dst_ptr, byte v32, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SetRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SetRowAnyLSX(byte* dst_ptr, byte v32, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBSetRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBSetRowC(byte* dst_argb, uint v32, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBSetRow_X86", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBSetRowX86(byte* dst_argb, uint v32, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBSetRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBSetRowNEON(byte* dst, uint v32, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBSetRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBSetRowAnyNEON(byte* dst_ptr, uint v32, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBSetRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBSetRowMSA(byte* dst_argb, uint v32, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBSetRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBSetRowAnyMSA(byte* dst_ptr, uint v32, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBSetRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBSetRowLSX(byte* dst_argb, uint v32, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBSetRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBSetRowAnyLSX(byte* dst_ptr, uint v32, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBShuffleRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBShuffleRowC(byte* src_argb, byte* dst_argb, byte* shuffler, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBShuffleRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBShuffleRowSSSE3(byte* src_argb, byte* dst_argb, byte* shuffler, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBShuffleRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBShuffleRowAVX2(byte* src_argb, byte* dst_argb, byte* shuffler, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBShuffleRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBShuffleRowNEON(byte* src_argb, byte* dst_argb, byte* shuffler, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBShuffleRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBShuffleRowMSA(byte* src_argb, byte* dst_argb, byte* shuffler, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBShuffleRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBShuffleRowLSX(byte* src_argb, byte* dst_argb, byte* shuffler, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBShuffleRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBShuffleRowLASX(byte* src_argb, byte* dst_argb, byte* shuffler, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBShuffleRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBShuffleRowAnySSSE3(byte* src_ptr, byte* dst_ptr, byte* param, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBShuffleRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBShuffleRowAnyAVX2(byte* src_ptr, byte* dst_ptr, byte* param, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBShuffleRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBShuffleRowAnyNEON(byte* src_ptr, byte* dst_ptr, byte* param, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBShuffleRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBShuffleRowAnyMSA(byte* src_ptr, byte* dst_ptr, byte* param, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBShuffleRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBShuffleRowAnyLSX(byte* src_ptr, byte* dst_ptr, byte* param, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBShuffleRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBShuffleRowAnyLASX(byte* src_ptr, byte* dst_ptr, byte* param, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToARGBRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToARGBRowSSSE3(byte* src_rgb24, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToARGBRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToARGBRowSSSE3(byte* src_raw, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToRGBARow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToRGBARowSSSE3(byte* src_raw, byte* dst_rgba, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToRGB24Row_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToRGB24RowSSSE3(byte* src_raw, byte* dst_rgb24, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB565ToARGBRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB565ToARGBRowSSE2(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB1555ToARGBRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB1555ToARGBRowSSE2(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB4444ToARGBRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB4444ToARGBRowSSE2(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB565ToARGBRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB565ToARGBRowAVX2(byte* src_rgb565, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB1555ToARGBRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB1555ToARGBRowAVX2(byte* src_argb1555, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB4444ToARGBRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB4444ToARGBRowAVX2(byte* src_argb4444, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToARGBRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToARGBRowNEON(byte* src_rgb24, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToARGBRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToARGBRowMSA(byte* src_rgb24, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToARGBRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToARGBRowLSX(byte* src_rgb24, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToARGBRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToARGBRowLASX(byte* src_rgb24, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToARGBRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToARGBRowRVV(byte* src_rgb24, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToARGBRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToARGBRowNEON(byte* src_raw, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToRGBARow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToRGBARowNEON(byte* src_raw, byte* dst_rgba, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToARGBRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToARGBRowMSA(byte* src_raw, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToARGBRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToARGBRowLSX(byte* src_raw, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToARGBRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToARGBRowLASX(byte* src_raw, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToARGBRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToARGBRowRVV(byte* src_raw, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToRGBARow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToRGBARowRVV(byte* src_raw, byte* dst_rgba, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToRGB24Row_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToRGB24RowNEON(byte* src_raw, byte* dst_rgb24, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToRGB24Row_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToRGB24RowMSA(byte* src_raw, byte* dst_rgb24, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToRGB24Row_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToRGB24RowLSX(byte* src_raw, byte* dst_rgb24, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToRGB24Row_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToRGB24RowRVV(byte* src_raw, byte* dst_rgb24, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB565ToARGBRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB565ToARGBRowNEON(byte* src_rgb565, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB565ToARGBRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB565ToARGBRowMSA(byte* src_rgb565, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB565ToARGBRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB565ToARGBRowLSX(byte* src_rgb565, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB565ToARGBRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB565ToARGBRowLASX(byte* src_rgb565, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB1555ToARGBRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB1555ToARGBRowNEON(byte* src_argb1555, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB1555ToARGBRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB1555ToARGBRowMSA(byte* src_argb1555, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB1555ToARGBRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB1555ToARGBRowLSX(byte* src_argb1555, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB1555ToARGBRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB1555ToARGBRowLASX(byte* src_argb1555, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB4444ToARGBRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB4444ToARGBRowNEON(byte* src_argb4444, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB4444ToARGBRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB4444ToARGBRowMSA(byte* src_argb4444, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB4444ToARGBRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB4444ToARGBRowLSX(byte* src_argb4444, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB4444ToARGBRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB4444ToARGBRowLASX(byte* src_argb4444, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToARGBRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToARGBRowC(byte* src_rgb24, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToARGBRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToARGBRowC(byte* src_raw, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToRGBARow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToRGBARowC(byte* src_raw, byte* dst_rgba, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToRGB24Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToRGB24RowC(byte* src_raw, byte* dst_rgb24, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB565ToARGBRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB565ToARGBRowC(byte* src_rgb565, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB1555ToARGBRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB1555ToARGBRowC(byte* src_argb1555, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB4444ToARGBRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB4444ToARGBRowC(byte* src_argb4444, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AR30ToARGBRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void AR30ToARGBRowC(byte* src_ar30, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AR30ToABGRRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void AR30ToABGRRowC(byte* src_ar30, byte* dst_abgr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToAR30Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToAR30RowC(byte* src_argb, byte* dst_ar30, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AR30ToAB30Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void AR30ToAB30RowC(byte* src_ar30, byte* dst_ab30, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToARGBRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToARGBRowAnySSSE3(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToARGBRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToARGBRowAnySSSE3(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToRGBARow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToRGBARowAnySSSE3(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToRGB24Row_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToRGB24RowAnySSSE3(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB565ToARGBRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB565ToARGBRowAnySSE2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB1555ToARGBRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB1555ToARGBRowAnySSE2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB4444ToARGBRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB4444ToARGBRowAnySSE2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB565ToARGBRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB565ToARGBRowAnyAVX2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB1555ToARGBRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB1555ToARGBRowAnyAVX2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB4444ToARGBRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB4444ToARGBRowAnyAVX2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToARGBRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToARGBRowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToARGBRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToARGBRowAnyMSA(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToARGBRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToARGBRowAnyLSX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB24ToARGBRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB24ToARGBRowAnyLASX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToARGBRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToARGBRowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToRGBARow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToRGBARowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToARGBRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToARGBRowAnyMSA(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToARGBRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToARGBRowAnyLSX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToARGBRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToARGBRowAnyLASX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToRGB24Row_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToRGB24RowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToRGB24Row_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToRGB24RowAnyMSA(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RAWToRGB24Row_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RAWToRGB24RowAnyLSX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB565ToARGBRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB565ToARGBRowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB565ToARGBRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB565ToARGBRowAnyMSA(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB565ToARGBRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB565ToARGBRowAnyLSX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGB565ToARGBRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGB565ToARGBRowAnyLASX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB1555ToARGBRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB1555ToARGBRowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB1555ToARGBRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB1555ToARGBRowAnyMSA(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB4444ToARGBRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB4444ToARGBRowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB1555ToARGBRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB1555ToARGBRowAnyLSX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB1555ToARGBRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB1555ToARGBRowAnyLASX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB4444ToARGBRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB4444ToARGBRowAnyMSA(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB4444ToARGBRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB4444ToARGBRowAnyLSX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGB4444ToARGBRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGB4444ToARGBRowAnyLASX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB24Row_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB24RowSSSE3(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRAWRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRAWRowSSSE3(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB565Row_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB565RowSSE2(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToARGB1555Row_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToARGB1555RowSSE2(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToARGB4444Row_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToARGB4444RowSSE2(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToAR30Row_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToAR30RowSSSE3(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToAR30Row_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToAR30RowSSSE3(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRAWRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRAWRowAVX2(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB24Row_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB24RowAVX2(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB24Row_AVX512VBMI", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB24RowAVX512VBMI(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB565DitherRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB565DitherRowC(byte* src_argb, byte* dst_rgb, uint dither4, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB565DitherRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB565DitherRowSSE2(byte* src, byte* dst, uint dither4, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB565DitherRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB565DitherRowAVX2(byte* src, byte* dst, uint dither4, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB565Row_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB565RowAVX2(byte* src_argb, byte* dst_rgb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToARGB1555Row_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToARGB1555RowAVX2(byte* src_argb, byte* dst_rgb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToARGB4444Row_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToARGB4444RowAVX2(byte* src_argb, byte* dst_rgb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToAR30Row_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToAR30RowAVX2(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToAR30Row_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToAR30RowAVX2(byte* src, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB24Row_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB24RowNEON(byte* src_argb, byte* dst_rgb24, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRAWRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRAWRowNEON(byte* src_argb, byte* dst_raw, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB565Row_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB565RowNEON(byte* src_argb, byte* dst_rgb565, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToARGB1555Row_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToARGB1555RowNEON(byte* src_argb, byte* dst_argb1555, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToARGB4444Row_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToARGB4444RowNEON(byte* src_argb, byte* dst_argb4444, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB565DitherRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB565DitherRowNEON(byte* src_argb, byte* dst_rgb, uint dither4, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB24Row_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB24RowMSA(byte* src_argb, byte* dst_rgb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRAWRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRAWRowMSA(byte* src_argb, byte* dst_rgb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB565Row_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB565RowMSA(byte* src_argb, byte* dst_rgb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToARGB1555Row_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToARGB1555RowMSA(byte* src_argb, byte* dst_rgb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToARGB4444Row_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToARGB4444RowMSA(byte* src_argb, byte* dst_rgb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB565DitherRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB565DitherRowMSA(byte* src_argb, byte* dst_rgb, uint dither4, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB565DitherRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB565DitherRowLSX(byte* src_argb, byte* dst_rgb, uint dither4, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB565DitherRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB565DitherRowLASX(byte* src_argb, byte* dst_rgb, uint dither4, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB24Row_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB24RowLSX(byte* src_argb, byte* dst_rgb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB24Row_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB24RowLASX(byte* src_argb, byte* dst_rgb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRAWRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRAWRowLSX(byte* src_argb, byte* dst_rgb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRAWRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRAWRowLASX(byte* src_argb, byte* dst_rgb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB565Row_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB565RowLSX(byte* src_argb, byte* dst_rgb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB565Row_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB565RowLASX(byte* src_argb, byte* dst_rgb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToARGB1555Row_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToARGB1555RowLSX(byte* src_argb, byte* dst_rgb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToARGB1555Row_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToARGB1555RowLASX(byte* src_argb, byte* dst_rgb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToARGB4444Row_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToARGB4444RowLSX(byte* src_argb, byte* dst_rgb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToARGB4444Row_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToARGB4444RowLASX(byte* src_argb, byte* dst_rgb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRAWRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRAWRowRVV(byte* src_argb, byte* dst_raw, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToABGRRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToABGRRowRVV(byte* src_argb, byte* dst_abgr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToBGRARow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToBGRARowRVV(byte* src_argb, byte* dst_rgba, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGBARow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGBARowRVV(byte* src_argb, byte* dst_rgb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB24Row_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB24RowRVV(byte* src_argb, byte* dst_rgb24, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToABGRRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToABGRRowC(byte* src_argb, byte* dst_abgr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToBGRARow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToBGRARowC(byte* src_argb, byte* dst_bgra, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGBARow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGBARowC(byte* src_argb, byte* dst_rgb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB24Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB24RowC(byte* src_argb, byte* dst_rgb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRAWRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRAWRowC(byte* src_argb, byte* dst_rgb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB565Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB565RowC(byte* src_argb, byte* dst_rgb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToARGB1555Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToARGB1555RowC(byte* src_argb, byte* dst_rgb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToARGB4444Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToARGB4444RowC(byte* src_argb, byte* dst_rgb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToAR30Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToAR30RowC(byte* src_abgr, byte* dst_ar30, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToAR64Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToAR64RowC(byte* src_argb, ushort* dst_ar64, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToAB64Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToAB64RowC(byte* src_argb, ushort* dst_ab64, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AR64ToARGBRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void AR64ToARGBRowC(ushort* src_ar64, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AB64ToARGBRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void AB64ToARGBRowC(ushort* src_ab64, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AR64ToAB64Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void AR64ToAB64RowC(ushort* src_ar64, ushort* dst_ab64, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToARGBRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToARGBRowC(byte* src_rgba, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AR64ShuffleRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void AR64ShuffleRowC(byte* src_ar64, byte* dst_ar64, byte* shuffler, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToAR64Row_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToAR64RowSSSE3(byte* src_argb, ushort* dst_ar64, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToAB64Row_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToAB64RowSSSE3(byte* src_argb, ushort* dst_ab64, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AR64ToARGBRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void AR64ToARGBRowSSSE3(ushort* src_ar64, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AB64ToARGBRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void AB64ToARGBRowSSSE3(ushort* src_ab64, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToAR64Row_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToAR64RowAVX2(byte* src_argb, ushort* dst_ar64, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToAB64Row_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToAB64RowAVX2(byte* src_argb, ushort* dst_ab64, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AR64ToARGBRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void AR64ToARGBRowAVX2(ushort* src_ar64, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AB64ToARGBRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void AB64ToARGBRowAVX2(ushort* src_ab64, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToAR64Row_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToAR64RowNEON(byte* src_argb, ushort* dst_ar64, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToAB64Row_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToAB64RowNEON(byte* src_argb, ushort* dst_ab64, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AR64ToARGBRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void AR64ToARGBRowNEON(ushort* src_ar64, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AB64ToARGBRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void AB64ToARGBRowNEON(ushort* src_ab64, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToAR64Row_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToAR64RowRVV(byte* src_argb, ushort* dst_ar64, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToAB64Row_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToAB64RowRVV(byte* src_argb, ushort* dst_ab64, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AR64ToARGBRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void AR64ToARGBRowRVV(ushort* src_ar64, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AB64ToARGBRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void AB64ToARGBRowRVV(ushort* src_ab64, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AR64ToAB64Row_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void AR64ToAB64RowRVV(ushort* src_ar64, ushort* dst_ab64, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBAToARGBRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBAToARGBRowRVV(byte* src_rgba, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToAR64Row_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToAR64RowAnySSSE3(byte* src_ptr, ushort* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToAB64Row_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToAB64RowAnySSSE3(byte* src_ptr, ushort* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AR64ToARGBRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void AR64ToARGBRowAnySSSE3(ushort* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AB64ToARGBRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void AB64ToARGBRowAnySSSE3(ushort* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToAR64Row_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToAR64RowAnyAVX2(byte* src_ptr, ushort* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToAB64Row_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToAB64RowAnyAVX2(byte* src_ptr, ushort* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AR64ToARGBRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void AR64ToARGBRowAnyAVX2(ushort* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AB64ToARGBRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void AB64ToARGBRowAnyAVX2(ushort* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToAR64Row_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToAR64RowAnyNEON(byte* src_ptr, ushort* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToAB64Row_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToAB64RowAnyNEON(byte* src_ptr, ushort* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AR64ToARGBRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void AR64ToARGBRowAnyNEON(ushort* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AB64ToARGBRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void AB64ToARGBRowAnyNEON(ushort* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "J400ToARGBRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void J400ToARGBRowSSE2(byte* src_y, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "J400ToARGBRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void J400ToARGBRowAVX2(byte* src_y, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "J400ToARGBRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void J400ToARGBRowNEON(byte* src_y, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "J400ToARGBRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void J400ToARGBRowMSA(byte* src_y, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "J400ToARGBRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void J400ToARGBRowLSX(byte* src_y, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "J400ToARGBRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void J400ToARGBRowRVV(byte* src_y, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "J400ToARGBRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void J400ToARGBRowC(byte* src_y, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "J400ToARGBRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void J400ToARGBRowAnySSE2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "J400ToARGBRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void J400ToARGBRowAnyAVX2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "J400ToARGBRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void J400ToARGBRowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "J400ToARGBRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void J400ToARGBRowAnyMSA(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "J400ToARGBRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void J400ToARGBRowAnyLSX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444ToARGBRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I444ToARGBRowC(byte* src_y, byte* src_u, byte* src_v, byte* rgb_buf, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444ToRGB24Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I444ToRGB24RowC(byte* src_y, byte* src_u, byte* src_v, byte* rgb_buf, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGBRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGBRowC(byte* src_y, byte* src_u, byte* src_v, byte* rgb_buf, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToAR30Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToAR30RowC(byte* src_y, byte* src_u, byte* src_v, byte* rgb_buf, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I210ToAR30Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I210ToAR30RowC(ushort* src_y, ushort* src_u, ushort* src_v, byte* rgb_buf, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I210ToARGBRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I210ToARGBRowC(ushort* src_y, ushort* src_u, ushort* src_v, byte* rgb_buf, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I212ToAR30Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I212ToAR30RowC(ushort* src_y, ushort* src_u, ushort* src_v, byte* rgb_buf, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I212ToARGBRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I212ToARGBRowC(ushort* src_y, ushort* src_u, ushort* src_v, byte* rgb_buf, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I410ToAR30Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I410ToAR30RowC(ushort* src_y, ushort* src_u, ushort* src_v, byte* rgb_buf, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I410ToARGBRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I410ToARGBRowC(ushort* src_y, ushort* src_u, ushort* src_v, byte* rgb_buf, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I210AlphaToARGBRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I210AlphaToARGBRowC(ushort* src_y, ushort* src_u, ushort* src_v, ushort* src_a, byte* rgb_buf, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I410AlphaToARGBRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I410AlphaToARGBRowC(ushort* src_y, ushort* src_u, ushort* src_v, ushort* src_a, byte* rgb_buf, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444AlphaToARGBRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I444AlphaToARGBRowC(byte* src_y, byte* src_u, byte* src_v, byte* src_a, byte* rgb_buf, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422AlphaToARGBRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422AlphaToARGBRowC(byte* src_y, byte* src_u, byte* src_v, byte* src_a, byte* rgb_buf, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToARGBRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToARGBRowC(byte* src_y, byte* src_uv, byte* rgb_buf, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToRGB565Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToRGB565RowC(byte* src_y, byte* src_uv, byte* dst_rgb565, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToARGBRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV21ToARGBRowC(byte* src_y, byte* src_vu, byte* rgb_buf, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToRGB24Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToRGB24RowC(byte* src_y, byte* src_uv, byte* rgb_buf, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToRGB24Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV21ToRGB24RowC(byte* src_y, byte* src_vu, byte* rgb_buf, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToYUV24Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV21ToYUV24RowC(byte* src_y, byte* src_vu, byte* dst_yuv24, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToARGBRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToARGBRowC(byte* src_yuy2, byte* rgb_buf, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToARGBRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToARGBRowC(byte* src_uyvy, byte* rgb_buf, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P210ToARGBRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void P210ToARGBRowC(ushort* src_y, ushort* src_uv, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P410ToARGBRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void P410ToARGBRowC(ushort* src_y, ushort* src_uv, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P210ToAR30Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void P210ToAR30RowC(ushort* src_y, ushort* src_uv, byte* dst_ar30, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P410ToAR30Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void P410ToAR30RowC(ushort* src_y, ushort* src_uv, byte* dst_ar30, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGBARow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGBARowC(byte* src_y, byte* src_u, byte* src_v, byte* rgb_buf, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGB24Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGB24RowC(byte* src_y, byte* src_u, byte* src_v, byte* rgb_buf, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGB4444Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGB4444RowC(byte* src_y, byte* src_u, byte* src_v, byte* dst_argb4444, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGB1555Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGB1555RowC(byte* src_y, byte* src_u, byte* src_v, byte* dst_argb1555, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGB565Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGB565RowC(byte* src_y, byte* src_u, byte* src_v, byte* dst_rgb565, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGBRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGBRowAVX2(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGBRow_AVX512BW", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGBRowAVX512BW(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGBARow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGBARowAVX2(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444ToARGBRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I444ToARGBRowSSSE3(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444ToARGBRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I444ToARGBRowAVX2(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444ToRGB24Row_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I444ToRGB24RowSSSE3(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_rgb24, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444ToRGB24Row_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I444ToRGB24RowAVX2(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_rgb24, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGBRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGBRowSSSE3(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToAR30Row_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToAR30RowSSSE3(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ar30, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I210ToAR30Row_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I210ToAR30RowSSSE3(ushort* y_buf, ushort* u_buf, ushort* v_buf, byte* dst_ar30, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I210ToARGBRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I210ToARGBRowSSSE3(ushort* y_buf, ushort* u_buf, ushort* v_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I212ToAR30Row_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I212ToAR30RowSSSE3(ushort* y_buf, ushort* u_buf, ushort* v_buf, byte* dst_ar30, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I212ToARGBRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I212ToARGBRowSSSE3(ushort* y_buf, ushort* u_buf, ushort* v_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I410ToAR30Row_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I410ToAR30RowSSSE3(ushort* y_buf, ushort* u_buf, ushort* v_buf, byte* dst_ar30, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I410ToARGBRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I410ToARGBRowSSSE3(ushort* y_buf, ushort* u_buf, ushort* v_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I210AlphaToARGBRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I210AlphaToARGBRowSSSE3(ushort* y_buf, ushort* u_buf, ushort* v_buf, ushort* a_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I410AlphaToARGBRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I410AlphaToARGBRowSSSE3(ushort* y_buf, ushort* u_buf, ushort* v_buf, ushort* a_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToAR30Row_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToAR30RowAVX2(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ar30, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I210ToARGBRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I210ToARGBRowAVX2(ushort* y_buf, ushort* u_buf, ushort* v_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I210ToAR30Row_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I210ToAR30RowAVX2(ushort* y_buf, ushort* u_buf, ushort* v_buf, byte* dst_ar30, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I212ToARGBRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I212ToARGBRowAVX2(ushort* y_buf, ushort* u_buf, ushort* v_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I212ToAR30Row_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I212ToAR30RowAVX2(ushort* y_buf, ushort* u_buf, ushort* v_buf, byte* dst_ar30, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I410ToAR30Row_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I410ToAR30RowAVX2(ushort* y_buf, ushort* u_buf, ushort* v_buf, byte* dst_ar30, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I410ToARGBRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I410ToARGBRowAVX2(ushort* y_buf, ushort* u_buf, ushort* v_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I210AlphaToARGBRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I210AlphaToARGBRowAVX2(ushort* y_buf, ushort* u_buf, ushort* v_buf, ushort* a_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I410AlphaToARGBRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I410AlphaToARGBRowAVX2(ushort* y_buf, ushort* u_buf, ushort* v_buf, ushort* a_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444AlphaToARGBRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I444AlphaToARGBRowSSSE3(byte* y_buf, byte* u_buf, byte* v_buf, byte* a_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444AlphaToARGBRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I444AlphaToARGBRowAVX2(byte* y_buf, byte* u_buf, byte* v_buf, byte* a_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422AlphaToARGBRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422AlphaToARGBRowSSSE3(byte* y_buf, byte* u_buf, byte* v_buf, byte* a_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422AlphaToARGBRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422AlphaToARGBRowAVX2(byte* y_buf, byte* u_buf, byte* v_buf, byte* a_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToARGBRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToARGBRowSSSE3(byte* y_buf, byte* uv_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToARGBRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToARGBRowAVX2(byte* y_buf, byte* uv_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToRGB24Row_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToRGB24RowSSSE3(byte* src_y, byte* src_uv, byte* dst_rgb24, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToRGB24Row_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV21ToRGB24RowSSSE3(byte* src_y, byte* src_vu, byte* dst_rgb24, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToRGB565Row_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToRGB565RowSSSE3(byte* src_y, byte* src_uv, byte* dst_rgb565, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToRGB24Row_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToRGB24RowAVX2(byte* src_y, byte* src_uv, byte* dst_rgb24, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToRGB24Row_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV21ToRGB24RowAVX2(byte* src_y, byte* src_vu, byte* dst_rgb24, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToYUV24Row_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV21ToYUV24RowSSSE3(byte* src_y, byte* src_vu, byte* dst_yuv24, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToYUV24Row_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV21ToYUV24RowAVX2(byte* src_y, byte* src_vu, byte* dst_yuv24, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToRGB565Row_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToRGB565RowAVX2(byte* src_y, byte* src_uv, byte* dst_rgb565, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToARGBRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV21ToARGBRowSSSE3(byte* y_buf, byte* vu_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToARGBRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV21ToARGBRowAVX2(byte* y_buf, byte* vu_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToARGBRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToARGBRowSSSE3(byte* yuy2_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToARGBRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToARGBRowSSSE3(byte* uyvy_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToARGBRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToARGBRowAVX2(byte* yuy2_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToARGBRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToARGBRowAVX2(byte* uyvy_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P210ToARGBRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void P210ToARGBRowSSSE3(ushort* y_buf, ushort* uv_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P410ToARGBRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void P410ToARGBRowSSSE3(ushort* y_buf, ushort* uv_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P210ToAR30Row_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void P210ToAR30RowSSSE3(ushort* y_buf, ushort* uv_buf, byte* dst_ar30, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P410ToAR30Row_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void P410ToAR30RowSSSE3(ushort* y_buf, ushort* uv_buf, byte* dst_ar30, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P210ToARGBRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void P210ToARGBRowAVX2(ushort* y_buf, ushort* uv_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P410ToARGBRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void P410ToARGBRowAVX2(ushort* y_buf, ushort* uv_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P210ToAR30Row_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void P210ToAR30RowAVX2(ushort* y_buf, ushort* uv_buf, byte* dst_ar30, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P410ToAR30Row_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void P410ToAR30RowAVX2(ushort* y_buf, ushort* uv_buf, byte* dst_ar30, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGBARow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGBARowSSSE3(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_rgba, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGB4444Row_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGB4444RowSSSE3(byte* src_y, byte* src_u, byte* src_v, byte* dst_argb4444, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGB4444Row_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGB4444RowAVX2(byte* src_y, byte* src_u, byte* src_v, byte* dst_argb4444, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGB1555Row_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGB1555RowSSSE3(byte* src_y, byte* src_u, byte* src_v, byte* dst_argb1555, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGB1555Row_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGB1555RowAVX2(byte* src_y, byte* src_u, byte* src_v, byte* dst_argb1555, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGB565Row_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGB565RowSSSE3(byte* src_y, byte* src_u, byte* src_v, byte* dst_rgb565, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGB565Row_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGB565RowAVX2(byte* src_y, byte* src_u, byte* src_v, byte* dst_rgb565, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGB24Row_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGB24RowSSSE3(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_rgb24, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGB24Row_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGB24RowAVX2(byte* src_y, byte* src_u, byte* src_v, byte* dst_rgb24, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGBRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGBRowAnyAVX2(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGBRow_Any_AVX512BW", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGBRowAnyAVX512BW(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGBARow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGBARowAnyAVX2(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444ToARGBRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I444ToARGBRowAnySSSE3(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444ToRGB24Row_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I444ToRGB24RowAnySSSE3(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444ToARGBRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I444ToARGBRowAnyAVX2(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444ToRGB24Row_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I444ToRGB24RowAnyAVX2(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGBRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGBRowAnySSSE3(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToAR30Row_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToAR30RowAnySSSE3(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I210ToAR30Row_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I210ToAR30RowAnySSSE3(ushort* y_buf, ushort* u_buf, ushort* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I210ToARGBRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I210ToARGBRowAnySSSE3(ushort* y_buf, ushort* u_buf, ushort* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I212ToAR30Row_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I212ToAR30RowAnySSSE3(ushort* y_buf, ushort* u_buf, ushort* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I212ToARGBRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I212ToARGBRowAnySSSE3(ushort* y_buf, ushort* u_buf, ushort* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I410ToAR30Row_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I410ToAR30RowAnySSSE3(ushort* y_buf, ushort* u_buf, ushort* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I410ToARGBRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I410ToARGBRowAnySSSE3(ushort* y_buf, ushort* u_buf, ushort* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I210AlphaToARGBRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I210AlphaToARGBRowAnySSSE3(ushort* y_buf, ushort* u_buf, ushort* v_buf, ushort* a_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I410AlphaToARGBRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I410AlphaToARGBRowAnySSSE3(ushort* y_buf, ushort* u_buf, ushort* v_buf, ushort* a_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToAR30Row_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToAR30RowAnyAVX2(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I210ToARGBRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I210ToARGBRowAnyAVX2(ushort* y_buf, ushort* u_buf, ushort* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I210ToAR30Row_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I210ToAR30RowAnyAVX2(ushort* y_buf, ushort* u_buf, ushort* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I212ToARGBRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I212ToARGBRowAnyAVX2(ushort* y_buf, ushort* u_buf, ushort* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I212ToAR30Row_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I212ToAR30RowAnyAVX2(ushort* y_buf, ushort* u_buf, ushort* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I410ToAR30Row_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I410ToAR30RowAnyAVX2(ushort* y_buf, ushort* u_buf, ushort* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I410ToARGBRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I410ToARGBRowAnyAVX2(ushort* y_buf, ushort* u_buf, ushort* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I210AlphaToARGBRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I210AlphaToARGBRowAnyAVX2(ushort* y_buf, ushort* u_buf, ushort* v_buf, ushort* a_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I410AlphaToARGBRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I410AlphaToARGBRowAnyAVX2(ushort* y_buf, ushort* u_buf, ushort* v_buf, ushort* a_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444AlphaToARGBRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I444AlphaToARGBRowAnySSSE3(byte* y_buf, byte* u_buf, byte* v_buf, byte* a_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444AlphaToARGBRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I444AlphaToARGBRowAnyAVX2(byte* y_buf, byte* u_buf, byte* v_buf, byte* a_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422AlphaToARGBRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422AlphaToARGBRowAnySSSE3(byte* y_buf, byte* u_buf, byte* v_buf, byte* a_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422AlphaToARGBRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422AlphaToARGBRowAnyAVX2(byte* y_buf, byte* u_buf, byte* v_buf, byte* a_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToARGBRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToARGBRowAnySSSE3(byte* y_buf, byte* uv_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToARGBRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToARGBRowAnyAVX2(byte* y_buf, byte* uv_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToARGBRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV21ToARGBRowAnySSSE3(byte* y_buf, byte* uv_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToARGBRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV21ToARGBRowAnyAVX2(byte* y_buf, byte* uv_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToRGB24Row_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToRGB24RowAnySSSE3(byte* y_buf, byte* uv_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToRGB24Row_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV21ToRGB24RowAnySSSE3(byte* y_buf, byte* uv_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToRGB24Row_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToRGB24RowAnyAVX2(byte* y_buf, byte* uv_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToRGB24Row_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV21ToRGB24RowAnyAVX2(byte* y_buf, byte* uv_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToYUV24Row_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV21ToYUV24RowAnySSSE3(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToYUV24Row_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV21ToYUV24RowAnyAVX2(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToRGB565Row_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToRGB565RowAnySSSE3(byte* y_buf, byte* uv_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToRGB565Row_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToRGB565RowAnyAVX2(byte* y_buf, byte* uv_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToARGBRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToARGBRowAnySSSE3(byte* src_ptr, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToARGBRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToARGBRowAnySSSE3(byte* src_ptr, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToARGBRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToARGBRowAnyAVX2(byte* src_ptr, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToARGBRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToARGBRowAnyAVX2(byte* src_ptr, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P210ToARGBRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void P210ToARGBRowAnySSSE3(ushort* y_buf, ushort* uv_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P410ToARGBRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void P410ToARGBRowAnySSSE3(ushort* y_buf, ushort* uv_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P210ToAR30Row_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void P210ToAR30RowAnySSSE3(ushort* y_buf, ushort* uv_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P410ToAR30Row_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void P410ToAR30RowAnySSSE3(ushort* y_buf, ushort* uv_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P210ToARGBRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void P210ToARGBRowAnyAVX2(ushort* y_buf, ushort* uv_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P410ToARGBRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void P410ToARGBRowAnyAVX2(ushort* y_buf, ushort* uv_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P210ToAR30Row_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void P210ToAR30RowAnyAVX2(ushort* y_buf, ushort* uv_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P410ToAR30Row_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void P410ToAR30RowAnyAVX2(ushort* y_buf, ushort* uv_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGBARow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGBARowAnySSSE3(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGB4444Row_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGB4444RowAnySSSE3(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGB4444Row_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGB4444RowAnyAVX2(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGB1555Row_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGB1555RowAnySSSE3(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGB1555Row_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGB1555RowAnyAVX2(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGB565Row_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGB565RowAnySSSE3(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGB565Row_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGB565RowAnyAVX2(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGB24Row_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGB24RowAnySSSE3(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGB24Row_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGB24RowAnyAVX2(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I400ToARGBRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I400ToARGBRowC(byte* src_y, byte* rgb_buf, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I400ToARGBRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I400ToARGBRowSSE2(byte* y_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I400ToARGBRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I400ToARGBRowAVX2(byte* y_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I400ToARGBRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I400ToARGBRowNEON(byte* src_y, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I400ToARGBRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I400ToARGBRowMSA(byte* src_y, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I400ToARGBRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I400ToARGBRowLSX(byte* src_y, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I400ToARGBRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I400ToARGBRowRVV(byte* src_y, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I400ToARGBRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I400ToARGBRowAnySSE2(byte* src_ptr, byte* dst_ptr, IntPtr param, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I400ToARGBRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I400ToARGBRowAnyAVX2(byte* src_ptr, byte* dst_ptr, IntPtr param, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I400ToARGBRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I400ToARGBRowAnyNEON(byte* src_ptr, byte* dst_ptr, IntPtr param, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I400ToARGBRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I400ToARGBRowAnyMSA(byte* src_ptr, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I400ToARGBRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I400ToARGBRowAnyLSX(byte* src_ptr, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBBlendRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBBlendRowSSSE3(byte* src_argb, byte* src_argb1, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBBlendRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBBlendRowNEON(byte* src_argb, byte* src_argb1, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBBlendRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBBlendRowMSA(byte* src_argb0, byte* src_argb1, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBBlendRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBBlendRowLSX(byte* src_argb0, byte* src_argb1, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBBlendRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBBlendRowRVV(byte* src_argb0, byte* src_argb1, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBBlendRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBBlendRowC(byte* src_argb, byte* src_argb1, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "BlendPlaneRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void BlendPlaneRowSSSE3(byte* src0, byte* src1, byte* alpha, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "BlendPlaneRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void BlendPlaneRowAnySSSE3(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "BlendPlaneRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void BlendPlaneRowAVX2(byte* src0, byte* src1, byte* alpha, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "BlendPlaneRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void BlendPlaneRowAnyAVX2(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "BlendPlaneRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void BlendPlaneRowRVV(byte* src0, byte* src1, byte* alpha, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "BlendPlaneRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void BlendPlaneRowC(byte* src0, byte* src1, byte* alpha, byte* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBMultiplyRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBMultiplyRowC(byte* src_argb, byte* src_argb1, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBMultiplyRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBMultiplyRowSSE2(byte* src_argb, byte* src_argb1, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBMultiplyRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBMultiplyRowAnySSE2(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBMultiplyRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBMultiplyRowAVX2(byte* src_argb, byte* src_argb1, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBMultiplyRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBMultiplyRowAnyAVX2(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBMultiplyRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBMultiplyRowNEON(byte* src_argb, byte* src_argb1, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBMultiplyRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBMultiplyRowAnyNEON(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBMultiplyRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBMultiplyRowMSA(byte* src_argb0, byte* src_argb1, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBMultiplyRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBMultiplyRowAnyMSA(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBMultiplyRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBMultiplyRowLSX(byte* src_argb0, byte* src_argb1, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBMultiplyRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBMultiplyRowLASX(byte* src_argb0, byte* src_argb1, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBMultiplyRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBMultiplyRowAnyLSX(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBMultiplyRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBMultiplyRowAnyLASX(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBAddRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBAddRowC(byte* src_argb, byte* src_argb1, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBAddRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBAddRowSSE2(byte* src_argb, byte* src_argb1, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBAddRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBAddRowAnySSE2(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBAddRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBAddRowAVX2(byte* src_argb, byte* src_argb1, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBAddRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBAddRowAnyAVX2(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBAddRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBAddRowNEON(byte* src_argb, byte* src_argb1, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBAddRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBAddRowAnyNEON(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBAddRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBAddRowMSA(byte* src_argb0, byte* src_argb1, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBAddRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBAddRowAnyMSA(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBAddRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBAddRowLSX(byte* src_argb0, byte* src_argb1, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBAddRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBAddRowLASX(byte* src_argb0, byte* src_argb1, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBAddRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBAddRowAnyLSX(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBAddRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBAddRowAnyLASX(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBSubtractRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBSubtractRowC(byte* src_argb, byte* src_argb1, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBSubtractRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBSubtractRowSSE2(byte* src_argb, byte* src_argb1, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBSubtractRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBSubtractRowAnySSE2(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBSubtractRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBSubtractRowAVX2(byte* src_argb, byte* src_argb1, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBSubtractRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBSubtractRowAnyAVX2(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBSubtractRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBSubtractRowNEON(byte* src_argb, byte* src_argb1, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBSubtractRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBSubtractRowAnyNEON(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBSubtractRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBSubtractRowMSA(byte* src_argb0, byte* src_argb1, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBSubtractRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBSubtractRowAnyMSA(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBSubtractRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBSubtractRowLSX(byte* src_argb0, byte* src_argb1, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBSubtractRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBSubtractRowLASX(byte* src_argb0, byte* src_argb1, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBSubtractRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBSubtractRowAnyLSX(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBSubtractRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBSubtractRowAnyLASX(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB24Row_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB24RowAnySSSE3(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRAWRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRAWRowAnySSSE3(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB565Row_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB565RowAnySSE2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToARGB1555Row_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToARGB1555RowAnySSE2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToARGB4444Row_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToARGB4444RowAnySSE2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToAR30Row_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToAR30RowAnySSSE3(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToAR30Row_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToAR30RowAnySSSE3(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRAWRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRAWRowAnyAVX2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB24Row_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB24RowAnyAVX2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB24Row_Any_AVX512VBMI", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB24RowAnyAVX512VBMI(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB565DitherRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB565DitherRowAnySSE2(byte* src_ptr, byte* dst_ptr, uint param, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB565DitherRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB565DitherRowAnyAVX2(byte* src_ptr, byte* dst_ptr, uint param, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB565Row_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB565RowAnyAVX2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToARGB1555Row_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToARGB1555RowAnyAVX2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToARGB4444Row_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToARGB4444RowAnyAVX2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ABGRToAR30Row_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ABGRToAR30RowAnyAVX2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToAR30Row_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToAR30RowAnyAVX2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB24Row_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB24RowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRAWRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRAWRowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB565Row_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB565RowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToARGB1555Row_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToARGB1555RowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToARGB4444Row_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToARGB4444RowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB565DitherRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB565DitherRowAnyNEON(byte* src_ptr, byte* dst_ptr, uint param, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB24Row_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB24RowAnyMSA(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRAWRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRAWRowAnyMSA(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB565Row_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB565RowAnyMSA(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToARGB1555Row_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToARGB1555RowAnyMSA(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToARGB4444Row_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToARGB4444RowAnyMSA(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB565DitherRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB565DitherRowAnyMSA(byte* src_ptr, byte* dst_ptr, uint param, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB565DitherRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB565DitherRowAnyLSX(byte* src_ptr, byte* dst_ptr, uint param, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB565DitherRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB565DitherRowAnyLASX(byte* src_ptr, byte* dst_ptr, uint param, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB24Row_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB24RowAnyLSX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB24Row_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB24RowAnyLASX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRAWRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRAWRowAnyLSX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRAWRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRAWRowAnyLASX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB565Row_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB565RowAnyLSX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToRGB565Row_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToRGB565RowAnyLASX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToARGB1555Row_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToARGB1555RowAnyLSX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToARGB1555Row_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToARGB1555RowAnyLASX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToARGB4444Row_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToARGB4444RowAnyLSX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBToARGB4444Row_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBToARGB4444RowAnyLASX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444ToARGBRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I444ToARGBRowAnyNEON(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444ToRGB24Row_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I444ToRGB24RowAnyNEON(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGBRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGBRowAnyNEON(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444AlphaToARGBRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I444AlphaToARGBRowAnyNEON(byte* y_buf, byte* u_buf, byte* v_buf, byte* a_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422AlphaToARGBRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422AlphaToARGBRowAnyNEON(byte* y_buf, byte* u_buf, byte* v_buf, byte* a_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGBARow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGBARowAnyNEON(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGB24Row_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGB24RowAnyNEON(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGB4444Row_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGB4444RowAnyNEON(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGB1555Row_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGB1555RowAnyNEON(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGB565Row_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGB565RowAnyNEON(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToARGBRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToARGBRowAnyNEON(byte* y_buf, byte* uv_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToARGBRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV21ToARGBRowAnyNEON(byte* y_buf, byte* uv_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToRGB24Row_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToRGB24RowAnyNEON(byte* y_buf, byte* uv_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToRGB24Row_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV21ToRGB24RowAnyNEON(byte* y_buf, byte* uv_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToYUV24Row_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV21ToYUV24RowAnyNEON(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToRGB565Row_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToRGB565RowAnyNEON(byte* y_buf, byte* uv_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToARGBRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToARGBRowAnyNEON(byte* src_ptr, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToARGBRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToARGBRowAnyNEON(byte* src_ptr, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P210ToARGBRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void P210ToARGBRowNEON(ushort* y_buf, ushort* uv_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P410ToARGBRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void P410ToARGBRowNEON(ushort* y_buf, ushort* uv_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P210ToAR30Row_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void P210ToAR30RowNEON(ushort* y_buf, ushort* uv_buf, byte* dst_ar30, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P410ToAR30Row_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void P410ToAR30RowNEON(ushort* y_buf, ushort* uv_buf, byte* dst_ar30, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P210ToARGBRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void P210ToARGBRowAnyNEON(ushort* y_buf, ushort* uv_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P410ToARGBRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void P410ToARGBRowAnyNEON(ushort* y_buf, ushort* uv_buf, byte* dst_argb, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P210ToAR30Row_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void P210ToAR30RowAnyNEON(ushort* y_buf, ushort* uv_buf, byte* dst_ar30, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "P410ToAR30Row_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void P410ToAR30RowAnyNEON(ushort* y_buf, ushort* uv_buf, byte* dst_ar30, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444ToARGBRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I444ToARGBRowAnyMSA(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I444ToARGBRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I444ToARGBRowAnyLSX(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGBRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGBRowAnyMSA(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGBRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGBRowAnyLSX(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGBRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGBRowAnyLASX(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGBARow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGBARowAnyMSA(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGBARow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGBARowAnyLSX(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGBARow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGBARowAnyLASX(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422AlphaToARGBRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422AlphaToARGBRowAnyMSA(byte* y_buf, byte* u_buf, byte* v_buf, byte* a_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422AlphaToARGBRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422AlphaToARGBRowAnyLSX(byte* y_buf, byte* u_buf, byte* v_buf, byte* a_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422AlphaToARGBRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422AlphaToARGBRowAnyLASX(byte* y_buf, byte* u_buf, byte* v_buf, byte* a_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGB24Row_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGB24RowAnyMSA(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGB24Row_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGB24RowAnyLSX(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGB24Row_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGB24RowAnyLASX(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGB565Row_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGB565RowAnyMSA(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGB565Row_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGB565RowAnyLSX(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToRGB565Row_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToRGB565RowAnyLASX(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGB4444Row_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGB4444RowAnyMSA(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGB4444Row_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGB4444RowAnyLSX(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGB4444Row_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGB4444RowAnyLASX(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGB1555Row_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGB1555RowAnyMSA(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGB1555Row_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGB1555RowAnyLSX(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToARGB1555Row_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToARGB1555RowAnyLASX(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToARGBRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToARGBRowAnyMSA(byte* y_buf, byte* uv_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToRGB565Row_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToRGB565RowAnyMSA(byte* y_buf, byte* uv_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToARGBRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV21ToARGBRowAnyMSA(byte* y_buf, byte* uv_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToARGBRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToARGBRowAnyMSA(byte* src_ptr, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToARGBRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToARGBRowAnyMSA(byte* src_ptr, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToARGBRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToARGBRowAnyLSX(byte* y_buf, byte* uv_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToARGBRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToARGBRowAnyLASX(byte* y_buf, byte* uv_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToRGB565Row_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToRGB565RowAnyLSX(byte* y_buf, byte* uv_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV12ToRGB565Row_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV12ToRGB565RowAnyLASX(byte* y_buf, byte* uv_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToARGBRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV21ToARGBRowAnyLSX(byte* y_buf, byte* uv_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "NV21ToARGBRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void NV21ToARGBRowAnyLASX(byte* y_buf, byte* uv_buf, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToARGBRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToARGBRowAnyLSX(byte* src_ptr, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToARGBRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToARGBRowAnyLSX(byte* src_ptr, byte* dst_ptr, IntPtr yuvconstants, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToYRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToYRowAVX2(byte* src_yuy2, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToUVRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToUVRowAVX2(byte* src_yuy2, int stride_yuy2, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToNVUVRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToNVUVRowAVX2(byte* src_yuy2, int stride_yuy2, byte* dst_uv, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToUV422Row_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToUV422RowAVX2(byte* src_yuy2, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToYRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToYRowSSE2(byte* src_yuy2, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToUVRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToUVRowSSE2(byte* src_yuy2, int stride_yuy2, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToNVUVRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToNVUVRowSSE2(byte* src_yuy2, int stride_yuy2, byte* dst_uv, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToUV422Row_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToUV422RowSSE2(byte* src_yuy2, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToYRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToYRowNEON(byte* src_yuy2, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToUVRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToUVRowNEON(byte* src_yuy2, int stride_yuy2, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToNVUVRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToNVUVRowNEON(byte* src_yuy2, int stride_yuy2, byte* dst_uv, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToUV422Row_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToUV422RowNEON(byte* src_yuy2, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToYRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToYRowMSA(byte* src_yuy2, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToYRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToYRowLSX(byte* src_yuy2, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToYRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToYRowLASX(byte* src_yuy2, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToUVRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToUVRowMSA(byte* src_yuy2, int src_stride_yuy2, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToUVRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToUVRowLSX(byte* src_yuy2, int src_stride_yuy2, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToUVRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToUVRowLASX(byte* src_yuy2, int src_stride_yuy2, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToUV422Row_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToUV422RowMSA(byte* src_yuy2, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToUV422Row_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToUV422RowLSX(byte* src_yuy2, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToUV422Row_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToUV422RowLASX(byte* src_yuy2, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToYRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToYRowC(byte* src_yuy2, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToUVRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToUVRowC(byte* src_yuy2, int src_stride_yuy2, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToNVUVRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToNVUVRowC(byte* src_yuy2, int src_stride_yuy2, byte* dst_uv, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToUV422Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToUV422RowC(byte* src_yuy2, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToYRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToYRowAnyAVX2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToUVRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToUVRowAnyAVX2(byte* src_ptr, int src_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToNVUVRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToNVUVRowAnyAVX2(byte* src_yuy2, int stride_yuy2, byte* dst_uv, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToUV422Row_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToUV422RowAnyAVX2(byte* src_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToYRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToYRowAnySSE2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToUVRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToUVRowAnySSE2(byte* src_ptr, int src_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToNVUVRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToNVUVRowAnySSE2(byte* src_yuy2, int stride_yuy2, byte* dst_uv, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToUV422Row_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToUV422RowAnySSE2(byte* src_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToYRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToYRowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToUVRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToUVRowAnyNEON(byte* src_ptr, int src_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToNVUVRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToNVUVRowAnyNEON(byte* src_yuy2, int stride_yuy2, byte* dst_uv, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToUV422Row_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToUV422RowAnyNEON(byte* src_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToYRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToYRowAnyMSA(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToYRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToYRowAnyLSX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToYRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToYRowAnyLASX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToUVRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToUVRowAnyMSA(byte* src_ptr, int src_stride_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToUVRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToUVRowAnyLSX(byte* src_ptr, int src_stride_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToUVRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToUVRowAnyLASX(byte* src_ptr, int src_stride_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToUV422Row_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToUV422RowAnyMSA(byte* src_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToUV422Row_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToUV422RowAnyLSX(byte* src_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "YUY2ToUV422Row_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void YUY2ToUV422RowAnyLASX(byte* src_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToYRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToYRowAVX2(byte* src_uyvy, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToUVRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToUVRowAVX2(byte* src_uyvy, int stride_uyvy, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToUV422Row_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToUV422RowAVX2(byte* src_uyvy, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToYRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToYRowSSE2(byte* src_uyvy, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToUVRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToUVRowSSE2(byte* src_uyvy, int stride_uyvy, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToUV422Row_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToUV422RowSSE2(byte* src_uyvy, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToYRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToYRowNEON(byte* src_uyvy, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToUVRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToUVRowNEON(byte* src_uyvy, int stride_uyvy, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToUV422Row_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToUV422RowNEON(byte* src_uyvy, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToYRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToYRowMSA(byte* src_uyvy, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToYRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToYRowLSX(byte* src_uyvy, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToYRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToYRowLASX(byte* src_uyvy, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToUVRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToUVRowMSA(byte* src_uyvy, int src_stride_uyvy, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToUVRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToUVRowLSX(byte* src_uyvy, int src_stride_uyvy, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToUVRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToUVRowLASX(byte* src_uyvy, int src_stride_uyvy, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToUV422Row_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToUV422RowMSA(byte* src_uyvy, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToUV422Row_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToUV422RowLSX(byte* src_uyvy, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToUV422Row_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToUV422RowLASX(byte* src_uyvy, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToYRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToYRowC(byte* src_uyvy, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToUVRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToUVRowC(byte* src_uyvy, int src_stride_uyvy, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToUV422Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToUV422RowC(byte* src_uyvy, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToYRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToYRowAnyAVX2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToUVRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToUVRowAnyAVX2(byte* src_ptr, int src_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToUV422Row_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToUV422RowAnyAVX2(byte* src_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToYRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToYRowAnySSE2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToUVRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToUVRowAnySSE2(byte* src_ptr, int src_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToUV422Row_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToUV422RowAnySSE2(byte* src_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToYRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToYRowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToUVRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToUVRowAnyNEON(byte* src_ptr, int src_stride, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToUV422Row_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToUV422RowAnyNEON(byte* src_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToYRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToYRowAnyMSA(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToYRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToYRowAnyLSX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToYRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToYRowAnyLASX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToUVRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToUVRowAnyMSA(byte* src_ptr, int src_stride_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToUVRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToUVRowAnyLSX(byte* src_ptr, int src_stride_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToUVRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToUVRowAnyLASX(byte* src_ptr, int src_stride_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToUV422Row_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToUV422RowAnyMSA(byte* src_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToUV422Row_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToUV422RowAnyLSX(byte* src_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "UYVYToUV422Row_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void UYVYToUV422RowAnyLASX(byte* src_ptr, byte* dst_u, byte* dst_v, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SwapUVRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SwapUVRowC(byte* src_uv, byte* dst_vu, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SwapUVRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SwapUVRowNEON(byte* src_uv, byte* dst_vu, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SwapUVRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SwapUVRowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SwapUVRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SwapUVRowSSSE3(byte* src_uv, byte* dst_vu, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SwapUVRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SwapUVRowAnySSSE3(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SwapUVRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SwapUVRowAVX2(byte* src_uv, byte* dst_vu, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SwapUVRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SwapUVRowAnyAVX2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AYUVToYRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void AYUVToYRowC(byte* src_ayuv, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AYUVToUVRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void AYUVToUVRowC(byte* src_ayuv, int src_stride_ayuv, byte* dst_uv, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AYUVToVURow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void AYUVToVURowC(byte* src_ayuv, int src_stride_ayuv, byte* dst_vu, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AYUVToYRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void AYUVToYRowNEON(byte* src_ayuv, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AYUVToUVRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void AYUVToUVRowNEON(byte* src_ayuv, int src_stride_ayuv, byte* dst_uv, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AYUVToVURow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void AYUVToVURowNEON(byte* src_ayuv, int src_stride_ayuv, byte* dst_vu, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AYUVToYRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void AYUVToYRowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AYUVToUVRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void AYUVToUVRowAnyNEON(byte* src_ptr, int src_stride, byte* dst_vu, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "AYUVToVURow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void AYUVToVURowAnyNEON(byte* src_ptr, int src_stride, byte* dst_vu, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToYUY2Row_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToYUY2RowC(byte* src_y, byte* src_u, byte* src_v, byte* dst_frame, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToUYVYRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToUYVYRowC(byte* src_y, byte* src_u, byte* src_v, byte* dst_frame, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToYUY2Row_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToYUY2RowSSE2(byte* src_y, byte* src_u, byte* src_v, byte* dst_yuy2, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToUYVYRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToUYVYRowSSE2(byte* src_y, byte* src_u, byte* src_v, byte* dst_uyvy, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToYUY2Row_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToYUY2RowAnySSE2(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToUYVYRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToUYVYRowAnySSE2(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToYUY2Row_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToYUY2RowAVX2(byte* src_y, byte* src_u, byte* src_v, byte* dst_yuy2, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToUYVYRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToUYVYRowAVX2(byte* src_y, byte* src_u, byte* src_v, byte* dst_uyvy, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToYUY2Row_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToYUY2RowAnyAVX2(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToUYVYRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToUYVYRowAnyAVX2(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToYUY2Row_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToYUY2RowNEON(byte* src_y, byte* src_u, byte* src_v, byte* dst_yuy2, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToUYVYRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToUYVYRowNEON(byte* src_y, byte* src_u, byte* src_v, byte* dst_uyvy, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToYUY2Row_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToYUY2RowAnyNEON(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToUYVYRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToUYVYRowAnyNEON(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToYUY2Row_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToYUY2RowMSA(byte* src_y, byte* src_u, byte* src_v, byte* dst_yuy2, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToYUY2Row_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToYUY2RowLSX(byte* src_y, byte* src_u, byte* src_v, byte* dst_yuy2, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToYUY2Row_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToYUY2RowLASX(byte* src_y, byte* src_u, byte* src_v, byte* dst_yuy2, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToUYVYRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToUYVYRowMSA(byte* src_y, byte* src_u, byte* src_v, byte* dst_uyvy, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToUYVYRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToUYVYRowLSX(byte* src_y, byte* src_u, byte* src_v, byte* dst_uyvy, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToUYVYRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToUYVYRowLASX(byte* src_y, byte* src_u, byte* src_v, byte* dst_uyvy, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToYUY2Row_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToYUY2RowAnyMSA(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToYUY2Row_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToYUY2RowAnyLSX(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToYUY2Row_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToYUY2RowAnyLASX(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToUYVYRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToUYVYRowAnyMSA(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToUYVYRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToUYVYRowAnyLSX(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "I422ToUYVYRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void I422ToUYVYRowAnyLASX(byte* y_buf, byte* u_buf, byte* v_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBAttenuateRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBAttenuateRowC(byte* src_argb, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBAttenuateRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBAttenuateRowSSSE3(byte* src_argb, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBAttenuateRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBAttenuateRowAVX2(byte* src_argb, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBAttenuateRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBAttenuateRowNEON(byte* src_argb, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBAttenuateRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBAttenuateRowMSA(byte* src_argb, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBAttenuateRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBAttenuateRowLSX(byte* src_argb, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBAttenuateRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBAttenuateRowLASX(byte* src_argb, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBAttenuateRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBAttenuateRowRVV(byte* src_argb, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBAttenuateRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBAttenuateRowAnySSSE3(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBAttenuateRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBAttenuateRowAnyAVX2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBAttenuateRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBAttenuateRowAnyNEON(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBAttenuateRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBAttenuateRowAnyMSA(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBAttenuateRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBAttenuateRowAnyLSX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBAttenuateRow_Any_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBAttenuateRowAnyLASX(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBUnattenuateRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBUnattenuateRowC(byte* src_argb, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBUnattenuateRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBUnattenuateRowSSE2(byte* src_argb, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBUnattenuateRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBUnattenuateRowAVX2(byte* src_argb, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBUnattenuateRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBUnattenuateRowAnySSE2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBUnattenuateRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBUnattenuateRowAnyAVX2(byte* src_ptr, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBGrayRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBGrayRowC(byte* src_argb, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBGrayRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBGrayRowSSSE3(byte* src_argb, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBGrayRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBGrayRowNEON(byte* src_argb, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBGrayRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBGrayRowMSA(byte* src_argb, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBGrayRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBGrayRowLSX(byte* src_argb, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBGrayRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBGrayRowLASX(byte* src_argb, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBSepiaRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBSepiaRowC(byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBSepiaRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBSepiaRowSSSE3(byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBSepiaRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBSepiaRowNEON(byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBSepiaRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBSepiaRowMSA(byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBSepiaRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBSepiaRowLSX(byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBSepiaRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBSepiaRowLASX(byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBColorMatrixRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBColorMatrixRowC(byte* src_argb, byte* dst_argb, sbyte* matrix_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBColorMatrixRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBColorMatrixRowSSSE3(byte* src_argb, byte* dst_argb, sbyte* matrix_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBColorMatrixRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBColorMatrixRowNEON(byte* src_argb, byte* dst_argb, sbyte* matrix_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBColorMatrixRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBColorMatrixRowMSA(byte* src_argb, byte* dst_argb, sbyte* matrix_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBColorMatrixRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBColorMatrixRowLSX(byte* src_argb, byte* dst_argb, sbyte* matrix_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBColorTableRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBColorTableRowC(byte* dst_argb, byte* table_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBColorTableRow_X86", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBColorTableRowX86(byte* dst_argb, byte* table_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBColorTableRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBColorTableRowC(byte* dst_argb, byte* table_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "RGBColorTableRow_X86", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void RGBColorTableRowX86(byte* dst_argb, byte* table_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBQuantizeRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBQuantizeRowC(byte* dst_argb, int scale, int interval_size, int interval_offset, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBQuantizeRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBQuantizeRowSSE2(byte* dst_argb, int scale, int interval_size, int interval_offset, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBQuantizeRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBQuantizeRowNEON(byte* dst_argb, int scale, int interval_size, int interval_offset, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBQuantizeRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBQuantizeRowMSA(byte* dst_argb, int scale, int interval_size, int interval_offset, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBQuantizeRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBQuantizeRowLSX(byte* dst_argb, int scale, int interval_size, int interval_offset, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBShadeRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBShadeRowC(byte* src_argb, byte* dst_argb, int width, uint value);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBShadeRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBShadeRowSSE2(byte* src_argb, byte* dst_argb, int width, uint value);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBShadeRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBShadeRowNEON(byte* src_argb, byte* dst_argb, int width, uint value);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBShadeRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBShadeRowMSA(byte* src_argb, byte* dst_argb, int width, uint value);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBShadeRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBShadeRowLSX(byte* src_argb, byte* dst_argb, int width, uint value);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBShadeRow_LASX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBShadeRowLASX(byte* src_argb, byte* dst_argb, int width, uint value);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "CumulativeSumToAverageRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void CumulativeSumToAverageRowSSE2(int* topleft, int* botleft, int width, int area, byte* dst, int count);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ComputeCumulativeSumRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ComputeCumulativeSumRowSSE2(byte* row, int* cumsum, int* previous_cumsum, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "CumulativeSumToAverageRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void CumulativeSumToAverageRowC(int* tl, int* bl, int w, int area, byte* dst, int count);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ComputeCumulativeSumRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ComputeCumulativeSumRowC(byte* row, int* cumsum, int* previous_cumsum, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBAffineRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBAffineRowC1(byte* src_argb, int src_argb_stride, byte* dst_argb, float* uv_dudv, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBAffineRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBAffineRowSSE21(byte* src_argb, int src_argb_stride, byte* dst_argb, float* src_dudv, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "InterpolateRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void InterpolateRowC(byte* dst_ptr, byte* src_ptr, long src_stride, int width, int source_y_fraction);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "InterpolateRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void InterpolateRowSSSE3(byte* dst_ptr, byte* src_ptr, long src_stride, int dst_width, int source_y_fraction);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "InterpolateRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void InterpolateRowAVX2(byte* dst_ptr, byte* src_ptr, long src_stride, int dst_width, int source_y_fraction);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "InterpolateRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void InterpolateRowNEON(byte* dst_ptr, byte* src_ptr, long src_stride, int dst_width, int source_y_fraction);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "InterpolateRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void InterpolateRowMSA(byte* dst_ptr, byte* src_ptr, long src_stride, int width, int source_y_fraction);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "InterpolateRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void InterpolateRowLSX(byte* dst_ptr, byte* src_ptr, long src_stride, int width, int source_y_fraction);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "InterpolateRow_RVV", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void InterpolateRowRVV(byte* dst_ptr, byte* src_ptr, long src_stride, int width, int source_y_fraction);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "InterpolateRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void InterpolateRowAnyNEON(byte* dst_ptr, byte* src_ptr, long src_stride_ptr, int width, int source_y_fraction);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "InterpolateRow_Any_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void InterpolateRowAnySSSE3(byte* dst_ptr, byte* src_ptr, long src_stride_ptr, int width, int source_y_fraction);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "InterpolateRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void InterpolateRowAnyAVX2(byte* dst_ptr, byte* src_ptr, long src_stride_ptr, int width, int source_y_fraction);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "InterpolateRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void InterpolateRowAnyMSA(byte* dst_ptr, byte* src_ptr, long src_stride_ptr, int width, int source_y_fraction);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "InterpolateRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void InterpolateRowAnyLSX(byte* dst_ptr, byte* src_ptr, long src_stride_ptr, int width, int source_y_fraction);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "InterpolateRow_16_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void InterpolateRow16C(ushort* dst_ptr, ushort* src_ptr, long src_stride, int width, int source_y_fraction);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "InterpolateRow_16_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void InterpolateRow16NEON(ushort* dst_ptr, ushort* src_ptr, long src_stride, int width, int source_y_fraction);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "InterpolateRow_16_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void InterpolateRow16AnyNEON(ushort* dst_ptr, ushort* src_ptr, long src_stride, int width, int source_y_fraction);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "InterpolateRow_16To8_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void InterpolateRow16To8C(byte* dst_ptr, ushort* src_ptr, long src_stride, int scale, int width, int source_y_fraction);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "InterpolateRow_16To8_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void InterpolateRow16To8NEON(byte* dst_ptr, ushort* src_ptr, long src_stride, int scale, int width, int source_y_fraction);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "InterpolateRow_16To8_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void InterpolateRow16To8AnyNEON(byte* dst_ptr, ushort* src_ptr, long src_stride, int scale, int width, int source_y_fraction);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "InterpolateRow_16To8_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void InterpolateRow16To8AVX2(byte* dst_ptr, ushort* src_ptr, long src_stride, int scale, int width, int source_y_fraction);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "InterpolateRow_16To8_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void InterpolateRow16To8AnyAVX2(byte* dst_ptr, ushort* src_ptr, long src_stride, int scale, int width, int source_y_fraction);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelXRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelXRowC(byte* src_y0, byte* src_y1, byte* src_y2, byte* dst_sobelx, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelXRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelXRowSSE2(byte* src_y0, byte* src_y1, byte* src_y2, byte* dst_sobelx, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelXRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelXRowNEON(byte* src_y0, byte* src_y1, byte* src_y2, byte* dst_sobelx, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelXRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelXRowMSA(byte* src_y0, byte* src_y1, byte* src_y2, byte* dst_sobelx, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelYRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelYRowC(byte* src_y0, byte* src_y1, byte* dst_sobely, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelYRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelYRowSSE2(byte* src_y0, byte* src_y1, byte* dst_sobely, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelYRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelYRowNEON(byte* src_y0, byte* src_y1, byte* dst_sobely, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelYRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelYRowMSA(byte* src_y0, byte* src_y1, byte* dst_sobely, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelRowC(byte* src_sobelx, byte* src_sobely, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelRowSSE2(byte* src_sobelx, byte* src_sobely, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelRowNEON(byte* src_sobelx, byte* src_sobely, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelRowMSA(byte* src_sobelx, byte* src_sobely, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelRowLSX(byte* src_sobelx, byte* src_sobely, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelToPlaneRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelToPlaneRowC(byte* src_sobelx, byte* src_sobely, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelToPlaneRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelToPlaneRowSSE2(byte* src_sobelx, byte* src_sobely, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelToPlaneRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelToPlaneRowNEON(byte* src_sobelx, byte* src_sobely, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelToPlaneRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelToPlaneRowMSA(byte* src_sobelx, byte* src_sobely, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelToPlaneRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelToPlaneRowLSX(byte* src_sobelx, byte* src_sobely, byte* dst_y, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelXYRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelXYRowC(byte* src_sobelx, byte* src_sobely, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelXYRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelXYRowSSE2(byte* src_sobelx, byte* src_sobely, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelXYRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelXYRowNEON(byte* src_sobelx, byte* src_sobely, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelXYRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelXYRowMSA(byte* src_sobelx, byte* src_sobely, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelXYRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelXYRowLSX(byte* src_sobelx, byte* src_sobely, byte* dst_argb, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelRowAnySSE2(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelRowAnyNEON(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelRowAnyMSA(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelRowAnyLSX(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelToPlaneRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelToPlaneRowAnySSE2(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelToPlaneRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelToPlaneRowAnyNEON(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelToPlaneRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelToPlaneRowAnyMSA(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelToPlaneRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelToPlaneRowAnyLSX(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelXYRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelXYRowAnySSE2(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelXYRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelXYRowAnyNEON(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelXYRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelXYRowAnyMSA(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "SobelXYRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void SobelXYRowAnyLSX(byte* y_buf, byte* uv_buf, byte* dst_ptr, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBPolynomialRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBPolynomialRowC(byte* src_argb, byte* dst_argb, float* poly, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBPolynomialRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBPolynomialRowSSE2(byte* src_argb, byte* dst_argb, float* poly, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBPolynomialRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBPolynomialRowAVX2(byte* src_argb, byte* dst_argb, float* poly, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "HalfFloatRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void HalfFloatRowC(ushort* src, ushort* dst, float scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "HalfFloatRow_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void HalfFloatRowSSE2(ushort* src, ushort* dst, float scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "HalfFloatRow_Any_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void HalfFloatRowAnySSE2(ushort* src_ptr, ushort* dst_ptr, float param, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "HalfFloatRow_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void HalfFloatRowAVX2(ushort* src, ushort* dst, float scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "HalfFloatRow_Any_AVX2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void HalfFloatRowAnyAVX2(ushort* src_ptr, ushort* dst_ptr, float param, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "HalfFloatRow_F16C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void HalfFloatRowF16C(ushort* src, ushort* dst, float scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "HalfFloatRow_Any_F16C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void HalfFloatRowAnyF16C(ushort* src, ushort* dst, float scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "HalfFloat1Row_F16C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void HalfFloat1RowF16C(ushort* src, ushort* dst, float scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "HalfFloat1Row_Any_F16C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void HalfFloat1RowAnyF16C(ushort* src, ushort* dst, float scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "HalfFloatRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void HalfFloatRowNEON(ushort* src, ushort* dst, float scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "HalfFloatRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void HalfFloatRowAnyNEON(ushort* src_ptr, ushort* dst_ptr, float param, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "HalfFloat1Row_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void HalfFloat1RowNEON(ushort* src, ushort* dst, float scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "HalfFloat1Row_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void HalfFloat1RowAnyNEON(ushort* src_ptr, ushort* dst_ptr, float param, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "HalfFloatRow_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void HalfFloatRowMSA(ushort* src, ushort* dst, float scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "HalfFloatRow_Any_MSA", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void HalfFloatRowAnyMSA(ushort* src_ptr, ushort* dst_ptr, float param, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "HalfFloatRow_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void HalfFloatRowLSX(ushort* src, ushort* dst, float scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "HalfFloatRow_Any_LSX", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void HalfFloatRowAnyLSX(ushort* src_ptr, ushort* dst_ptr, float param, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ByteToFloatRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ByteToFloatRowC(byte* src, float* dst, float scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ByteToFloatRow_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ByteToFloatRowNEON(byte* src, float* dst, float scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ByteToFloatRow_Any_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ByteToFloatRowAnyNEON(byte* src_ptr, float* dst_ptr, float param, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ConvertFP16ToFP32Row_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ConvertFP16ToFP32RowNEON(ushort* src, float* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ConvertFP16ToFP32Column_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ConvertFP16ToFP32ColumnNEON(ushort* src, int src_stride, float* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ConvertFP32ToFP16Row_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ConvertFP32ToFP16RowNEON(float* src, ushort* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBLumaColorTableRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBLumaColorTableRowC(byte* src_argb, byte* dst_argb, int width, byte* luma, uint lumacoeff);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ARGBLumaColorTableRow_SSSE3", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ARGBLumaColorTableRowSSSE3(byte* src_argb, byte* dst_argb, int width, byte* luma, uint lumacoeff);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleMaxSamples_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern float ScaleMaxSamplesC(float* src, float* dst, float scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleMaxSamples_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern float ScaleMaxSamplesNEON(float* src, float* dst, float scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleSumSamples_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern float ScaleSumSamplesC(float* src, float* dst, float scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleSumSamples_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern float ScaleSumSamplesNEON(float* src, float* dst, float scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleSamples_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ScaleSamplesC(float* src, float* dst, float scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ScaleSamples_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ScaleSamplesNEON(float* src, float* dst, float scale, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "GaussRow_F32_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void GaussRowF32NEON(float* src, float* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "GaussRow_F32_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void GaussRowF32C(float* src, float* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "GaussCol_F32_NEON", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void GaussColF32NEON(float* src0, float* src1, float* src2, float* src3, float* src4, float* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "GaussCol_F32_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void GaussColF32C(float* src0, float* src1, float* src2, float* src3, float* src4, float* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "GaussRow_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void GaussRowC(uint* src, ushort* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "GaussCol_C", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void GaussColC(ushort* src0, ushort* src1, ushort* src2, ushort* src3, ushort* src4, uint* dst, int width);

            [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "ClampFloatToZero_SSE2", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void ClampFloatToZeroSSE2(float* src_x, float* dst_y, int width);

        #endregion

        [SuppressUnmanagedCodeSecurity, DllImport(DLL_NAME, EntryPoint = "CanonicalFourCC", CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint CanonicalFourCC(uint fourcc);
    }
    public enum FourCC
    {
        FOURCC_I420 = 808596553,
        FOURCC_I422 = 842150985,
        FOURCC_I444 = 875836489,
        FOURCC_I400 = 808465481,
        FOURCC_NV21 = 825382478,
        FOURCC_NV12 = 842094158,
        FOURCC_YUY2 = 844715353,
        FOURCC_UYVY = 1498831189,
        FOURCC_I010 = 808529993,
        FOURCC_I210 = 808530505,
        FOURCC_M420 = 808596557,
        FOURCC_ARGB = 1111970369,
        FOURCC_BGRA = 1095911234,
        FOURCC_ABGR = 1380401729,
        FOURCC_AR30 = 808669761,
        FOURCC_AB30 = 808665665,
        FOURCC_AR64 = 875975233,
        FOURCC_AB64 = 875971137,
        FOURCC_24BG = 1195521074,
        FOURCC_RAW = 544694642,
        FOURCC_RGBA = 1094862674,
        FOURCC_RGBP = 1346520914,
        FOURCC_RGBO = 1329743698,
        FOURCC_R444 = 875836498,
        FOURCC_MJPG = 1196444237,
        FOURCC_YV12 = 842094169,
        FOURCC_YV16 = 909203033,
        FOURCC_YV24 = 875714137,
        FOURCC_YU12 = 842093913,
        FOURCC_J420 = 808596554,
        FOURCC_J422 = 842150986,
        FOURCC_J444 = 875836490,
        FOURCC_J400 = 808465482,
        FOURCC_F420 = 808596550,
        FOURCC_F422 = 842150982,
        FOURCC_F444 = 875836486,
        FOURCC_H420 = 808596552,
        FOURCC_H422 = 842150984,
        FOURCC_H444 = 875836488,
        FOURCC_U420 = 808596565,
        FOURCC_U422 = 842150997,
        FOURCC_U444 = 875836501,
        FOURCC_F010 = 808529990,
        FOURCC_H010 = 808529992,
        FOURCC_U010 = 808530005,
        FOURCC_F210 = 808530502,
        FOURCC_H210 = 808530504,
        FOURCC_U210 = 808530517,
        FOURCC_P010 = 808530000,
        FOURCC_P210 = 808530512,
        FOURCC_IYUV = 1448433993,
        FOURCC_YU16 = 909202777,
        FOURCC_YU24 = 875713881,
        FOURCC_YUYV = 1448695129,
        FOURCC_YUVS = 1937143161,
        FOURCC_HDYC = 1129923656,
        FOURCC_2VUY = 2037741106,
        FOURCC_JPEG = 1195724874,
        FOURCC_DMB1 = 828534116,
        FOURCC_BA81 = 825770306,
        FOURCC_RGB3 = 859981650,
        FOURCC_BGR3 = 861030210,
        FOURCC_CM32 = 536870912,
        FOURCC_CM24 = 402653184,
        FOURCC_L555 = 892679500,
        FOURCC_L565 = 892745036,
        FOURCC_5551 = 825570613,
        FOURCC_I411 = 825308233,
        FOURCC_Q420 = 808596561,
        FOURCC_RGGB = 1111967570,
        FOURCC_BGGR = 1380403010,
        FOURCC_GRBG = 1195528775,
        FOURCC_GBRG = 1196573255,
        FOURCC_H264 = 875967048,
        FOURCC_ANY = -1
    }

    public enum FourCCBpp
    {
        FOURCC_BPP_I420 = 12,
        FOURCC_BPP_I422 = 16,
        FOURCC_BPP_I444 = 24,
        FOURCC_BPP_I411 = 12,
        FOURCC_BPP_I400 = 8,
        FOURCC_BPP_NV21 = 12,
        FOURCC_BPP_NV12 = 12,
        FOURCC_BPP_YUY2 = 16,
        FOURCC_BPP_UYVY = 16,
        FOURCC_BPP_M420 = 12,
        FOURCC_BPP_Q420 = 12,
        FOURCC_BPP_ARGB = 32,
        FOURCC_BPP_BGRA = 32,
        FOURCC_BPP_ABGR = 32,
        FOURCC_BPP_RGBA = 32,
        FOURCC_BPP_AR30 = 32,
        FOURCC_BPP_AB30 = 32,
        FOURCC_BPP_AR64 = 64,
        FOURCC_BPP_AB64 = 64,
        FOURCC_BPP_24BG = 24,
        FOURCC_BPP_RAW = 24,
        FOURCC_BPP_RGBP = 16,
        FOURCC_BPP_RGBO = 16,
        FOURCC_BPP_R444 = 16,
        FOURCC_BPP_RGGB = 8,
        FOURCC_BPP_BGGR = 8,
        FOURCC_BPP_GRBG = 8,
        FOURCC_BPP_GBRG = 8,
        FOURCC_BPP_YV12 = 12,
        FOURCC_BPP_YV16 = 16,
        FOURCC_BPP_YV24 = 24,
        FOURCC_BPP_YU12 = 12,
        FOURCC_BPP_J420 = 12,
        FOURCC_BPP_J400 = 8,
        FOURCC_BPP_H420 = 12,
        FOURCC_BPP_H422 = 16,
        FOURCC_BPP_I010 = 15,
        FOURCC_BPP_I210 = 20,
        FOURCC_BPP_H010 = 15,
        FOURCC_BPP_H210 = 20,
        FOURCC_BPP_P010 = 15,
        FOURCC_BPP_P210 = 20,
        FOURCC_BPP_MJPG = 0,
        FOURCC_BPP_H264 = 0,
        FOURCC_BPP_IYUV = 12,
        FOURCC_BPP_YU16 = 16,
        FOURCC_BPP_YU24 = 24,
        FOURCC_BPP_YUYV = 16,
        FOURCC_BPP_YUVS = 16,
        FOURCC_BPP_HDYC = 16,
        FOURCC_BPP_2VUY = 16,
        FOURCC_BPP_JPEG = 1,
        FOURCC_BPP_DMB1 = 1,
        FOURCC_BPP_BA81 = 8,
        FOURCC_BPP_RGB3 = 24,
        FOURCC_BPP_BGR3 = 24,
        FOURCC_BPP_CM32 = 32,
        FOURCC_BPP_CM24 = 24,
        FOURCC_BPP_ANY = 0
    }

    public enum RotationMode
    {
        kRotate0 = 0,
        kRotate90 = 90,
        kRotate180 = 180,
        kRotate270 = 270,
        kRotateNone = 0,
        kRotateClockwise = 90,
        kRotateCounterClockwise = 270
    }

    public enum FilterMode
    {
        kFilterNone = 0,
        kFilterLinear = 1,
        kFilterBilinear = 2,
        kFilterBox = 3
    }
}

