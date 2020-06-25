using System;
using VectorRasterBridge;

namespace VectorRasterBridge
{
    public abstract class Shape
    {
        protected readonly IRenderer _renderer;

        public Shape(IRenderer renderer)
        {
            _renderer = renderer;
        }
        public string Name { get; set; }

        public override string ToString()
        {
            _renderer.Name = Name;
            return _renderer.WhatToRenderAs;
        }
    }

    public class Triangle : Shape
    {
        public Triangle(IRenderer renderer) : base(renderer)
        {
            Name = "Triangle";
        }
    }

    public class Square : Shape
    {
        public Square(IRenderer renderer) : base(renderer)
        {
            Name = "Square";
        }
    }
}
