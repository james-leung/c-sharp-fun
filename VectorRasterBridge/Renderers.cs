using System;
using System.Collections.Generic;
using System.Text;

namespace VectorRasterBridge
{
    public interface IRenderer
    {
        string Name { get; set; }
        string WhatToRenderAs { get; }
    }
    public class RasterRenderer : IRenderer
    {
        public string Name { get; set; } = "shape";
        public string WhatToRenderAs => $"Drawing {Name} as pixels";

    }

    public class VectorRenderer : IRenderer
    {
        public string Name { get; set; } = "shape";
        public string WhatToRenderAs => $"Drawing {Name} as lines";
    }
}
