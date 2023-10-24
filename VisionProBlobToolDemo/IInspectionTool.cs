using Cognex.VisionPro.Display;
using Cognex.VisionPro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionProBlobToolDemo
{
    #region 인터페이스 구현
    public interface IInspectionTool
    {
        void Init();
        void SetRegion();
        void SetPolarity(int property);
        void SetThreshold(int value);
        void SetMinPixel(int value);
        void ShowRegion(CogDisplay display);
        void Run(CogImage8Grey img, CogDisplay display, int index);
        void DrawResult(CogDisplay display, double textXCoordinate, double textYCoordinate, string msg);
        void SaveRegion();
        void GetRegion(Boolean file_exists, int index);
        void GetIndex(int index);
        void DisplayParam();
        void GetParam(Boolean file_exists, int index);
        void SetParam();
        void SetScope();
    }
    #endregion
    public static class BlobToolFactory
    {
        public static IInspectionTool CreateTools(IInspectionTool tool)
        {
            return tool;
        }
    }

    //public static class BlobToolFactory
    //{
    //    public static IInspectionTool CreateTools()
    //    {
    //        IInspectionTool tool = null;

    //        //tool = new cBlob();

    //        return tool;
    //    }
    //}
}
