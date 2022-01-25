using System;
using System.IO;

namespace UnitTestReader
{
    internal class MockStream: MemoryStream
    {
        //private Boolean _isDisposeCalled;

        protected override void Dispose( Boolean disposing )
        {
        }
        public Boolean IsDisposeCalled
        {
            get; set;

            //private set;
        }
    }
}
