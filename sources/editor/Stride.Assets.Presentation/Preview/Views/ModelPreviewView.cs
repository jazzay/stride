// Copyright (c) Stride contributors (https://stride3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System.Windows;
using Stride.Editor.Preview.View;

namespace Stride.Assets.Presentation.Preview.Views
{
    public class ModelPreviewView : StridePreviewView
    {
        static ModelPreviewView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ModelPreviewView), new FrameworkPropertyMetadata(typeof(ModelPreviewView)));
        }
    }
}
