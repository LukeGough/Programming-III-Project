// <copyright file="PipeServer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Server
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Threading;
    using Microsoft.Win32.SafeHandles;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable SA1600 // Elements should be documented
    public class PipeServer
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        [DllImport("kernel32.dll", SetLastError = true)]
#pragma warning disable SA1400 // Access modifier should be declared
        static extern SafeFileHandle CreateNamedPipe(
#pragma warning restore SA1400 // Access modifier should be declared
#pragma warning disable SA1121 // Use built-in type alias
#pragma warning disable SA1114 // Parameter list should follow declaration
           String pipeName,
#pragma warning restore SA1114 // Parameter list should follow declaration
#pragma warning restore SA1121 // Use built-in type alias
           uint dwOpenMode,
           uint dwPipeMode,
           uint nMaxInstances,
           uint nOutBufferSize,
           uint nInBufferSize,
           uint nDefaultTimeOut,
           IntPtr lpSecurityAttributes);

        [DllImport("kernel32.dll", SetLastError = true)]
#pragma warning disable SA1400 // Access modifier should be declared
        static extern int ConnectNamedPipe(
#pragma warning restore SA1400 // Access modifier should be declared
#pragma warning disable SA1114 // Parameter list should follow declaration
           SafeFileHandle hNamedPipe,
#pragma warning restore SA1114 // Parameter list should follow declaration
           IntPtr lpOverlapped);

        [DllImport("kernel32.dll", SetLastError = true)]
#pragma warning disable SA1400 // Access modifier should be declared
        static extern bool DisconnectNamedPipe(SafeFileHandle hHandle);
#pragma warning restore SA1400 // Access modifier should be declared

        [StructLayoutAttribute(LayoutKind.Sequential)]
#pragma warning disable SA1400 // Access modifier should be declared
        struct SECURITY_DESCRIPTOR
#pragma warning restore SA1400 // Access modifier should be declared
        {
#pragma warning disable SA1307 // Accessible fields should begin with upper-case letter
            public byte revision;
#pragma warning restore SA1307 // Accessible fields should begin with upper-case letter
#pragma warning disable SA1307 // Accessible fields should begin with upper-case letter
            public byte size;
#pragma warning restore SA1307 // Accessible fields should begin with upper-case letter
#pragma warning disable SA1307 // Accessible fields should begin with upper-case letter
            public short control;
#pragma warning restore SA1307 // Accessible fields should begin with upper-case letter
#pragma warning disable SA1307 // Accessible fields should begin with upper-case letter
            public IntPtr owner;
#pragma warning restore SA1307 // Accessible fields should begin with upper-case letter
#pragma warning disable SA1307 // Accessible fields should begin with upper-case letter
            public IntPtr group;
#pragma warning restore SA1307 // Accessible fields should begin with upper-case letter
#pragma warning disable SA1307 // Accessible fields should begin with upper-case letter
            public IntPtr sacl;
#pragma warning restore SA1307 // Accessible fields should begin with upper-case letter
#pragma warning disable SA1307 // Accessible fields should begin with upper-case letter
            public IntPtr dacl;
#pragma warning restore SA1307 // Accessible fields should begin with upper-case letter
        }

        [StructLayout(LayoutKind.Sequential)]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable SA1202 // Elements should be ordered by access
#pragma warning disable SA1600 // Elements should be documented
        public struct SECURITY_ATTRIBUTES
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore SA1202 // Elements should be ordered by access
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable SA1307 // Accessible fields should begin with upper-case letter
#pragma warning disable SA1600 // Elements should be documented
            public int nLength;
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore SA1307 // Accessible fields should begin with upper-case letter
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable SA1307 // Accessible fields should begin with upper-case letter
#pragma warning disable SA1600 // Elements should be documented
            public IntPtr lpSecurityDescriptor;
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore SA1307 // Accessible fields should begin with upper-case letter
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable SA1307 // Accessible fields should begin with upper-case letter
#pragma warning disable SA1600 // Elements should be documented
            public int bInheritHandle;
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore SA1307 // Accessible fields should begin with upper-case letter
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        }

#pragma warning disable SA1201 // Elements should appear in the correct order
#pragma warning disable SA1310 // Field names should not contain underscore
        private const uint SECURITY_DESCRIPTOR_REVISION = 1;
#pragma warning restore SA1310 // Field names should not contain underscore
#pragma warning restore SA1201 // Elements should appear in the correct order

        [DllImport("advapi32.dll", SetLastError = true)]
#pragma warning disable SA1400 // Access modifier should be declared
        static extern bool InitializeSecurityDescriptor(ref SECURITY_DESCRIPTOR sd, uint dwRevision);
#pragma warning restore SA1400 // Access modifier should be declared

        [DllImport("advapi32.dll", SetLastError = true)]
#pragma warning disable SA1400 // Access modifier should be declared
        static extern bool SetSecurityDescriptorDacl(ref SECURITY_DESCRIPTOR sd, bool daclPresent, IntPtr dacl, bool daclDefaulted);
#pragma warning restore SA1400 // Access modifier should be declared

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable SA1600 // Elements should be documented
        public class Client
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable SA1307 // Accessible fields should begin with upper-case letter
#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1401 // Fields should be private
            public SafeFileHandle handle;
#pragma warning restore SA1401 // Fields should be private
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore SA1307 // Accessible fields should begin with upper-case letter
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable SA1307 // Accessible fields should begin with upper-case letter
#pragma warning disable SA1401 // Fields should be private
#pragma warning disable SA1600 // Elements should be documented
            public FileStream stream;
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore SA1401 // Fields should be private
#pragma warning restore SA1307 // Accessible fields should begin with upper-case letter
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        }

#pragma warning disable SA1201 // Elements should appear in the correct order
#pragma warning disable SA1629 // Documentation text should end with a period
#pragma warning disable SA1629 // Documentation text should end with a period
        /// <summary>
        /// Handles messages received from a client pipe
        /// </summary>
        /// <param name="message">The byte message received</param>
        public delegate void MessageReceivedHandler(byte[] message);
#pragma warning restore SA1629 // Documentation text should end with a period
#pragma warning restore SA1629 // Documentation text should end with a period
#pragma warning restore SA1201 // Elements should appear in the correct order

        /// <summary>
        /// Event is called whenever a message is received from a client pipe
        /// </summary>
        public event MessageReceivedHandler MessageReceived;
#pragma warning disable SA1507 // Code should not contain multiple blank lines in a row


#pragma warning disable SA1201 // Elements should appear in the correct order
#pragma warning disable SA1629 // Documentation text should end with a period
        /// <summary>
        /// Handles client disconnected messages
        /// </summary>
        public delegate void ClientDisconnectedHandler();
#pragma warning restore SA1507 // Code should not contain multiple blank lines in a row
#pragma warning restore SA1629 // Documentation text should end with a period
#pragma warning restore SA1201 // Elements should appear in the correct order

        /// <summary>
        /// Event is called when a client pipe is severed.
        /// </summary>
        public event ClientDisconnectedHandler ClientDisconnected;

#pragma warning disable SA1201 // Elements should appear in the correct order
#pragma warning disable SA1310 // Field names should not contain underscore
#pragma warning disable SA1400 // Access modifier should be declared
        const int BUFFER_SIZE = 4096;
#pragma warning restore SA1400 // Access modifier should be declared
#pragma warning restore SA1310 // Field names should not contain underscore
#pragma warning restore SA1201 // Elements should appear in the correct order

#pragma warning disable SA1400 // Access modifier should be declared
        readonly List<Client> clients = new List<Client>();
#pragma warning restore SA1400 // Access modifier should be declared
#pragma warning disable SA1400 // Access modifier should be declared
        Thread listenThread;
#pragma warning restore SA1400 // Access modifier should be declared
#pragma warning disable SA1507 // Code should not contain multiple blank lines in a row


#pragma warning disable SA1629 // Documentation text should end with a period
#pragma warning disable SA1623 // Property summary documentation should match accessors
        /// <summary>
        /// The total number of PipeClients connected to this server
        /// </summary>
        public int TotalConnectedClients
#pragma warning restore SA1507 // Code should not contain multiple blank lines in a row
#pragma warning restore SA1623 // Property summary documentation should match accessors
#pragma warning restore SA1629 // Documentation text should end with a period
        {
            get
            {
                lock (this.clients)
                {
                    return this.clients.Count;
                }
            }
        }

#pragma warning disable SA1623 // Property summary documentation should match accessors
#pragma warning disable SA1629 // Documentation text should end with a period
        /// <summary>
        /// The name of the pipe this server is connected to
        /// </summary>
        public string PipeName { get; private set; }
#pragma warning restore SA1629 // Documentation text should end with a period
#pragma warning restore SA1623 // Property summary documentation should match accessors

#pragma warning disable SA1629 // Documentation text should end with a period
#pragma warning disable SA1623 // Property summary documentation should match accessors
        /// <summary>
        /// Is the server currently running
        /// </summary>
        public bool Running { get; private set; }
#pragma warning restore SA1623 // Property summary documentation should match accessors
#pragma warning restore SA1629 // Documentation text should end with a period
#pragma warning disable SA1507 // Code should not contain multiple blank lines in a row


        /// <summary>
        /// Starts the pipe server on a particular name.
        /// </summary>
        /// <param name="pipename">The name of the pipe.</param>
        public void Start(string pipename)
#pragma warning restore SA1507 // Code should not contain multiple blank lines in a row
        {
            this.PipeName = pipename;

            // Start the listening thread
            this.listenThread = new Thread(this.ListenForClients)
            {
#pragma warning disable SA1413 // Use trailing comma in multi-line initializers
                IsBackground = true
#pragma warning restore SA1413 // Use trailing comma in multi-line initializers
            };

            this.listenThread.Start();

            this.Running = true;
        }

#pragma warning disable SA1400 // Access modifier should be declared
        void ListenForClients()
#pragma warning restore SA1400 // Access modifier should be declared
        {
            SECURITY_DESCRIPTOR sd = new SECURITY_DESCRIPTOR();

            // set the Security Descriptor to be completely permissive
            InitializeSecurityDescriptor(ref sd, SECURITY_DESCRIPTOR_REVISION);
            SetSecurityDescriptorDacl(ref sd, true, IntPtr.Zero, false);

            IntPtr ptrSD = Marshal.AllocCoTaskMem(Marshal.SizeOf(sd));
            Marshal.StructureToPtr(sd, ptrSD, false);

            SECURITY_ATTRIBUTES sa = new SECURITY_ATTRIBUTES
            {
                nLength = Marshal.SizeOf(sd),
                lpSecurityDescriptor = ptrSD,
#pragma warning disable SA1413 // Use trailing comma in multi-line initializers
                bInheritHandle = 1
#pragma warning restore SA1413 // Use trailing comma in multi-line initializers
            };

            IntPtr ptrSA = Marshal.AllocCoTaskMem(Marshal.SizeOf(sa));
            Marshal.StructureToPtr(sa, ptrSA, false);
#pragma warning disable SA1507 // Code should not contain multiple blank lines in a row


            while (true)
#pragma warning restore SA1507 // Code should not contain multiple blank lines in a row
            {
                // Creates an instance of a named pipe for one client
                // DUPLEX | FILE_FLAG_OVERLAPPED = 0x00000003 | 0x40000000;
                SafeFileHandle clientHandle =
                    CreateNamedPipe(
                        this.PipeName,
                        0x40000003,
                        0,
                        255,
                        BUFFER_SIZE,
                        BUFFER_SIZE,
                        0,
                        ptrSA);

                // Could not create named pipe instance
                if (clientHandle.IsInvalid)
#pragma warning disable SA1503 // Braces should not be omitted
                    continue;
#pragma warning restore SA1503 // Braces should not be omitted

                int success = ConnectNamedPipe(clientHandle, IntPtr.Zero);

                // Could not connect client
                if (success == 0)
                {
                    // close the handle, and wait for the next client
                    clientHandle.Close();
                    continue;
                }

                Client client = new Client
                {
#pragma warning disable SA1413 // Use trailing comma in multi-line initializers
                    handle = clientHandle
#pragma warning restore SA1413 // Use trailing comma in multi-line initializers
                };

                lock (this.clients)
#pragma warning disable SA1503 // Braces should not be omitted
                    this.clients.Add(client);
#pragma warning restore SA1503 // Braces should not be omitted

                Thread readThread = new Thread(this.Read)
                {
#pragma warning disable SA1413 // Use trailing comma in multi-line initializers
                    IsBackground = true
#pragma warning restore SA1413 // Use trailing comma in multi-line initializers
                };
                readThread.Start(client);
            }

            // free up the ptrs (never reached due to infinite loop)
#pragma warning disable CS0162 // Unreachable code detected
            Marshal.FreeCoTaskMem(ptrSD);
#pragma warning restore CS0162 // Unreachable code detected
            Marshal.FreeCoTaskMem(ptrSA);
        }

#pragma warning disable SA1400 // Access modifier should be declared
        void Read(object clientObj)
#pragma warning restore SA1400 // Access modifier should be declared
        {
            Client client = (Client)clientObj;
            client.stream = new FileStream(client.handle, FileAccess.ReadWrite, BUFFER_SIZE, true);
            byte[] buffer = new byte[BUFFER_SIZE];

            while (true)
            {
                int bytesRead = 0;

                using (MemoryStream ms = new MemoryStream())
                {
                    try
                    {
                        // read the total stream length
                        int totalSize = client.stream.Read(buffer, 0, 4);

                        // client has disconnected
                        if (totalSize == 0)
#pragma warning disable SA1503 // Braces should not be omitted
                            break;
#pragma warning restore SA1503 // Braces should not be omitted

                        totalSize = BitConverter.ToInt32(buffer, 0);

                        do
                        {
                            int numBytes = client.stream.Read(buffer, 0, Math.Min(totalSize - bytesRead, BUFFER_SIZE));

                            ms.Write(buffer, 0, numBytes);

                            bytesRead += numBytes;

#pragma warning disable SA1508 // Closing braces should not be preceded by blank line
#pragma warning disable SA1500 // Braces for multi-line statements should not share line
                        } while (bytesRead < totalSize);
#pragma warning restore SA1500 // Braces for multi-line statements should not share line
#pragma warning restore SA1508 // Closing braces should not be preceded by blank line

#pragma warning disable SA1508 // Closing braces should not be preceded by blank line
                    }
#pragma warning restore SA1508 // Closing braces should not be preceded by blank line
                    catch
                    {
                        // read error has occurred
                        break;
                    }

                    // client has disconnected
                    if (bytesRead == 0)
#pragma warning disable SA1503 // Braces should not be omitted
                        break;
#pragma warning restore SA1503 // Braces should not be omitted

                    // fire message received event
                    if (this.MessageReceived != null)
#pragma warning disable SA1503 // Braces should not be omitted
                        this.MessageReceived(ms.ToArray());
#pragma warning restore SA1503 // Braces should not be omitted
                }
            }

            // the clients must be locked - otherwise "stream.Close()"
            // could be called while SendMessage(byte[]) is being called on another thread.
            // This leads to an IO error & several wasted days.
            lock (this.clients)
            {
                // clean up resources
                DisconnectNamedPipe(client.handle);
                client.stream.Close();
                client.handle.Close();

                this.clients.Remove(client);
            }

            // invoke the event, a client disconnected
            if (this.ClientDisconnected != null)
#pragma warning disable SA1503 // Braces should not be omitted
                this.ClientDisconnected();
#pragma warning restore SA1503 // Braces should not be omitted
        }

        /// <summary>
        /// Sends a message to all connected clients.
        /// </summary>
        /// <param name="message">The message to send.</param>
        public void SendMessage(byte[] message)
        {
            lock (this.clients)
            {
                // get the entire stream length
                byte[] messageLength = BitConverter.GetBytes(message.Length);

                foreach (Client client in this.clients)
                {
                    // length
                    client.stream.Write(messageLength, 0, 4);

                    // data
                    client.stream.Write(message, 0, message.Length);
                    client.stream.Flush();
                }
            }
        }
    }
}
