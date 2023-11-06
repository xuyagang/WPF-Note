using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_TreeView
{
    /// <summary>
    /// 文件夹名称比较器
    /// </summary>
    internal class PathHelper : IComparer<string>
    {
        [System.Runtime.InteropServices.DllImport("Shlwapi.dll", CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
        public static extern int StrCmpLogicalW(string s1, string s2);
        public int Compare(string x, string y)
        {
            return StrCmpLogicalW(x, y);
        }
    }
}
