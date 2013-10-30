﻿namespace ReLi.Framework.Library.Net
{
    #region Using Declarations

    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using ReLi.Framework.Library;
    using ReLi.Framework.Library.IO;
    using ReLi.Framework.Library.Collections;
    using ReLi.Framework.Library.Threading;
    using ReLi.Framework.Library.Serialization;

    #endregion
        
	public class DownloadResultList : ObjectListBase<ITaskResult>
    {
        public DownloadResultList()
            : base()
        {}

        public DownloadResultList(IEnumerable<ITaskResult> objDownloadResults)
            : base(objDownloadResults)
        {}

        public DownloadResultList(SerializedObject objSerializedObject)
            : base(objSerializedObject)
        {}

        public DownloadResultList(BinaryReaderExtension objBinaryReader)
            : base(objBinaryReader)
        {}
        
        public bool Completed
        {
            get
            {
                int intCompletedCount = GetCountByType(TaskResultType.Completed);
                bool blnCompleted = (intCompletedCount == this.Count);

                return blnCompleted;
            }
        }

        public bool Failed
        {
            get
            {
                int intFailedCount = GetCountByType(TaskResultType.Failed);
                bool blnFailed = (intFailedCount > 0);

                return blnFailed;
            }
        }

        public ITaskResult[] GetResultsByType(TaskResultType enuTaskResultType)
        {
            List<ITaskResult> objTaskResults = new List<ITaskResult>();
            foreach (ITaskResult objTaskResult in this)
            {
                if (objTaskResult.Result == enuTaskResultType)
                {
                    objTaskResults.Add(objTaskResult);
                }
            }

            return objTaskResults.ToArray();
        }

        public int GetCountByType(TaskResultType enuTaskResultType)
        {
            int intCount = 0;
            foreach (ITaskResult objTaskResult in this)
            {
                if (objTaskResult.Result == enuTaskResultType)
                {
                    intCount++;
                }
            }

            return intCount;
        }

        #region SerializableObject Members

        public override void WriteData(SerializedObject objSerializedObject)
        {
            base.WriteData(objSerializedObject);
        }

        public override void ReadData(SerializedObject objSerializedObject)
        {
            base.ReadData(objSerializedObject);
        }

        #endregion

        #region TransportableObject Members

        public override void WriteData(BinaryWriterExtension objBinaryWriter)
        {
            base.WriteData(objBinaryWriter);
        }

        public override void ReadData(BinaryReaderExtension objBinaryReader)
        {
            base.ReadData(objBinaryReader);
        }

        #endregion

    }
}
