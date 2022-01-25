using System;
using System.IO;

namespace UnitTestReader
{
    /// <summary>
    /// Reprezentuje czytnik strumienia.
    /// </summary>
    public class Reader: Stream
    {
        private Stream  stream;
        private Boolean leaveInnerStreamOpen;

        private Int64   bytesRead;
        private Int32   _dynamicBytes;
        private Boolean isDisposed;

        /// <summary>
        /// Zwalnia zasoby.
        /// </summary>
        /// <param name="disposing">n/a</param>
        protected override void Dispose( Boolean disposing )
        {
            if (disposing)
            {
                base.Dispose( disposing );
                isDisposed = true;
                IsOpen = false;
                leaveInnerStreamOpen = false;
            }

        }

        /// <summary>
        /// Tworzy instancję klasy <see cref="Reader"/>.
        /// </summary>
        /// <param name="stream">Strumień danych.</param>
        /// <param name="leaveInnerStreamOpen">Wartość [true] jeśli strumień danych powinien pozostać 
        /// otwarty po wywołaniu metody <see cref="Stream.Dispose()"/>.</param>
        public Reader( Stream  stream,
                       Boolean leaveInnerStreamOpen )
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            else if (!stream.CanRead)
            {
                throw new ArgumentException("stream");
            }
            
            this.stream = stream;
            this.leaveInnerStreamOpen = leaveInnerStreamOpen;
            //bytesRead = 0;
            if (!leaveInnerStreamOpen)
                IsOpen = false;
            IsOpen = true;
        }

        /// <summary>
        /// n/a
        /// </summary>
        /// <param name="buffer">n/a</param>
        /// <param name="offset">n/a</param>
        /// <param name="count">n/a</param>
        /// <returns>n/a</returns>
        public override Int32 Read( Byte[] buffer,
                                    Int32  offset,
                                    Int32  count )
        {
            if (offset + count > buffer.Length)
                throw new ArgumentException();
            else if (buffer is null)
                throw new ArgumentNullException();
            else if (offset < 0 || count < 0)
                throw new ArgumentOutOfRangeException();
            else if (isDisposed)
                throw new ObjectDisposedException(nameof(stream));

            //just for test case
            BytesRead = (long)buffer.Length - offset;

            //DynamicBytes = buffer.Length;

            int read = stream.Read(buffer, offset, count);

            for (int i = 0; i < buffer.Length; ++i)
            {
                buffer[i] = (byte)(buffer[i] - (byte)offset);
            }
            
            return read;
        }

        public Int32 DynamicBytes
        {
            get
            {
                return _dynamicBytes;
            }
            set
            {
                _dynamicBytes = value;
            }
        }


        /// <summary>
        /// n/a
        /// </summary>
        /// <param name="offset">n/a</param>
        /// <param name="origin">n/a</param>
        /// <returns>n/a</returns>
        public override Int64 Seek( Int64      offset,
                                    SeekOrigin origin )
        {
            if ( isDisposed )
                throw new ObjectDisposedException(nameof(stream));

            throw new NotSupportedException();
        }

        /// <summary>
        /// n/a
        /// </summary>
        /// <param name="buffer">n/a</param>
        /// <param name="offset">n/a</param>
        /// <param name="count">n/a</param>
        public override void Write( Byte[] buffer,
                                    Int32  offset,
                                    Int32  count )
        {
            if ( isDisposed )
                throw new ObjectDisposedException(nameof(stream));

            throw new NotSupportedException();
        }

        /// <summary>
        /// n/a
        /// </summary>
        /// <param name="value">n/a</param>
        public override void SetLength( Int64 value )
        {
            if ( isDisposed )
                throw new ObjectDisposedException(nameof(stream));

            throw new NotSupportedException();
        }

        /// <summary>
        /// n/a
        /// </summary>
        public override void Flush()
        {
            stream.Flush();
        }

        /// <summary>
        /// Wartość [true] jeśli czytnik jest otwarty.
        /// </summary>
        public Boolean IsOpen
        {
            get; private set;
        }

        /// <summary>
        /// Rozmiar danych odczytanych ze strumienia.
        /// </summary>
        public Int64 BytesRead
        {
            get
            {
                return bytesRead;
            }
            set
            {
                bytesRead = value;
            }
        }

        /// <summary>
        /// n/a
        /// </summary>
        public override Boolean CanRead
        {
            get 
            { 
                return true;
            }
        }

        /// <summary>
        /// n/a
        /// </summary>
        public override Boolean CanSeek
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// n/a
        /// </summary>
        public override Boolean CanWrite
        {
            get
            {
                return false;//stream.CanWrite;
            }
        }

        /// <summary>
        /// n/a
        /// </summary>
        public override Int64 Position
        { 
            get
            {
                if (isDisposed)
                    throw new ObjectDisposedException(nameof(stream));

                throw new NotSupportedException();
            }
            set 
            {
                if (isDisposed)
                    throw new ObjectDisposedException(nameof(stream));

                throw new NotSupportedException();
            }

        }

        /// <summary>
        /// n/a
        /// </summary>
        public override Int64 Length
        {
            get
            {
                if ( isDisposed )
                    throw new ObjectDisposedException(nameof(stream));

                throw new NotSupportedException();
            }
        }
    }
}
