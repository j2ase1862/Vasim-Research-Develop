using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionProBlobToolDemo
{
    #region 이 부분은 구글신에게 물어보세요!! 키워드는 싱글톤 패턴입니다.
    public class GlobalInstance
    {
        
        private static readonly Lazy<GlobalInstance> lazyInstance =
            new Lazy<GlobalInstance>(() => new GlobalInstance());

        private IInspectionTool inspectionTool;

        public static GlobalInstance Instance => lazyInstance.Value;

        private GlobalInstance()
        {
            //get
            //{
            //    if (instance == null)
            //    {
            //        instance = new GlobalInstance();
            //    }
            //    return instance;
            //}
        }

        public IInspectionTool Tool
        {
            get { return inspectionTool; }
            set { inspectionTool = value; }
        }
    }
    #endregion


    //public class GlobalInstance
    //{
    //    private static GlobalInstance instance;

    //    private IInspectionTool inspectionTool;

    //    public static GlobalInstance Instance
    //    {
    //        get
    //        {
    //            if (instance == null)
    //            {
    //                instance = new GlobalInstance();
    //            }
    //            return instance;
    //        }
    //    }

    //    public IInspectionTool _tool
    //    {
    //        get { return inspectionTool; }
    //        set { inspectionTool = value; }
    //    }
    //}
}
