using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lwssp.Entinies
{
    public class Pt
    {
        public float X { get; set; } // 横坐标 左-1.0~1.0右
        public float Y { get; set; } // 纵坐标 下-1.0~1.0上

        public Pt(float x, float y)
        {
            X=x; Y=y;
        }
    }
    public class Glyphs
    {
        public string Name { get; set; }
        public int Index { get; set; }
        public List<Pt> Path { get; set; } = new List<Pt>();
        public void AddPoint(Pt point) => Path.Add(point);
        public void AddPoint(float x, float y) => Path.Add(new Pt(x, y));

        public Glyphs(string n, int i)
        {
            Name = n; Index = i;
            AddPoint(2.0f, 0);
        }
        
        //简化路径
        public void Simplify()
        {
            if (Path == null || Path.Count == 0)
            {
                Path = new List<Pt>();
                return;
            }
            if (Path.Count == 1)
            {
                return;
            }

            var result = new List<Pt>();
            bool lastWasSpecial = false;
            for (int i = 0; i < Path.Count; i++)
            {
                var current = Path[i];
                bool currentIsSpecial = current.X == 2.0;
                if (i == 0 && currentIsSpecial)
                {
                    continue;
                }
                if (currentIsSpecial && lastWasSpecial)
                {
                    continue;
                }

                if (currentIsSpecial && i != Path.Count - 1)
                {
                    result.Add(current);
                    lastWasSpecial = true;
                }
                else
                {
                    result.Add(current);
                    lastWasSpecial = false;
                }
            }
            Path = new List<Pt>(result.ToArray());
        }
        public int LineIndex(int objIdx)
        {
            Simplify();
            int cnt = 0;
            for (int i = 0; i < Path.Count; i++)
            {
                if (Path[i].X == 2.0)
                {
                    cnt++;
                }
                if (cnt == objIdx)
                {
                    return i;
                }
            }
            return -1;
        }
    }
    public class IdxComp
    {
        public string Name { get; }
        public int Index { get; }
        private readonly List<Glyphs> _glyphs = new List<Glyphs>();
        public IdxComp(string name, int index)
        {
            Name = name ?? throw new ArgumentException(nameof(name));
            Index = index;
        }
        public void AddGlyph(Glyphs glyph)
        {
            if (glyph == null)
                throw new ArgumentNullException(nameof(glyph));
            _glyphs.Add(glyph);
        }
        public IReadOnlyList<Glyphs> glyphs => _glyphs.AsReadOnly();
        public int GlyphCount => _glyphs.Count;
    }
}
