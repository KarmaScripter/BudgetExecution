﻿// ************************************************************************************************
//     Assembly:                Budget Execution
//     Author:                  Terry D. Eppler
//     Created:              13-11-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        16-11-2023
// ************************************************************************************************
// <copyright file="BabyBoy.cs.cs" company="Terry D. Eppler">
//    This is a Federal Budget, Finance, and Accounting application for the
//    US Environmental Protection Agency (US EPA).
//    Copyright ©  2023  Terry Eppler
// 
//    Permission is hereby granted, free of charge, to any person obtaining a copy
//    of this software and associated documentation files (the “Software”),
//    to deal in the Software without restriction,
//    including without limitation the rights to use,
//    copy, modify, merge, publish, distribute, sublicense,
//    and/or sell copies of the Software,
//    and to permit persons to whom the Software is furnished to do so,
//    subject to the following conditions:
// 
//    The above copyright notice and this permission notice shall be included in all
//    copies or substantial portions of the Software.
// 
//    THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
//    INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT.
//    IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
//    DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
//    DEALINGS IN THE SOFTWARE.
// 
//    You can contact me at: terryeppler@gmail.com or eppler.terry@epa.gov
// </copyright>
// <summary>
//   Eppler, Terry.cs
// </summary>
// ************************************************************************************************

namespace BudgetExecution
{
    using System.Diagnostics.CodeAnalysis;
    using System.Net;
    using System.Net.Sockets;
    using System;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "ReplaceAutoPropertyWithComputedProperty" ) ]
    public class BabyBoy : Baby
    {
        /// <summary>
        /// Gets or sets the bytes.
        /// </summary>
        /// <value>
        /// The bytes.
        /// </value>
        public int Bytes
        {
            get
            {
                return _bytes;
            }
            private set
            {
                _bytes = value;
            }
        }

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        public int Port
        {
            get
            {
                return _port;
            }
            private set
            {
                _port = value;
            }
        }

        /// <summary>
        /// Gets or sets the buffer.
        /// </summary>
        /// <value>
        /// The buffer.
        /// </value>
        public byte[ ] Data
        {
            get
            {
                return _data;
            }
            private set
            {
                _data = value;
            }
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message
        {
            get
            {
                return _message;
            }
            private set
            {
                _message = value;
            }
        }

        /// <summary>
        /// Gets or sets the server.
        /// </summary>
        /// <value>
        /// The server.
        /// </value>
        public Socket Socket
        {
            get
            {
                return _socket;
            }
            private set
            {
                _socket = value;
            }
        }

        /// <summary>
        /// Gets or sets the local.
        /// </summary>
        /// <value>
        /// The local.
        /// </value>
        public IPAddress Address
        {
            get
            {
                return _ipAddress;
            }
            private set
            {
                _ipAddress = value;
            }
        }

        /// <summary>
        /// Gets or sets the local.
        /// </summary>
        /// <value>
        /// The local.
        /// </value>
        public IPEndPoint EndPoint
        {
            get
            {
                return _ipEndPoint;
            }
            private set
            {
                _ipEndPoint = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// this instance is connected.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is connected;
        /// otherwise, <c>false</c>.
        /// </value>
        public bool IsConnected
        {
            get
            {
                return _isConnected;
            }
            private set
            {
                _isConnected = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BabyBoy"/> class.
        /// </summary>
        public BabyBoy( )
        {
            _bytes = 1024;
            _port = 5000;
            _data = new byte[ Bytes ];
            _ipAddress = IPAddress.Any;
            _ipEndPoint = new IPEndPoint( Address, Port );
            _socket = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
            _isConnected = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BabyBoy"/> class.
        /// </summary>
        /// <param name="address">The ip address.</param>
        /// <param name="port">The port number.</param>
        /// <param name="size">Size of the buffer.</param>
        public BabyBoy( string address, int port = 5000, int size = 1024 )
        {
            _bytes = size;
            _port = port;
            _data = new byte[ Bytes ];
            _ipAddress = IPAddress.Parse( address );
            _ipEndPoint = new IPEndPoint( Address, port );
            _socket = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
            _isConnected = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BabyBoy"/> class.
        /// </summary>
        /// <param name="address">The ip address.</param>
        /// <param name="port">The port.</param>
        /// <param name="size"> </param>
        public BabyBoy( IPAddress address, int port = 5000, int size = 1024 )
        {
            _bytes = size;
            _port = port;
            _data = new byte[ size ];
            _ipAddress = address;
            _ipEndPoint = new IPEndPoint( address, port );
            _socket = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
            _isConnected = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BabyBoy"/> class.
        /// </summary>
        /// <param name="endPoint">The ip address.</param>
        /// <param name="size">Size of the buffer.</param>
        public BabyBoy( IPEndPoint endPoint, int size = 1024 )
        {
            _bytes = size;
            _port = endPoint.Port;
            _data = new byte[ size ];
            _ipAddress = endPoint.Address;
            _ipEndPoint = endPoint;
            _socket = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
            _isConnected = false;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BabyBoy"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        public BabyBoy( BabyBoy client )
        {
            _bytes = client.Bytes;
            _port = client.Port;
            _data = client.Data;
            _ipAddress = client.Address;
            _ipEndPoint = client.EndPoint;
            _socket = client.Socket;
            _isConnected = client.IsConnected;
        }

        /// <summary>
        /// Connects this instance.
        /// </summary>
        public void Connect( )
        {
            try
            {
                _message = "You look like a baby!";
                _data = Encoding.ASCII.GetBytes( _message );
                _socket.Connect( _ipEndPoint );
                _isConnected = _socket.Connected;
                _socket.Send( _data );
                SendNotification( _message );
            }
            catch( Exception _ex )
            {
                _socket?.Dispose( );
                Fail( _ex );
            }
        }

        /// <summary>
        /// Sends the message.
        /// </summary>
        public void SendMessage( )
        {
            try
            {
                _message = "You look like a baby!";
                _data = Encoding.ASCII.GetBytes( _message );
                if( _socket.Connected )
                {
                    _socket.Send( _data );
                    SendNotification( _message );
                }
                else
                {
                    _socket.Connect( _ipEndPoint );
                    _isConnected = _socket.Connected;
                    _socket.Send( _data );
                }
            }
            catch( Exception _ex )
            {
                _socket?.Dispose( );
                Fail( _ex );
            }
        }

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void SendMessage( string message )
        {
            try
            {
                ThrowIf.Null( message, nameof( message ) );
                _message = message;
                _data = Encoding.ASCII.GetBytes( message );
                if( _socket.Connected )
                {
                    _socket.Send( _data );
                }
                else
                {
                    _socket.Connect( _ipEndPoint );
                    _isConnected = _socket.Connected;
                    _socket.Send( _data );
                }
            }
            catch( Exception _ex )
            {
                _socket?.Dispose( );
                Fail( _ex );
            }
        }

        /// <summary>
        /// Notifies this instance.
        /// </summary>
        private void Notify( string message )
        {
            try
            {
                ThrowIf.Null( message, nameof( message ) );
                var _notify = new SplashMessage( message );
                _notify.Show( );
            }
            catch( Exception _ex )
            {
                Socket?.Dispose( );
                Fail( _ex );
            }
        }

        /// <summary>
        /// Deconstructs the specified bytes.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="port">The port.</param>
        /// <param name="data">The data.</param>
        /// <param name="ipAddress">The ip address.</param>
        /// <param name="endPoint">The end point.</param>
        /// <param name="socket">The socket.</param>
        /// <param name="message">The message.</param>
        public void Deconstruct( out int bytes, out int port, out byte[ ] data,
            out IPAddress ipAddress, out IPEndPoint endPoint, out Socket socket,
            out string message )
        {
            bytes = Bytes;
            port = Port;
            data = Data;
            ipAddress = Address;
            endPoint = EndPoint;
            socket = Socket;
            message = Message;
        }
    }
}