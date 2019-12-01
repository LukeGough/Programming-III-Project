// <copyright file="PipeClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1200 // Using directives should be placed correctly
using System;
#pragma warning restore SA1200 // Using directives should be placed correctly
#pragma warning disable SA1200 // Using directives should be placed correctly
using System.IO;
#pragma warning restore SA1200 // Using directives should be placed correctly
#pragma warning disable SA1200 // Using directives should be placed correctly
using System.Runtime.InteropServices;
#pragma warning restore SA1200 // Using directives should be placed correctly
#pragma warning disable SA1200 // Using directives should be placed correctly
using System.Threading;
#pragma warning restore SA1200 // Using directives should be placed correctly
#pragma warning disable SA1200 // Using directives should be placed correctly
using Microsoft.Win32.SafeHandles;
#pragma warning restore SA1200 // Using directives should be placed correctly

namespace Client
{
#pragma warning disable SA1629 // Documentation text should end with a period
    /// <summary>
    /// Allow pipe communication between a server and a client
    /// </summary>
    public class PipeClient
#pragma warning restore SA1629 // Documentation text should end with a period
    {
        [DllImport("kernel32.dll", SetLastError = true)]
#pragma warning disable SA1400 // Access modifier should be declared
        static extern SafeFileHandle CreateFile(
#pragma warning restore SA1400 // Access modifier should be declared
#pragma warning disable SA1121 // Use built-in type alias
#pragma warning disable SA1114 // Parameter list should follow declaration
           String pipeName,
#pragma warning restore SA1114 // Parameter list should follow declaration
#pragma warning restore SA1121 // Use built-in type alias
           uint dwDesiredAccess,
           uint dwShareMode,
           IntPtr lpSecurityAttributes,
           uint dwCreationDisposition,
           uint dwFlagsAndAttributes,
           IntPtr hTemplate);

#pragma warning disable SA1201 // Elements should appear in the correct order
#pragma warning disable SA1629 // Documentation text should end with a period
#pragma warning disable SA1629 // Documentation text should end with a period
        /// <summary>
        /// Handles messages received from a server pipe
        /// </summary>
        /// <param name="message">The byte message received</param>
        public delegate void MessageReceivedHandler(byte[] message);
#pragma warning restore SA1629 // Documentation text should end with a period
#pragma warning restore SA1629 // Documentation text should end with a period
#pragma warning restore SA1201 // Elements should appear in the correct order

        /// <summary>
        /// Event is called whenever a message is received from the server pipe
        /// </summary>
        public event MessageReceivedHandler MessageReceived;
#pragma warning disable SA1507 // Code should not contain multiple blank lines in a row


#pragma warning disable SA1201 // Elements should appear in the correct order
#pragma warning disable SA1629 // Documentation text should end with a period
        /// <summary>
        /// Handles server disconnected messages
        /// </summary>
        public delegate void ServerDisconnectedHandler();
#pragma warning restore SA1507 // Code should not contain multiple blank lines in a row
#pragma warning restore SA1629 // Documentation text should end with a period
#pragma warning restore SA1201 // Elements should appear in the correct order

        /// <summary>
        /// Event is called when the server pipe is severed.
        /// </summary>
        public event ServerDisconnectedHandler ServerDisconnected;

#pragma warning disable SA1310 // Field names should not contain underscore
#pragma warning disable SA1400 // Access modifier should be declared
#pragma warning disable SA1201 // Elements should appear in the correct order
        const int BUFFER_SIZE = 4096;
#pragma warning restore SA1201 // Elements should appear in the correct order
#pragma warning restore SA1400 // Access modifier should be declared
#pragma warning restore SA1310 // Field names should not contain underscore

#pragma warning disable SA1400 // Access modifier should be declared
        FileStream stream;
#pragma warning restore SA1400 // Access modifier should be declared
#pragma warning disable SA1400 // Access modifier should be declared
        SafeFileHandle handle;
#pragma warning restore SA1400 // Access modifier should be declared
#pragma warning disable SA1400 // Access modifier should be declared
        Thread readThread;
#pragma warning restore SA1400 // Access modifier should be declared

#pragma warning disable SA1629 // Documentation text should end with a period
#pragma warning disable SA1623 // Property summary documentation should match accessors
        /// <summary>
        /// Is this client connected to a server pipe
        /// </summary>
        public bool Connected { get; private set; }
#pragma warning restore SA1623 // Property summary documentation should match accessors
#pragma warning restore SA1629 // Documentation text should end with a period

#pragma warning disable SA1629 // Documentation text should end with a period
#pragma warning disable SA1623 // Property summary documentation should match accessors
        /// <summary>
        /// The pipe this client is connected to
        /// </summary>
        public string PipeName { get; private set; }
#pragma warning restore SA1623 // Property summary documentation should match accessors
#pragma warning restore SA1629 // Documentation text should end with a period

        /// <summary>
        /// Connects to the server with a pipename.
        /// </summary>
        /// <param name="pipename">The name of the pipe to connect to.</param>
        public void Connect(string pipename)
        {
#pragma warning disable SA1101 // Prefix local calls with this
            if (Connected)
#pragma warning restore SA1101 // Prefix local calls with this
#pragma warning disable SA1503 // Braces should not be omitted
                throw new Exception("Already connected to pipe server.");
#pragma warning restore SA1503 // Braces should not be omitted

#pragma warning disable SA1101 // Prefix local calls with this
            PipeName = pipename;
#pragma warning restore SA1101 // Prefix local calls with this

#pragma warning disable SA1101 // Prefix local calls with this
            handle =
#pragma warning restore SA1101 // Prefix local calls with this
               CreateFile(
#pragma warning disable SA1101 // Prefix local calls with this
                  PipeName,
#pragma warning restore SA1101 // Prefix local calls with this
                  0xC0000000, // GENERIC_READ | GENERIC_WRITE = 0x80000000 | 0x40000000
                  0,
                  IntPtr.Zero,
                  3, // OPEN_EXISTING
                  0x40000000, // FILE_FLAG_OVERLAPPED
                  IntPtr.Zero);
#pragma warning disable SA1507 // Code should not contain multiple blank lines in a row

#pragma warning disable SA1028 // Code should not contain trailing whitespace
            
#pragma warning disable SA1005 // Single line comments should begin with single space
#pragma warning disable SA1515 // Single-line comment should be preceded by blank line
//could not create handle - server probably not running
#pragma warning disable SA1101 // Prefix local calls with this
            if (handle.IsInvalid)
#pragma warning restore SA1507 // Code should not contain multiple blank lines in a row
#pragma warning restore SA1515 // Single-line comment should be preceded by blank line
#pragma warning restore SA1028 // Code should not contain trailing whitespace
#pragma warning restore SA1101 // Prefix local calls with this
#pragma warning restore SA1005 // Single line comments should begin with single space
#pragma warning disable SA1503 // Braces should not be omitted
                return;
#pragma warning restore SA1503 // Braces should not be omitted

#pragma warning disable SA1101 // Prefix local calls with this
            Connected = true;
#pragma warning restore SA1101 // Prefix local calls with this
#pragma warning disable SA1507 // Code should not contain multiple blank lines in a row

#pragma warning disable SA1028 // Code should not contain trailing whitespace
            
#pragma warning disable SA1005 // Single line comments should begin with single space
#pragma warning disable SA1515 // Single-line comment should be preceded by blank line
//start listening for messages
#pragma warning disable SA1101 // Prefix local calls with this
#pragma warning disable SA1101 // Prefix local calls with this
            readThread = new Thread(Read)
#pragma warning restore SA1515 // Single-line comment should be preceded by blank line
#pragma warning restore SA1028 // Code should not contain trailing whitespace
#pragma warning restore SA1507 // Code should not contain multiple blank lines in a row
#pragma warning restore SA1005 // Single line comments should begin with single space
#pragma warning restore SA1101 // Prefix local calls with this
#pragma warning restore SA1101 // Prefix local calls with this
            {
#pragma warning disable SA1413 // Use trailing comma in multi-line initializers
                IsBackground = true
#pragma warning restore SA1413 // Use trailing comma in multi-line initializers
            };
#pragma warning disable SA1101 // Prefix local calls with this
            readThread.Start();
#pragma warning restore SA1101 // Prefix local calls with this
        }

        /// <summary>
        /// Disconnects from the server.
        /// </summary>
        public void Disconnect()
        {
#pragma warning disable SA1101 // Prefix local calls with this
            if (!Connected)
#pragma warning restore SA1101 // Prefix local calls with this
#pragma warning disable SA1503 // Braces should not be omitted
                return;
#pragma warning restore SA1503 // Braces should not be omitted

            // we're no longer connected to the server
#pragma warning disable SA1101 // Prefix local calls with this
            Connected = false;
#pragma warning restore SA1101 // Prefix local calls with this
#pragma warning disable SA1101 // Prefix local calls with this
            PipeName = null;
#pragma warning restore SA1101 // Prefix local calls with this
#pragma warning disable SA1507 // Code should not contain multiple blank lines in a row

#pragma warning disable SA1028 // Code should not contain trailing whitespace
            
#pragma warning disable SA1005 // Single line comments should begin with single space
#pragma warning disable SA1515 // Single-line comment should be preceded by blank line
//clean up resource
#pragma warning disable SA1101 // Prefix local calls with this
            if (stream != null)
#pragma warning restore SA1507 // Code should not contain multiple blank lines in a row
#pragma warning restore SA1515 // Single-line comment should be preceded by blank line
#pragma warning restore SA1028 // Code should not contain trailing whitespace
#pragma warning restore SA1005 // Single line comments should begin with single space
#pragma warning restore SA1101 // Prefix local calls with this
#pragma warning disable SA1503 // Braces should not be omitted
#pragma warning disable SA1101 // Prefix local calls with this
                stream.Close();
#pragma warning restore SA1101 // Prefix local calls with this
#pragma warning restore SA1503 // Braces should not be omitted
#pragma warning disable SA1101 // Prefix local calls with this
            handle.Close();
#pragma warning restore SA1101 // Prefix local calls with this

#pragma warning disable SA1101 // Prefix local calls with this
            stream = null;
#pragma warning restore SA1101 // Prefix local calls with this
#pragma warning disable SA1101 // Prefix local calls with this
            handle = null;
#pragma warning restore SA1101 // Prefix local calls with this
        }

#pragma warning disable SA1400 // Access modifier should be declared
        void Read()
#pragma warning restore SA1400 // Access modifier should be declared
        {
#pragma warning disable SA1101 // Prefix local calls with this
#pragma warning disable SA1101 // Prefix local calls with this
            stream = new FileStream(handle, FileAccess.ReadWrite, BUFFER_SIZE, true);
#pragma warning restore SA1101 // Prefix local calls with this
#pragma warning restore SA1101 // Prefix local calls with this
            byte[] readBuffer = new byte[BUFFER_SIZE];

            while (true)
            {
                int bytesRead = 0;

                using (MemoryStream ms = new MemoryStream())
                {
                    try
                    {
                        // read the total stream length
#pragma warning disable SA1101 // Prefix local calls with this
                        int totalSize = stream.Read(readBuffer, 0, 4);
#pragma warning restore SA1101 // Prefix local calls with this

                        // client has disconnected
                        if (totalSize == 0)
#pragma warning disable SA1503 // Braces should not be omitted
                            break;
#pragma warning restore SA1503 // Braces should not be omitted

                        totalSize = BitConverter.ToInt32(readBuffer, 0);

                        do
                        {
#pragma warning disable SA1101 // Prefix local calls with this
                            int numBytes = stream.Read(readBuffer, 0, Math.Min(totalSize - bytesRead, BUFFER_SIZE));
#pragma warning restore SA1101 // Prefix local calls with this

                            ms.Write(readBuffer, 0, numBytes);

                            bytesRead += numBytes;

#pragma warning disable SA1500 // Braces for multi-line statements should not share line
#pragma warning disable SA1508 // Closing braces should not be preceded by blank line
                        } while (bytesRead < totalSize);
#pragma warning restore SA1508 // Closing braces should not be preceded by blank line
#pragma warning restore SA1500 // Braces for multi-line statements should not share line

#pragma warning disable SA1508 // Closing braces should not be preceded by blank line
                    }
#pragma warning restore SA1508 // Closing braces should not be preceded by blank line
                    catch
#pragma warning disable SA1505 // Opening braces should not be followed by blank line
                    {
#pragma warning restore SA1505 // Opening braces should not be followed by blank line
#pragma warning disable SA1028 // Code should not contain trailing whitespace
                        
#pragma warning disable SA1005 // Single line comments should begin with single space
//read error has occurred
                        break;
#pragma warning restore SA1028 // Code should not contain trailing whitespace
#pragma warning restore SA1005 // Single line comments should begin with single space
                    }
#pragma warning disable SA1507 // Code should not contain multiple blank lines in a row

#pragma warning disable SA1028 // Code should not contain trailing whitespace
                    
#pragma warning disable SA1005 // Single line comments should begin with single space
#pragma warning disable SA1515 // Single-line comment should be preceded by blank line
//client has disconnected
                    if (bytesRead == 0)
#pragma warning restore SA1028 // Code should not contain trailing whitespace
#pragma warning restore SA1507 // Code should not contain multiple blank lines in a row
#pragma warning restore SA1515 // Single-line comment should be preceded by blank line
#pragma warning restore SA1005 // Single line comments should begin with single space
#pragma warning disable SA1503 // Braces should not be omitted
                        break;
#pragma warning restore SA1503 // Braces should not be omitted
#pragma warning disable SA1507 // Code should not contain multiple blank lines in a row

#pragma warning disable SA1028 // Code should not contain trailing whitespace
                    
#pragma warning disable SA1005 // Single line comments should begin with single space
#pragma warning disable SA1515 // Single-line comment should be preceded by blank line
//fire message received event
#pragma warning disable SA1101 // Prefix local calls with this
                    if (MessageReceived != null)
#pragma warning restore SA1515 // Single-line comment should be preceded by blank line
#pragma warning restore SA1028 // Code should not contain trailing whitespace
#pragma warning restore SA1507 // Code should not contain multiple blank lines in a row
#pragma warning restore SA1101 // Prefix local calls with this
#pragma warning restore SA1005 // Single line comments should begin with single space
#pragma warning disable SA1101 // Prefix local calls with this
#pragma warning disable SA1503 // Braces should not be omitted
                        MessageReceived(ms.ToArray());
#pragma warning restore SA1503 // Braces should not be omitted
#pragma warning restore SA1101 // Prefix local calls with this
                }
            }

            // if connected, then the disconnection was
            // caused by a server terminating, otherwise it was from
            // a call to Disconnect()
#pragma warning disable SA1101 // Prefix local calls with this
            if (Connected)
#pragma warning restore SA1101 // Prefix local calls with this
#pragma warning disable SA1505 // Opening braces should not be followed by blank line
            {
#pragma warning restore SA1505 // Opening braces should not be followed by blank line
#pragma warning disable SA1028 // Code should not contain trailing whitespace
                
#pragma warning disable SA1005 // Single line comments should begin with single space
//clean up resource
#pragma warning disable SA1101 // Prefix local calls with this
                stream.Close();
#pragma warning restore SA1028 // Code should not contain trailing whitespace
#pragma warning restore SA1101 // Prefix local calls with this
#pragma warning restore SA1005 // Single line comments should begin with single space
#pragma warning disable SA1101 // Prefix local calls with this
                handle.Close();
#pragma warning restore SA1101 // Prefix local calls with this

#pragma warning disable SA1101 // Prefix local calls with this
                stream = null;
#pragma warning restore SA1101 // Prefix local calls with this
#pragma warning disable SA1101 // Prefix local calls with this
                handle = null;
#pragma warning restore SA1101 // Prefix local calls with this

                // we're no longer connected to the server
#pragma warning disable SA1101 // Prefix local calls with this
                Connected = false;
#pragma warning restore SA1101 // Prefix local calls with this
#pragma warning disable SA1101 // Prefix local calls with this
                PipeName = null;
#pragma warning restore SA1101 // Prefix local calls with this

#pragma warning disable SA1101 // Prefix local calls with this
                if (ServerDisconnected != null)
#pragma warning restore SA1101 // Prefix local calls with this
#pragma warning disable SA1101 // Prefix local calls with this
#pragma warning disable SA1503 // Braces should not be omitted
                    ServerDisconnected();
#pragma warning restore SA1503 // Braces should not be omitted
#pragma warning restore SA1101 // Prefix local calls with this
            }
        }

#pragma warning disable SA1202 // Elements should be ordered by access
        /// <summary>
        /// Sends a message to the server.
        /// </summary>
        /// <param name="message">The message to send.</param>
        /// <returns>True if the message is sent successfully - false otherwise.</returns>
        public bool SendMessage(byte[] message)
#pragma warning restore SA1202 // Elements should be ordered by access
        {
            try
            {
                // write the entire stream length
#pragma warning disable SA1101 // Prefix local calls with this
                stream.Write(BitConverter.GetBytes(message.Length), 0, 4);
#pragma warning restore SA1101 // Prefix local calls with this

#pragma warning disable SA1101 // Prefix local calls with this
                stream.Write(message, 0, message.Length);
#pragma warning restore SA1101 // Prefix local calls with this
#pragma warning disable SA1101 // Prefix local calls with this
                stream.Flush();
#pragma warning restore SA1101 // Prefix local calls with this
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
